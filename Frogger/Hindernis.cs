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


        public Hindernis(int X, int Y, int Width, int Height, int Speed, Color Color):this(X,Y,Width,Height,Speed)
        {
            this.Color = Color;
            Brush = new SolidBrush(Color);
        }
        public Hindernis(int X, int Y, int Width, int Height, int Speed)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            Random rnd = new Random();
            Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Color = randomColor;
            Brush = new SolidBrush(randomColor);
        }

        public void Move()
        {
            this.X = this.X - Speed;
        }

    }
}
