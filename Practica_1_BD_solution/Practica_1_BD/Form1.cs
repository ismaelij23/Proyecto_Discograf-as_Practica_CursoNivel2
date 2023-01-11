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
            cboBoxCampo.Items.Add("Título");
            cboBoxCampo.Items.Add("CantCanciones");
            cboBoxCampo.Items.Add("Estilo");
            cboBoxCampo.Items.Add("Edición");
        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }

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
                ocultarColumnas();
                cargarImagen(listaDisco[0].UrlImagen);

                //listaEstilo = datosEstilos.listar();
                //dgvEstilos.DataSource = listaEstilo;
                //dgvEstilos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnas()
        {
            dgvDiscos.Columns["UrlImagen"].Visible = false;
            dgvDiscos.Columns["Id"].Visible = false;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DiscosDatos negocio = new DiscosDatos();
            try
            {
                string campo = cboBoxCampo.SelectedItem.ToString();
                string criterio = cboBoxCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            List<Disco> lista_filtrada;
            string filtro = txtFiltrar.Text;

            if (filtro.Length >= 3)
                lista_filtrada = listaDisco.FindAll(x => x.Titulo.ToUpper().Contains(txtFiltrar.Text.ToUpper()) || x.Style.Descripcion.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
            else
                lista_filtrada = listaDisco;

            dgvDiscos.DataSource = null; // Primero se pisa para que el dgv quede sin ningun disco cargado.
            dgvDiscos.DataSource = lista_filtrada;
            ocultarColumnas();
        }

        private void cboBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboBoxCampo.SelectedItem.ToString();

            if(opcion == "CantCanciones")
            {
                cboBoxCriterio.Items.Clear();
                cboBoxCriterio.Items.Add("Mayor a");
                cboBoxCriterio.Items.Add("Menor a");
                cboBoxCriterio.Items.Add("Igual a");
            }
            else
            {
                cboBoxCriterio.Items.Clear();
                cboBoxCriterio.Items.Add("Comienza con");
                cboBoxCriterio.Items.Add("Termina con");
                cboBoxCriterio.Items.Add("Contiene");
            }
        }
        }
    }

