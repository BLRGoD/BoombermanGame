namespace BoombermanGame
{
    partial class FormGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGame));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обИгреToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обАвтореToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelGame = new System.Windows.Forms.Panel();
            this.labelScore = new System.Windows.Forms.Label();
            this.timerFireClear = new System.Windows.Forms.Timer(this.components);
            this.timerGameOver = new System.Windows.Forms.Timer(this.components);
            this.сложностьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.лёгкийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.среднийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сложныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(788, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сложностьToolStripMenuItem,
            this.toolStripSeparator1,
            this.новаяИграToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обИгреToolStripMenuItem,
            this.обАвтореToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // обИгреToolStripMenuItem
            // 
            this.обИгреToolStripMenuItem.Name = "обИгреToolStripMenuItem";
            this.обИгреToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.обИгреToolStripMenuItem.Text = "Об игре";
            this.обИгреToolStripMenuItem.Click += new System.EventHandler(this.обИгреToolStripMenuItem_Click);
            // 
            // обАвтореToolStripMenuItem
            // 
            this.обАвтореToolStripMenuItem.Name = "обАвтореToolStripMenuItem";
            this.обАвтореToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.обАвтореToolStripMenuItem.Text = "Об Авторе";
            this.обАвтореToolStripMenuItem.Click += new System.EventHandler(this.обАвтореToolStripMenuItem_Click);
            // 
            // panelGame
            // 
            this.panelGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGame.Location = new System.Drawing.Point(0, 61);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(788, 497);
            this.panelGame.TabIndex = 1;
            // 
            // labelScore
            // 
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelScore.Location = new System.Drawing.Point(0, 24);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(788, 34);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "NewGame";
            this.labelScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerFireClear
            // 
            this.timerFireClear.Interval = 1000;
            this.timerFireClear.Tick += new System.EventHandler(this.timerFireClear_Tick);
            // 
            // timerGameOver
            // 
            this.timerGameOver.Tick += new System.EventHandler(this.timerGameOver_Tick);
            // 
            // сложностьToolStripMenuItem
            // 
            this.сложностьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.лёгкийToolStripMenuItem,
            this.среднийToolStripMenuItem,
            this.сложныйToolStripMenuItem});
            this.сложностьToolStripMenuItem.Name = "сложностьToolStripMenuItem";
            this.сложностьToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сложностьToolStripMenuItem.Text = "Сложность";
            // 
            // лёгкийToolStripMenuItem
            // 
            this.лёгкийToolStripMenuItem.Name = "лёгкийToolStripMenuItem";
            this.лёгкийToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.лёгкийToolStripMenuItem.Text = "Лёгкий";
            this.лёгкийToolStripMenuItem.Click += new System.EventHandler(this.лёгкийToolStripMenuItem_Click);
            // 
            // среднийToolStripMenuItem
            // 
            this.среднийToolStripMenuItem.Name = "среднийToolStripMenuItem";
            this.среднийToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.среднийToolStripMenuItem.Text = "Средний";
            this.среднийToolStripMenuItem.Click += new System.EventHandler(this.среднийToolStripMenuItem_Click);
            // 
            // сложныйToolStripMenuItem
            // 
            this.сложныйToolStripMenuItem.Name = "сложныйToolStripMenuItem";
            this.сложныйToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.сложныйToolStripMenuItem.Text = "Сложный";
            this.сложныйToolStripMenuItem.Click += new System.EventHandler(this.сложныйToolStripMenuItem_Click);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 556);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.panelGame);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boomberman";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обИгреToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обАвтореToolStripMenuItem;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer timerFireClear;
        private System.Windows.Forms.Timer timerGameOver;
        private System.Windows.Forms.ToolStripMenuItem сложностьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem лёгкийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem среднийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сложныйToolStripMenuItem;
    }
}

