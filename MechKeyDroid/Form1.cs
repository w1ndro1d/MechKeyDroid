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
        int keyPressed;
        string normalPath;
        string spacePath;
        bool trayNotifShown = false;
        
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
                        //checking for i!=keyPressed ensures that sound will not repeat when holding down a key
                        //but this brings another undesired consequence i.e no sound is produced when the same key is pressed more than once consecutively
                        //so we deal with this using else if below
                        if (keyState == -32767 && i != keyPressed)
                        {
                            keyPressed = i;
                            
                            //separate sound for Tab, CapsLock, LShift, RShift, Space, Backspace, Enter
                            if (i == 9 || i == 20 || i == 160 || i == 161 || i == 32 || i == 8 || i == 13 || i == 16)
                            {
                                
                                var wavReader = new WaveFileReader(spacePath);
                                var wavOut = new WaveOut();
                                wavOut.Volume = (float)volumeMultiplier;
                                wavOut.Init(wavReader);
                                wavOut.Play();
                                
                                
                            }
                            //for all keys except those above
                            else
                            {         
                                
                                var wavReader = new WaveFileReader(normalPath);
                                var wavOut = new WaveOut();
                                wavOut.Volume = (float)volumeMultiplier;
                                wavOut.Init(wavReader);
                                wavOut.Play();

                            }
                                                                            
                        }
                        //check for key release. keyState becomes positive when key is released
                        //if key pressed now is the same key that was just pressed set flag to 0(reset the flag). this ensures audio is played even in consecutive presses of same key
                        else if(keyState >=0 && i==keyPressed)
                        {
                            keyPressed = 0;
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
                    volumeMultiplier = 0.1;
                    break;
                case 2:
                    volumeMultiplier = 0.2;
                    break;
                case 3:
                    volumeMultiplier = 0.3;
                    break;
                case 4:
                    volumeMultiplier = 0.4;
                    break;
                case 5:
                    volumeMultiplier = 0.5;
                    break;
                case 6:
                    volumeMultiplier = 0.6;
                    break;
                case 7:
                    volumeMultiplier = 0.7;
                    break;
                case 8:
                    volumeMultiplier = 0.8;
                    break;
                case 9:
                    volumeMultiplier = 0.9;
                    break;
                case 10:
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
            if (WindowState == FormWindowState.Minimized && trayNotifShown == false)
            {
                this.Hide();
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000);
                trayNotifShown = true;
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon.Visible = false;
            }
            else if(WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon.Visible = true;
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

        private void selectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(selectComboBox.SelectedIndex == 0)//default option
            {
                normalPath = "Resources/default_everything.wav";
                spacePath = "Resources/default_space.wav";
            }
            else if(selectComboBox.SelectedIndex == 1)//thock option
            {
                normalPath = "Resources/thock_everything.wav";
                spacePath = "Resources/thock_space.wav";
            }
        }
    }
    
}
