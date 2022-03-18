namespace FlowerShopView
{
    partial class FormStorehouse
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelFIO = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxFIO = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(23, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(62, 15);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(23, 51);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(125, 15);
            this.labelFIO.TabIndex = 1;
            this.labelFIO.Text = "ФИО ответственного:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(161, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(317, 23);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxFIO
            // 
            this.textBoxFIO.Location = new System.Drawing.Point(161, 48);
            this.textBoxFIO.Name = "textBoxFIO";
            this.textBoxFIO.Size = new System.Drawing.Size(317, 23);
            this.textBoxFIO.TabIndex = 3;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnComponent,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(23, 96);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(583, 314);
            this.dataGridView.TabIndex = 4;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "Id склада";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.Visible = false;
            // 
            // ColumnComponent
            // 
            this.ColumnComponent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComponent.HeaderText = "Компонент";
            this.ColumnComponent.Name = "ColumnComponent";
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(371, 424);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 36);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(499, 424);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 36);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormStorehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 472);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.textBoxFIO);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelFIO);
            this.Controls.Add(this.labelName);
            this.Name = "FormStorehouse";
            this.Text = "Склад";
            this.Load += new System.EventHandler(this.FormStorehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelName;
        private Label labelFIO;
        private TextBox textBoxName;
        private TextBox textBoxFIO;
        private DataGridView dataGridView;
        private Button buttonSave;
        private Button buttonCancel;
        private DataGridViewTextBoxColumn ColumnID;
        private DataGridViewTextBoxColumn ColumnComponent;
        private DataGridViewTextBoxColumn ColumnCount;
    }
}