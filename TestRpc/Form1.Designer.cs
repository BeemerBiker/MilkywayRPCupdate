namespace TestRpc
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.TBoxOutput = new System.Windows.Forms.TextBox();
            this.MWTimer = new System.Windows.Forms.Timer(this.components);
            this.pBarTimer = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TBoxOutput
            // 
            this.TBoxOutput.Location = new System.Drawing.Point(42, 175);
            this.TBoxOutput.Multiline = true;
            this.TBoxOutput.Name = "TBoxOutput";
            this.TBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TBoxOutput.Size = new System.Drawing.Size(355, 230);
            this.TBoxOutput.TabIndex = 1;
            // 
            // MWTimer
            // 
            this.MWTimer.Interval = 1000;
            this.MWTimer.Tick += new System.EventHandler(this.MWTimer_Tick);
            // 
            // pBarTimer
            // 
            this.pBarTimer.Location = new System.Drawing.Point(42, 110);
            this.pBarTimer.Maximum = 119;
            this.pBarTimer.Name = "pBarTimer";
            this.pBarTimer.Size = new System.Drawing.Size(355, 23);
            this.pBarTimer.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 450);
            this.Controls.Add(this.pBarTimer);
            this.Controls.Add(this.TBoxOutput);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TBoxOutput;
        private System.Windows.Forms.Timer MWTimer;
        private System.Windows.Forms.ProgressBar pBarTimer;
    }
}

