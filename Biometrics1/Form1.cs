using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Biometrics1
{
    public partial class Form1 : Form
    {
        int oldbr = 0, oldc = 0;
        OpenFileDialog op;

        public Form1()
        {
            InitializeComponent();
        }

        private void ChooseIm(object sender, EventArgs e)
        {
            if(pictureBox1.Image!=null) pictureBox1.Image.Dispose();
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
                try
                {
                    pictureBox1.Image.Save(sv.FileName);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("File is in use and cannot be modified\nTry saving to another file");
                }
            }
        }

        private void ToStart(object sender, EventArgs e)
        {
            //Trace.WriteLine("toStart");
            BrightnessBar.Value = 0;
            ContrastBar.Value = 0;
            pictureBox1.Load(op.FileName);
        }

        private int Check(double n)
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
            float change = ((float)(BrightnessBar.Value - oldbr))/2.0f;//recalculated by percents
            oldbr = BrightnessBar.Value;

            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check(c.R+change), Check(c.G+change), Check(c.B+change)));
                }
            //Trace.WriteLine("Done");
            pictureBox1.Image = b;
        }

        private void Contrast(object sender, EventArgs e)
        {
            float contr = ((float)(ContrastBar.Value-oldc + 255)) / 255.0f;
            contr *= contr;
            oldc = ContrastBar.Value;

            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check((((float)c.R / 255.0 - 0.5) * contr + 0.5) * 255.0),
                        Check((((float)c.G / 255.0 - 0.5) * contr + 0.5) * 255.0),
                        Check((((float)c.B / 255.0 - 0.5) * contr + 0.5) * 255.0)));
                }
            //Trace.WriteLine("Done");
            pictureBox1.Image = b;
        }
    }
}
