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

namespace Practica_1_BD
{
    public partial class FrnAltaDisco : Form
    {
        private Disco disco = null;
        public FrnAltaDisco()
        {
            InitializeComponent();
        }

        public FrnAltaDisco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        { 
            DiscosDatos diskDatos = new DiscosDatos();
            try
            {
                if(disco == null)
                    disco = new Disco();

                disco.Titulo = txtTitulo.Text;
                disco.FechaLanzamiento = DateTime.Parse(txtFechaLanzamiento.Text);
                disco.CantCanciones = int.Parse(txtCantCanciones.Text);
                disco.UrlImagen = txtUrlImagen.Text;
                disco.Style = (Estilo)cboBoxEstilo.SelectedItem;
                disco.TipoEdicion = (Edicion)cboBoxEdicion.SelectedItem;

                if(disco.Id != 0)
                {
                    diskDatos.Modificar(disco);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    diskDatos.Agregar(disco);
                    MessageBox.Show("Agregado exitosamente");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrnAltaDisco_Load(object sender, EventArgs e)
        {
            // Agrego los datos que hay en la columna Estilos de la base de datos al cboBoxEstilos:
            EstilosDatos datosEstilos = new EstilosDatos();
            EdicionDatos edicionDatos = new EdicionDatos();
            try
            {
                cboBoxEstilo.DataSource = datosEstilos.listar();
                cboBoxEstilo.ValueMember = "Id";
                cboBoxEstilo.DisplayMember = "Descripcion";
                cboBoxEdicion.DataSource = edicionDatos.listar();
                cboBoxEdicion.ValueMember = "Id";
                cboBoxEdicion.DisplayMember = "Descripcion";

                if(disco != null)
                {
                    txtTitulo.Text = disco.Titulo;
                    txtFechaLanzamiento.Text = disco.FechaLanzamiento.ToString();
                    txtCantCanciones.Text = disco.CantCanciones.ToString();
                    txtUrlImagen.Text = disco.UrlImagen;
                    cargarImagen(disco.UrlImagen);
                    cboBoxEstilo.SelectedValue = disco.Style.Id;
                    cboBoxEdicion.SelectedValue = disco.TipoEdicion.Id;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBoxUrl.Load(imagen);
            }
            catch (Exception ex)
            {

                pictureBoxUrl.Load("https://www.jennybeaumont.com/wp-content/uploads/2015/03/placeholder.gif");
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }
    }
}
