﻿namespace FlowerShopView
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
            this.складыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнениеСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокБукетовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыПоБукетамToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.списокЗаказовToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.таблицаСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.компонентыНаСкладахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.buttonTakeOrderInWork = new System.Windows.Forms.Button();
            this.buttonOrderReady = new System.Windows.Forms.Button();
            this.buttonIssuedOrder = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.заказыПоДатамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнениеСкладовToolStripMenuItem,
            this.отчётыToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1076, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.компонентыToolStripMenuItem,
            this.букетыToolStripMenuItem,
            this.складыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // компонентыToolStripMenuItem
            // 
            this.компонентыToolStripMenuItem.Name = "компонентыToolStripMenuItem";
            this.компонентыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.компонентыToolStripMenuItem.Text = "Компоненты";
            this.компонентыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // букетыToolStripMenuItem
            // 
            this.букетыToolStripMenuItem.Name = "букетыToolStripMenuItem";
            this.букетыToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.букетыToolStripMenuItem.Text = "Букеты";
            this.букетыToolStripMenuItem.Click += new System.EventHandler(this.букетыToolStripMenuItem_Click);
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
            // отчётыToolStripMenuItem1
            // 
            this.отчётыToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.списокБукетовToolStripMenuItem1,
            this.компонентыПоБукетамToolStripMenuItem1,
            this.списокЗаказовToolStripMenuItem1,
            this.таблицаСкладовToolStripMenuItem,
            this.компонентыНаСкладахToolStripMenuItem,
            this.заказыПоДатамToolStripMenuItem});
            this.отчётыToolStripMenuItem1.Name = "отчётыToolStripMenuItem1";
            this.отчётыToolStripMenuItem1.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem1.Text = "Отчёты";
            // 
            // списокБукетовToolStripMenuItem1
            // 
            this.списокБукетовToolStripMenuItem1.Name = "списокБукетовToolStripMenuItem1";
            this.списокБукетовToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.списокБукетовToolStripMenuItem1.Text = "Список букетов";
            this.списокБукетовToolStripMenuItem1.Click += new System.EventHandler(this.списокБукетовToolStripMenuItem1_Click);
            // 
            // компонентыПоБукетамToolStripMenuItem1
            // 
            this.компонентыПоБукетамToolStripMenuItem1.Name = "компонентыПоБукетамToolStripMenuItem1";
            this.компонентыПоБукетамToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.компонентыПоБукетамToolStripMenuItem1.Text = "Компоненты по букетам";
            this.компонентыПоБукетамToolStripMenuItem1.Click += new System.EventHandler(this.компонентыПоБукетамToolStripMenuItem1_Click);
            // 
            // списокЗаказовToolStripMenuItem1
            // 
            this.списокЗаказовToolStripMenuItem1.Name = "списокЗаказовToolStripMenuItem1";
            this.списокЗаказовToolStripMenuItem1.Size = new System.Drawing.Size(210, 22);
            this.списокЗаказовToolStripMenuItem1.Text = "Список заказов";
            this.списокЗаказовToolStripMenuItem1.Click += new System.EventHandler(this.списокЗаказовToolStripMenuItem1_Click);
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
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(819, 411);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(871, 70);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(180, 33);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // buttonTakeOrderInWork
            // 
            this.buttonTakeOrderInWork.Location = new System.Drawing.Point(871, 119);
            this.buttonTakeOrderInWork.Name = "buttonTakeOrderInWork";
            this.buttonTakeOrderInWork.Size = new System.Drawing.Size(180, 33);
            this.buttonTakeOrderInWork.TabIndex = 3;
            this.buttonTakeOrderInWork.Text = "Отдать на выполнение";
            this.buttonTakeOrderInWork.UseVisualStyleBackColor = true;
            this.buttonTakeOrderInWork.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // buttonOrderReady
            // 
            this.buttonOrderReady.Location = new System.Drawing.Point(871, 170);
            this.buttonOrderReady.Name = "buttonOrderReady";
            this.buttonOrderReady.Size = new System.Drawing.Size(180, 33);
            this.buttonOrderReady.TabIndex = 4;
            this.buttonOrderReady.Text = "Заказ готов";
            this.buttonOrderReady.UseVisualStyleBackColor = true;
            this.buttonOrderReady.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // buttonIssuedOrder
            // 
            this.buttonIssuedOrder.Location = new System.Drawing.Point(871, 222);
            this.buttonIssuedOrder.Name = "buttonIssuedOrder";
            this.buttonIssuedOrder.Size = new System.Drawing.Size(180, 33);
            this.buttonIssuedOrder.TabIndex = 5;
            this.buttonIssuedOrder.Text = "Заказ выдан";
            this.buttonIssuedOrder.UseVisualStyleBackColor = true;
            this.buttonIssuedOrder.Click += new System.EventHandler(this.buttonIssuedOrder_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(871, 274);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(180, 33);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
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
            this.ClientSize = new System.Drawing.Size(1076, 450);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonIssuedOrder);
            this.Controls.Add(this.buttonOrderReady);
            this.Controls.Add(this.buttonTakeOrderInWork);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
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
        private DataGridView dataGridView;
        private Button buttonCreateOrder;
        private Button buttonTakeOrderInWork;
        private Button buttonOrderReady;
        private Button buttonIssuedOrder;
        private Button buttonRef;
        private ToolStripMenuItem отчётыToolStripMenuItem1;
        private ToolStripMenuItem списокБукетовToolStripMenuItem1;
        private ToolStripMenuItem компонентыПоБукетамToolStripMenuItem1;
        private ToolStripMenuItem списокЗаказовToolStripMenuItem1;
        private ToolStripMenuItem таблицаСкладовToolStripMenuItem;
        private ToolStripMenuItem компонентыНаСкладахToolStripMenuItem;
        private ToolStripMenuItem заказыПоДатамToolStripMenuItem;
    }
}