using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Biometrics1
{
    public partial class Form1 : Form
    {
        int oldbr = 0;
        OpenFileDialog op;

        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseIm(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            //op.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if(op.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
            }
        }

        private void SaveIm(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.DefaultExt = ".jpg";
            //sv.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            sv.FileName = "New_image";
            if(sv.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image.Save(sv.FileName);
            }
        }

        private void ToStart(object sender, EventArgs e)
        {
            Trace.WriteLine("toStart");
            BrightnessBar.Value = 0;
            ContrastBar.Value = 0;
            pictureBox1.Load(op.FileName);
        }

        private int Check(float n)
        {
            if (n < 0) return 0;
            else if (n > 255) return 255;
            else return (int)n;
        }

        private void Grayscale(object sender, EventArgs e)
        {
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for(int j=0;j<b.Height;j++)
                for(int i=0;i<b.Width;i++)
                {
                    c = b.GetPixel(i, j);
                    int avg = (c.R + c.G + c.B) / 3;
                    b.SetPixel(i, j, Color.FromArgb(c.A, avg, avg, avg));
                }
            pictureBox1.Image = b;
        }

        private void Negation(object sender, EventArgs e)
        {
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, 255-c.R, 255-c.G, 255-c.B));
                }
            pictureBox1.Image = b;
        }

        private void Brightness(object sender, EventArgs e)
        {
            float change = ((float)(BrightnessBar.Value - oldbr))/10.0f;

            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    //Trace.WriteLine(c.R + " " + c.G + " " + c.B);
                    //Trace.WriteLine(c.R+change + " " + c.G+change + " " + c.B+change);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check(c.R+change), Check(c.G+change), Check(c.B+change)));
                }
            Trace.WriteLine("Done");
            pictureBox1.Image = b;
        }

        private void Contrast(object sender, EventArgs e)
        {
            int factor = (259 * (ContrastBar.Value + 255)) / (255 * (259 - ContrastBar.Value));
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check(factor*( c.R-128)+128), Check(factor * (c.G - 128) + 128), Check(factor * (c.B - 128) + 128)));
                }
            Trace.WriteLine("Done");
            pictureBox1.Image = b;//how many times can be changed??
        }
    }
}
