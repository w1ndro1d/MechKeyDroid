using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using NAudio.Wave;

namespace MechKeyDroid
{
    public partial class Form1 : Form
    {
        double volumeMultiplier = 0.25;

        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Int32 virtualKey);

        public Form1()
        {
            InitializeComponent();
            selectComboBox.SelectedIndex = 0; //set Default on startup
                        
            
        }

        private void handleKeyPress()
        {
            while (true)
            {
                if (!backgroundWorker.CancellationPending)
                {
                    
                    Thread.Sleep(5);
                    for (int i = 8; i < 255; i++) //start from i=0 for mouse clicks as well
                    {
                        int keyState = GetAsyncKeyState(i);
                        if (keyState == -32767)
                        {
                            //Invoke(new Action(() =>
                            //{
                            //    keysListView.Items.Add(((char)i).ToString());
                            //}));

                            var wavReader = new WaveFileReader("C:\\Users\\WINDROID\\Desktop\\audio_key_thock.wav");
                            var wavOut = new WaveOut();
                            wavOut.Volume = (float)volumeMultiplier;
                            wavOut.Init(wavReader);
                            wavOut.Play();
                                                        

                        }
                    }
                }

            }

        }


        private void initButton_Click(object sender, EventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
            initButton.Enabled = false;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
            notifyIcon.BalloonTipText = "Application has been minimized to tray. Click on the icon for more options.";
            notifyIcon.Text = "MechKeyDroid";

            this.Icon= new System.Drawing.Icon("Resources/mechkeydroid_icon.ico");
            notifyIcon.Icon = new System.Drawing.Icon("Resources/mechkeydroid_icon.ico");
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            handleKeyPress();
        }

        private void volumeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            volumeLabel.Text = volumeTrackBar.Value.ToString();
            switch (volumeTrackBar.Value)
            {
                case 0:
                    volumeMultiplier = 0;
                    break;
                case 1:
                    volumeMultiplier = 0.25;
                    break;
                case 2:
                    volumeMultiplier = 0.5;
                    break;
                case 3:
                    volumeMultiplier = 0.75;
                    break;
                case 4:
                    volumeMultiplier = 1;
                    break;
            }
            
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon.Visible = true;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }
    }
    
}
