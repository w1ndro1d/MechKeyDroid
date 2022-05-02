using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using NAudio.Wave;


namespace MechKeyDroid
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        double volumeMultiplier = 0.4;
        int keyPressed;
        int j=8;
        int selectedOption;
        string normalPath;
        string aPath, bPath, cPath, dPath, ePath, fPath, gPath, hPath, iPath, jPath, kPath, lPath, mPath, nPath, oPath, pPath, qPath, rPath, sPath, tPath, uPath, vPath, wPath, xPath, yPath, zPath, tabPath, capsPath, enterPath, backspacePath;

        private void mouseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(mouseCheckBox.Checked)
            {
                j = 0;
            }
            else
            {
                j = 8;
            }
        }

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
                    
                    for (int i = j; i < 255; i++) //start from i=0 for mouse clicks as well
                    {
                        
                        int keyState = GetAsyncKeyState(i);
                        //checking for i!=keyPressed ensures that sound will not repeat when holding down a key
                        //but this brings another undesired consequence i.e no sound is produced when the same key is pressed more than once consecutively
                        //so we deal with this using else if below
                        if (keyState == -32767 && i != keyPressed)
                        {
                            keyPressed = i;



                            //two conditions for default sound
                            if (selectedOption == 0)
                            {
                                //separate sound for Tab, CapsLock, Space, Backspace, Enter
                                if (i == 9 || i == 20 || i == 32 || i == 8 || i == 13)
                                {
                                    playSound(spacePath);

                                }
                                //dont play sound for shift, control, alt
                                else if (i == 16 || i == 17 || i == 18 || i == 160 || i == 161 || i == 162 || i == 163 || i == 164 || i == 165)
                                {
                                    break;
                                }
                                //for all keys except those above
                                else
                                {
                                    playSound(normalPath);

                                }
                            }
                            //conditions for nk-cream
                            else if (selectedOption == 1)
                            {
                                switch(i)
                                {
                                    case 65:
                                        playSound(aPath);
                                        break;
                                    case 66:
                                        playSound(bPath);
                                        break;
                                    case 67:
                                        playSound(cPath);
                                        break;
                                    case 68:
                                        playSound(dPath);
                                        break;
                                    case 69:
                                        playSound(ePath);
                                        break;
                                    case 70:
                                        playSound(fPath);
                                        break;
                                    case 71:
                                        playSound(gPath);
                                        break;
                                    case 72:
                                        playSound(hPath);
                                        break;
                                    case 73:
                                        playSound(iPath);
                                        break;
                                    case 74:
                                        playSound(jPath);
                                        break;
                                    case 75:
                                        playSound(kPath);
                                        break;
                                    case 76:
                                        playSound(lPath);
                                        break;
                                    case 77:
                                        playSound(mPath);
                                        break;
                                    case 78:
                                        playSound(nPath);
                                        break;
                                    case 79:
                                        playSound(oPath);
                                        break;
                                    case 80:
                                        playSound(pPath);
                                        break;
                                    case 81:
                                        playSound(qPath);
                                        break;
                                    case 82:
                                        playSound(rPath);
                                        break;
                                    case 83:
                                        playSound(sPath);
                                        break;
                                    case 84:
                                        playSound(tPath);
                                        break;
                                    case 85:
                                        playSound(uPath);
                                        break;
                                    case 86:
                                        playSound(vPath);
                                        break;
                                    case 87:
                                        playSound(wPath);
                                        break;
                                    case 88:
                                        playSound(xPath);
                                        break;
                                    case 89:
                                        playSound(yPath);
                                        break;
                                    case 90:
                                        playSound(zPath);
                                        break;
                                    //backspace
                                    case 8:
                                        playSound(backspacePath);
                                        break;
                                    //capslock
                                    case 20:
                                        playSound(capsPath);
                                        break;
                                    //enter
                                    case 13:
                                        playSound(enterPath);
                                        break;
                                    //space
                                    case 32:
                                        playSound(spacePath);
                                        break;
                                    //tab
                                    case 9:
                                        playSound(tabPath);
                                        break;
                                    //right mouse click
                                    case 2:
                                        playSound(fPath);
                                        break;
                                    //x2 mouse button
                                    case 6:
                                        playSound(aPath);
                                        break;

                                    //dont play sound for ctrl, shift and alt
                                    case 16:
                                        break;
                                    case 17:
                                        break;
                                    case 18:
                                        break;
                                    case 160:
                                        break;
                                    case 161:
                                        break;
                                    case 162:
                                        break;
                                    case 163:
                                        break;
                                    case 164:
                                        break;
                                    case 165:
                                        break;

                                    //any other key not specified above
                                    default:
                                        playSound(gPath);
                                        break;
                                }
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


        private void playSound(string keyPath)
        {
            var wavReader = new WaveFileReader(keyPath);
            var wavOut = new WaveOut();
            wavOut.Volume = (float)volumeMultiplier;
            wavOut.Init(wavReader);
            wavOut.Play();
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
                selectedOption = 0;
                normalPath = "Resources/default/default_everything.wav";
                spacePath = "Resources/default/default_space.wav";
            }
            else if(selectComboBox.SelectedIndex == 1)//nk cream option
            {
                selectedOption = 1;
                normalPath = "Resources/nk-cream/g.wav";
                aPath = "Resources/nk-cream/a.wav";
                bPath = "Resources/nk-cream/b.wav";
                cPath = "Resources/nk-cream/c.wav";
                dPath = "Resources/nk-cream/d.wav";
                ePath = "Resources/nk-cream/e.wav";
                fPath = "Resources/nk-cream/f.wav";
                gPath = "Resources/nk-cream/g.wav";
                hPath = "Resources/nk-cream/h.wav";
                iPath = "Resources/nk-cream/i.wav";
                jPath = "Resources/nk-cream/j.wav";
                kPath = "Resources/nk-cream/k.wav";
                lPath = "Resources/nk-cream/l.wav";
                mPath = "Resources/nk-cream/m.wav";
                nPath = "Resources/nk-cream/n.wav";
                oPath = "Resources/nk-cream/o.wav";
                pPath = "Resources/nk-cream/p.wav";
                qPath = "Resources/nk-cream/q.wav";
                rPath = "Resources/nk-cream/r.wav";
                sPath = "Resources/nk-cream/s.wav";
                tPath = "Resources/nk-cream/t.wav";
                uPath = "Resources/nk-cream/u.wav";
                vPath = "Resources/nk-cream/v.wav";
                wPath = "Resources/nk-cream/w.wav";
                xPath = "Resources/nk-cream/x.wav";
                yPath = "Resources/nk-cream/y.wav";
                zPath = "Resources/nk-cream/z.wav";
                tabPath = "Resources/nk-cream/tab.wav";
                capsPath = "Resources/nk-cream/caps.wav";
                enterPath = "Resources/nk-cream/enter.wav";
                backspacePath = "Resources/nk-cream/backspace.wav";
                spacePath = "Resources/nk-cream/space.wav";
            }
        }
    }
    
}
