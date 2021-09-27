
namespace Desktop.MainForm
{
    partial class UCProducts
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
            this.tpnContainer = new System.Windows.Forms.TableLayoutPanel();
            this.lvProduct = new System.Windows.Forms.ListView();
            this.menuStripMember = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStripAdmin = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpnContainer.SuspendLayout();
            this.menuStripMember.SuspendLayout();
            this.menuStripAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpnContainer
            // 
            this.tpnContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tpnContainer.ColumnCount = 1;
            this.tpnContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnContainer.Controls.Add(this.lvProduct, 0, 1);
            this.tpnContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpnContainer.Location = new System.Drawing.Point(0, 0);
            this.tpnContainer.Name = "tpnContainer";
            this.tpnContainer.Padding = new System.Windows.Forms.Padding(10);
            this.tpnContainer.RowCount = 2;
            this.tpnContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tpnContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tpnContainer.Size = new System.Drawing.Size(579, 434);
            this.tpnContainer.TabIndex = 0;
            // 
            // lvProduct
            // 
            this.lvProduct.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.lvProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProduct.HideSelection = false;
            this.lvProduct.Location = new System.Drawing.Point(13, 75);
            this.lvProduct.Name = "lvProduct";
            this.lvProduct.Size = new System.Drawing.Size(553, 346);
            this.lvProduct.TabIndex = 0;
            this.lvProduct.UseCompatibleStateImageBehavior = false;
            this.lvProduct.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvProducts_MouseClick);
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
            // UCProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tpnContainer);
            this.Name = "UCProducts";
            this.Size = new System.Drawing.Size(579, 434);
            this.tpnContainer.ResumeLayout(false);
            this.menuStripMember.ResumeLayout(false);
            this.menuStripAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tpnContainer;
        private System.Windows.Forms.ListView lvProduct;
        private System.Windows.Forms.ContextMenuStrip menuStripMember;
        private System.Windows.Forms.ToolStripMenuItem buyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuStripAdmin;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}
