using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pokedex
{
    public partial class Detailview : Form, IsetValue
    {
        int PokemonID;

        OleDbCommand com;
        public Detailview(int id)
        {
            InitializeComponent();
            this.Visible = true;
            this.PokemonID = id;
            fuelleAnsicht();            
        }

        private void fuelleAnsicht()
        {
            aufbaueVerbindung();
            setzeBasisAttribute();
            setzeTaktik();
        }

        private void setzeTaktik()
        {
            
        }

        private void setzeBasisAttribute()
        {
            String[] splittedValue;
            com.CommandText = "SELECT Typ FROM Pokemon p WHERE p.ID = PokeID";
            com.Parameters.AddWithValue("PokeID", PokemonID);

            OleDbDataReader rd = com.ExecuteReader();

            splittedValue = splitValue(setValue(rd.Read()));

            rd.Close();
            rd = null;
            com.CommandText = null;
            com.Parameters.Clear();

            for (int j = 0; j < splittedValue.Length; j++)
            {
                com.CommandText = "SELECT Typname FROM Typen t WHERE t.ID = TypID";
                com.Parameters.AddWithValue("PokeID", splittedValue[j]);

                rd = com.ExecuteReader();

                while (rd.Read())
                {
                    Typ1.Text = Convert.ToString(setValue(rd));
                    if (!string.IsNullOrEmpty(Typ1.Text))
                    {
                        Typ2.Text = Convert.ToString(setValue(rd));
                    }
                }
                com.Parameters.Clear();
            }
        }

        private void aufbaueVerbindung()
        {
            OleDbConnection con = new OleDbConnection(Properties.Settings.Default.DbPathSchool);
            con.Open();
            com = con.CreateCommand();            
        }

        private String[] splitValue(object value)
        {
            String buffer = value.ToString();
            return buffer.Split(',');
        }

        private void ButtonZurück_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public object setValue(object obj)
        {
            if(DBNull.Value.Equals(obj))
            {
                return null;
            }
            return obj;
        }
    }
}
