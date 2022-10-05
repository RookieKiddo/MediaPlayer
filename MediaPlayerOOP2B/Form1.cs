using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MediaPlayerOOP2B
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string A, string B, int C, int D);
        string F;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile("Media//bg1.jpg");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                btnBrowse_Click(null, null);
            }
            F = "open "+txtSearch.Text+" type MPEGVideo alias ABC";
            mciSendString(F, null, 0, 0);
            if (btnAction.Text.Equals("Play"))
            {
                mciSendString("play ABC", null, 0, 0);
                btnAction.Text = "Pause";
                btnAction.Image = Image.FromFile("Media//Pause.png");
                pictureBox1.Image = Image.FromFile("Media//waves.gif");
            }
            else
            {
                mciSendString("pause ABC", null, 0, 0);
                btnAction.Text = "Play";
                btnAction.Image = Image.FromFile("Media//Play.png");
                pictureBox1.Image = Image.FromFile("Media//bg1.jpg");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            mciSendString("close ABC", null, 0, 0);
            btnAction.Text = "Play";
            btnAction.Image = Image.FromFile("Media//Play.png");
            pictureBox1.Image = Image.FromFile("Media//bg1.jpg");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = "F:/AudioNaats/";
            DialogResult DR = OFD.ShowDialog();
            if (DR == DialogResult.OK)
            {
                txtSearch.Text = OFD.FileName;
            }
        }
    }
}
