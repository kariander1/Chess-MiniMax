namespace Chess
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debuggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showThreatningRouteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freestyleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToTheRescuePieceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Copyrights = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbPieceProp = new System.Windows.Forms.Label();
            this.pbPiecePicture = new System.Windows.Forms.PictureBox();
            this.lstMoveHistory = new System.Windows.Forms.ListView();
            this.clmnPiece = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnFrom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnTo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imglstPiecesPicture = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPiecePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.debuggingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(716, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.newToolStripMenuItem.Text = "New..";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // debuggingToolStripMenuItem
            // 
            this.debuggingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showThreatningRouteToolStripMenuItem,
            this.showToTheRescuePieceToolStripMenuItem,
            this.freestyleToolStripMenuItem});
            this.debuggingToolStripMenuItem.Name = "debuggingToolStripMenuItem";
            this.debuggingToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.debuggingToolStripMenuItem.Text = "Debugging";
            // 
            // showThreatningRouteToolStripMenuItem
            // 
            this.showThreatningRouteToolStripMenuItem.Name = "showThreatningRouteToolStripMenuItem";
            this.showThreatningRouteToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.showThreatningRouteToolStripMenuItem.Text = "Show threatening route";
            this.showThreatningRouteToolStripMenuItem.Click += new System.EventHandler(this.showThreatningRouteToolStripMenuItem_Click);
            // 
            // freestyleToolStripMenuItem
            // 
            this.freestyleToolStripMenuItem.Name = "freestyleToolStripMenuItem";
            this.freestyleToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.freestyleToolStripMenuItem.Text = "Freestyle";
            this.freestyleToolStripMenuItem.Click += new System.EventHandler(this.freestyleToolStripMenuItem_Click);
            // 
            // showToTheRescuePieceToolStripMenuItem
            // 
            this.showToTheRescuePieceToolStripMenuItem.Name = "showToTheRescuePieceToolStripMenuItem";
            this.showToTheRescuePieceToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.showToTheRescuePieceToolStripMenuItem.Text = "Show \"To The Rescue\" piece";
            this.showToTheRescuePieceToolStripMenuItem.Click += new System.EventHandler(this.showToTheRescuePieceToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copyrights,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 555);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(716, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Copyrights
            // 
            this.Copyrights.Name = "Copyrights";
            this.Copyrights.Size = new System.Drawing.Size(127, 17);
            this.Copyrights.Text = "Made By Shai Yehezkel";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(28, 17);
            this.toolStripStatusLabel3.Text = "       ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel2.Text = "Move";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbPieceProp);
            this.groupBox1.Controls.Add(this.pbPiecePicture);
            this.groupBox1.Location = new System.Drawing.Point(553, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(151, 100);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Piece";
            // 
            // lbPieceProp
            // 
            this.lbPieceProp.AutoSize = true;
            this.lbPieceProp.Location = new System.Drawing.Point(6, 53);
            this.lbPieceProp.Name = "lbPieceProp";
            this.lbPieceProp.Size = new System.Drawing.Size(0, 13);
            this.lbPieceProp.TabIndex = 1;
            // 
            // pbPiecePicture
            // 
            this.pbPiecePicture.Location = new System.Drawing.Point(7, 20);
            this.pbPiecePicture.Name = "pbPiecePicture";
            this.pbPiecePicture.Size = new System.Drawing.Size(30, 30);
            this.pbPiecePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPiecePicture.TabIndex = 0;
            this.pbPiecePicture.TabStop = false;
            // 
            // lstMoveHistory
            // 
            this.lstMoveHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMoveHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnPiece,
            this.clmnFrom,
            this.clmnTo});
            this.lstMoveHistory.LargeImageList = this.imglstPiecesPicture;
            this.lstMoveHistory.Location = new System.Drawing.Point(553, 144);
            this.lstMoveHistory.Name = "lstMoveHistory";
            this.lstMoveHistory.Size = new System.Drawing.Size(151, 408);
            this.lstMoveHistory.SmallImageList = this.imglstPiecesPicture;
            this.lstMoveHistory.TabIndex = 12;
            this.lstMoveHistory.UseCompatibleStateImageBehavior = false;
            this.lstMoveHistory.View = System.Windows.Forms.View.Details;
            // 
            // clmnPiece
            // 
            this.clmnPiece.Text = "Piece";
            this.clmnPiece.Width = 87;
            // 
            // clmnFrom
            // 
            this.clmnFrom.Text = "From";
            this.clmnFrom.Width = 35;
            // 
            // clmnTo
            // 
            this.clmnTo.Text = "To";
            this.clmnTo.Width = 25;
            // 
            // imglstPiecesPicture
            // 
            this.imglstPiecesPicture.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglstPiecesPicture.ImageSize = new System.Drawing.Size(16, 16);
            this.imglstPiecesPicture.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 577);
            this.Controls.Add(this.lstMoveHistory);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPiecePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Copyrights;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.GroupBox groupBox1;
        
        private System.Windows.Forms.Label lbPieceProp;
        private System.Windows.Forms.ListView lstMoveHistory;
        private System.Windows.Forms.ColumnHeader clmnPiece;
        private System.Windows.Forms.ColumnHeader clmnFrom;
        private System.Windows.Forms.ImageList imglstPiecesPicture;
        private System.Windows.Forms.ColumnHeader clmnTo;
        private System.Windows.Forms.PictureBox pbPiecePicture;
        private System.Windows.Forms.ToolStripMenuItem debuggingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showThreatningRouteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freestyleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToTheRescuePieceToolStripMenuItem;
    }
}

