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
    public partial class FormDiscos : Form
    {
        private List<Disco> listaDisco;
        private List<Estilo> listaEstilo;
        public FormDiscos()
        {
            InitializeComponent();
        }

        private void FormDiscos_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.UrlImagen);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBoxDisco.Load(imagen);
            }
            catch (Exception ex)
            {

                pictureBoxDisco.Load("https://www.jennybeaumont.com/wp-content/uploads/2015/03/placeholder.gif");
            }
        }

        private void cargar()
        {
            //Carga de los datos de los Discos en el dgvDiscos
            DiscosDatos datos = new DiscosDatos();
            EstilosDatos datosEstilos = new EstilosDatos();
            try
            {
                listaDisco = datos.listar();
                dgvDiscos.DataSource = listaDisco;
                dgvDiscos.Columns["UrlImagen"].Visible = false;
                dgvDiscos.Columns["Id"].Visible = false;
                cargarImagen(listaDisco[0].UrlImagen);

                listaEstilo = datosEstilos.listar();
                dgvEstilos.DataSource = listaEstilo;
                dgvEstilos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrnAltaDisco alta = new FrnAltaDisco();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
            FrnAltaDisco modificar = new FrnAltaDisco(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminacionLogica_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)
        {
            DiscosDatos datosDisco_a_eliminar = new DiscosDatos();
            Disco seleccionado;

            try
            {
                DialogResult respuesta = MessageBox.Show("Está seguro de querer eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

                    if (logico)
                        datosDisco_a_eliminar.Eliminar_logico(seleccionado.Id);
                    else
                        datosDisco_a_eliminar.Eliminar_fisico(seleccionado.Id);
                    
                    cargar();
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
