using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika
{
    class Funkcja
    {
        private int func_number = 1;
        public void setFunction(int number)
        {
            if(number>5 && number < 1)
            {
                throw new IndexOutOfRangeException("Błęny numer funkcji, podan umer od 1 do 5");
            }
            func_number = number;
        }
        public double getFunctionValuAt(double x, double y, double time)
        {
            switch (func_number)
            {
                case 1: return -1*(Math.Pow(Math.Cos(x),2)+Math.Pow(Math.Cos(y),2))*Math.Sin(time);
                case 2: break;
                case 3: break;
                case 4: break;
                case 5: break;
            }
            return 1;
        }
    }
    class VectorField
    {
        private Funkcja func;
        public VectorField(Funkcja f)
        {
            func = f;
            
        }
        public void paint(System.Windows.Forms.Panel p)
        {
            p.Paint += new System.Windows.Forms.PaintEventHandler(drawField);
        }
        public void drawField(object Sender, System.Windows.Forms.PaintEventArgs e)
        {
            Panel p = Sender as Panel;
            double xmin = -2.0;
            double xmax = 2.0;
            double ymin = -2.0;
            double ymax = 2.0;
            double stepx = (xmax - xmin) / p.Width;
            double stepy = (ymax - ymin) / p.Height;
            double[,] values = new double[p.Height, p.Width];
            double time = Math.PI / 2.0;
            double min = Double.MaxValue;
            double max = Double.MinValue;
            for (int i = 0; i < p.Height; ++i)
            {
                for (int j = 0; j < p.Width; ++j)
                {
                    values[i, j] = func.getFunctionValuAt(xmin+j*stepx, ymin+i*stepy, time);
                    if (values[i, j] > max)
                    {
                        max = values[i, j];
                    }
                    if (values[i, j] < min)
                    {
                        min = values[i, j];
                    }
                }
            }
            using (System.Drawing.Graphics gr = e.Graphics) {
                
                for (int i = 0; i < p.Height; ++i)
                {
                    for (int j = 0; j < p.Width; ++j)
                    {
                        int red = (int)((values[i,j]-min) /(max - min) *255);
                        int green = 255 - red;
                        int blue = 0;
                        gr.FillRectangle(new SolidBrush(Color.FromArgb(red,green, blue)), new Rectangle(j, i, 1, 1));
                    }
                }
            }
        } 
    }
}
