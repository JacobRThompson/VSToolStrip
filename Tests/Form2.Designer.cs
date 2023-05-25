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
            comboBox1 = new ComboBox();
            toolStrip1 = new ToolStrip();
            honeycombToolStripButton1 = new Honeycomb.UI.ToolStripControls.HoneycombToolStripButton();
            honeycombToolStripButton2 = new Honeycomb.UI.ToolStripControls.HoneycombToolStripButton();
            honeycombComboBox1 = new HoneycombComboBox();
            honeycombComboBox2 = new HoneycombComboBox();
            comboBox2 = new ComboBox();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20" });
            comboBox1.Location = new Point(510, 234);
            comboBox1.Margin = new Padding(2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(82, 23);
            comboBox1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            toolStrip1.BackColor = SystemColors.ActiveCaption;
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { honeycombToolStripButton1, honeycombToolStripButton2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 25);
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
            honeycombToolStripButton1.Size = new Size(72, 25);
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
            honeycombToolStripButton2.Size = new Size(72, 25);
            honeycombToolStripButton2.Text = "label1";
            // 
            // honeycombComboBox1
            // 
            honeycombComboBox1.DisabledMsg = "";
            honeycombComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            honeycombComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            honeycombComboBox1.FormattingEnabled = true;
            honeycombComboBox1.Items.AddRange(new object[] { "once", "upon", "a", "time" });
            honeycombComboBox1.Location = new Point(115, 197);
            honeycombComboBox1.Name = "honeycombComboBox1";
            honeycombComboBox1.Size = new Size(148, 24);
            honeycombComboBox1.TabIndex = 6;
            // 
            // honeycombComboBox2
            // 
            honeycombComboBox2.DisabledMsg = "";
            honeycombComboBox2.FormattingEnabled = true;
            honeycombComboBox2.Items.AddRange(new object[] { "once", "upon", "a", "time" });
            honeycombComboBox2.Location = new Point(269, 197);
            honeycombComboBox2.Name = "honeycombComboBox2";
            honeycombComboBox2.Size = new Size(148, 23);
            honeycombComboBox2.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(499, 100);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(119, 23);
            comboBox2.TabIndex = 8;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox2);
            Controls.Add(honeycombComboBox2);
            Controls.Add(honeycombComboBox1);
            Controls.Add(toolStrip1);
            Controls.Add(comboBox1);
            ForeColor = Color.DarkGray;
            Name = "Form2";
            Text = "Form2";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private ComboBox comboBox1;
        private ToolStrip toolStrip1;
        private Honeycomb.UI.ToolStripControls.HoneycombToolStripButton honeycombToolStripButton1;
        private Honeycomb.UI.ToolStripControls.HoneycombToolStripButton honeycombToolStripButton2;
        private HoneycombComboBox honeycombComboBox1;
        private HoneycombComboBox honeycombComboBox2;
        private ComboBox comboBox2;
    }
}