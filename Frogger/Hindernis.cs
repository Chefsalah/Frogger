using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public Hindernis(int X, int Y, int Width, int Height, int Speed, Color Color)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
            this.Speed = Speed;
            this.Color = Color;
            this.Brush = new SolidBrush(Color);
        }

        public void Move()
        {
            this.X = this.X - Speed;
        }

    }
}
