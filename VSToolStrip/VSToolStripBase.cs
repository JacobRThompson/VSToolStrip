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
using VSToolStrip.Properties;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.AxHost;
using System.Buffers;

namespace VSToolStrip
{
    public partial class VSToolStripBase : UserControl, VSToolStrip.IPinnable
    {


        private PushButtonState _buttonState = PushButtonState.Normal;

        private bool _checked = false;

        public VSToolStripBase()
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
        }

        private void Label_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public event EventHandler? PinnedChanged;
        public event EventHandler? CheckedChanged;

        public Rectangle TextRectangle => label.Bounds;

        public bool HasMouse => Bounds.Contains(this.Parent.PointToClient(Cursor.Position));

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


        public new void Hide() => base.Visible = false;


        protected override void OnMouseLeave(EventArgs e)
        {
            if (!this.HasMouse)
            {
                base.OnMouseLeave(e);
                ButtonState = PushButtonState.Normal;
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.HasMouse)
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

        private void CloseButton_Click(object sender, EventArgs e) => this.Hide();

        protected override void OnPaint(PaintEventArgs e)
        {

            /*
            //this.BackColor = Application.RenderWithVisualStyles ? Color.Azure : this.Parent.BackColor;
            //ButtonRenderer.DrawParentBackground(e.Graphics, Bounds, this);
            ButtonRenderer.DrawButton(
                e.Graphics,
                new(0, 0, this.Width, this.Height),
                string.Empty,
                this.Font, ButtonState == PushButtonState.Pressed,
                this.ButtonState);

            if (Checked)
            {
                ControlPaint.DrawBorder(
                    e.Graphics,
                    new(0, 0, this.Width, this.Height),
                    Color.Red,
                    ButtonBorderStyle.Solid);
            }
            */
            base.OnPaint(e);
        }



    }
}
