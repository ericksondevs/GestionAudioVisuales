using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Modelo;
using DataModel.DAO.EstadosDAO;
using DataModel.DAO.Marcas;

namespace GestorAudioVisuales.Modelos
{
    public partial class CtrlModelos : UserControl
    {
        public static int IdModelo;
        ModeloDAO dao = new ModeloDAO();

        public static CtrlModelos _userCtrlModelo;
        public static string titulo { get { return "Gestión de Modelos"; } }
        public static CtrlModelos userCtrlModelo
        {
            get
            {
                if (_userCtrlModelo == null)
                {
                    _userCtrlModelo = new CtrlModelos();
                }
                return _userCtrlModelo;

            }
        }

        public CtrlModelos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {
                    DataModel.Modelos te = new DataModel.Modelos();
                    
                    te.Descripcion = txtModelo.Text;
                    te.IdMarca = Convert.ToInt32(cmbEstado.SelectedValue);
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);
                    
                    dao.InsertModelos(te);
                    dao.Submit();
                    MessageBox.Show("Registro agregado exitosamente");
                    LlenarCamposModelo(te.Id);
                    errorProvider1.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {
                    if (string.IsNullOrEmpty(txtId.Text) && txtId.Text != "0")
                    {
                        txtId.Focus();
                        errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar una modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Modelos te = new DataModel.Modelos();
                    
                    te.Id = Convert.ToInt32(txtId.Text);
                    te.Descripcion = txtModelo.Text;
                    te.IdMarca = Convert.ToInt32(cmbEstado.SelectedValue);
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);

                    dao.EditModelo(te);
                    dao.Submit();
                    MessageBox.Show("Registro modificado exitosamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text) && txtId.Text != "0")
                {
                    txtId.Focus();
                    errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar una modelo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtId.Text);


                dao.DeleteModelo(id);
                dao.Submit();
                MessageBox.Show("Registro eliminado exitosamente");
                LimpiarCampos();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            IdModelo = 0;
            LlenarCamposModelo(new DataModel.Modelos());
        }

        private void CtrlModelos_Load(object sender, EventArgs e)
        {
            CargarEstados();
            CargarMarcas();
            if (IdModelo != 0)
            {
                LlenarCamposModelo(IdModelo);
            }
        }

        private void CargarEstados()
        {
            try
            {
                EstadoDAO dao = new EstadoDAO();
                var data = dao.LoadEstados(1);
                cmbEstado.DataSource = data;
                cmbEstado.DisplayMember = "Descripcion";
                cmbEstado.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarMarcas()
        {
            try
            {
                MarcasDAO dao = new MarcasDAO();
                var data = dao.LoadMarcas();
                cmbMarca.DataSource = data;
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int ValidarCampos()
        {
            int flag = 0;
            
            if (string.IsNullOrEmpty(txtModelo.Text))
            {
                txtModelo.Focus();
                errorProvider1.SetError(txtModelo, MessageBox.Show("El campo modelo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbMarca.Text))
            {
                cmbMarca.Focus();
                errorProvider1.SetError(cmbMarca, MessageBox.Show("El campo marca es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbEstado.Text))
            {
                cmbEstado.Focus();
                errorProvider1.SetError(cmbEstado, MessageBox.Show("El campo estado es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            return flag;
        }

        private void LlenarCamposModelo(int idModelo)
        {
            try
            {
                DataModel.Modelos ma;

                {
                    ma = dao.GetModelo(idModelo);
                    txtId.Text = ma.Id.ToString();
                    cmbMarca.SelectedValue = ma.IdMarca.ToString();
                    txtModelo.Text = ma.Descripcion;
                    cmbEstado.SelectedValue = ma.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposModelo(DataModel.Modelos mo)
        {
            try
            {
                txtId.Text = mo.Id.ToString();
                txtModelo.Text = mo.Descripcion;
                cmbMarca.SelectedValue = mo.IdMarca.ToString();
                cmbEstado.SelectedValue = mo.Estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
