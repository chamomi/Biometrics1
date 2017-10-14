using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Resources;
using System.Drawing.Drawing2D;

namespace Biometrics1
{
    public partial class Form1 : Form
    {
        int oldbr = 0, oldc = 0;
        OpenFileDialog op;
        bool GRAY = false;

        public Form1()
        {
            InitializeComponent();
        }

        //Opens image
        private void ChooseIm(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                Start();
            }
            op = new OpenFileDialog();
            op.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(op.FileName);
            }
        }

        //Saves current version of image to file
        private void SaveIm(object sender, EventArgs e)
        {
            SaveFileDialog sv = new SaveFileDialog();
            sv.DefaultExt = ".jpg";
            sv.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            sv.FileName = "New_image";
            if (sv.ShowDialog() == DialogResult.OK)
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

        //Reopens initial image file
        private void ToStart(object sender, EventArgs e)
        {
            pictureBox1.Load(op.FileName);
            Start();
        }

        //Initial state of controls
        private void Start()
        {
            BrightnessBar.Value = 0;
            ContrastBar.Value = 0;
            oldbr = 0;
            oldc = 0;
            GRAY = false;
            ThresholdBar.Value = 0;
            ThresholdBar.Enabled = true;
            pictureBox1.Load(op.FileName);
            if (GrayHist.Image != null)
            {
                GrayHist.Image.Dispose();
                GrayHist.Image = null;
            }
            if (RHist.Image != null)
            {
                RHist.Image.Dispose();
                RHist.Image = null;
            }
            if (GHist.Image != null)
            {
                GHist.Image.Dispose();
                GHist.Image = null;
            }
            if (BHist.Image != null)
            {
                BHist.Image.Dispose();
                BHist.Image = null;
            }
            if(VertProj.Image!=null)
            {
                VertProj.Image.Dispose();
                VertProj.Image = null;
            }
            if(HorProj.Image!=null)
            {
                HorProj.Image.Dispose();
                HorProj.Image = null;
            }
        }

        //Checks if value is in color range
        private int Check(double n)
        {
            if (n < 0) return 0;
            else if (n > 255) return 255;
            else return (int)n;
        }

        //Grayscale button click
        private void Grayscale(object sender, EventArgs e)
        {
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    int avg = (c.R + c.G + c.B) / 3;
                    try
                    {
                        b.SetPixel(i, j, Color.FromArgb(c.A, avg, avg, avg));
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("Images with indexes pixels are unfortunately unsupported");
                        break;
                    }
                }
            pictureBox1.Image = b;
            GRAY = true;
        }

        //Negation button click
        private void Negation(object sender, EventArgs e)
        {
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, 255 - c.R, 255 - c.G, 255 - c.B));
                }
            pictureBox1.Image = b;
        }

        //BrightnessBar adjustment, applies its value change to image
        private void Brightness(object sender, EventArgs e)
        {
            float change = ((float)(BrightnessBar.Value - oldbr)) / 2.0f;//recalculated by percents
            oldbr = BrightnessBar.Value;

            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check(c.R + change), Check(c.G + change), Check(c.B + change)));
                }
            pictureBox1.Image = b;
        }

        //ContrastBar adjustment, applies its value change to image
        private void Contrast(object sender, EventArgs e)
        {
            float contr = ((float)(ContrastBar.Value - oldc + 255)) / 255.0f;
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
            pictureBox1.Image = b;
        }

        //Threshold slider adjustment, applies ThresholdBar value to image
        private void Threshold(object sender, EventArgs e)
        {
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;

            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    if ((c.R + c.G + c.B) < ThresholdBar.Value*3)
                        b.SetPixel(i, j, Color.FromArgb(c.A, 0, 0, 0));
                    else b.SetPixel(i, j, Color.FromArgb(c.A, 255, 255, 255));
                }
            pictureBox1.Image = b;
            GRAY = true;
            ThresholdBar.Enabled = false;
        }

        //Otsu Treshold button click
        //Invokes threshold finding and applies it
        private void OtsuThreshold(object sender, EventArgs e)
        {
            button3.PerformClick();//grayscale
            int th = FindOtsu() *3;

            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;

            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    if ((c.R + c.G + c.B) < th)
                        b.SetPixel(i, j, Color.FromArgb(c.A, 0, 0, 0));
                    else b.SetPixel(i, j, Color.FromArgb(c.A, 255, 255, 255));
                }
            pictureBox1.Image = b;

            ThresholdBar.Value = th/3;
            ThresholdBar.Enabled = false;
        }

        //Returns Otsu threshold for image
        private int FindOtsu() //https://www.codeproject.com/Articles/38319/Famous-Otsu-Thresholding-in-C
        {
            int t = 0;

            int[][] hist = new int[3][];
            for (int i = 0; i < 3; i++)
                hist[i] = new int[256];
            Hist(hist);

            float p1, p2, p12;
            float[] vec = new float[256];
            for (int i = 1; i < 255; i++)
            {
                p1 = Px(0, i, hist[0]);
                p2 = Px(i + 1, 255, hist[0]);
                p12 = p1 * p2;
                if (p12 == 0)
                    p12 = 1;
                float diff = (Mx(0, i, hist[0]) * p2) - (Mx(i + 1, 255, hist[0]) * p1);
                vec[i] = diff * diff / p12;
            }

            float max = 0;
            for(int i=0;i<vec.Length;i++)
                if(vec[i]>max)
                {
                    max = vec[i];
                    t = i;
                }
            return t;
        }

        //Helper function for FindOtsu(), sums given part of array
        private static float Px(int init, int end, int[] hist)
        {
            int sum = 0;
            int i;

            for (i = init; i <= end; i++)
                sum += hist[i];

            return (float)sum;
        }

        //Helper function for FindOtsu()
        private static float Mx(int init, int end, int[] hist)
        {
            int sum = 0;
            int i;

            for (i = init; i <= end; i++)
                sum += i * hist[i];

            return (float)sum;
        }

        //Creates histograms for image
        private void Hist(int[][] hist)
        {
            hist.Initialize();

            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;

            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    hist[0][c.R]++;
                    hist[1][c.G]++;
                    hist[2][c.B]++;
                }
        }

        //Returns max value in array(histogram)
        private int MaxHist(int[] hist)
        {
            int max = 0;
            for(int i=0;i<hist.Length;i++)
                if (hist[i] > max) max = hist[i];
            return max;
        }

        //Histogram button click
        //Invokes creation and drawing of histogram
        private void Histogram_Click(object sender, EventArgs e)
        {
            Color[] RGB = new Color[3];
            RGB[0] = Color.Red;
            RGB[1] = Color.Green;
            RGB[2] = Color.Blue;

            int[][] hist = new int[3][];
            for (int i = 0; i < 3; i++)
                hist[i] = new int[256];
            Hist(hist);
            if (GRAY == true) DrawHist(hist[0], Color.Black);
            else
                for (int i=0;i<3;i++)
                   DrawHist(hist[i], RGB[i]);
        }

        //Draws histograms in pictureboxes based on given color(Gray, RGB, Orange-vertical projection, Purple-horizontal projection PictureBox)
        private void DrawHist(int[] hist, Color c)
        {
            int m = MaxHist(hist);
            Bitmap img = new Bitmap(256, m);

            Graphics gr = Graphics.FromImage(img);
            RectangleF data_bounds = new RectangleF(0, 0, hist.Length, m);
            PointF[] points =
            {
                    new PointF(0, m),
                    new PointF(256, m),
                    new PointF(0, 0)
            };
            Matrix transformation = new Matrix(data_bounds, points);
            gr.Transform = transformation;

            using (Pen thin_pen = new Pen(c, 0))
            {
                for (int i = 0; i < hist.Length; i++)
                {
                    RectangleF rect = new RectangleF(i, 0, 1, hist[i]);
                    using (Brush the_brush =
                        new SolidBrush(c))
                    {
                        gr.FillRectangle(the_brush, rect);
                        gr.DrawRectangle(thin_pen, rect.X, rect.Y,
                            rect.Width, rect.Height);
                    }
                }
            }
            //show img in appropriate picturebox
            if (c == Color.Red)
            {
                if (RHist.Image != null)
                    RHist.Image.Dispose();

                RHist.Image = img;
            }
            else if (c == Color.Green)
            {
                if (GHist.Image != null)
                    GHist.Image.Dispose();

                GHist.Image = img;
            }
            else if (c == Color.Blue)
            {
                if (BHist.Image != null)
                    BHist.Image.Dispose();

                BHist.Image = img;
            }
            else if (c == Color.Orange)
            {
                if (VertProj.Image != null)
                    VertProj.Image.Dispose();

                VertProj.Image = img;
            }
            else if (c == Color.Purple)
            {
                if (HorProj.Image != null)
                    HorProj.Image.Dispose();

                HorProj.Image = img;
            }
            else
            {
                if (GrayHist.Image != null)
                    GrayHist.Image.Dispose();

                GrayHist.Image = img;
            }
        }

        //Projection button click
        //Creates vertical and horizontal projection, invokes thier drawing
        //Quite slow
        private void Projection(object sender, EventArgs e)
        {
            Color c;
            Bitmap b = (Bitmap)pictureBox1.Image;

            //vertical projection
            int[] ProjX = new int[b.Width];
            for (int j = 0; j < b.Width; j++)
            {
                ProjX[j] = 0;
                for (int i = 0; i < b.Height; i++)
                {
                    c = b.GetPixel(j, i);
                    ProjX[j] += c.R + c.G + c.B;
                }
            }
            DrawHist(ProjX, Color.Orange);

            //horizontal projection
            int[] ProjY = new int[b.Height];
            for (int j = 0; j < b.Height; j++)
            {
                ProjY[j] = 0;
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    ProjY[j] += c.R + c.G + c.B;
                }
            }
            DrawHist(ProjY, Color.Purple);
        }

        //Histogram Stretching button click
        //Performs histogram stretching on image and updates displayed histograms
        private void HistStretch(object sender, EventArgs e)
        {
            int[][] hist = new int[3][];
            for (int i = 0; i < 3; i++)
                hist[i] = new int[256];
            Hist(hist);

            int[] Imax = new int[3];
            int[] Imin = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int j = 0;
                while (hist[i][j] == 0) j++;
                Imin[i] = j;

                j = hist[i].Length-1;
                while (hist[i][j] == 0) j--;
                Imax[i] = j;
            }

            int[][] LUT = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                LUT[i] = new int[256];

                for (int j = 0; j < 256; j++)
                    LUT[i][j] = 255 * (j - Imin[i]) / (Imax[i] - Imin[i]);
            }

            Color c;
            Bitmap b = new Bitmap(pictureBox1.Image);
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check(LUT[0][c.R]), Check(LUT[1][c.G]), Check(LUT[2][c.B])));
                }
            pictureBox1.Image = b;

            button6.PerformClick();//display new histograms
        }

        //Histogram Equalization button click
        //Performs histogram equalization on image and updates displayed histograms
        private void HistEqual(object sender, EventArgs e)
        {
            int[][] hist = new int[3][];
            for (int i = 0; i < 3; i++)
                hist[i] = new int[256];
            Hist(hist);

            int[][] LUT = new int[3][];
            for (int i = 0; i < 3; i++)
            {
                LUT[i] = new int[256];

                for (int j = 0; j < 256; j++)
                    LUT[i][j] = 255 * sum(hist[i],1,j) / sum(hist[i],1,255);
            }

            Color c;
            Bitmap b = new Bitmap(pictureBox1.Image);
            for (int j = 0; j < b.Height; j++)
                for (int i = 0; i < b.Width; i++)
                {
                    c = b.GetPixel(i, j);
                    b.SetPixel(i, j, Color.FromArgb(c.A, Check(LUT[0][c.R]), Check(LUT[1][c.G]), Check(LUT[2][c.B])));
                }
            pictureBox1.Image = b;

            button6.PerformClick();//display new histograms
        }

        //Helper function for HistEqual()
        //Sums up elements of given array with indexes a-b
        private int sum(int[] hist, int a, int b)
        {
            int sum = 0;
            for (int i = a; i <= b; i++)
            {
                sum += hist[i];
            }
            return sum;
        }
    }
}
