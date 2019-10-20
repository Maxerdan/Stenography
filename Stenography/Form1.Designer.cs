namespace Stenography
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textToCode = new System.Windows.Forms.TextBox();
            this.choosePic = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(384, 277);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textToCode
            // 
            this.textToCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textToCode.Location = new System.Drawing.Point(402, 12);
            this.textToCode.Multiline = true;
            this.textToCode.Name = "textToCode";
            this.textToCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textToCode.Size = new System.Drawing.Size(386, 277);
            this.textToCode.TabIndex = 1;
            // 
            // choosePic
            // 
            this.choosePic.Location = new System.Drawing.Point(12, 295);
            this.choosePic.Name = "choosePic";
            this.choosePic.Size = new System.Drawing.Size(90, 36);
            this.choosePic.TabIndex = 2;
            this.choosePic.Text = "Выбрать изображение";
            this.choosePic.UseVisualStyleBackColor = true;
            this.choosePic.Click += new System.EventHandler(this.choosePic_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(693, 295);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(95, 36);
            this.buttonDecode.TabIndex = 3;
            this.buttonDecode.Text = "Декодировать";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // buttonCode
            // 
            this.buttonCode.Location = new System.Drawing.Point(402, 295);
            this.buttonCode.Name = "buttonCode";
            this.buttonCode.Size = new System.Drawing.Size(95, 36);
            this.buttonCode.TabIndex = 4;
            this.buttonCode.Text = "Закодировать";
            this.buttonCode.UseVisualStyleBackColor = true;
            this.buttonCode.Click += new System.EventHandler(this.buttonCode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonCode);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.choosePic);
            this.Controls.Add(this.textToCode);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Stenography";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textToCode;
        private System.Windows.Forms.Button choosePic;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonCode;
    }
}

