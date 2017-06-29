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
        String[] splittedValue;

        OleDbCommand com;
        OleDbConnection con;
        OleDbDataReader rd;
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

        private void setzeBasisAttribute()
        {
            leseTypenAusDB();
            schreibeTypenNameninGUI();

            com.CommandText = "SELECT Beschreibung, Gewicht, Groesse, Kategorie, Geschlecht, Faehigkeit FROM Pokemon WHERE ID = PokeID";
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("PokeID", PokemonID);

            rd = com.ExecuteReader();
            rd.Read();
            int i = 0;
            Description.Text = Convert.ToString(setValue(rd[i]));
            Weight.Text = Convert.ToString(setValue(rd[++i]));
            boxHeight.Text = Convert.ToString(setValue(rd[++i]));
            Category.Text = Convert.ToString(setValue(rd[++i]));
            Gender.Text = Convert.ToString(setValue(rd[++i]));
            Ability.Text = Convert.ToString(setValue(rd[++i]));
            rd.Close();
            rd = null;
        }

        private void schreibeTypenNameninGUI()
        {
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

        private void leseTypenAusDB()
        {
            com.CommandText = "SELECT PokTyp FROM Pokemon WHERE ID = PokeID";
            com.CommandType = CommandType.Text;
            com.Parameters.AddWithValue("PokeID", PokemonID);

            rd = com.ExecuteReader();
            rd.Read();

            splittedValue = splitValue(setValue(rd[0]));

            rd.Close();
            rd = null;
            com.CommandText = null;
            com.Parameters.Clear();
        }

        private void setzeTaktik()
        {
            com.CommandText = "SELECT Schwaechen FROM Pokemon WHERE ID = PokeID";
            com.Parameters.AddWithValue("PokeID", PokemonID);
            rd = com.ExecuteReader();
            rd.Read();
            splittedValue = splitValue(setValue(rd[0]));
            rd.Close();
            rd = null;
            com.CommandText = null;
            com.Parameters.Clear();

            schreibeSchwaechenInGUI();
        }

        private void schreibeSchwaechenInGUI()
        {
            for (int i = 0; i < splittedValue.Length; i++)
            {
                com.CommandText = "SELECT TypName FROM Typen WHERE ID = TypID";
                com.Parameters.AddWithValue("TypID", splittedValue[i]);
                rd = com.ExecuteReader();
                rd.Read();
                if (!String.IsNullOrEmpty(Schwaeche1.Text))
                {
                    if (!String.IsNullOrEmpty(Schwaeche2.Text))
                    {
                        if (!String.IsNullOrEmpty(Schwaeche3.Text))
                        {
                            if (!String.IsNullOrEmpty(Schwaeche4.Text))
                            {
                                if (!String.IsNullOrEmpty(Schwaeche5.Text))
                                {
                                    if (!string.IsNullOrEmpty(Schwaeche6.Text))
                                    {
                                        if(!String.IsNullOrEmpty(Schwaeche7.Text))
                                        {

                                        }
                                        else
                                        {
                                            Schwaeche7.Text = Convert.ToString(setValue(rd[0]));
                                        }

                                    }
                                    else
                                    {
                                        Schwaeche6.Text = Convert.ToString(setValue(rd[0]));
                                    }
                                }
                                else
                                {
                                    Schwaeche5.Text = Convert.ToString(setValue(rd[0]));
                                }
                            }
                            else
                            {
                                Schwaeche4.Text = Convert.ToString(setValue(rd[0]));
                            }
                        }
                        else
                        {
                            Schwaeche3.Text = Convert.ToString(setValue(rd[0]));
                        }
                    }
                    else
                    {
                        Schwaeche2.Text = Convert.ToString(setValue(rd[0]));
                    }
                }
                else
                {
                    Schwaeche1.Text = Convert.ToString(setValue(rd[0]));
                }
                rd.Close();
                com.Parameters.Clear();
                com.CommandText = null;

            }
        }

        private void aufbaueVerbindung()
        {
            con = new OleDbConnection(Properties.Settings.Default.DbPathSchool);
            try
            {
                con.Open();
            }
            catch(Exception)
            {
                MessageBox.Show("DB existiert nicht!");
                return;
            }
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
