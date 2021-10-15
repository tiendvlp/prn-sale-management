
namespace Desktop.Orders
{
    partial class FormOrders
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStripMember = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAdmin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimeToPicker = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFromPicker = new System.Windows.Forms.DateTimePicker();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreateStatistic = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lvOrders = new System.Windows.Forms.ListView();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblTotalEarn = new System.Windows.Forms.Label();
            this.menuStripMember.SuspendLayout();
            this.menuStripAdmin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMember
            // 
            this.menuStripMember.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buyToolStripMenuItem});
            this.menuStripMember.Name = "menuStripMember";
            this.menuStripMember.Size = new System.Drawing.Size(95, 26);
            // 
            // buyToolStripMenuItem
            // 
            this.buyToolStripMenuItem.Name = "buyToolStripMenuItem";
            this.buyToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.buyToolStripMenuItem.Text = "Buy";
            // 
            // menuStripAdmin
            // 
            this.menuStripAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.menuStripAdmin.Name = "menuStripAdmin";
            this.menuStripAdmin.Size = new System.Drawing.Size(113, 48);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvOrders, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.26732F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.73267F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 395);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTotalEarn);
            this.panel1.Controls.Add(this.lblTotalSales);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimeToPicker);
            this.panel1.Controls.Add(this.dateTimeFromPicker);
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.btnCreateStatistic);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 153);
            this.panel1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(317, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Totals earns:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(317, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total sales:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "To:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "From:";
            // 
            // dateTimeToPicker
            // 
            this.dateTimeToPicker.Location = new System.Drawing.Point(73, 62);
            this.dateTimeToPicker.Name = "dateTimeToPicker";
            this.dateTimeToPicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimeToPicker.TabIndex = 5;
            // 
            // dateTimeFromPicker
            // 
            this.dateTimeFromPicker.Location = new System.Drawing.Point(73, 27);
            this.dateTimeFromPicker.Name = "dateTimeFromPicker";
            this.dateTimeFromPicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimeFromPicker.TabIndex = 4;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(641, 72);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(98, 36);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreateStatistic
            // 
            this.btnCreateStatistic.Location = new System.Drawing.Point(123, 108);
            this.btnCreateStatistic.Name = "btnCreateStatistic";
            this.btnCreateStatistic.Size = new System.Drawing.Size(97, 26);
            this.btnCreateStatistic.TabIndex = 2;
            this.btnCreateStatistic.Text = "Create statistic";
            this.btnCreateStatistic.UseVisualStyleBackColor = true;
            this.btnCreateStatistic.Click += new System.EventHandler(this.btnCreateStatistic_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(641, 14);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 36);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lvOrders
            // 
            this.lvOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOrders.HideSelection = false;
            this.lvOrders.Location = new System.Drawing.Point(3, 162);
            this.lvOrders.Name = "lvOrders";
            this.lvOrders.Size = new System.Drawing.Size(763, 230);
            this.lvOrders.TabIndex = 3;
            this.lvOrders.UseCompatibleStateImageBehavior = false;
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSales.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalSales.Location = new System.Drawing.Point(398, 22);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(57, 21);
            this.lblTotalSales.TabIndex = 10;
            this.lblTotalSales.Text = "label5";
            // 
            // lblTotalEarn
            // 
            this.lblTotalEarn.AutoSize = true;
            this.lblTotalEarn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalEarn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTotalEarn.Location = new System.Drawing.Point(398, 57);
            this.lblTotalEarn.Name = "lblTotalEarn";
            this.lblTotalEarn.Size = new System.Drawing.Size(57, 21);
            this.lblTotalEarn.TabIndex = 11;
            this.lblTotalEarn.Text = "label5";
            // 
            // FormOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 395);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormOrders";
            this.menuStripMember.ResumeLayout(false);
            this.menuStripAdmin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip menuStripMember;
        private System.Windows.Forms.ToolStripMenuItem buyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCreateStatistic;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimeToPicker;
        private System.Windows.Forms.DateTimePicker dateTimeFromPicker;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListView lvOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalEarn;
        private System.Windows.Forms.Label lblTotalSales;
    }
}
