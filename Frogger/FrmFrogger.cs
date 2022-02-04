using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Frogger
{
    public partial class FrmFrogger : Form
    {
        static int anzahlBereiche = 6;
        // -1 ist ein Platzhalter
        int breite = -1;
        int hoehe = -1;
        int hoeheJeBereich = -1;
        Rectangle[] alleBahnen = new Rectangle[anzahlBereiche];
        List<Hindernis> alleHindernisse = new List<Hindernis>();
        Rectangle spieler;
        int spawnRate = 14;
        int spawnZaehler = 0;
        Random rndBahn = new Random();


        public FrmFrogger()
        {
            InitializeComponent();
        }

        private void FrmFrogger_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void FrmFrogger_Paint(object sender, PaintEventArgs e)
        {
            if (tmrGameTick.Enabled == false)
            {
                breite = this.ClientSize.Width;
                hoehe = this.ClientSize.Height;

                hoeheJeBereich = hoehe / anzahlBereiche;

                //Puffer für Rundungsfehler
                hoeheJeBereich = hoeheJeBereich + 2;

                spieler = new Rectangle((breite / 2) - 15, hoehe - 35, 30, 30);

                for (int i = 0; i < alleBahnen.Length; i++)
                {
                    alleBahnen[i] = new Rectangle(0, i * hoeheJeBereich, breite, hoeheJeBereich);
                }

                tmrGameTick.Start();
            }


            SolidBrush brStart = new SolidBrush(Color.LightBlue);
            SolidBrush brZiel = new SolidBrush(Color.LightYellow);
            SolidBrush brBahnHell = new SolidBrush(Color.LightGray);
            SolidBrush brBahnDunkel = new SolidBrush(Color.Gray);
            SolidBrush brSpieler = new SolidBrush(Color.Green);
            SolidBrush brBlack = new SolidBrush(Color.Black);
            Pen pnRand = new Pen(Color.Black, 1);

            for (int i = 0; i < alleBahnen.Length; i++)
            {
                if (i % 2 == 0)
                {
                    e.Graphics.FillRectangle(brBahnHell, alleBahnen[i]);
                }
                else
                {
                    e.Graphics.FillRectangle(brBahnDunkel, alleBahnen[i]);
                }
            }

            e.Graphics.FillRectangle(brZiel, alleBahnen[0]);
            e.Graphics.FillRectangle(brStart, alleBahnen[alleBahnen.Length - 1]);

            e.Graphics.DrawRectangles(pnRand, alleBahnen);

            foreach (Hindernis aktuellesHindernis in alleHindernisse)
            {
                e.Graphics.FillRectangle(
                    aktuellesHindernis.Brush,
                    aktuellesHindernis.X,
                    aktuellesHindernis.Y,
                    aktuellesHindernis.Width,
                    aktuellesHindernis.Height);
            }

            e.Graphics.FillEllipse(brSpieler, spieler);

            e.Graphics.DrawString("Level: " + aktuellesLevel, new Font("Arial", 16), brBlack, 0, 0);
        }

        private void tmrGameTick_Tick(object sender, EventArgs e)
        {
            spawnZaehler++;
            if (spawnZaehler > spawnRate)
            {
                spawnZaehler = 0;

                int zufall = rndBahn.Next(1, anzahlBereiche - 1);
                int yWertDerBahn = alleBahnen[zufall].Top;

                alleHindernisse.Add(new Hindernis(breite, yWertDerBahn, 60, hoeheJeBereich, 10));
            }

            foreach (Hindernis aktuellesHindernis in alleHindernisse)
            {
                aktuellesHindernis.Move();
            }

            for (int i = alleHindernisse.Count - 1; i >= 0; i--)
            {
                if ((alleHindernisse[i].X + alleHindernisse[i].Width) < 0)
                {
                    alleHindernisse.RemoveAt(i);

                }
            }
            foreach (Hindernis hindernis in alleHindernisse)
            {
                if (spieler.IntersectsWith(hindernis.recHindernis))
                {
                    ResetLevel();
                }
            }

            this.Refresh();
        }

        private void ResetLevel()
        {
            ResetPlayerPosition();
            alleHindernisse = new List<Hindernis>();
            aktuellesLevel = 1;
        }

        private void FrmFrogger_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                spieler.Y = spieler.Y - hoeheJeBereich;
            }

            else if (e.KeyCode == Keys.Down)
            {
                spieler.Y = spieler.Y + hoeheJeBereich;
            }

            else if (e.KeyCode == Keys.Left)
            {
                spieler.X -= hoeheJeBereich;
            }

            else if (e.KeyCode == Keys.Right)
            {
                spieler.X += hoeheJeBereich;
            }

            if (spieler.X < 0)
            {
                spieler.X = 0;
            }
            else if (spieler.X + spieler.Width> ClientSize.Width)
            {
                spieler.X = ClientSize.Width - spieler.Width;
            }
            else if (spieler.Y < 0)
            {
                spieler.Y = 0;
            }
            else if (spieler.Y +spieler.Height > ClientSize.Height)
            {
                spieler.Y = ClientSize.Height - spieler.Height;
            }


            if (spieler.IntersectsWith(alleBahnen[0]))
            {
                NextLevel();
                ResetPlayerPosition();
            }

            this.Refresh();
        }

        private void ResetPlayerPosition()
        {
            spieler.Y = alleBahnen[alleBahnen.Length - 1].Y;
        }

        int aktuellesLevel = 1;
        private void NextLevel()
        {
            aktuellesLevel++;
            if (spawnRate > 5)
            {
                spawnRate--;
            }
        }
    }
}
