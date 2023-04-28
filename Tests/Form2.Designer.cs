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
            honeycombComboBox1 = new HoneycombComboBox();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // honeycombComboBox1
            // 
            honeycombComboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            honeycombComboBox1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            honeycombComboBox1.FormattingEnabled = true;
            honeycombComboBox1.Items.AddRange(new object[] { "once", "upon", "a", "time" });
            honeycombComboBox1.Location = new Point(146, 125);
            honeycombComboBox1.Name = "honeycombComboBox1";
            honeycombComboBox1.Size = new Size(195, 44);
            honeycombComboBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "once", "upon", "a", "time" });
            comboBox1.Location = new Point(392, 125);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(171, 23);
            comboBox1.TabIndex = 1;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(comboBox1);
            Controls.Add(honeycombComboBox1);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
        }

        #endregion

        private HoneycombComboBox honeycombComboBox1;
        private ComboBox comboBox1;
    }
}