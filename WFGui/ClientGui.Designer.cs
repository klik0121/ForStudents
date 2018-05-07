namespace WFGui
{
    partial class ClientGui
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.commands = new System.Windows.Forms.DataGridView();
            this.btnNewCommand = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.commands)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.commands, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnNewCommand, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.36364F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(504, 264);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // commands
            // 
            this.commands.AllowUserToAddRows = false;
            this.commands.AllowUserToDeleteRows = false;
            this.commands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.commands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commands.Location = new System.Drawing.Point(3, 3);
            this.commands.Name = "commands";
            this.commands.ReadOnly = true;
            this.commands.Size = new System.Drawing.Size(498, 227);
            this.commands.TabIndex = 0;
            // 
            // btnNewCommand
            // 
            this.btnNewCommand.Location = new System.Drawing.Point(3, 236);
            this.btnNewCommand.Name = "btnNewCommand";
            this.btnNewCommand.Size = new System.Drawing.Size(128, 23);
            this.btnNewCommand.TabIndex = 1;
            this.btnNewCommand.Text = "Новая команда";
            this.btnNewCommand.UseVisualStyleBackColor = true;
            this.btnNewCommand.Click += new System.EventHandler(this.CreateNewCommand);
            // 
            // ClientGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 264);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ClientGui";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.commands)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView commands;
        private System.Windows.Forms.Button btnNewCommand;
    }
}

