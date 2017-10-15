namespace Biometrics1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.ThresholdBar = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.ContrastBar = new System.Windows.Forms.TrackBar();
            this.BrightnessBar = new System.Windows.Forms.TrackBar();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button15 = new System.Windows.Forms.Button();
            this.RHist = new System.Windows.Forms.PictureBox();
            this.GHist = new System.Windows.Forms.PictureBox();
            this.BHist = new System.Windows.Forms.PictureBox();
            this.GrayHist = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.HorProj = new System.Windows.Forms.PictureBox();
            this.VertProj = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayHist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorProj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VertProj)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(503, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(225, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose an image from directory:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(506, 225);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChooseIm);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(506, 394);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SaveIm);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(471, 281);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(503, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Save current image";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.ThresholdBar);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button11);
            this.groupBox1.Controls.Add(this.button12);
            this.groupBox1.Controls.Add(this.button13);
            this.groupBox1.Controls.Add(this.button14);
            this.groupBox1.Controls.Add(this.ContrastBar);
            this.groupBox1.Controls.Add(this.BrightnessBar);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 157);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(443, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 40);
            this.button5.TabIndex = 19;
            this.button5.Text = "Otsu Thresholding";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OtsuThreshold);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(452, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Thresholding";
            // 
            // ThresholdBar
            // 
            this.ThresholdBar.LargeChange = 10;
            this.ThresholdBar.Location = new System.Drawing.Point(443, 27);
            this.ThresholdBar.Maximum = 255;
            this.ThresholdBar.Name = "ThresholdBar";
            this.ThresholdBar.Size = new System.Drawing.Size(100, 45);
            this.ThresholdBar.SmallChange = 10;
            this.ThresholdBar.TabIndex = 17;
            this.ThresholdBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Threshold);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(541, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Edge detection";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(311, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Filters";
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.Location = new System.Drawing.Point(3, 95);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(85, 62);
            this.button8.TabIndex = 8;
            this.button8.Text = "Histogram stretching";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.HistStretch);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.Location = new System.Drawing.Point(94, 95);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(95, 62);
            this.button9.TabIndex = 9;
            this.button9.Text = "Histogram equalization";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.HistEqual);
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.Location = new System.Drawing.Point(195, 110);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(85, 47);
            this.button10.TabIndex = 10;
            this.button10.Text = "Averaging";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.Averaging);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button11.Location = new System.Drawing.Point(287, 110);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(85, 47);
            this.button11.TabIndex = 11;
            this.button11.Text = "Gaussian";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.Gaussian);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.Location = new System.Drawing.Point(378, 110);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(93, 47);
            this.button12.TabIndex = 12;
            this.button12.Text = "Sharpening";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.Sharpen);
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button13.Location = new System.Drawing.Point(510, 110);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(85, 47);
            this.button13.TabIndex = 13;
            this.button13.Text = "Roberts Cross";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button14
            // 
            this.button14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button14.Location = new System.Drawing.Point(601, 110);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(85, 47);
            this.button14.TabIndex = 14;
            this.button14.Text = "Sobel filter";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // ContrastBar
            // 
            this.ContrastBar.LargeChange = 10;
            this.ContrastBar.Location = new System.Drawing.Point(305, 27);
            this.ContrastBar.Maximum = 255;
            this.ContrastBar.Minimum = -255;
            this.ContrastBar.Name = "ContrastBar";
            this.ContrastBar.Size = new System.Drawing.Size(132, 45);
            this.ContrastBar.SmallChange = 10;
            this.ContrastBar.TabIndex = 10;
            this.ContrastBar.ValueChanged += new System.EventHandler(this.Contrast);
            // 
            // BrightnessBar
            // 
            this.BrightnessBar.LargeChange = 10;
            this.BrightnessBar.Location = new System.Drawing.Point(179, 27);
            this.BrightnessBar.Maximum = 255;
            this.BrightnessBar.Minimum = -255;
            this.BrightnessBar.Name = "BrightnessBar";
            this.BrightnessBar.Size = new System.Drawing.Size(132, 45);
            this.BrightnessBar.SmallChange = 10;
            this.BrightnessBar.TabIndex = 9;
            this.BrightnessBar.ValueChanged += new System.EventHandler(this.Brightness);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(640, 9);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(95, 61);
            this.button7.TabIndex = 8;
            this.button7.Text = "Projection";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Projection);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(549, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 61);
            this.button6.TabIndex = 7;
            this.button6.Text = "Histogram";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Histogram_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(350, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Contrast";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button4.Location = new System.Drawing.Point(94, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 61);
            this.button4.TabIndex = 3;
            this.button4.Text = "Negation";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Negation);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(3, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 61);
            this.button3.TabIndex = 2;
            this.button3.Text = "Grayscale";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Grayscale);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(201, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Brightness";
            // 
            // button15
            // 
            this.button15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button15.Location = new System.Drawing.Point(543, 284);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(165, 40);
            this.button15.TabIndex = 8;
            this.button15.Text = "Open initial image";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.ToStart);
            // 
            // RHist
            // 
            this.RHist.BackColor = System.Drawing.Color.White;
            this.RHist.Location = new System.Drawing.Point(207, 478);
            this.RHist.Name = "RHist";
            this.RHist.Size = new System.Drawing.Size(160, 100);
            this.RHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.RHist.TabIndex = 9;
            this.RHist.TabStop = false;
            // 
            // GHist
            // 
            this.GHist.BackColor = System.Drawing.Color.White;
            this.GHist.Location = new System.Drawing.Point(395, 478);
            this.GHist.Name = "GHist";
            this.GHist.Size = new System.Drawing.Size(160, 100);
            this.GHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GHist.TabIndex = 10;
            this.GHist.TabStop = false;
            // 
            // BHist
            // 
            this.BHist.BackColor = System.Drawing.Color.White;
            this.BHist.Location = new System.Drawing.Point(587, 478);
            this.BHist.Name = "BHist";
            this.BHist.Size = new System.Drawing.Size(160, 100);
            this.BHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BHist.TabIndex = 11;
            this.BHist.TabStop = false;
            // 
            // GrayHist
            // 
            this.GrayHist.BackColor = System.Drawing.Color.White;
            this.GrayHist.Location = new System.Drawing.Point(15, 478);
            this.GrayHist.Name = "GrayHist";
            this.GrayHist.Size = new System.Drawing.Size(160, 100);
            this.GrayHist.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayHist.TabIndex = 12;
            this.GrayHist.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(49, 462);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 15);
            this.label8.TabIndex = 13;
            this.label8.Text = "Gray Histogram";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(249, 460);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 14;
            this.label9.Text = "Red Histogram";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(429, 460);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 15);
            this.label10.TabIndex = 15;
            this.label10.Text = "Green Histogram";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(627, 462);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(92, 15);
            this.label11.TabIndex = 16;
            this.label11.Text = "Blue Histogram";
            // 
            // HorProj
            // 
            this.HorProj.BackColor = System.Drawing.Color.White;
            this.HorProj.Location = new System.Drawing.Point(15, 599);
            this.HorProj.Name = "HorProj";
            this.HorProj.Size = new System.Drawing.Size(160, 59);
            this.HorProj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HorProj.TabIndex = 17;
            this.HorProj.TabStop = false;
            // 
            // VertProj
            // 
            this.VertProj.BackColor = System.Drawing.Color.White;
            this.VertProj.Location = new System.Drawing.Point(207, 599);
            this.VertProj.Name = "VertProj";
            this.VertProj.Size = new System.Drawing.Size(160, 59);
            this.VertProj.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.VertProj.TabIndex = 18;
            this.VertProj.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(37, 581);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 15);
            this.label12.TabIndex = 19;
            this.label12.Text = "Horizontal projection";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(235, 581);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(104, 15);
            this.label13.TabIndex = 20;
            this.label13.Text = "Vertical projection";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(764, 670);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.VertProj);
            this.Controls.Add(this.HorProj);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GrayHist);
            this.Controls.Add(this.BHist);
            this.Controls.Add(this.GHist);
            this.Controls.Add(this.RHist);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biometrics1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ThresholdBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContrastBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrightnessBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrayHist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HorProj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VertProj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar ContrastBar;
        private System.Windows.Forms.TrackBar BrightnessBar;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar ThresholdBar;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox RHist;
        private System.Windows.Forms.PictureBox GHist;
        private System.Windows.Forms.PictureBox BHist;
        private System.Windows.Forms.PictureBox GrayHist;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox HorProj;
        private System.Windows.Forms.PictureBox VertProj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

