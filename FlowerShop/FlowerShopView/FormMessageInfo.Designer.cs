namespace FlowerShopView
{
    partial class FormMessageInfo
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
            this.textBoxReply = new System.Windows.Forms.TextBox();
            this.buttonReply = new System.Windows.Forms.Button();
            this.labelSenderName = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelDateDelivery = new System.Windows.Forms.Label();
            this.textBoxReplySubject = new System.Windows.Forms.TextBox();
            this.labelReplySubject = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxReply
            // 
            this.textBoxReply.Location = new System.Drawing.Point(12, 378);
            this.textBoxReply.Multiline = true;
            this.textBoxReply.Name = "textBoxReply";
            this.textBoxReply.Size = new System.Drawing.Size(776, 248);
            this.textBoxReply.TabIndex = 0;
            // 
            // buttonReply
            // 
            this.buttonReply.Location = new System.Drawing.Point(630, 638);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(141, 33);
            this.buttonReply.TabIndex = 1;
            this.buttonReply.Text = "Отправить ответ";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // labelSenderName
            // 
            this.labelSenderName.AutoSize = true;
            this.labelSenderName.Location = new System.Drawing.Point(28, 21);
            this.labelSenderName.Name = "labelSenderName";
            this.labelSenderName.Size = new System.Drawing.Size(78, 15);
            this.labelSenderName.TabIndex = 2;
            this.labelSenderName.Text = "Отправитель";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Location = new System.Drawing.Point(28, 55);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(65, 15);
            this.labelSubject.TabIndex = 3;
            this.labelSubject.Text = "Заголовок";
            // 
            // labelBody
            // 
            this.labelBody.AutoSize = true;
            this.labelBody.Location = new System.Drawing.Point(99, 123);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(36, 15);
            this.labelBody.TabIndex = 4;
            this.labelBody.Text = "Текст";
            // 
            // labelDateDelivery
            // 
            this.labelDateDelivery.AutoSize = true;
            this.labelDateDelivery.Location = new System.Drawing.Point(28, 87);
            this.labelDateDelivery.Name = "labelDateDelivery";
            this.labelDateDelivery.Size = new System.Drawing.Size(72, 15);
            this.labelDateDelivery.TabIndex = 5;
            this.labelDateDelivery.Text = "Доставлено";
            // 
            // textBoxReplySubject
            // 
            this.textBoxReplySubject.Location = new System.Drawing.Point(83, 338);
            this.textBoxReplySubject.Name = "textBoxReplySubject";
            this.textBoxReplySubject.Size = new System.Drawing.Size(634, 23);
            this.textBoxReplySubject.TabIndex = 6;
            // 
            // labelReplySubject
            // 
            this.labelReplySubject.AutoSize = true;
            this.labelReplySubject.Location = new System.Drawing.Point(12, 341);
            this.labelReplySubject.Name = "labelReplySubject";
            this.labelReplySubject.Size = new System.Drawing.Size(65, 15);
            this.labelReplySubject.TabIndex = 7;
            this.labelReplySubject.Text = "Заголовок";
            // 
            // FormMessageInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 683);
            this.Controls.Add(this.labelReplySubject);
            this.Controls.Add(this.textBoxReplySubject);
            this.Controls.Add(this.labelDateDelivery);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelSenderName);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.textBoxReply);
            this.Name = "FormMessageInfo";
            this.Text = "Письмо";
            this.Load += new System.EventHandler(this.FormMessageInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxReply;
        private Button buttonReply;
        private Label labelSenderName;
        private Label labelSubject;
        private Label labelBody;
        private Label labelDateDelivery;
        private TextBox textBoxReplySubject;
        private Label labelReplySubject;
    }
}