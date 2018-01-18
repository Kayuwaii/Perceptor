using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptor
{
    class Perceptor
    {
        public float[] wheights;
        float learningRate;

        public Perceptor(float lr)
        {
            Random r = new Random();
            learningRate = lr;
            this.wheights = new float[]{ NextFloat(r), NextFloat(r) };
        }

        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-1, 1));
            return (float)(mantissa * exponent);
        }

        public int Classify(Item itm)
        {
            float[] tempCoords = itm.coords;
            float sum = 0;
            for (int i = 0; i < wheights.Length; i++)
            {
                sum += tempCoords[i] * wheights[i];
            }
            return activator(sum);
        }

        public void train(Item[] dataset)
        {
            foreach( Item i in dataset)
            {
                int answer = Classify(i);
                float error = i.state - answer;
                for (int k = 0; k < wheights.Length; k++)
                {
                    this.wheights[k] += error * i.coords[k] * learningRate;
                }
            }
        }

        private int activator(float n)
        {
            if (n > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
