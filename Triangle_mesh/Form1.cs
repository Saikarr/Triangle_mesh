using System.Numerics;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Triangle_mesh
{
    public partial class Form1 : Form
    {
        private bool IsAnimated = true;
        private bool IsOnlyMesh = false;
        private bool IsOnlyFill = false;
        private bool IsTexture = false;
        private Bitmap Texture;
        private Mesh mesh;
        private Color objectcolor = Color.Red;
        private Color lightcolor = Color.White;
        private Vector3 light = new Vector3(150, 0, -200);
        public Form1()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            string path = "../../../ControlPoints2.txt";
            mesh = new Mesh(Mesh.ReadControlPoints(path));
            string path2 = "../../../Teemofrompaint.png";
            Texture = new Bitmap(path2);
            Task.Run(() =>
            {
                //Thread.Sleep(100);
                while (true)
                {
                    Thread.Sleep(80);
                    BeginInvoke(new Action(() =>
                    {
                        pictureBox1.Invalidate();
                        //light = new Vector3(100 * (float)Math.Sin(DateTime.Now.Millisecond / 100), 100 * (float)Math.Cos(DateTime.Now.Millisecond / 100), -200);
                        if (IsAnimated)
                        {
                            long time = DateTimeOffset.Now.ToUnixTimeMilliseconds() / 100;
                            light = new Vector3(100 * (float)Math.Sin(time), 100 * (float)Math.Cos(time), zTrackBar.Value);
                        }
                    }));

                    //pictureBox1.Invalidate();
                }
            });
            //new Task(() => MainLoop()).Start();
        }
        public void MainLoop()
        {
            while (true)
            {
                pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.ScaleTransform(1, -1);
            g.TranslateTransform(pictureBox1.Width / 2, -pictureBox1.Height / 2);

            Bitmap BM = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            mesh.Draw(BM, e, mTrackBar.Value, (float)kdTrackBar.Value / 10, (float)ksTrackBar.Value / 10,
                lightcolor, objectcolor, light, IsOnlyMesh, IsOnlyFill, IsTexture, Texture);
            e.Graphics.DrawImage(BM, -250, -250);
        }

        private void alphaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            mesh.Rotate(alphaTrackBar.Value, betaTrackBar.Value);
            //mesh.CalculateTriangles(triangleTrackBar.Value);
        }

        private void betaTrackBar_ValueChanged(object sender, EventArgs e)
        {
            mesh.Rotate(alphaTrackBar.Value, betaTrackBar.Value);
            //mesh.CalculateTriangles(triangleTrackBar.Value);
        }

        private void triangleTrackBar_ValueChanged(object sender, EventArgs e)
        {
            mesh.CalculateTriangles(triangleTrackBar.Value);
            mesh.Rotate(alphaTrackBar.Value, betaTrackBar.Value);
        }

        private void objectColorButton_Click(object sender, EventArgs e)
        {
            //ColorDialog MyDialog = new ColorDialog();
            colorDialog.Color = objectcolor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                objectcolor = colorDialog.Color;
                objectPictureBox.BackColor = objectcolor;
            }
        }

        private void lightColorButton_Click(object sender, EventArgs e)
        {
            colorDialog.Color = lightcolor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lightcolor = colorDialog.Color;
                lightPictureBox.BackColor = lightcolor;
            }
        }

        private void meshCheckbox_Click(object sender, EventArgs e)
        {
            IsOnlyMesh = meshCheckbox.Checked;
            fillingCheckbox.Checked = false;
            IsOnlyFill = false;
        }

        private void fillingCheckbox_Click(object sender, EventArgs e)
        {
            IsOnlyFill = fillingCheckbox.Checked;
            meshCheckbox.Checked = false;
            IsOnlyMesh = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (IsAnimated)
            {
                stopButton.Text = "Resume";
                IsAnimated = false;
            }
            else
            {
                stopButton.Text = "Stop the light";
                IsAnimated = true;
            }
        }

        private void textureRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            IsTexture = textureRadioButton.Checked;
        }
    }
}
