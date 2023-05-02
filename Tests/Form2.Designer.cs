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
            honeycombListBox1 = new HoneycombListBox();
            honeycombComboBox_bad1 = new HoneycombComboBox();
            SuspendLayout();
            // 
            // honeycombListBox1
            // 
            honeycombListBox1.DrawMode = DrawMode.OwnerDrawFixed;
            honeycombListBox1.FormattingEnabled = true;
            honeycombListBox1.HorizontalScrollbar = true;
            honeycombListBox1.ItemHeight = 25;
            honeycombListBox1.Items.AddRange(new object[] { "once", "upon", "a", "time" });
            honeycombListBox1.Location = new Point(90, 101);
            honeycombListBox1.Margin = new Padding(0);
            honeycombListBox1.Name = "honeycombListBox1";
            honeycombListBox1.Size = new Size(120, 54);
            honeycombListBox1.TabIndex = 0;
            // 
            // honeycombComboBox_bad1
            // 
            honeycombComboBox_bad1.DisabledMsg = "";
            honeycombComboBox_bad1.DrawMode = DrawMode.OwnerDrawFixed;
            honeycombComboBox_bad1.DropDownStyle = ComboBoxStyle.DropDownList;
            honeycombComboBox_bad1.FormattingEnabled = true;
            honeycombComboBox_bad1.Items.AddRange(new object[] { "once", "upon", "a", "time" });
            honeycombComboBox_bad1.Location = new Point(309, 136);
            honeycombComboBox_bad1.Margin = new Padding(2);
            honeycombComboBox_bad1.Name = "honeycombComboBox_bad1";
            honeycombComboBox_bad1.Size = new Size(187, 24);
            honeycombComboBox_bad1.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(honeycombComboBox_bad1);
            Controls.Add(honeycombListBox1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private HoneycombListBox honeycombListBox1;
        private HoneycombComboBox honeycombComboBox_bad1;
        private PictureBox pictureBox1;
    }
}