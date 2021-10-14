
namespace Desktop.Orders
{
    partial class FormCreateOrder
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
            this.tbnMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainLayoutContainer = new System.Windows.Forms.Panel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tbnMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbnMain
            // 
            this.tbnMain.ColumnCount = 1;
            this.tbnMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbnMain.Controls.Add(this.btnConfirm, 0, 2);
            this.tbnMain.Controls.Add(this.panel1, 0, 0);
            this.tbnMain.Controls.Add(this.mainLayoutContainer, 0, 1);
            this.tbnMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbnMain.Location = new System.Drawing.Point(0, 0);
            this.tbnMain.MaximumSize = new System.Drawing.Size(621, 541);
            this.tbnMain.MinimumSize = new System.Drawing.Size(621, 541);
            this.tbnMain.Name = "tbnMain";
            this.tbnMain.RowCount = 3;
            this.tbnMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.886043F));
            this.tbnMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.25166F));
            this.tbnMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.8623F));
            this.tbnMain.Size = new System.Drawing.Size(621, 541);
            this.tbnMain.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.BackColor = System.Drawing.Color.Maroon;
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirm.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnConfirm.Location = new System.Drawing.Point(220, 511);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(220, 3, 220, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(181, 26);
            this.btnConfirm.TabIndex = 75;
            this.btnConfirm.Text = "Confirm Order";
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 36);
            this.panel1.TabIndex = 76;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(515, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // mainLayoutContainer
            // 
            this.mainLayoutContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayoutContainer.Location = new System.Drawing.Point(3, 45);
            this.mainLayoutContainer.Name = "mainLayoutContainer";
            this.mainLayoutContainer.Size = new System.Drawing.Size(615, 460);
            this.mainLayoutContainer.TabIndex = 77;
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 561);
            this.ControlBox = false;
            this.Controls.Add(this.tbnMain);
            this.Name = "FormCreateOrder";
            this.ShowInTaskbar = false;
            this.Text = "Create Orders";
            this.tbnMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbnMain;
        private UCOrderInfo ucOrderInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel mainLayoutContainer;
    }
}