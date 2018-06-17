using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.EstadosDAO;
using DataModel.DAO.Marcas;

namespace GestorAudioVisuales.Marcas
{
    public partial class CtrlMarcas : UserControl
    {
        public static int IdMarca;
        MarcasDAO dao = new MarcasDAO();

        public static CtrlMarcas _userCtrlMarcas;
        public static string titulo { get { return "Gestión de Marcas"; } }
        public static CtrlMarcas userCtrlMarcas
        {
            get
            {
                if (_userCtrlMarcas == null)
                {
                    _userCtrlMarcas = new CtrlMarcas();
                }
                return _userCtrlMarcas;

            }
        }

        public CtrlMarcas()
        {
            InitializeComponent();
        }

        private void CtrlMarcas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEstados();

                if (IdMarca != 0)
                {
                    LlenarCamposMarca(IdMarca);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarEstados()
        {
            EstadoDAO dao = new EstadoDAO();
            var data = dao.LoadEstados(1);
            cmbEstado.DataSource = data;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "Id";
        }

        private int ValidarCampos()
        {
            int flag = 0;
            
            if (string.IsNullOrEmpty(txtMarca.Text))
            {
                txtMarca.Focus();
                errorProvider1.SetError(txtMarca, MessageBox.Show("El campo marca es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
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

        private void LlenarCamposMarca(int idMarca)
        {
            try
            {
                DataModel.Marcas ma;

                {
                    ma = dao.GetMarca(idMarca);
                    txtId.Text = ma.Id.ToString();
                    txtMarca.Text = ma.Descripcion;
                    cmbEstado.SelectedValue = ma.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposMarca(DataModel.Marcas ma)
        {
            try
            {
                txtId.Text = ma.Id.ToString();
                txtMarca.Text = ma.Descripcion;
                cmbEstado.SelectedValue = ma.Estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {
                    DataModel.Marcas te = new DataModel.Marcas();
                    
                    te.Descripcion = txtMarca.Text;
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);

                    dao.InsertMarca(te);
                    dao.Submit();
                    MessageBox.Show("Registro agregado exitosamente");
                    LlenarCamposMarca(te.Id);
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
                        errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar una marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Marcas te = new DataModel.Marcas();
                    
                    te.Id = Convert.ToInt32(txtId.Text);
                    te.Descripcion = txtMarca.Text;
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);

                    dao.EditMarca(te);
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
                    errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar una marca", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtId.Text);


                dao.DeleteMarca(id);
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
            IdMarca = 0;
            LlenarCamposMarca(new DataModel.Marcas());
        }
    }
}
