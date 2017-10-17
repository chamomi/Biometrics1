using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Resources;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

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
                    ProjX[j] += (c.R + c.G + c.B)/3;
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
                    ProjY[j] += (c.R + c.G + c.B)/3;
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

        //Averaging button click
        //Invokes image extension, averages colors from 3x3 squares
        private void Averaging(object sender, EventArgs e)
        {
            Bitmap b = ExtendBitmap((Bitmap)pictureBox1.Image);
            Bitmap result = new Bitmap(pictureBox1.Image);

            pictureBox1.Image = b;
            for(int i=1;i<b.Width-2;i++)
                for(int j=1;j<b.Height-2;j++)
                {
                    int[] sum = new int[3];
                    for (int a = 0; a < 3; a++)
                        sum[a] = 0;

                    for(int k=i-1;k<=i+1;k++)
                        for(int t=j-1;t<=j+1;t++)
                        {
                            sum[0] += b.GetPixel(k, t).R;
                            sum[1] += b.GetPixel(k, t).G;
                            sum[2] += b.GetPixel(k, t).B;
                        }

                    result.SetPixel(i - 1, j - 1, Color.FromArgb(result.GetPixel(i - 1, j - 1).A, Check(sum[0] / 9), Check(sum[1] / 9), Check(sum[2] / 9)));
                }
            pictureBox1.Image = result;
        }

        //Helper function for Averaging()
        //Extends bitmap by duplicating outer border 
        private Bitmap ExtendBitmap(Bitmap b)
        {
            Bitmap exten = new Bitmap(b.Width + 2, b.Height + 2);

            for (int i = 1; i < exten.Width - 1; i++)
                for (int j = 1; j < exten.Height - 1; j++)
                    exten.SetPixel(i, j, b.GetPixel(i - 1, j - 1));

            exten.SetPixel(0, 0, exten.GetPixel(1, 1));
            exten.SetPixel(exten.Width - 1, 0, exten.GetPixel(exten.Width - 2, 1));
            exten.SetPixel(0, exten.Height - 1, exten.GetPixel(1, exten.Height - 2));
            exten.SetPixel(exten.Width - 1, exten.Height - 1, exten.GetPixel(exten.Width - 2, exten.Height - 2));

            for (int i = 1; i < exten.Width - 1; i++)
                exten.SetPixel(i, 0, exten.GetPixel(i, 1));
            for (int i = 1; i < exten.Width - 1; i++)
                exten.SetPixel(i, exten.Height - 1, exten.GetPixel(i, exten.Height - 2));
            for (int i = 1; i < exten.Height - 1; i++)
                exten.SetPixel(0, i, exten.GetPixel(1, i));
            for (int i = 1; i < exten.Height - 1; i++)
                exten.SetPixel(exten.Width - 1, i, exten.GetPixel(exten.Width - 2, i));

            return exten;
        }

        //Gaussian button click
        //Invokes image extension 2 times and applies Gauss filter to image
        private void Gaussian(object sender, EventArgs e)
        {
            Bitmap b = ExtendBitmap(ExtendBitmap((Bitmap)pictureBox1.Image));
            pictureBox1.Image = ApplyGauss(b);
        }

        //Applies Gauss filter to given extended image
        //Firstly performs horizontal filtering and then vertical one with function ApplyVector()
        private Bitmap ApplyGauss(Bitmap b)
        {
            Bitmap result = new Bitmap(pictureBox1.Image);

            int[] sum = new int[3];

            //horizontal filter
            for(int i=0;i<b.Width-5;i++)
                for(int j=2;j<b.Height-3;j++)
                {
                    for (int k = 0; k < 3; k++)
                        sum[k] = 0;
                    ApplyG5Vector(ref sum, b, i, j, 0);
                    result.SetPixel(i, j - 2, Color.FromArgb(result.GetPixel(i, j - 2).A, Check(sum[0]), Check(sum[1]), Check(sum[2])));
                }

            //vertical filter
            for (int i = 2; i < b.Width - 3; i++)
                for (int j = 0; j < b.Height - 5; j++)
                {
                    for (int k = 0; k < 3; k++)
                        sum[k] = 0;
                    ApplyG5Vector(ref sum, b, i, j, 1);
                    result.SetPixel(i - 2, j, Color.FromArgb(result.GetPixel(i - 2, j).A, Check(sum[0]), Check(sum[1]), Check(sum[2])));
                }
            return result;
        }

        //Helper function for ApplyGauss()
        //Calculates new RGB values for each pixel
        //radius = 3; sigma = 1;
        private void ApplyG5Vector(ref int[] sum, Bitmap b, int w, int h, int mode)
        {
            double[] vector = new double[] { 1 / (Math.E * Math.E * Math.Sqrt(2 * Math.PI)),
                        1 / Math.Sqrt(2 * Math.PI * Math.E),
                        1 / Math.Sqrt(2 * Math.PI),
                        1 / Math.Sqrt(2 * Math.PI * Math.E),
                        1 / (Math.E * Math.E * Math.Sqrt(2 * Math.PI)) };
            Color c;

            switch (mode)
            {
                //horizontal vector
                case 0:
                    for (int i = 0; i < 5; i++)
                    {
                        c = b.GetPixel(w + i, h);
                        sum[0] += (int)(vector[i] * c.R);
                        sum[1] += (int)(vector[i] * c.G);
                        sum[2] += (int)(vector[i] * c.B);
                    }
                    break;
                //vertical vector
                case 1:
                    for (int i = 0; i < 5; i++)
                    {
                        c = b.GetPixel(w, h+i);
                        sum[0] += (int)(vector[i] * c.R);
                        sum[1] += (int)(vector[i] * c.G);
                        sum[2] += (int)(vector[i] * c.B);
                    }
                    break;
            }
        }

        //Sharpening filter button click
        //Invokes image extention, creates sharpening kernel and invokes matrix application to image
        private void Sharpen(object sender, EventArgs e)
        {
            Bitmap b = ExtendBitmap((Bitmap)pictureBox1.Image);

            int[,] kernel = new int[3, 3] { { -1, -1, -1 }, { -1, 9, -1 }, { -1, -1, -1 } };

            pictureBox1.Image = ApplyMatrix(b, kernel);
        }

        //Applies kernel matrix to image b, returns processed image
        private Bitmap ApplyMatrix(Bitmap b, int[,] kernel)
        {
            Bitmap result = (Bitmap)pictureBox1.Image;
            int dim = (int)Math.Sqrt(kernel.Length);//dimention of kernel

            int[] sum = new int[3];
            Color c;
            for(int i=0;i<b.Width-dim;i++)
                for(int j=0;j<b.Height-dim;j++)
                {
                    for (int k = 0; k < 3; k++)
                        sum[k] = 0;
                    for (int m=0;m<dim;m++)
                        for(int n=0;n<dim;n++)
                        {
                            c = b.GetPixel(i + m, j + n);
                            sum[0] += c.R * kernel[n, m];
                            sum[1] += c.G * kernel[n, m];
                            sum[2] += c.B * kernel[n, m];
                        }
                    try
                    {
                        result.SetPixel(i, j, Color.FromArgb(result.GetPixel(i, j).A, Check(sum[0]), Check(sum[1]), Check(sum[2])));
                    }
                    catch (InvalidOperationException)
                    {
                        MessageBox.Show("Images with indexes pixels are unfortunately unsupported");
                        break;
                    }
                }
            return result;
        }

        //Roberts Cross button click
        //Invokes application of Roberts kernels, sums values of intensities of results
        private void RobertsEdge(object sender, EventArgs e)
        {
            int[,] Gx = new int[2, 2] { { 1, 0 }, { 0, -1 } };
            int[,] Gy = new int[2, 2] { { 0, 1 }, { -1, 0 } };

            Bitmap b1 = ApplyMatrix((Bitmap)pictureBox1.Image, Gx);
            Bitmap b2 = ApplyMatrix((Bitmap)pictureBox1.Image, Gy);

            Bitmap result = (Bitmap)pictureBox1.Image;
            for(int i=0;i<result.Width;i++)
                for(int j=0;j<result.Height;j++)
                {
                    result.SetPixel(i, j, Color.FromArgb(result.GetPixel(i, j).A, Check(b1.GetPixel(i, j).R + b2.GetPixel(i, j).R),
                        Check(b1.GetPixel(i, j).G + b2.GetPixel(i, j).G),
                        Check(b1.GetPixel(i, j).B + b2.GetPixel(i, j).B)));
                }
            pictureBox1.Image = result;
        }

        //Sobel filter button click
        //Calculates new values for each pixel by Sobel kernels
        private void SobelEdge(object sender, EventArgs e)
        {
            int[,] Gx = new int[3, 3] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] Gy = new int[3, 3] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            Bitmap b = (Bitmap)pictureBox1.Image;
            BitmapData sourceData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];
            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            b.UnlockBits(sourceData);

            double[] colorX = new double[3];
            double[] colorY = new double[3];
            double[] colorTotal = new double[3];

            int filterOffset = 1;
            int calcOffset = 0;
            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY < b.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < b.Width - filterOffset; offsetX++)
                {
                    for (int i = 0; i < 3; i++)
                        colorX[i] = colorY[i] = colorTotal[i] = 0;

                    byteOffset = offsetY * sourceData.Stride + offsetX * 4;

                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride);

                            colorX[0] += (double)(pixelBuffer[calcOffset + 2]) * Gx[filterY + filterOffset, filterX + filterOffset];
                            colorX[1] += (double)(pixelBuffer[calcOffset + 1]) * Gx[filterY + filterOffset, filterX + filterOffset];
                            colorX[2] += (double)(pixelBuffer[calcOffset]) * Gx[filterY + filterOffset, filterX + filterOffset];

                            colorY[0] += (double)(pixelBuffer[calcOffset + 2]) * Gy[filterY + filterOffset, filterX + filterOffset];
                            colorY[1] += (double)(pixelBuffer[calcOffset + 1]) * Gy[filterY + filterOffset, filterX + filterOffset];
                            colorY[2] += (double)(pixelBuffer[calcOffset]) * Gy[filterY + filterOffset, filterX + filterOffset];
                        }
                    }
                    colorTotal[0] = Math.Sqrt((colorX[0] * colorX[0]) + (colorY[0] * colorY[0]));
                    colorTotal[1] = Math.Sqrt((colorX[1] * colorX[1]) + (colorY[1] * colorY[1]));
                    colorTotal[2] = Math.Sqrt((colorX[2] * colorX[2]) + (colorY[2] * colorY[2]));

                    resultBuffer[byteOffset] = (byte)Check(colorTotal[2]);
                    resultBuffer[byteOffset + 1] = (byte)Check(colorTotal[1]);
                    resultBuffer[byteOffset + 2] = (byte)Check(colorTotal[0]);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(b.Width, b.Height);
            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            pictureBox1.Image = resultBitmap;
        }
    }
}
