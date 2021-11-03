using OpenTK;
using System;
using System.Drawing;

namespace Proiect
{
    class Randomizer
    {
        private Random r;
        private const int MIN_VAL = -25;
        private const int MAX_VAL = 25;

        public Randomizer()
        {
            r = new Random();
        }

        /// <summary>
        ///  This method return a random color when requested
        /// </summary>
        /// <returns>The color randomly generated!</returns>

        public Color RandomColor()
        {
            int genR = r.Next(0, 255);
            int genG = r.Next(0, 255);
            int genB = r.Next(0, 255);

            Color col = Color.FromArgb(genR, genB, genG);
            return col;
        }

        public Vector3 Generate3DPoint()
        {
            int a = r.Next(MIN_VAL, MAX_VAL);
            int b = r.Next(MIN_VAL, MAX_VAL);
            int c = r.Next(MIN_VAL, MAX_VAL);

            Vector3 vec = new Vector3(a, b, c);

            return vec;
        }

        public Vector3 Generate3DPoint(int spec)
        {
            int a = r.Next(-1 * spec, spec);
            int b = r.Next(-1 * spec, spec);
            int c = r.Next(-1 * spec, spec);

            Vector3 vec = new Vector3(a, b, c);

            return vec;
        }

        public int GeneratePositiveInt(int limit)
        {
            int a = r.Next(0, limit);

            return a;
        }
    }
}