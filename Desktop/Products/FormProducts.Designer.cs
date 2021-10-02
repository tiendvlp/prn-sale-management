
namespace Desktop.Products
{
    partial class FormProducts
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
            this.lvProduct = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUnitFilter = new System.Windows.Forms.CheckBox();
            this.chkPriceFilter = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUnitMin = new System.Windows.Forms.TextBox();
            this.txtUnitMax = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPriceMin = new System.Windows.Forms.TextBox();
            this.txtPriceMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.menuStripMember.SuspendLayout();
            this.menuStripAdmin.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.buyToolStripMenuItem.Click += new System.EventHandler(this.OnMemberMenu_click);
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
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.OnAdminMenu_click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.OnAdminMenu_click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lvProduct, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.67327F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.32674F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(769, 395);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lvProduct
            // 
            this.lvProduct.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(3, 132);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(763, 260);
            this.lvProduct.TabIndex = 1;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvProducts_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkUnitFilter);
            this.panel1.Controls.Add(this.chkPriceFilter);
            this.panel1.Controls.Add(this.tableLayoutPanel3);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtProductId);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.btnFilter);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(763, 123);
            this.panel1.TabIndex = 2;
            // 
            // chkUnitFilter
            // 
            this.chkUnitFilter.AutoSize = true;
            this.chkUnitFilter.Location = new System.Drawing.Point(282, 77);
            this.chkUnitFilter.Name = "chkUnitFilter";
            this.chkUnitFilter.Size = new System.Drawing.Size(15, 14);
            this.chkUnitFilter.TabIndex = 17;
            this.chkUnitFilter.UseVisualStyleBackColor = true;
            // 
            // chkPriceFilter
            // 
            this.chkPriceFilter.AutoSize = true;
            this.chkPriceFilter.Location = new System.Drawing.Point(19, 77);
            this.chkPriceFilter.Name = "chkPriceFilter";
            this.chkPriceFilter.Size = new System.Drawing.Size(15, 14);
            this.chkPriceFilter.TabIndex = 16;
            this.chkPriceFilter.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtUnitMin, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtUnitMax, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(343, 70);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(169, 26);
            this.tableLayoutPanel3.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(70, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "to";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnitMin
            // 
            this.txtUnitMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitMin.Location = new System.Drawing.Point(3, 3);
            this.txtUnitMin.Name = "txtUnitMin";
            this.txtUnitMin.Size = new System.Drawing.Size(61, 23);
            this.txtUnitMin.TabIndex = 1;
            this.txtUnitMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onUnitKeyDown);
            // 
            // txtUnitMax
            // 
            this.txtUnitMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUnitMax.Location = new System.Drawing.Point(103, 3);
            this.txtUnitMax.Name = "txtUnitMax";
            this.txtUnitMax.Size = new System.Drawing.Size(63, 23);
            this.txtUnitMax.TabIndex = 2;
            this.txtUnitMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onUnitKeyDown);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPriceMin, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtPriceMax, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(79, 70);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(169, 26);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(70, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "to";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPriceMin
            // 
            this.txtPriceMin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPriceMin.Location = new System.Drawing.Point(3, 3);
            this.txtPriceMin.Name = "txtPriceMin";
            this.txtPriceMin.Size = new System.Drawing.Size(61, 23);
            this.txtPriceMin.TabIndex = 1;
            this.txtPriceMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onPriceKeyDown);
            // 
            // txtPriceMax
            // 
            this.txtPriceMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPriceMax.Location = new System.Drawing.Point(103, 3);
            this.txtPriceMax.Name = "txtPriceMax";
            this.txtPriceMax.Size = new System.Drawing.Size(63, 23);
            this.txtPriceMax.TabIndex = 2;
            this.txtPriceMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onPriceKeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Price";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Units";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name";
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(79, 26);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(169, 23);
            this.txtProductId.TabIndex = 4;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(343, 26);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(169, 23);
            this.txtProductName.TabIndex = 3;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(537, 45);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(78, 26);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(634, 60);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 36);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(634, 18);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(98, 36);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "New Product";
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // FormProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 395);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormProducts";
            this.menuStripMember.ResumeLayout(false);
            this.menuStripAdmin.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip menuStripMember;
        private System.Windows.Forms.ToolStripMenuItem buyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUnitMin;
        private System.Windows.Forms.TextBox txtUnitMax;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPriceMin;
        private System.Windows.Forms.TextBox txtPriceMax;
        private System.Windows.Forms.CheckBox chkUnitFilter;
        private System.Windows.Forms.CheckBox chkPriceFilter;
    }
}
