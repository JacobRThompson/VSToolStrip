using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


using System.Windows.Forms.VisualStyles;



namespace Honeycomb.UI.BaseComponents
{
    public partial class HoneycombToolStripButtonBase : UserControl, IPinnableUIElement, IHighlightable
    {
        const int ICON_DEFAULT_SIZE = 15;

        private int _iconMargin = 1;
        private bool _highlighted = false;
        private bool _showIcons = true;
        private PushButtonState _buttonState = PushButtonState.Normal;

        private bool _checked = false;

        public HoneycombToolStripButtonBase()
        {
            InitializeComponent();

            label.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            label.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
            label.MouseDown += (object? sender, MouseEventArgs e) => OnMouseDown(e);
            label.MouseUp += (object? sender, MouseEventArgs e) => OnMouseUp(e); ;
            label.Click += (object? sender, EventArgs e) => OnClick(e);

            flowLayoutPanel1.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            flowLayoutPanel1.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
            flowLayoutPanel1.MouseDown += (object? sender, MouseEventArgs e) => OnMouseDown(e);
            flowLayoutPanel1.MouseUp += (object? sender, MouseEventArgs e) => OnMouseUp(e);
            flowLayoutPanel1.Click += (object? sender, EventArgs e) => OnClick(e);

            PinToggle.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            PinToggle.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);
            PinToggle.CheckedChanged += (object? sender, EventArgs e) => OnPinnedChanged(e);

            CloseButton.MouseEnter += (object? sender, EventArgs e) => OnMouseEnter(e);
            CloseButton.MouseLeave += (object? sender, EventArgs e) => OnMouseLeave(e);

            this.DoubleBuffered = true;
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public event EventHandler? PinnedChanged;
        public event EventHandler? CheckedChanged;
        public event EventHandler? HighlightedChanged;

   
        [DefaultValue(true)]
        public bool ShowIcons
        {
            get => _showIcons;
            set
            {
                if (_showIcons != value)
                {
                    _showIcons = value;

                    SuspendLayout();
                    PinToggle.Visible = value;
                    CloseButton.Visible = value;
                    ResumeLayout();
                }
            }
        }

        [DefaultValue(1)]
        public int IconMargin
        {
            get => _iconMargin;
            set
            {
                if (_iconMargin != value)
                {
                    _iconMargin = value;
                    SuspendLayout();
                    PinToggle.Size = new Size(ICON_DEFAULT_SIZE - 2 * _iconMargin, ICON_DEFAULT_SIZE - 2 * _iconMargin);
                    PinToggle.Margin = new(0, _iconMargin + 3, _iconMargin, _iconMargin + 3);

                    CloseButton.Size = new Size(ICON_DEFAULT_SIZE - 2 * _iconMargin, ICON_DEFAULT_SIZE - 2 * _iconMargin);
                    CloseButton.Margin = new(3, _iconMargin + 3, _iconMargin, _iconMargin + 3);
                    ResumeLayout();
                }
            }
        }

        [DefaultValue(true)]
        public virtual bool CheckOnClick { get; set; } = true;

        public bool Checked
        {
            get => _checked;
            set
            {
                if (_checked != value)
                {
                    _checked = value;
                    OnCheckedChanged(EventArgs.Empty);
                    Invalidate();
                }
            }
        }

        internal PushButtonState ButtonState
        {
            get => _buttonState;
            set
            {
                if (_buttonState != value)
                {
                    _buttonState = value;
                    Invalidate();
                }
            }
        }

        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                label.Font = value;
            }
        }

        public override string Text
        {
            get => label.Text;
            set => label.Text = value;
        }

        public bool Pinned
        {
            get => PinToggle.Checked;
            set => PinToggle.Checked = value;
        }

        public new bool Visible
        {
            get => base.Visible;
            set
            {
                //Do nothing if we are trying to hide control while it is pinned
                if (!value & Pinned) { }
                else
                {
                    base.Visible = value;
                    OnVisibleChanged(EventArgs.Empty);
                }
            }
        }

        public bool Highlighted
        {
            get => _highlighted;
            set
            {
                _highlighted = value;
                OnHighlightedChanged(EventArgs.Empty);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e) => this.Hide();

        public new void Hide() => base.Visible = false;

        protected virtual void OnHighlightedChanged(EventArgs e)
        {
            label.Highlighted = this.Highlighted;
            Invalidate();
            HighlightedChanged?.Invoke(this, e);
        }


        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.HasMouse())
            {
                base.OnMouseLeave(e);
                ButtonState = PushButtonState.Normal;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.HasMouse())
            {
                base.OnMouseEnter(e);
                ButtonState = PushButtonState.Hot;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            ButtonState = PushButtonState.Hot;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            ButtonState = PushButtonState.Pressed;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (CheckOnClick)
                Checked = !Checked;
        }

        protected virtual void OnPinnedChanged(EventArgs e)
        {
            PinnedChanged?.Invoke(this, e);
            Invalidate();
        }

        protected virtual void OnCheckedChanged(EventArgs e)
        {
            CheckedChanged?.Invoke(this, e);
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {
            const float HOT_OPACITY = 0.33f;

            Color backgroundColor;
            Color outlineColor;

            switch (ButtonState)
            {
                case PushButtonState.Hot:
                    if (Highlighted)
                    {
                        backgroundColor = Lerp(SystemColors.MenuHighlight, Parent.BackColor, HOT_OPACITY);
                        outlineColor = this.Checked ?
                            Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                            backgroundColor;
                    }
                    else
                    {
                        backgroundColor = ProfessionalColors.ButtonSelectedHighlight;
                        outlineColor = this.Checked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            ProfessionalColors.ButtonSelectedHighlightBorder;
                    }
                    break;

                case PushButtonState.Pressed:
                    if (Highlighted)
                    {
                        backgroundColor = Lerp(SystemColors.MenuHighlight, Parent.BackColor, 1f - HOT_OPACITY);
                        outlineColor = SystemColors.MenuHighlight;
                    }
                    else
                    {
                        backgroundColor = ProfessionalColors.ButtonPressedHighlight;
                        outlineColor = this.Checked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            ProfessionalColors.ButtonPressedBorder;
                    }
                    break;

                default:
                    if (Highlighted)
                    {
                        backgroundColor = SystemColors.MenuHighlight;
                        outlineColor = this.Checked ?
                            Lerp(Color.Black, ProfessionalColors.ButtonCheckedHighlightBorder, .25f) :
                            SystemColors.InactiveBorder;
                    }
                    else
                    {
                        backgroundColor = BackColor;
                        outlineColor = this.Checked ?
                            ProfessionalColors.ButtonCheckedHighlightBorder :
                            SystemColors.InactiveBorder;
                    }
                    break;
            }

            e.Graphics.Clear(backgroundColor);
            e.Graphics.DrawRectangle(
                new Pen(outlineColor),
                new(Point.Empty, this.Size - new Size(1, 1)));
        }

    }
}
