namespace Doodle_Jump
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.labelLose = new System.Windows.Forms.Label();
            this.buttonControl = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.Color.Transparent;
            this.buttonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Bauhaus 93", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(92)))), ((int)(((byte)(10)))));
            this.buttonStart.Location = new System.Drawing.Point(162, 283);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(121, 65);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Play";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.BackColor = System.Drawing.Color.Transparent;
            this.buttonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRestart.Font = new System.Drawing.Font("Bauhaus 93", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(92)))), ((int)(((byte)(10)))));
            this.buttonRestart.Location = new System.Drawing.Point(112, 413);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(219, 47);
            this.buttonRestart.TabIndex = 1;
            this.buttonRestart.Text = "Play again";
            this.buttonRestart.UseVisualStyleBackColor = false;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // labelLose
            // 
            this.labelLose.AutoSize = true;
            this.labelLose.BackColor = System.Drawing.Color.Transparent;
            this.labelLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelLose.Font = new System.Drawing.Font("Bauhaus 93", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(92)))), ((int)(((byte)(10)))));
            this.labelLose.Location = new System.Drawing.Point(103, 198);
            this.labelLose.Name = "labelLose";
            this.labelLose.Size = new System.Drawing.Size(234, 49);
            this.labelLose.TabIndex = 2;
            this.labelLose.Text = "You Lose :(";
            this.labelLose.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonControl
            // 
            this.buttonControl.BackColor = System.Drawing.Color.Transparent;
            this.buttonControl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonControl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonControl.Font = new System.Drawing.Font("Bauhaus 93", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonControl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(92)))), ((int)(((byte)(10)))));
            this.buttonControl.Location = new System.Drawing.Point(146, 392);
            this.buttonControl.Name = "buttonControl";
            this.buttonControl.Size = new System.Drawing.Size(148, 50);
            this.buttonControl.TabIndex = 3;
            this.buttonControl.Text = "Control";
            this.buttonControl.UseVisualStyleBackColor = false;
            this.buttonControl.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Transparent;
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Bauhaus 93", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(92)))), ((int)(((byte)(10)))));
            this.buttonExit.Location = new System.Drawing.Point(162, 526);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(98, 45);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelScore.Font = new System.Drawing.Font("Bauhaus 93", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(92)))), ((int)(((byte)(10)))));
            this.labelScore.Location = new System.Drawing.Point(105, 283);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(148, 39);
            this.labelScore.TabIndex = 5;
            this.labelScore.Text = "Score: 0";
            this.labelScore.Click += new System.EventHandler(this.labelScore_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(445, 693);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonControl);
            this.Controls.Add(this.labelLose);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonStart);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Label labelLose;
        private System.Windows.Forms.Button buttonControl;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelScore;
    }
}

