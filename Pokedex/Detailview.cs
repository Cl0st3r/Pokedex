using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class Detailview : Form
    {
        public Detailview()
        {
            InitializeComponent();
        }

        private void ButtonZurück_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
