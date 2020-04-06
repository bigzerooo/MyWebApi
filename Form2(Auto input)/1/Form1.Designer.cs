using System.Data;
namespace _1
{
    partial class MainForm
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnRequest = new System.Windows.Forms.Button();
            this.tbDatSource = new System.Windows.Forms.TextBox();
            this.tbInitCat = new System.Windows.Forms.TextBox();
            this.tbRequest = new System.Windows.Forms.TextBox();
            this.labDatSource = new System.Windows.Forms.Label();
            this.labInitCat = new System.Windows.Forms.Label();
            this.labSQLReq = new System.Windows.Forms.Label();
            this.datGridDBTables = new System.Windows.Forms.DataGridView();
            this.datGridSQLResult = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.datGridDBTables)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGridSQLResult)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnect.Location = new System.Drawing.Point(340, 38);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(154, 23);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect to DB";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnRequest
            // 
            this.btnRequest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequest.Enabled = false;
            this.btnRequest.Location = new System.Drawing.Point(340, 223);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(154, 23);
            this.btnRequest.TabIndex = 1;
            this.btnRequest.Text = "Send Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.BtnRequest_Click);
            // 
            // tbDatSource
            // 
            this.tbDatSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDatSource.BackColor = System.Drawing.SystemColors.Info;
            this.tbDatSource.ForeColor = System.Drawing.Color.Green;
            this.tbDatSource.Location = new System.Drawing.Point(135, 12);
            this.tbDatSource.Name = "tbDatSource";
            this.tbDatSource.Size = new System.Drawing.Size(359, 20);
            this.tbDatSource.TabIndex = 2;
            this.tbDatSource.Text = ".\\SQLEXPRESS";
            // 
            // tbInitCat
            // 
            this.tbInitCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbInitCat.BackColor = System.Drawing.SystemColors.Info;
            this.tbInitCat.ForeColor = System.Drawing.Color.Green;
            this.tbInitCat.Location = new System.Drawing.Point(135, 38);
            this.tbInitCat.Name = "tbInitCat";
            this.tbInitCat.Size = new System.Drawing.Size(187, 20);
            this.tbInitCat.TabIndex = 3;
            this.tbInitCat.Text = "usersdb";
            // 
            // tbRequest
            // 
            this.tbRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRequest.BackColor = System.Drawing.SystemColors.Info;
            this.tbRequest.Enabled = false;
            this.tbRequest.ForeColor = System.Drawing.Color.Green;
            this.tbRequest.Location = new System.Drawing.Point(135, 223);
            this.tbRequest.Name = "tbRequest";
            this.tbRequest.Size = new System.Drawing.Size(187, 20);
            this.tbRequest.TabIndex = 4;
            this.tbRequest.Text = "SELECT * FROM Users";
            // 
            // labDatSource
            // 
            this.labDatSource.AutoSize = true;
            this.labDatSource.Location = new System.Drawing.Point(24, 12);
            this.labDatSource.Name = "labDatSource";
            this.labDatSource.Size = new System.Drawing.Size(67, 13);
            this.labDatSource.TabIndex = 5;
            this.labDatSource.Text = "Data Source";
            // 
            // labInitCat
            // 
            this.labInitCat.AutoSize = true;
            this.labInitCat.Location = new System.Drawing.Point(24, 38);
            this.labInitCat.Name = "labInitCat";
            this.labInitCat.Size = new System.Drawing.Size(70, 13);
            this.labInitCat.TabIndex = 6;
            this.labInitCat.Text = "Initial Catalog";
            // 
            // labSQLReq
            // 
            this.labSQLReq.AutoSize = true;
            this.labSQLReq.Location = new System.Drawing.Point(24, 223);
            this.labSQLReq.Name = "labSQLReq";
            this.labSQLReq.Size = new System.Drawing.Size(71, 13);
            this.labSQLReq.TabIndex = 7;
            this.labSQLReq.Text = "SQL Request";
            // 
            // datGridDBTables
            // 
            this.datGridDBTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datGridDBTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGridDBTables.Enabled = false;
            this.datGridDBTables.Location = new System.Drawing.Point(27, 67);
            this.datGridDBTables.Name = "datGridDBTables";
            this.datGridDBTables.ReadOnly = true;
            this.datGridDBTables.Size = new System.Drawing.Size(467, 150);
            this.datGridDBTables.TabIndex = 8;
            this.datGridDBTables.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DatGridDBTables_MouseUp);
            this.datGridDBTables.Resize += new System.EventHandler(this.DatGridDBTables_Resize);
            // 
            // datGridSQLResult
            // 
            this.datGridSQLResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datGridSQLResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datGridSQLResult.Enabled = false;
            this.datGridSQLResult.Location = new System.Drawing.Point(27, 252);
            this.datGridSQLResult.Name = "datGridSQLResult";
            this.datGridSQLResult.ReadOnly = true;
            this.datGridSQLResult.Size = new System.Drawing.Size(467, 127);
            this.datGridSQLResult.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 393);
            this.Controls.Add(this.datGridSQLResult);
            this.Controls.Add(this.datGridDBTables);
            this.Controls.Add(this.labSQLReq);
            this.Controls.Add(this.labInitCat);
            this.Controls.Add(this.labDatSource);
            this.Controls.Add(this.tbRequest);
            this.Controls.Add(this.tbInitCat);
            this.Controls.Add(this.tbDatSource);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.btnConnect);
            this.MaximumSize = new System.Drawing.Size(660, 532);
            this.MinimumSize = new System.Drawing.Size(300, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Base Requests";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datGridDBTables)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datGridSQLResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.TextBox tbDatSource;
        private System.Windows.Forms.TextBox tbInitCat;
        private System.Windows.Forms.TextBox tbRequest;
        private System.Windows.Forms.Label labDatSource;
        private System.Windows.Forms.Label labInitCat;
        private System.Windows.Forms.Label labSQLReq;
        private System.Windows.Forms.DataGridView datGridDBTables;
        private System.Windows.Forms.DataGridView datGridSQLResult;
    }
}

