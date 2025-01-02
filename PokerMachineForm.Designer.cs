namespace PokerMachine
{
    partial class PokerMachineForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            pictureBox10 = new PictureBox();
            pictureBox9 = new PictureBox();
            pictureBox8 = new PictureBox();
            pictureBox7 = new PictureBox();
            pictureBox6 = new PictureBox();
            lblTitle = new Label();
            btnPaytable = new Button();
            lblResult = new Label();
            lblBalance = new Label();
            lblBet = new Label();
            btnBet = new Button();
            btnDeal = new Button();
            panel2 = new Panel();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnHold3 = new Button();
            btnHold1 = new Button();
            btnHold2 = new Button();
            btnHold4 = new Button();
            btnHold5 = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(pictureBox10);
            panel1.Controls.Add(pictureBox9);
            panel1.Controls.Add(pictureBox8);
            panel1.Controls.Add(pictureBox7);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(lblTitle);
            panel1.Controls.Add(btnPaytable);
            panel1.Controls.Add(lblResult);
            panel1.Controls.Add(lblBalance);
            panel1.Controls.Add(lblBet);
            panel1.Controls.Add(btnBet);
            panel1.Controls.Add(btnDeal);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(statusStrip1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(930, 621);
            panel1.TabIndex = 0;
            // 
            // pictureBox10
            // 
            pictureBox10.BackgroundImage = Properties.Resources.chip1;
            pictureBox10.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox10.Location = new Point(687, 474);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(54, 49);
            pictureBox10.TabIndex = 18;
            pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            pictureBox9.BackgroundImage = Properties.Resources.chip3;
            pictureBox9.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox9.Location = new Point(179, 34);
            pictureBox9.Name = "pictureBox9";
            pictureBox9.Size = new Size(54, 49);
            pictureBox9.TabIndex = 17;
            pictureBox9.TabStop = false;
            // 
            // pictureBox8
            // 
            pictureBox8.BackgroundImage = Properties.Resources.chip2;
            pictureBox8.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox8.Location = new Point(663, 34);
            pictureBox8.Name = "pictureBox8";
            pictureBox8.Size = new Size(54, 49);
            pictureBox8.TabIndex = 16;
            pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            pictureBox7.BackgroundImage = Properties.Resources.poker_cards;
            pictureBox7.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox7.Location = new Point(0, 34);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(54, 49);
            pictureBox7.TabIndex = 15;
            pictureBox7.TabStop = false;
            pictureBox7.Click += pictureBox7_Click;
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.poker_cards;
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(876, 34);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(54, 49);
            pictureBox6.TabIndex = 14;
            pictureBox6.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Showcard Gothic", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.DarkSlateGray;
            lblTitle.Location = new Point(273, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(350, 60);
            lblTitle.TabIndex = 13;
            lblTitle.Text = "Video Poker";
            // 
            // btnPaytable
            // 
            btnPaytable.BackColor = Color.Sienna;
            btnPaytable.FlatStyle = FlatStyle.Popup;
            btnPaytable.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPaytable.Location = new Point(830, 551);
            btnPaytable.Name = "btnPaytable";
            btnPaytable.Size = new Size(75, 30);
            btnPaytable.TabIndex = 12;
            btnPaytable.Text = "Paytable";
            btnPaytable.UseVisualStyleBackColor = false;
            btnPaytable.Click += btnPaytable_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblResult.ForeColor = Color.Gold;
            lblResult.Location = new Point(299, 83);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(27, 30);
            lblResult.TabIndex = 11;
            lblResult.Text = "``";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBalance.ForeColor = Color.DarkGray;
            lblBalance.Location = new Point(419, 485);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(84, 17);
            lblBalance.TabIndex = 10;
            lblBalance.Text = "Credits : 100";
            // 
            // lblBet
            // 
            lblBet.AutoSize = true;
            lblBet.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBet.ForeColor = Color.DarkGray;
            lblBet.Location = new Point(255, 485);
            lblBet.Name = "lblBet";
            lblBet.Size = new Size(40, 17);
            lblBet.TabIndex = 9;
            lblBet.Text = "Bet : ";
            // 
            // btnBet
            // 
            btnBet.BackColor = Color.SaddleBrown;
            btnBet.FlatStyle = FlatStyle.Popup;
            btnBet.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBet.Location = new Point(235, 511);
            btnBet.Name = "btnBet";
            btnBet.Size = new Size(75, 28);
            btnBet.TabIndex = 8;
            btnBet.Text = "Bet";
            btnBet.UseVisualStyleBackColor = false;
            // 
            // btnDeal
            // 
            btnDeal.BackColor = Color.YellowGreen;
            btnDeal.FlatStyle = FlatStyle.Popup;
            btnDeal.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeal.Location = new Point(402, 511);
            btnDeal.Name = "btnDeal";
            btnDeal.Size = new Size(126, 63);
            btnDeal.TabIndex = 2;
            btnDeal.Text = "Deal";
            btnDeal.UseVisualStyleBackColor = false;
            btnDeal.Click += btnDeal_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.SteelBlue;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox5);
            panel2.Controls.Add(pictureBox4);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(btnHold3);
            panel2.Controls.Add(btnHold1);
            panel2.Controls.Add(btnHold2);
            panel2.Controls.Add(btnHold4);
            panel2.Controls.Add(btnHold5);
            panel2.Location = new Point(24, 116);
            panel2.Name = "panel2";
            panel2.Size = new Size(881, 352);
            panel2.TabIndex = 1;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.LightGray;
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.BorderStyle = BorderStyle.FixedSingle;
            pictureBox5.Location = new Point(711, 70);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(156, 205);
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.LightGray;
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.BorderStyle = BorderStyle.FixedSingle;
            pictureBox4.Location = new Point(538, 70);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(156, 205);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.LightGray;
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(364, 70);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(156, 205);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.LightGray;
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(190, 70);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(156, 205);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.LightGray;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(15, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(156, 205);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnHold3
            // 
            btnHold3.BackColor = Color.DarkGray;
            btnHold3.FlatStyle = FlatStyle.Popup;
            btnHold3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHold3.Location = new Point(405, 290);
            btnHold3.Name = "btnHold3";
            btnHold3.Size = new Size(75, 34);
            btnHold3.TabIndex = 5;
            btnHold3.Text = "Hold";
            btnHold3.UseVisualStyleBackColor = false;
            btnHold3.Click += btnHold3_Click;
            // 
            // btnHold1
            // 
            btnHold1.BackColor = Color.DarkGray;
            btnHold1.FlatStyle = FlatStyle.Popup;
            btnHold1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHold1.Location = new Point(53, 290);
            btnHold1.Name = "btnHold1";
            btnHold1.Size = new Size(75, 34);
            btnHold1.TabIndex = 3;
            btnHold1.Text = "Hold";
            btnHold1.UseVisualStyleBackColor = false;
            btnHold1.Click += btnHold1_Click;
            // 
            // btnHold2
            // 
            btnHold2.BackColor = Color.DarkGray;
            btnHold2.FlatStyle = FlatStyle.Popup;
            btnHold2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHold2.Location = new Point(228, 290);
            btnHold2.Name = "btnHold2";
            btnHold2.Size = new Size(75, 34);
            btnHold2.TabIndex = 4;
            btnHold2.Text = "Hold";
            btnHold2.UseVisualStyleBackColor = false;
            btnHold2.Click += btnHold2_Click;
            // 
            // btnHold4
            // 
            btnHold4.BackColor = Color.DarkGray;
            btnHold4.FlatStyle = FlatStyle.Popup;
            btnHold4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHold4.Location = new Point(576, 290);
            btnHold4.Name = "btnHold4";
            btnHold4.Size = new Size(75, 34);
            btnHold4.TabIndex = 6;
            btnHold4.Text = "Hold";
            btnHold4.UseVisualStyleBackColor = false;
            btnHold4.Click += btnHold4_Click;
            // 
            // btnHold5
            // 
            btnHold5.BackColor = Color.DarkGray;
            btnHold5.FlatStyle = FlatStyle.Popup;
            btnHold5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHold5.Location = new Point(750, 290);
            btnHold5.Name = "btnHold5";
            btnHold5.Size = new Size(75, 34);
            btnHold5.TabIndex = 7;
            btnHold5.Text = "Hold";
            btnHold5.UseVisualStyleBackColor = false;
            btnHold5.Click += btnHold5_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 599);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(930, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(74, 17);
            toolStripStatusLabel1.Text = "Bax Creation";
            // 
            // PokerMachineForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkCyan;
            ClientSize = new Size(930, 621);
            Controls.Add(panel1);
            Name = "PokerMachineForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Poker Machine";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Panel panel2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnHold1;
        private Button btnDeal;
        private Button btnHold5;
        private Button btnHold4;
        private Button btnHold3;
        private Button btnHold2;
        private Button btnBet;
        private Label lblBet;
        private Label lblBalance;
        private Label lblResult;
        private Button btnPaytable;
        private Label lblTitle;
        private PictureBox pictureBox7;
        private PictureBox pictureBox6;
        private PictureBox pictureBox9;
        private PictureBox pictureBox8;
        private PictureBox pictureBox10;
    }
}
