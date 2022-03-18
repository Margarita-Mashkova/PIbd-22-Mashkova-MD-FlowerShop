namespace FlowerShopView
{
    partial class FormStorehouseComponent
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
            this.labelStorehouse = new System.Windows.Forms.Label();
            this.labelComponent = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxStorehouse = new System.Windows.Forms.ComboBox();
            this.comboBoxComponent = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStorehouse
            // 
            this.labelStorehouse.AutoSize = true;
            this.labelStorehouse.Location = new System.Drawing.Point(21, 20);
            this.labelStorehouse.Name = "labelStorehouse";
            this.labelStorehouse.Size = new System.Drawing.Size(43, 15);
            this.labelStorehouse.TabIndex = 0;
            this.labelStorehouse.Text = "Склад:";
            // 
            // labelComponent
            // 
            this.labelComponent.AutoSize = true;
            this.labelComponent.Location = new System.Drawing.Point(21, 59);
            this.labelComponent.Name = "labelComponent";
            this.labelComponent.Size = new System.Drawing.Size(72, 15);
            this.labelComponent.TabIndex = 1;
            this.labelComponent.Text = "Компонент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(21, 99);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(112, 96);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(243, 23);
            this.textBoxCount.TabIndex = 3;
            // 
            // comboBoxStorehouse
            // 
            this.comboBoxStorehouse.FormattingEnabled = true;
            this.comboBoxStorehouse.Location = new System.Drawing.Point(112, 17);
            this.comboBoxStorehouse.Name = "comboBoxStorehouse";
            this.comboBoxStorehouse.Size = new System.Drawing.Size(243, 23);
            this.comboBoxStorehouse.TabIndex = 4;
            // 
            // comboBoxComponent
            // 
            this.comboBoxComponent.FormattingEnabled = true;
            this.comboBoxComponent.Location = new System.Drawing.Point(112, 56);
            this.comboBoxComponent.Name = "comboBoxComponent";
            this.comboBoxComponent.Size = new System.Drawing.Size(243, 23);
            this.comboBoxComponent.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(112, 140);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(108, 34);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(247, 140);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(108, 34);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormStorehouseComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 186);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxComponent);
            this.Controls.Add(this.comboBoxStorehouse);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComponent);
            this.Controls.Add(this.labelStorehouse);
            this.Name = "FormStorehouseComponent";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormStorehouseComponent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelStorehouse;
        private Label labelComponent;
        private Label labelCount;
        private TextBox textBoxCount;
        private ComboBox comboBoxStorehouse;
        private ComboBox comboBoxComponent;
        private Button buttonSave;
        private Button buttonCancel;
    }
}