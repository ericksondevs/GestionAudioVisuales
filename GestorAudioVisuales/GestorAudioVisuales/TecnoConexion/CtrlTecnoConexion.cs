using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.TecnoConexion;
using DataModel.DAO.EstadosDAO;

namespace GestorAudioVisuales.TecnoConexion
{
    public partial class CtrlTecnoConexion : UserControl
    {
        public static int IdTecnoConexion;
        TecnoConexionDAO dao = new TecnoConexionDAO();

        public static CtrlTecnoConexion _userCtrlTecnoConexion;
        public static string titulo { get { return "Gestión de Empleados"; } }
        public static CtrlTecnoConexion userCtrlTecnoConexion
        {
            get
            {
                if (_userCtrlTecnoConexion == null)
                {
                    _userCtrlTecnoConexion = new CtrlTecnoConexion();
                }
                return _userCtrlTecnoConexion;

            }
        }

        public CtrlTecnoConexion()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {
                    DataModel.Tecnologias_Conexion te = new DataModel.Tecnologias_Conexion();
                    
                    te.Descripcion = txtConexion.Text;
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);
                    
                    dao.InsertTecnologias_Conexion(te);
                    dao.Submit();
                    MessageBox.Show("Registro agregado exitosamente");
                    LlenarCamposTecnoConexion(te.Id);
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
                        errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar una tecnologia de conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Tecnologias_Conexion te = new DataModel.Tecnologias_Conexion();
                    
                    te.Id = Convert.ToInt32(txtId.Text);
                    te.Descripcion = txtConexion.Text;
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);

                    dao.EditTecnologias_Conexion(te);
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
                    errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar una tecnologia de conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtId.Text);


                dao.DeleteTecnoConexion(id);
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
            IdTecnoConexion = 0;
            LlenarCamposTecnoConexion(new DataModel.Tecnologias_Conexion());
        }

        private void CtrlTecnoConexion_Load(object sender, EventArgs e)
        {
            CargarEstados();

            if (IdTecnoConexion != 0)
            {
                LlenarCamposTecnoConexion(IdTecnoConexion);
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

        private int ValidarCampos()
        {
            int flag = 0;
            
            if (string.IsNullOrEmpty(txtConexion.Text))
            {
                txtConexion.Focus();
                errorProvider1.SetError(txtConexion, MessageBox.Show("El campo tecnologia de conexión es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
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

        private void LlenarCamposTecnoConexion(int idTecno)
        {
            try
            {
                DataModel.Tecnologias_Conexion ma;

                {
                    ma = dao.GetTecnologias_Conexion(idTecno);
                    txtId.Text = ma.Id.ToString();
                    txtConexion.Text = ma.Descripcion;
                    cmbEstado.SelectedValue = ma.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposTecnoConexion(DataModel.Tecnologias_Conexion mo)
        {
            try
            {
                txtId.Text = mo.Id.ToString();
                txtConexion.Text = mo.Descripcion;
                cmbEstado.SelectedValue = mo.Estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
