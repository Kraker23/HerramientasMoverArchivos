using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerramientaMoverArchivos
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            cMoverArchivos c = new cMoverArchivos();
            c.Dock = DockStyle.Fill;
            this.Controls.Add(c);

        }

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {

        }
    }
}
