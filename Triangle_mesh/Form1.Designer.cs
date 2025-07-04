﻿namespace Triangle_mesh
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            triangleTrackBar = new TrackBar();
            ksTrackBar = new TrackBar();
            alphaTrackBar = new TrackBar();
            kdTrackBar = new TrackBar();
            betaTrackBar = new TrackBar();
            mTrackBar = new TrackBar();
            groupBox1 = new GroupBox();
            mLabel = new Label();
            ksLabel = new Label();
            kdLabel = new Label();
            betaLabel = new Label();
            alphaLabel = new Label();
            trianglesLabel = new Label();
            zTrackBar = new TrackBar();
            zLabel = new Label();
            groupBox2 = new GroupBox();
            textureRadioButton = new RadioButton();
            colorRadioButton = new RadioButton();
            stopButton = new Button();
            fillingCheckbox = new CheckBox();
            meshCheckbox = new CheckBox();
            lightPictureBox = new PictureBox();
            objectPictureBox = new PictureBox();
            lightColorButton = new Button();
            objectColorButton = new Button();
            normalVectorCheckbox = new CheckBox();
            colorDialog = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)triangleTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)zTrackBar).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lightPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)objectPictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.White;
            pictureBox1.Location = new Point(15, 15);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(625, 625);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // triangleTrackBar
            // 
            triangleTrackBar.Location = new Point(8, 58);
            triangleTrackBar.Margin = new Padding(4);
            triangleTrackBar.Maximum = 50;
            triangleTrackBar.Minimum = 1;
            triangleTrackBar.Name = "triangleTrackBar";
            triangleTrackBar.Size = new Size(278, 69);
            triangleTrackBar.TabIndex = 1;
            triangleTrackBar.Tag = "";
            triangleTrackBar.Value = 10;
            triangleTrackBar.ValueChanged += triangleTrackBar_ValueChanged;
            // 
            // ksTrackBar
            // 
            ksTrackBar.Location = new Point(8, 465);
            ksTrackBar.Margin = new Padding(4);
            ksTrackBar.Name = "ksTrackBar";
            ksTrackBar.Size = new Size(278, 69);
            ksTrackBar.TabIndex = 2;
            // 
            // alphaTrackBar
            // 
            alphaTrackBar.Location = new Point(8, 158);
            alphaTrackBar.Margin = new Padding(4);
            alphaTrackBar.Maximum = 45;
            alphaTrackBar.Minimum = -45;
            alphaTrackBar.Name = "alphaTrackBar";
            alphaTrackBar.Size = new Size(278, 69);
            alphaTrackBar.TabIndex = 3;
            alphaTrackBar.ValueChanged += alphaTrackBar_ValueChanged;
            // 
            // kdTrackBar
            // 
            kdTrackBar.Location = new Point(8, 362);
            kdTrackBar.Margin = new Padding(4);
            kdTrackBar.Name = "kdTrackBar";
            kdTrackBar.Size = new Size(278, 69);
            kdTrackBar.TabIndex = 4;
            // 
            // betaTrackBar
            // 
            betaTrackBar.Location = new Point(8, 260);
            betaTrackBar.Margin = new Padding(4);
            betaTrackBar.Name = "betaTrackBar";
            betaTrackBar.Size = new Size(278, 69);
            betaTrackBar.TabIndex = 5;
            betaTrackBar.ValueChanged += betaTrackBar_ValueChanged;
            // 
            // mTrackBar
            // 
            mTrackBar.Location = new Point(8, 568);
            mTrackBar.Margin = new Padding(4);
            mTrackBar.Maximum = 100;
            mTrackBar.Minimum = 1;
            mTrackBar.Name = "mTrackBar";
            mTrackBar.Size = new Size(278, 69);
            mTrackBar.TabIndex = 6;
            mTrackBar.Value = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(mLabel);
            groupBox1.Controls.Add(ksLabel);
            groupBox1.Controls.Add(kdLabel);
            groupBox1.Controls.Add(betaLabel);
            groupBox1.Controls.Add(alphaLabel);
            groupBox1.Controls.Add(trianglesLabel);
            groupBox1.Controls.Add(triangleTrackBar);
            groupBox1.Controls.Add(mTrackBar);
            groupBox1.Controls.Add(alphaTrackBar);
            groupBox1.Controls.Add(ksTrackBar);
            groupBox1.Controls.Add(kdTrackBar);
            groupBox1.Controls.Add(betaTrackBar);
            groupBox1.Location = new Point(772, 15);
            groupBox1.Margin = new Padding(4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4);
            groupBox1.Size = new Size(382, 649);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // mLabel
            // 
            mLabel.AutoSize = true;
            mLabel.Location = new Point(8, 539);
            mLabel.Margin = new Padding(4, 0, 4, 0);
            mLabel.Name = "mLabel";
            mLabel.Size = new Size(28, 25);
            mLabel.TabIndex = 12;
            mLabel.Text = "m";
            // 
            // ksLabel
            // 
            ksLabel.AutoSize = true;
            ksLabel.Location = new Point(8, 436);
            ksLabel.Margin = new Padding(4, 0, 4, 0);
            ksLabel.Name = "ksLabel";
            ksLabel.Size = new Size(29, 25);
            ksLabel.TabIndex = 11;
            ksLabel.Text = "ks";
            // 
            // kdLabel
            // 
            kdLabel.AutoSize = true;
            kdLabel.Location = new Point(8, 334);
            kdLabel.Margin = new Padding(4, 0, 4, 0);
            kdLabel.Name = "kdLabel";
            kdLabel.Size = new Size(32, 25);
            kdLabel.TabIndex = 10;
            kdLabel.Text = "kd";
            // 
            // betaLabel
            // 
            betaLabel.AutoSize = true;
            betaLabel.Location = new Point(8, 231);
            betaLabel.Margin = new Padding(4, 0, 4, 0);
            betaLabel.Name = "betaLabel";
            betaLabel.Size = new Size(46, 25);
            betaLabel.TabIndex = 9;
            betaLabel.Text = "Beta";
            // 
            // alphaLabel
            // 
            alphaLabel.AutoSize = true;
            alphaLabel.Location = new Point(8, 129);
            alphaLabel.Margin = new Padding(4, 0, 4, 0);
            alphaLabel.Name = "alphaLabel";
            alphaLabel.Size = new Size(58, 25);
            alphaLabel.TabIndex = 8;
            alphaLabel.Text = "Alpha";
            // 
            // trianglesLabel
            // 
            trianglesLabel.AutoSize = true;
            trianglesLabel.Location = new Point(8, 29);
            trianglesLabel.Margin = new Padding(4, 0, 4, 0);
            trianglesLabel.Name = "trianglesLabel";
            trianglesLabel.Size = new Size(80, 25);
            trianglesLabel.TabIndex = 7;
            trianglesLabel.Text = "Triangles";
            // 
            // zTrackBar
            // 
            zTrackBar.Location = new Point(8, 182);
            zTrackBar.Margin = new Padding(4);
            zTrackBar.Maximum = 100;
            zTrackBar.Minimum = -300;
            zTrackBar.Name = "zTrackBar";
            zTrackBar.Size = new Size(278, 69);
            zTrackBar.TabIndex = 14;
            zTrackBar.TickFrequency = 10;
            zTrackBar.Value = -200;
            // 
            // zLabel
            // 
            zLabel.AutoSize = true;
            zLabel.Location = new Point(8, 154);
            zLabel.Margin = new Padding(4, 0, 4, 0);
            zLabel.Name = "zLabel";
            zLabel.Size = new Size(20, 25);
            zLabel.TabIndex = 13;
            zLabel.Text = "z";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textureRadioButton);
            groupBox2.Controls.Add(colorRadioButton);
            groupBox2.Controls.Add(stopButton);
            groupBox2.Controls.Add(fillingCheckbox);
            groupBox2.Controls.Add(meshCheckbox);
            groupBox2.Controls.Add(lightPictureBox);
            groupBox2.Controls.Add(objectPictureBox);
            groupBox2.Controls.Add(zLabel);
            groupBox2.Controls.Add(zTrackBar);
            groupBox2.Controls.Add(lightColorButton);
            groupBox2.Controls.Add(objectColorButton);
            groupBox2.Controls.Add(normalVectorCheckbox);
            groupBox2.Location = new Point(1175, 15);
            groupBox2.Margin = new Padding(4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4);
            groupBox2.Size = new Size(312, 649);
            groupBox2.TabIndex = 8;
            groupBox2.TabStop = false;
            groupBox2.Text = "groupBox2";
            // 
            // textureRadioButton
            // 
            textureRadioButton.AutoSize = true;
            textureRadioButton.Location = new Point(8, 469);
            textureRadioButton.Margin = new Padding(4);
            textureRadioButton.Name = "textureRadioButton";
            textureRadioButton.Size = new Size(92, 29);
            textureRadioButton.TabIndex = 19;
            textureRadioButton.Text = "Texture";
            textureRadioButton.UseVisualStyleBackColor = true;
            textureRadioButton.CheckedChanged += textureRadioButton_CheckedChanged;
            // 
            // colorRadioButton
            // 
            colorRadioButton.AutoSize = true;
            colorRadioButton.Checked = true;
            colorRadioButton.Location = new Point(8, 431);
            colorRadioButton.Margin = new Padding(4);
            colorRadioButton.Name = "colorRadioButton";
            colorRadioButton.Size = new Size(126, 29);
            colorRadioButton.TabIndex = 18;
            colorRadioButton.TabStop = true;
            colorRadioButton.Text = "Same color";
            colorRadioButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(8, 372);
            stopButton.Margin = new Padding(4);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(159, 36);
            stopButton.TabIndex = 17;
            stopButton.Text = "Stop the light";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // fillingCheckbox
            // 
            fillingCheckbox.AutoSize = true;
            fillingCheckbox.Location = new Point(8, 335);
            fillingCheckbox.Margin = new Padding(4);
            fillingCheckbox.Name = "fillingCheckbox";
            fillingCheckbox.Size = new Size(123, 29);
            fillingCheckbox.TabIndex = 13;
            fillingCheckbox.Text = "Only filling";
            fillingCheckbox.UseVisualStyleBackColor = true;
            fillingCheckbox.Click += fillingCheckbox_Click;
            // 
            // meshCheckbox
            // 
            meshCheckbox.AutoSize = true;
            meshCheckbox.Location = new Point(8, 298);
            meshCheckbox.Margin = new Padding(4);
            meshCheckbox.Name = "meshCheckbox";
            meshCheckbox.Size = new Size(123, 29);
            meshCheckbox.TabIndex = 14;
            meshCheckbox.Text = "Only mesh";
            meshCheckbox.UseVisualStyleBackColor = true;
            meshCheckbox.Click += meshCheckbox_Click;
            // 
            // lightPictureBox
            // 
            lightPictureBox.BackColor = Color.White;
            lightPictureBox.Location = new Point(182, 91);
            lightPictureBox.Margin = new Padding(4);
            lightPictureBox.Name = "lightPictureBox";
            lightPictureBox.Size = new Size(102, 36);
            lightPictureBox.TabIndex = 16;
            lightPictureBox.TabStop = false;
            // 
            // objectPictureBox
            // 
            objectPictureBox.BackColor = Color.Red;
            objectPictureBox.Location = new Point(182, 29);
            objectPictureBox.Margin = new Padding(4);
            objectPictureBox.Name = "objectPictureBox";
            objectPictureBox.Size = new Size(102, 40);
            objectPictureBox.TabIndex = 15;
            objectPictureBox.TabStop = false;
            // 
            // lightColorButton
            // 
            lightColorButton.Location = new Point(8, 91);
            lightColorButton.Margin = new Padding(4);
            lightColorButton.Name = "lightColorButton";
            lightColorButton.Size = new Size(159, 36);
            lightColorButton.TabIndex = 2;
            lightColorButton.Text = "Light Color";
            lightColorButton.UseVisualStyleBackColor = true;
            lightColorButton.Click += lightColorButton_Click;
            // 
            // objectColorButton
            // 
            objectColorButton.Location = new Point(8, 32);
            objectColorButton.Margin = new Padding(4);
            objectColorButton.Name = "objectColorButton";
            objectColorButton.Size = new Size(159, 36);
            objectColorButton.TabIndex = 1;
            objectColorButton.Text = "Object Color";
            objectColorButton.UseVisualStyleBackColor = true;
            objectColorButton.Click += objectColorButton_Click;
            // 
            // normalVectorCheckbox
            // 
            normalVectorCheckbox.AutoSize = true;
            normalVectorCheckbox.Location = new Point(8, 260);
            normalVectorCheckbox.Margin = new Padding(4);
            normalVectorCheckbox.Name = "normalVectorCheckbox";
            normalVectorCheckbox.Size = new Size(210, 29);
            normalVectorCheckbox.TabIndex = 0;
            normalVectorCheckbox.Text = "Modify normal vector";
            normalVectorCheckbox.UseVisualStyleBackColor = true;
            normalVectorCheckbox.CheckedChanged += normalVectorCheckbox_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1502, 672);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(pictureBox1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)triangleTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)ksTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alphaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)kdTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)betaTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mTrackBar).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)zTrackBar).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lightPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)objectPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private TrackBar triangleTrackBar;
        private TrackBar ksTrackBar;
        private TrackBar alphaTrackBar;
        private TrackBar kdTrackBar;
        private TrackBar betaTrackBar;
        private TrackBar mTrackBar;
        private GroupBox groupBox1;
        private Label mLabel;
        private Label ksLabel;
        private Label kdLabel;
        private Label betaLabel;
        private Label alphaLabel;
        private Label trianglesLabel;
        private TrackBar zTrackBar;
        private Label zLabel;
        private GroupBox groupBox2;
        private CheckBox normalVectorCheckbox;
        private ColorDialog colorDialog;
        private Button lightColorButton;
        private Button objectColorButton;
        private PictureBox lightPictureBox;
        private PictureBox objectPictureBox;
        private CheckBox fillingCheckbox;
        private CheckBox meshCheckbox;
        private Button stopButton;
        private RadioButton textureRadioButton;
        private RadioButton colorRadioButton;
    }
}
