using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {

        public double Zoom = 0.005f;

        public double shiftX = 500d;

        public double shiftY = 300d;

        public string pathFile;


        public Form1()
        {
            InitializeComponent();
            KeyPreview = true;
        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            fractal();
        }

        void fractal()
        {
            var bmp = new Bitmap(Width, Height);

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    var z = new complex(0, 0);

                    double x = (double)(i - shiftX) * Zoom;
                    double y = (double)(j - shiftY) * Zoom;

                    var c = new complex(x, y);

                    int iterator = 0;

                    while ((z.x * z.x + z.y * z.y) <= 4 && iterator < 255)
                    {
                        z = z * z + c;
                        iterator++;
                    }

                    if (iterator == 255)
                        bmp.SetPixel(i, j, Color.FromArgb(0,0, 0));

                    bmp.SetPixel(i, j, Color.FromArgb((byte)(iterator), (byte)(iterator),(byte)(iterator)));

                }




            pictureBox1.Image = bmp;


        }




        public class complex
        {

            public double x;
            public double y;

            public complex(double x, double y)
            {
                this.x = x;
                this.y = y;
            }




            public static complex operator+(complex a, complex b)
            {
                complex temp = new complex(0,0);
                temp.x = a.x + b.x;
                temp.y = a.y + b.y;
                return temp;
            }

            public static complex operator*(complex a, complex b)
            {
                complex temp = new complex(0, 0);
                temp.x = a.x * b.x - a.y * b.y;
                temp.y = a.x * b.y + a.y * b.x;
                return temp;
            }
        }

        int SHIFT = 90;


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

            if (e.KeyCode == Keys.A)
            {
                shiftX -= SHIFT;
                fractal();
            }

            if (e.KeyCode == Keys.D)
            {
                shiftX += SHIFT;
                fractal();
            }

            if (e.KeyCode == Keys.W)
            {
                shiftY -= SHIFT;
                fractal();
            }

            if (e.KeyCode == Keys.S)
            {
                shiftY += SHIFT;
                fractal();
            }
        }

 
    }
}
