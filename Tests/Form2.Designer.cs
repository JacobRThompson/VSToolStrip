namespace Tests
{
    partial class Form2
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
            pictureBox2 = new PictureBox();
            comboBox1 = new ComboBox();
            toolStrip1 = new ToolStrip();
            honeycombToolStripButton1 = new Honeycomb.UI.ToolStripControls.HoneycombToolStripButton();
            honeycombToolStripButton2 = new Honeycomb.UI.ToolStripControls.HoneycombToolStripButton();
            honeycombToolStripButtonBase1 = new Honeycomb.UI.BaseComponents.HoneycombToolStripButtonBase();
            honeycombToolStripButtonBase2 = new Honeycomb.UI.BaseComponents.HoneycombToolStripButtonBase();
            iconPushButton1 = new Honeycomb.UI.IconButtons.IconPushButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPushButton1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.Highlight;
            pictureBox2.BackgroundImage = Properties.Resources.Pinned_Icon;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(247, 390);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(121, 125);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox1.Location = new Point(728, 390);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(115, 33);
            comboBox1.TabIndex = 4;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { honeycombToolStripButton1, honeycombToolStripButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(1143, 36);
            toolStrip1.TabIndex = 5;
            toolStrip1.Text = "toolStrip1";
            // 
            // honeycombToolStripButton1
            // 
            honeycombToolStripButton1.BackColor = SystemColors.Control;
            honeycombToolStripButton1.ButtonState = System.Windows.Forms.VisualStyles.PushButtonState.Normal;
            honeycombToolStripButton1.CheckOnClick = true;
            honeycombToolStripButton1.DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            honeycombToolStripButton1.DefaultForeColor = SystemColors.ControlText;
            honeycombToolStripButton1.ForeColor = Color.Teal;
            honeycombToolStripButton1.Highlighted = true;
            honeycombToolStripButton1.Margin = new Padding(0);
            honeycombToolStripButton1.Name = "honeycombToolStripButton1";
            honeycombToolStripButton1.Size = new Size(107, 36);
            honeycombToolStripButton1.Text = "label1";
            // 
            // honeycombToolStripButton2
            // 
            honeycombToolStripButton2.BackColor = SystemColors.Control;
            honeycombToolStripButton2.ButtonState = System.Windows.Forms.VisualStyles.PushButtonState.Normal;
            honeycombToolStripButton2.CheckOnClick = true;
            honeycombToolStripButton2.DefaultFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            honeycombToolStripButton2.DefaultForeColor = SystemColors.ControlText;
            honeycombToolStripButton2.Highlighted = false;
            honeycombToolStripButton2.Margin = new Padding(0);
            honeycombToolStripButton2.Name = "honeycombToolStripButton2";
            honeycombToolStripButton2.Size = new Size(107, 36);
            honeycombToolStripButton2.Text = "label1";
            // 
            // honeycombToolStripButtonBase1
            // 
            honeycombToolStripButtonBase1.AutoSize = true;
            honeycombToolStripButtonBase1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            honeycombToolStripButtonBase1.BackColor = SystemColors.Control;
            honeycombToolStripButtonBase1.Checked = true;
            honeycombToolStripButtonBase1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            honeycombToolStripButtonBase1.ForeColor = Color.Fuchsia;
            honeycombToolStripButtonBase1.Highlighted = true;
            honeycombToolStripButtonBase1.Location = new Point(417, 175);
            honeycombToolStripButtonBase1.Margin = new Padding(5, 6, 5, 6);
            honeycombToolStripButtonBase1.Name = "honeycombToolStripButtonBase1";
            honeycombToolStripButtonBase1.Pinned = false;
            honeycombToolStripButtonBase1.Size = new Size(140, 46);
            honeycombToolStripButtonBase1.TabIndex = 6;
            // 
            // honeycombToolStripButtonBase2
            // 
            honeycombToolStripButtonBase2.AutoSize = true;
            honeycombToolStripButtonBase2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            honeycombToolStripButtonBase2.BackColor = Color.OrangeRed;
            honeycombToolStripButtonBase2.Checked = true;
            honeycombToolStripButtonBase2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            honeycombToolStripButtonBase2.ForeColor = Color.DarkGray;
            honeycombToolStripButtonBase2.Highlighted = false;
            honeycombToolStripButtonBase2.Location = new Point(501, 352);
            honeycombToolStripButtonBase2.Margin = new Padding(5, 6, 5, 6);
            honeycombToolStripButtonBase2.Name = "honeycombToolStripButtonBase2";
            honeycombToolStripButtonBase2.Pinned = false;
            honeycombToolStripButtonBase2.Size = new Size(140, 46);
            honeycombToolStripButtonBase2.TabIndex = 7;
            // 
            // iconPushButton1
            // 
            iconPushButton1.BackColor = Color.Transparent;
            iconPushButton1.BackgroundImage = Properties.Resources.Unpinned_Icon;
            iconPushButton1.Highlighted = false;
            iconPushButton1.IconColor = SystemColors.ActiveCaption;
            iconPushButton1.Location = new Point(568, 556);
            iconPushButton1.Name = "iconPushButton1";
            iconPushButton1.Size = new Size(132, 74);
            iconPushButton1.TabIndex = 8;
            iconPushButton1.TabStop = false;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(iconPushButton1);
            Controls.Add(honeycombToolStripButtonBase2);
            Controls.Add(honeycombToolStripButtonBase1);
            Controls.Add(toolStrip1);
            Controls.Add(comboBox1);
            Controls.Add(pictureBox2);
            ForeColor = Color.DarkGray;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form2";
            Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPushButton1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ComboBox comboBox1;
        private ToolStrip toolStrip1;
        private Honeycomb.UI.ToolStripControls.HoneycombToolStripButton honeycombToolStripButton1;
        private Honeycomb.UI.ToolStripControls.HoneycombToolStripButton honeycombToolStripButton2;
        private Honeycomb.UI.BaseComponents.HoneycombToolStripButtonBase honeycombToolStripButtonBase1;
        private Honeycomb.UI.BaseComponents.HoneycombToolStripButtonBase honeycombToolStripButtonBase2;
        private Honeycomb.UI.IconButtons.IconPushButton iconPushButton1;
    }
}