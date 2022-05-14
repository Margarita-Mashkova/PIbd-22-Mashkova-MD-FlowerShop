namespace FlowerShopView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.букетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.клиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исполнителиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокБукетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоБукетамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыНаСкладахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.заказыПоДатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вывестиПисьмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнениеСкладовToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.вывестиПисьмаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1471, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.букетыToolStripMenuItem,
            this.складыToolStripMenuItem,
            this.клиентыToolStripMenuItem,
            this.исполнителиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // букетыToolStripMenuItem
            // 
            this.букетыToolStripMenuItem.Name = "букетыToolStripMenuItem";
            this.букетыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.букетыToolStripMenuItem.Text = "Букеты";
            this.букетыToolStripMenuItem.Click += new System.EventHandler(this.букетыToolStripMenuItem_Click);
            // 
            // клиентыToolStripMenuItem
            // 
            this.клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            this.клиентыToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.клиентыToolStripMenuItem.Text = "Клиенты";
            this.клиентыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // исполнителиToolStripMenuItem
            // 
            this.исполнителиToolStripMenuItem.Name = "исполнителиToolStripMenuItem";
            this.исполнителиToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.исполнителиToolStripMenuItem.Text = "Исполнители";
            this.исполнителиToolStripMenuItem.Click += new System.EventHandler(this.исполнителиToolStripMenuItem_Click);
            // 
            // складыToolStripMenuItem
            // 
            this.складыToolStripMenuItem.Name = "складыToolStripMenuItem";
            this.складыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.складыToolStripMenuItem.Text = "Склады";
            this.складыToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click_1);
            // 
            // пополнениеСкладовToolStripMenuItem
            // 
            this.пополнениеСкладовToolStripMenuItem.Name = "пополнениеСкладовToolStripMenuItem";
            this.пополнениеСкладовToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.пополнениеСкладовToolStripMenuItem.Text = "Пополнение складов";
            this.пополнениеСкладовToolStripMenuItem.Click += new System.EventHandler(this.пополнениеСкладовToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокБукетовToolStripMenuItem,
            this.компонентыПоБукетамToolStripMenuItem,
            this.списокЗаказовToolStripMenuItem,
            this.таблицаСкладовToolStripMenuItem,
            this.компонентыНаСкладахToolStripMenuItem,
            this.заказыПоДатамToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem1";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // списокБукетовToolStripMenuItem
            // 
            this.списокБукетовToolStripMenuItem.Name = "списокБукетовToolStripMenuItem1";
            this.списокБукетовToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.списокБукетовToolStripMenuItem.Text = "Список букетов";
            this.списокБукетовToolStripMenuItem.Click += new System.EventHandler(this.списокБукетовToolStripMenuItem1_Click);
            // 
            // компонентыПоБукетамToolStripMenuItem
            // 
            this.компонентыПоБукетамToolStripMenuItem.Name = "компонентыПоБукетамToolStripMenuItem1";
            this.компонентыПоБукетамToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.компонентыПоБукетамToolStripMenuItem.Text = "Компоненты по букетам";
            this.компонентыПоБукетамToolStripMenuItem.Click += new System.EventHandler(this.компонентыПоБукетамToolStripMenuItem1_Click);
            // 
            // списокЗаказовToolStripMenuItem
            // 
            this.списокЗаказовToolStripMenuItem.Name = "списокЗаказовToolStripMenuItem1";
            this.списокЗаказовToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.списокЗаказовToolStripMenuItem.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem1_Click);
            // 
            // таблицаСкладовToolStripMenuItem
            // 
            this.таблицаСкладовToolStripMenuItem.Name = "таблицаСкладовToolStripMenuItem";
            this.таблицаСкладовToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.таблицаСкладовToolStripMenuItem.Text = "Таблица складов";
            this.таблицаСкладовToolStripMenuItem.Click += new System.EventHandler(this.таблицаСкладовToolStripMenuItem_Click);
            // 
            // компонентыНаСкладахToolStripMenuItem
            // 
            this.компонентыНаСкладахToolStripMenuItem.Name = "компонентыНаСкладахToolStripMenuItem";
            this.компонентыНаСкладахToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.компонентыНаСкладахToolStripMenuItem.Text = "Компоненты на складах";
            this.компонентыНаСкладахToolStripMenuItem.Click += new System.EventHandler(this.компонентыНаСкладахToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(1215, 411);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(1264, 63);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(180, 33);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(1264, 116);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(180, 33);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(1264, 168);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(180, 33);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // вывестиПисьмаToolStripMenuItem
            // 
            this.вывестиПисьмаToolStripMenuItem.Name = "вывестиПисьмаToolStripMenuItem";
            this.вывестиПисьмаToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.вывестиПисьмаToolStripMenuItem.Text = "Письма";
            this.вывестиПисьмаToolStripMenuItem.Click += new System.EventHandler(this.вывестиПисьмаToolStripMenuItem_Click);
            // 
            // заказыПоДатамToolStripMenuItem
            // 
            this.заказыПоДатамToolStripMenuItem.Name = "заказыПоДатамToolStripMenuItem";
            this.заказыПоДатамToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.заказыПоДатамToolStripMenuItem.Text = "Заказы по датам";
            this.заказыПоДатамToolStripMenuItem.Click += new System.EventHandler(this.заказыПоДатамToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1471, 450);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Цветочная лавка";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem справочникиToolStripMenuItem;
        private ToolStripMenuItem компонентыToolStripMenuItem;
        private ToolStripMenuItem букетыToolStripMenuItem;
        private ToolStripMenuItem складыToolStripMenuItem;
        private ToolStripMenuItem пополнениеСкладовToolStripMenuItem;
        private ToolStripMenuItem клиентыToolStripMenuItem;
        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonIssuedOrder;
        private Button buttonRef;
        private ToolStripMenuItem отчётыToolStripMenuItem;
        private ToolStripMenuItem списокБукетовToolStripMenuItem;
        private ToolStripMenuItem компонентыПоБукетамToolStripMenuItem;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem;
        private ToolStripMenuItem исполнителиToolStripMenuItem;
        private ToolStripMenuItem запускРаботToolStripMenuItem;
        private ToolStripMenuItem заказыПоДатамToolStripMenuItem;
        private ToolStripMenuItem компонентыНаСкладахToolStripMenuItem;
        private ToolStripMenuItem таблицаСкладовToolStripMenuItem;
        private ToolStripMenuItem вывестиПисьмаToolStripMenuItem;
    }
}
