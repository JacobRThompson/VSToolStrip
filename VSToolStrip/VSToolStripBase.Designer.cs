namespace VSToolStrip
{
    partial class VSToolStripBase
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VSToolStripBase));
            label = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            PinToggle = new IconButtons.IconToggleButton();
            CloseButton = new IconButtons.IconPushButton();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PinToggle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CloseButton).BeginInit();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.BackColor = Color.Transparent;
            label.Location = new Point(3, 3);
            label.Margin = new Padding(3, 3, 0, 0);
            label.Name = "label";
            label.Size = new Size(38, 15);
            label.TabIndex = 0;
            label.Text = "label1";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(PinToggle);
            flowLayoutPanel1.Controls.Add(CloseButton);
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(77, 21);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // PinToggle
            // 
            PinToggle.BackgroundImage = Properties.Resources.Unpinned;
            PinToggle.BackgroundImageLayout = ImageLayout.Stretch;
            PinToggle.Checked = false;
            PinToggle.DefaultCheckedImage = Properties.Resources.Pinned;
            PinToggle.DefaultUncheckedImage = Properties.Resources.Unpinned;
            PinToggle.DisabledCheckedImage = (Image)resources.GetObject("PinToggle.DisabledCheckedImage");
            PinToggle.DisabledUncheckedImage = (Image)resources.GetObject("PinToggle.DisabledUncheckedImage");
            PinToggle.HotCheckedImage = Properties.Resources.PinnedHot;
            PinToggle.HotUncheckedImage = Properties.Resources.UnpinnedHot;
            PinToggle.Location = new Point(41, 3);
            PinToggle.Margin = new Padding(0, 3, 0, 3);
            PinToggle.Name = "PinToggle";
            PinToggle.PressedCheckedImage = Properties.Resources.PinnedPushed;
            PinToggle.PressedUncheckedImage = Properties.Resources.UnpinnedPushed;
            PinToggle.Size = new Size(15, 15);
            PinToggle.TabIndex = 3;
            PinToggle.TabStop = false;
            // 
            // CloseButton
            // 
            CloseButton.BackgroundImage = Properties.Resources.CloseTab;
            CloseButton.BackgroundImageLayout = ImageLayout.Stretch;
            CloseButton.DefaultImage = Properties.Resources.CloseTab;
            CloseButton.DisabledImage = (Image)resources.GetObject("CloseButton.DisabledImage");
            CloseButton.HotImage = Properties.Resources.CloseTabHot;
            CloseButton.Location = new Point(59, 3);
            CloseButton.Name = "CloseButton";
            CloseButton.PressedImage = Properties.Resources.CloseTabPushed;
            CloseButton.Size = new Size(15, 15);
            CloseButton.TabIndex = 4;
            CloseButton.TabStop = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // VSToolStripBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.ControlLight;
            Controls.Add(flowLayoutPanel1);
            Name = "VSToolStripBase";
            Size = new Size(77, 21);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PinToggle).EndInit();
            ((System.ComponentModel.ISupportInitialize)CloseButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label;
        private FlowLayoutPanel flowLayoutPanel1;
        private IconButtons.IconToggleButton PinToggle;
        private IconButtons.IconPushButton CloseButton;
    }
}
