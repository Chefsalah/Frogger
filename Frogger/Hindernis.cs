using System;
using System.Drawing;

namespace Frogger
{
    public class Hindernis
    {
        // Diese Klasse beinhaltet alle Felder, die zur Darstellung eines Hindernisses notwendig ist.

        // Position
        public int X;
        public int Y;

        // Dimension
        public int Width;
        public int Height;

        // Geschwindigkeit
        public int Speed;

        // Zeichenmittel
        // Damit man Zeichenmittel nutzen kann, muss System.Drawing importiert werden (oben bei using...)
        public Color Color;
        public SolidBrush Brush;
        public Rectangle recHindernis
        {
            get { return new Rectangle(X, Y, Width, Height); }
        }


        public Hindernis(int X, int Y, int Width, int Height, int Speed, Color Color)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            this.Color = Color;
            Random rnd = new Random();
            this.Brush = new SolidBrush(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
        }

        public void Move()
        {
            this.X = this.X - Speed;
        }

    }
}
