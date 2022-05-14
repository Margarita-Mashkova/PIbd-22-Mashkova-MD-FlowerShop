namespace FlowerShopView
{
    partial class FormMessagesInfo
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.textBoxPageNumber = new System.Windows.Forms.TextBox();
            this.labelPageNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(1403, 134);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_CellMouseDoubleClick);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(1139, 165);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(122, 35);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(1284, 165);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(122, 35);
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "Вперёд";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // textBoxPageNumber
            // 
            this.textBoxPageNumber.Location = new System.Drawing.Point(1067, 172);
            this.textBoxPageNumber.Name = "textBoxPageNumber";
            this.textBoxPageNumber.Size = new System.Drawing.Size(60, 23);
            this.textBoxPageNumber.TabIndex = 4;
            this.textBoxPageNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxPageNumber.TextChanged += new System.EventHandler(this.textBoxPageNumber_TextChanged);
            // 
            // labelPageNumber
            // 
            this.labelPageNumber.AutoSize = true;
            this.labelPageNumber.Location = new System.Drawing.Point(998, 175);
            this.labelPageNumber.Name = "labelPageNumber";
            this.labelPageNumber.Size = new System.Drawing.Size(63, 15);
            this.labelPageNumber.TabIndex = 5;
            this.labelPageNumber.Text = "Страница:";
            // 
            // FormMessagesInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1427, 224);
            this.Controls.Add(this.labelPageNumber);
            this.Controls.Add(this.textBoxPageNumber);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormMessagesInfo";
            this.Text = "Письма";
            this.Load += new System.EventHandler(this.FormMessagesInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dataGridView;
        private Button buttonBack;
        private Button buttonNext;
        private TextBox textBoxPageNumber;
        private Label labelPageNumber;
    }
}