
namespace MechKeyDroid
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
            this.initButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.volumeTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.volumeLabel = new System.Windows.Forms.Label();
            this.selectComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // initButton
            // 
            this.initButton.Location = new System.Drawing.Point(100, 160);
            this.initButton.Name = "initButton";
            this.initButton.Size = new System.Drawing.Size(75, 32);
            this.initButton.TabIndex = 0;
            this.initButton.Text = "Initiate";
            this.initButton.UseVisualStyleBackColor = true;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // volumeTrackBar
            // 
            this.volumeTrackBar.Location = new System.Drawing.Point(6, 21);
            this.volumeTrackBar.Maximum = 4;
            this.volumeTrackBar.Name = "volumeTrackBar";
            this.volumeTrackBar.Size = new System.Drawing.Size(222, 45);
            this.volumeTrackBar.TabIndex = 1;
            this.volumeTrackBar.Value = 1;
            this.volumeTrackBar.ValueChanged += new System.EventHandler(this.volumeTrackBar_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.volumeLabel);
            this.groupBox1.Controls.Add(this.volumeTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Volume";
            // 
            // volumeLabel
            // 
            this.volumeLabel.AutoSize = true;
            this.volumeLabel.Location = new System.Drawing.Point(234, 21);
            this.volumeLabel.Name = "volumeLabel";
            this.volumeLabel.Size = new System.Drawing.Size(13, 15);
            this.volumeLabel.TabIndex = 2;
            this.volumeLabel.Text = "1";
            // 
            // selectComboBox
            // 
            this.selectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectComboBox.FormattingEnabled = true;
            this.selectComboBox.Items.AddRange(new object[] {
            "Default"});
            this.selectComboBox.Location = new System.Drawing.Point(6, 22);
            this.selectComboBox.Name = "selectComboBox";
            this.selectComboBox.Size = new System.Drawing.Size(241, 23);
            this.selectComboBox.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectComboBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 68);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferred Sound";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 200);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.initButton);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MechKeyDroid";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.volumeTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button initButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TrackBar volumeTrackBar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label volumeLabel;
        private System.Windows.Forms.ComboBox selectComboBox;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

