using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace winform_app
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> listaPokemon;
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            listaPokemon = negocio.listar();
            dgvPokemons.DataSource = listaPokemon;
            ///Borramos columna de URL
            dgvPokemons.Columns["UrlImagen"].Visible = false;
            pbxImagen.Load(listaPokemon[0].UrlImagen);
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            cargarImagen (seleccionado.UrlImagen);
        }

        private void cargarImagen( string imagen)
        {

            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception)
            {

                pbxImagen.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSrfJfKORWtgi8VlnS4Db6I1t7Fe5__xL3SMmMQseJzMdnNe0W5E9RwMZGoo-Sgk1MM5s0&usqp=CAU");
            }



        }
    
   }
}
