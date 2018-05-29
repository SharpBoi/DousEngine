namespace DousEngine
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
            this.myViewport1 = new DousEngine.Other.MyViewport();
            this.lFPS = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // myViewport1
            // 
            this.myViewport1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myViewport1.BackColor = System.Drawing.Color.White;
            this.myViewport1.Location = new System.Drawing.Point(12, 25);
            this.myViewport1.Name = "myViewport1";
            this.myViewport1.Size = new System.Drawing.Size(776, 413);
            this.myViewport1.TabIndex = 0;
            // 
            // lFPS
            // 
            this.lFPS.AutoSize = true;
            this.lFPS.Location = new System.Drawing.Point(12, 9);
            this.lFPS.Name = "lFPS";
            this.lFPS.Size = new System.Drawing.Size(36, 13);
            this.lFPS.TabIndex = 1;
            this.lFPS.Text = "FPS 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lFPS);
            this.Controls.Add(this.myViewport1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Other.MyViewport myViewport1;
        private System.Windows.Forms.Label lFPS;
    }
}

