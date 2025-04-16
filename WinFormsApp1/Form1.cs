using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormsApp1

{
    public partial class Form1 : Form
    {
        Bitmap? originalImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Obrazy (*.jpg;*.png)|*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog1.FileName);
                pictureBoxOriginal.Image = originalImage;

                StartProcessing();
            }
        }

        private void StartProcessing()
        {
            if (originalImage == null) return;
            Bitmap input1 = new Bitmap(originalImage);
            Bitmap input2 = new Bitmap(originalImage);
            Bitmap input3 = new Bitmap(originalImage);
            Bitmap input4 = new Bitmap(originalImage);

            Thread tGray = new Thread(() =>
            {
                
                Bitmap gray = MakeGrayscale(input1);
                Invoke(() => pictureBoxGray.Image = gray);
            });

            Thread tNegative = new Thread(() =>
            {
                Bitmap negative = MakeNegative(input2);
                Invoke(() => pictureBoxNegative.Image = negative);
            });

            Thread tMirror = new Thread(() =>
            {
                Bitmap mirror = MakeMirror(input3);
                Invoke(() => pictureBoxMirror.Image = mirror);
            });

            Thread tThreshold = new Thread(() =>
            {
                Bitmap threshold = MakeThreshold(input4, 128);
                Invoke(() => pictureBoxThreshold.Image = threshold);
            });

            tGray.Start();
            tNegative.Start();
            tMirror.Start();
            tThreshold.Start();
        }


        
        private Bitmap MakeGrayscale(Bitmap input)
        {
            Bitmap bmp = new Bitmap(input.Width, input.Height);
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    int avg = (c.R + c.G + c.B) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return bmp;
        }

        private Bitmap MakeNegative(Bitmap input)
        {
            Bitmap bmp = new Bitmap(input.Width, input.Height);
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    bmp.SetPixel(x, y, Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            return bmp;
        }

        private Bitmap MakeMirror(Bitmap input)
        {
            Bitmap bmp = new Bitmap(input.Width, input.Height);
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    bmp.SetPixel(input.Width - 1 - x, y, input.GetPixel(x, y));
                }
            }
            return bmp;
        }

        private Bitmap MakeThreshold(Bitmap input, int threshold)
        {
            Bitmap bmp = new Bitmap(input.Width, input.Height);
            for (int y = 0; y < input.Height; y++)
            {
                for (int x = 0; x < input.Width; x++)
                {
                    Color c = input.GetPixel(x, y);
                    int avg = (c.R + c.G + c.B) / 3;
                    Color newColor = (avg > threshold) ? Color.White : Color.Black;
                    bmp.SetPixel(x, y, newColor);
                }
            }
            return bmp;
        }
    }
}
