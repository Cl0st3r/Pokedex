namespace Pokedex
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pokedexDataSet1 = new Pokedex.PokedexDataSet();
            this.pokemon_TypTableAdapter1 = new Pokedex.PokedexDataSetTableAdapters.Pokemon_TypTableAdapter();
            this.pokemonTableAdapter1 = new Pokedex.PokedexDataSetTableAdapters.PokemonTableAdapter();
            this.typenTableAdapter1 = new Pokedex.PokedexDataSetTableAdapters.TypenTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1145, 473);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // pokedexDataSet1
            // 
            this.pokedexDataSet1.DataSetName = "PokedexDataSet";
            this.pokedexDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pokemon_TypTableAdapter1
            // 
            this.pokemon_TypTableAdapter1.ClearBeforeFill = true;
            // 
            // pokemonTableAdapter1
            // 
            this.pokemonTableAdapter1.ClearBeforeFill = true;
            // 
            // typenTableAdapter1
            // 
            this.typenTableAdapter1.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 550);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokedexDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private PokedexDataSet pokedexDataSet1;
        private PokedexDataSetTableAdapters.Pokemon_TypTableAdapter pokemon_TypTableAdapter1;
        private PokedexDataSetTableAdapters.PokemonTableAdapter pokemonTableAdapter1;
        private PokedexDataSetTableAdapters.TypenTableAdapter typenTableAdapter1;
    }
}

