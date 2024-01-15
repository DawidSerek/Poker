using System.Windows.Forms;

namespace PokerWinForms
{
    partial class Form1
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            buttonStart = new Button();
            labelPoker = new Label();
            picOppCard1 = new PictureBox();
            picOppCard2 = new PictureBox();
            picTabCard1 = new PictureBox();
            picTabCard2 = new PictureBox();
            picTabCard3 = new PictureBox();
            picTabCard4 = new PictureBox();
            picTabCard5 = new PictureBox();
            picPlaCard1 = new PictureBox();
            picPlaCard2 = new PictureBox();
            labelAction = new Label();
            labelFundusze = new Label();
            labelStawka = new Label();
            labelFunduszePlayer = new Label();
            labelStawkaPlayer = new Label();
            buttonPodbij = new Button();
            buttonSprawdz = new Button();
            buttonZrezygnuj = new Button();
            labelFunduszeInt = new Label();
            labelStawkaInt = new Label();
            labelFunduszePlayerInt = new Label();
            labelStawkaPlayerInt = new Label();
            textPodbijValue = new TextBox();
            labelActionDesc = new Label();
            ((System.ComponentModel.ISupportInitialize)picOppCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picOppCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlaCard1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picPlaCard2).BeginInit();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.BackColor = SystemColors.ControlDark;
            buttonStart.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(985, 585);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(277, 108);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = false;
            buttonStart.Click += buttonStart_Click;
            // 
            // labelPoker
            // 
            labelPoker.AutoSize = true;
            labelPoker.BackColor = Color.Transparent;
            labelPoker.Font = new Font("Goudy Stout", 100.200005F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            labelPoker.Location = new Point(70, 182);
            labelPoker.Name = "labelPoker";
            labelPoker.Size = new Size(1176, 230);
            labelPoker.TabIndex = 1;
            labelPoker.Text = "Poker";
            labelPoker.Click += label1_Click;
            // 
            // picOppCard1
            // 
            picOppCard1.Location = new Point(440, 70);
            picOppCard1.Name = "picOppCard1";
            picOppCard1.Size = new Size(150, 210);
            picOppCard1.SizeMode = PictureBoxSizeMode.StretchImage;
            picOppCard1.TabIndex = 3;
            picOppCard1.TabStop = false;
            picOppCard1.Visible = false;
            // 
            // picOppCard2
            // 
            picOppCard2.Location = new Point(610, 70);
            picOppCard2.Name = "picOppCard2";
            picOppCard2.Size = new Size(150, 210);
            picOppCard2.SizeMode = PictureBoxSizeMode.StretchImage;
            picOppCard2.TabIndex = 4;
            picOppCard2.TabStop = false;
            picOppCard2.Visible = false;
            // 
            // picTabCard1
            // 
            picTabCard1.Location = new Point(185, 345);
            picTabCard1.Name = "picTabCard1";
            picTabCard1.Size = new Size(150, 210);
            picTabCard1.SizeMode = PictureBoxSizeMode.StretchImage;
            picTabCard1.TabIndex = 6;
            picTabCard1.TabStop = false;
            picTabCard1.Visible = false;
            // 
            // picTabCard2
            // 
            picTabCard2.Location = new Point(355, 345);
            picTabCard2.Name = "picTabCard2";
            picTabCard2.Size = new Size(150, 210);
            picTabCard2.SizeMode = PictureBoxSizeMode.StretchImage;
            picTabCard2.TabIndex = 7;
            picTabCard2.TabStop = false;
            picTabCard2.Visible = false;
            // 
            // picTabCard3
            // 
            picTabCard3.Location = new Point(525, 345);
            picTabCard3.Name = "picTabCard3";
            picTabCard3.Size = new Size(150, 210);
            picTabCard3.SizeMode = PictureBoxSizeMode.StretchImage;
            picTabCard3.TabIndex = 8;
            picTabCard3.TabStop = false;
            picTabCard3.Visible = false;
            // 
            // picTabCard4
            // 
            picTabCard4.Location = new Point(695, 345);
            picTabCard4.Name = "picTabCard4";
            picTabCard4.Size = new Size(150, 210);
            picTabCard4.SizeMode = PictureBoxSizeMode.StretchImage;
            picTabCard4.TabIndex = 9;
            picTabCard4.TabStop = false;
            picTabCard4.Visible = false;
            // 
            // picTabCard5
            // 
            picTabCard5.Location = new Point(865, 345);
            picTabCard5.Name = "picTabCard5";
            picTabCard5.Size = new Size(150, 210);
            picTabCard5.SizeMode = PictureBoxSizeMode.StretchImage;
            picTabCard5.TabIndex = 10;
            picTabCard5.TabStop = false;
            picTabCard5.Visible = false;
            // 
            // picPlaCard1
            // 
            picPlaCard1.Location = new Point(440, 620);
            picPlaCard1.Name = "picPlaCard1";
            picPlaCard1.Size = new Size(150, 210);
            picPlaCard1.SizeMode = PictureBoxSizeMode.StretchImage;
            picPlaCard1.TabIndex = 11;
            picPlaCard1.TabStop = false;
            picPlaCard1.Visible = false;
            // 
            // picPlaCard2
            // 
            picPlaCard2.Location = new Point(610, 620);
            picPlaCard2.Name = "picPlaCard2";
            picPlaCard2.Size = new Size(150, 210);
            picPlaCard2.SizeMode = PictureBoxSizeMode.StretchImage;
            picPlaCard2.TabIndex = 12;
            picPlaCard2.TabStop = false;
            picPlaCard2.Visible = false;
            // 
            // labelAction
            // 
            labelAction.AutoSize = true;
            labelAction.BackColor = Color.Transparent;
            labelAction.Font = new Font("Showcard Gothic", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelAction.Location = new Point(940, 139);
            labelAction.Name = "labelAction";
            labelAction.Size = new Size(397, 59);
            labelAction.TabIndex = 13;
            labelAction.Text = "Ostatnia akcja";
            labelAction.Visible = false;
            // 
            // labelFundusze
            // 
            labelFundusze.AutoSize = true;
            labelFundusze.BackColor = Color.Transparent;
            labelFundusze.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFundusze.Location = new Point(70, 93);
            labelFundusze.Name = "labelFundusze";
            labelFundusze.Padding = new Padding(10);
            labelFundusze.Size = new Size(199, 57);
            labelFundusze.TabIndex = 15;
            labelFundusze.Text = "Fundusze:";
            labelFundusze.Visible = false;
            // 
            // labelStawka
            // 
            labelStawka.AutoSize = true;
            labelStawka.BackColor = Color.Transparent;
            labelStawka.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStawka.Location = new Point(97, 150);
            labelStawka.Name = "labelStawka";
            labelStawka.Padding = new Padding(10, 10, 38, 10);
            labelStawka.Size = new Size(199, 57);
            labelStawka.TabIndex = 16;
            labelStawka.Text = "Stawka:";
            labelStawka.Visible = false;
            // 
            // labelFunduszePlayer
            // 
            labelFunduszePlayer.AutoSize = true;
            labelFunduszePlayer.BackColor = Color.Transparent;
            labelFunduszePlayer.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelFunduszePlayer.Location = new Point(70, 643);
            labelFunduszePlayer.Name = "labelFunduszePlayer";
            labelFunduszePlayer.Padding = new Padding(10);
            labelFunduszePlayer.Size = new Size(199, 57);
            labelFunduszePlayer.TabIndex = 19;
            labelFunduszePlayer.Text = "Fundusze:";
            labelFunduszePlayer.Visible = false;
            // 
            // labelStawkaPlayer
            // 
            labelStawkaPlayer.AutoSize = true;
            labelStawkaPlayer.BackColor = Color.Transparent;
            labelStawkaPlayer.Font = new Font("Showcard Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelStawkaPlayer.Location = new Point(97, 700);
            labelStawkaPlayer.Name = "labelStawkaPlayer";
            labelStawkaPlayer.Padding = new Padding(10, 10, 38, 10);
            labelStawkaPlayer.Size = new Size(199, 57);
            labelStawkaPlayer.TabIndex = 20;
            labelStawkaPlayer.Text = "Stawka:";
            labelStawkaPlayer.Visible = false;
            // 
            // buttonPodbij
            // 
            buttonPodbij.BackColor = SystemColors.ControlDark;
            buttonPodbij.Font = new Font("Impact", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonPodbij.Location = new Point(1060, 642);
            buttonPodbij.Name = "buttonPodbij";
            buttonPodbij.Size = new Size(277, 108);
            buttonPodbij.TabIndex = 23;
            buttonPodbij.Text = "Podbij";
            buttonPodbij.UseVisualStyleBackColor = false;
            buttonPodbij.Visible = false;
            // 
            // buttonSprawdz
            // 
            buttonSprawdz.BackColor = SystemColors.ControlDark;
            buttonSprawdz.Font = new Font("Impact", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonSprawdz.Location = new Point(1060, 515);
            buttonSprawdz.Name = "buttonSprawdz";
            buttonSprawdz.Size = new Size(277, 108);
            buttonSprawdz.TabIndex = 24;
            buttonSprawdz.Text = "Sprawdź";
            buttonSprawdz.UseVisualStyleBackColor = false;
            buttonSprawdz.Visible = false;
            // 
            // buttonZrezygnuj
            // 
            buttonZrezygnuj.BackColor = SystemColors.ControlDark;
            buttonZrezygnuj.Font = new Font("Impact", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point, 238);
            buttonZrezygnuj.Location = new Point(1060, 388);
            buttonZrezygnuj.Name = "buttonZrezygnuj";
            buttonZrezygnuj.Size = new Size(277, 108);
            buttonZrezygnuj.TabIndex = 25;
            buttonZrezygnuj.Text = "Zrezygnuj";
            buttonZrezygnuj.UseVisualStyleBackColor = false;
            buttonZrezygnuj.Visible = false;
            // 
            // labelFunduszeInt
            // 
            labelFunduszeInt.AutoSize = true;
            labelFunduszeInt.BackColor = Color.Transparent;
            labelFunduszeInt.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFunduszeInt.Location = new Point(260, 103);
            labelFunduszeInt.Name = "labelFunduszeInt";
            labelFunduszeInt.Size = new Size(0, 37);
            labelFunduszeInt.TabIndex = 26;
            // 
            // labelStawkaInt
            // 
            labelStawkaInt.AutoSize = true;
            labelStawkaInt.BackColor = Color.Transparent;
            labelStawkaInt.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStawkaInt.Location = new Point(260, 160);
            labelStawkaInt.Name = "labelStawkaInt";
            labelStawkaInt.Size = new Size(0, 37);
            labelStawkaInt.TabIndex = 27;
            // 
            // labelFunduszePlayerInt
            // 
            labelFunduszePlayerInt.AutoSize = true;
            labelFunduszePlayerInt.BackColor = Color.Transparent;
            labelFunduszePlayerInt.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelFunduszePlayerInt.Location = new Point(260, 653);
            labelFunduszePlayerInt.Name = "labelFunduszePlayerInt";
            labelFunduszePlayerInt.Size = new Size(0, 37);
            labelFunduszePlayerInt.TabIndex = 28;
            // 
            // labelStawkaPlayerInt
            // 
            labelStawkaPlayerInt.AutoSize = true;
            labelStawkaPlayerInt.BackColor = Color.Transparent;
            labelStawkaPlayerInt.Font = new Font("Showcard Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelStawkaPlayerInt.Location = new Point(260, 710);
            labelStawkaPlayerInt.Name = "labelStawkaPlayerInt";
            labelStawkaPlayerInt.Size = new Size(0, 37);
            labelStawkaPlayerInt.TabIndex = 29;
            // 
            // textPodbijValue
            // 
            textPodbijValue.BackColor = SystemColors.ControlDark;
            textPodbijValue.Font = new Font("Impact", 28.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            textPodbijValue.Location = new Point(906, 662);
            textPodbijValue.Name = "textPodbijValue";
            textPodbijValue.Size = new Size(125, 65);
            textPodbijValue.TabIndex = 30;
            textPodbijValue.TextAlign = HorizontalAlignment.Center;
            textPodbijValue.Visible = false;
            // 
            // labelActionDesc
            // 
            labelActionDesc.AutoSize = true;
            labelActionDesc.BackColor = Color.Transparent;
            labelActionDesc.Font = new Font("Impact", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 238);
            labelActionDesc.Location = new Point(966, 198);
            labelActionDesc.Name = "labelActionDesc";
            labelActionDesc.Size = new Size(83, 35);
            labelActionDesc.TabIndex = 31;
            labelActionDesc.Text = "label1";
            labelActionDesc.TextAlign = ContentAlignment.MiddleCenter;
            labelActionDesc.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.background;
            ClientSize = new Size(1400, 900);
            Controls.Add(labelActionDesc);
            Controls.Add(textPodbijValue);
            Controls.Add(labelStawkaPlayerInt);
            Controls.Add(labelFunduszePlayerInt);
            Controls.Add(labelStawkaInt);
            Controls.Add(labelFunduszeInt);
            Controls.Add(buttonZrezygnuj);
            Controls.Add(buttonSprawdz);
            Controls.Add(buttonPodbij);
            Controls.Add(labelStawkaPlayer);
            Controls.Add(labelFunduszePlayer);
            Controls.Add(labelStawka);
            Controls.Add(labelFundusze);
            Controls.Add(labelAction);
            Controls.Add(picPlaCard2);
            Controls.Add(picPlaCard1);
            Controls.Add(picTabCard5);
            Controls.Add(picTabCard4);
            Controls.Add(picTabCard3);
            Controls.Add(picTabCard2);
            Controls.Add(picTabCard1);
            Controls.Add(picOppCard2);
            Controls.Add(picOppCard1);
            Controls.Add(labelPoker);
            Controls.Add(buttonStart);
            Name = "Form1";
            Text = "Poker";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picOppCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picOppCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard2).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard3).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard4).EndInit();
            ((System.ComponentModel.ISupportInitialize)picTabCard5).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlaCard1).EndInit();
            ((System.ComponentModel.ISupportInitialize)picPlaCard2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button buttonStart;
        private Label labelPoker;
        private PictureBox picOppCard1;
        private PictureBox picOppCard2;
        private PictureBox picTabCard1;
        private PictureBox picTabCard2;
        private PictureBox picTabCard3;
        private PictureBox picTabCard4;
        private PictureBox picTabCard5;
        private PictureBox picPlaCard1;
        private PictureBox picPlaCard2;
        private Label labelAction;
        private Label labelFundusze;
        private Label labelStawka;
        private Label labelFunduszePlayer;
        private Label labelStawkaPlayer;
        private Button buttonPodbij;
        private Button buttonSprawdz;
        private Button buttonZrezygnuj;
        private Label labelFunduszeInt;
        private Label labelStawkaInt;
        private Label labelFunduszePlayerInt;
        private Label labelStawkaPlayerInt;
        private TextBox textPodbijValue;
        private Label labelActionDesc;
    }
}
