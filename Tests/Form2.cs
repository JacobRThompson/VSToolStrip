using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            //Allows us to write to console while inside a form
            Program.AllocConsole();
            InitializeComponent();

        }
    }
}
