using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;

namespace VSToolStrip
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
    public class VSToolStripButton: ToolStripControlHost , VSToolStrip.IPinnable, IHighlightRenderableButton
    {
 
        private readonly VSToolStripBase _control ;

        private bool _highlighted = false;

        public VSToolStripButton() : base(new VSToolStripBase()) 
        {
            _control = (VSToolStripBase)Control;
            _control.CheckedChanged += (object? sender, EventArgs e) => OnCheckedChanged(e);
            _control.PinnedChanged += (object? sender, EventArgs e) => OnPinnedChanged(e);
            _control.VisibleChanged += (object? sender, EventArgs e) => OnVisibleChanged(e);
            _control.MouseDown += (object? sender, MouseEventArgs e) => OnMouseDown(e);
            _control.MouseUp += (object? sender, MouseEventArgs e) => OnMouseUp(e);
            _control.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            _control.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
        }

        public event EventHandler? PinnedChanged;
        public event EventHandler? CheckedChanged;
        public event EventHandler? HighlightedChanged;

        public void SuspendLayout() => _control.SuspendLayout();
        public void ResumeLayout() => _control.ResumeLayout();

        public virtual Color DefaultForeColor { get; set; } = SystemColors.ControlText;
        public virtual Font DefaultFont { get; set; } = new("Segoe UI", 9F, FontStyle.Regular);

        public virtual bool Highlighted 
        {
            get => _highlighted; 
            set
            {
                _highlighted = value;
                OnHighlighedChanged(EventArgs.Empty);
            }
        }

        public virtual PushButtonState ButtonState
        {
            get => _control.ButtonState;
            set => _control.ButtonState = value;
        }

        public override Color ForeColor 
        {
            get => base.ForeColor;
            set {
                base.ForeColor = value;
                OnForeColorChanged(EventArgs.Empty);
            }

        }

        public override Color BackColor 
        { 
            get => _control.BackColor; 
            set => _control.BackColor = value;
        }

        [DefaultValue(false)]
        public bool Pinned 
        { 
            get => _control.Pinned;
            set => _control.Pinned = value;  //Note: when we set this, _control's event handler will call OnPinnedChanged(e)
        }

        [DefaultValue(false)]
        public bool Checked
        {
            get => _control.Checked;
            set => _control.Checked = value; //Note: when we set this, _control's event handler will call OnCheckedChanged(e)
        }

        public new bool Visible
        {
            get => _control.Visible;
            set => _control.Visible = value; //Note: when we set this, _control's event handler will call OnVisibleChanged(e)
        }

        protected virtual void OnCheckedChanged(EventArgs e) => CheckedChanged?.Invoke(this, e);
        protected virtual void OnPinnedChanged(EventArgs e) => PinnedChanged?.Invoke(this, e);
        protected virtual void OnHighlighedChanged(EventArgs e)
        {         
            if (this.Highlighted)
            {
                this.Font = new Font(DefaultFont.FontFamily, DefaultFont.Size, FontStyle.Bold);
                this.ForeColor = SystemColors.HighlightText;
            }
            else
            {
                this.Font = DefaultFont;
                this.ForeColor = DefaultForeColor;
            }
            HighlightedChanged?.Invoke(this, e);
        }

        public void Hide() => _control.Hide();

        //TODO: Make this into its own renderer class

        protected override void OnPaint(PaintEventArgs e)
        {
            this.Owner.Renderer.DrawItemBackground(new(e.Graphics, this));
            this.Owner.Renderer.DrawItemText(
                new(
                    e.Graphics, 
                    this, 
                    this.Text, 
                    new Rectangle(
                        this._control.label.Location.X, 
                        this._control.label.Location.Y,
                        this._control.label.Width, 
                        this._control.label.Height),
                    this.ForeColor, 
                    this.Font, 
                    System.Drawing.ContentAlignment.MiddleLeft));
            //base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
    }
}
