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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: Diese Codezeile lädt Daten in die Tabelle "pokedexDataSet.Pokemon". Sie können sie bei Bedarf verschieben oder entfernen.
            this.pokemonTableAdapter.Fill(this.pokedexDataSet.Pokemon);
            // TODO: Diese Codezeile lädt Daten in die Tabelle "pokedexDataSet.Pokemon". Sie können sie bei Bedarf verschieben oder entfernen.
            this.pokemonTableAdapter.Fill(this.pokedexDataSet.Pokemon);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
            {
                MessageBox.Show("Fehler beim Finden!");
                return;
            }
            //i'll do my stuff.
            //MessageBox.Show("Gefunden mit" + dgv.CurrentRow.Cells[0].Value);

            new Detailview(Convert.ToInt16(dgv.CurrentRow.Cells[0].Value));
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv == null)
            {
                MessageBox.Show("Fehler beim Finden!");
                return;
            }
            //i'll do my stuff.
            //MessageBox.Show("Gefunden mit" + dgv.CurrentRow.Cells[0].Value);

            new Detailview(Convert.ToInt16(dgv.CurrentRow.Cells[0].Value));
        }
    }
}
