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
        OleDbConnection con;
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
            this.Focus();
        }

        private void setzeTaktik()
        {
            
        }

        private void setzeBasisAttribute()
        {
            String[] splittedValue;
            com.CommandText = "SELECT PokTyp FROM Pokemon WHERE ID = PokeID";
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("PokeID", PokemonID);

            OleDbDataReader rd = com.ExecuteReader();
            rd.Read();
            
            splittedValue = splitValue(setValue(rd[0]));

            rd.Close();
            rd = null;
            com.CommandText = null;
            com.Parameters.Clear();

            com.CommandText = "SELECT Typname FROM Typen WHERE ID = TypID";
            com.CommandType = CommandType.Text;
            for (int j = 0; j < splittedValue.Length; j++)
            {
                com.Parameters.AddWithValue("TypID", splittedValue[j]);

                rd = com.ExecuteReader();
                rd.Read();

                if (!string.IsNullOrEmpty(Typ1.Text))
                {
                    Typ2.Text = Convert.ToString(setValue(rd[0]));
                }
                else
                {
                    Typ1.Text = Convert.ToString(setValue(rd[0]));
                }
                com.Parameters.Clear();
                rd.Close();
            }
            rd.Close();
            rd = null;
        }

        private void aufbaueVerbindung()
        {
            con = new OleDbConnection(Properties.Settings.Default.DbPathSchool);
            con.Open();
            com = con.CreateCommand();            
        }

        private String[] splitValue(object value)
        {
            return value.ToString().Split(',');
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
