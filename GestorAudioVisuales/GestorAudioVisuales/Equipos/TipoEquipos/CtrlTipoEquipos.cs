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
using DataModel.DAO.TipoEquipo;

namespace GestorAudioVisuales.Equipos.TipoEquipos
{
    public partial class CtrlTipoEquipos : UserControl
    {
        public static int IdTipoEquipo;
        TipoEquipoDAO dao = new TipoEquipoDAO();

        public static CtrlTipoEquipos _userCtrlTipoEquipos;
        public static string titulo { get { return "Gestión de tipo de equipos"; } }
        public static CtrlTipoEquipos userCtrlTipoEquipos
        {
            get
            {
                if (_userCtrlTipoEquipos == null)
                {
                    _userCtrlTipoEquipos = new CtrlTipoEquipos();
                }
                return _userCtrlTipoEquipos;
            }
        }

        public CtrlTipoEquipos()
        {
            InitializeComponent();
        }

        private void CtrlTipoEquipos_Load(object sender, EventArgs e)
        {
            CargarEstados();

            if (IdTipoEquipo != 0)
            {
                LlenarCamposTipoEquipo(IdTipoEquipo);
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

            if (string.IsNullOrEmpty(txtTipoEquipo.Text))
            {
                txtTipoEquipo.Focus();
                errorProvider1.SetError(txtTipoEquipo, MessageBox.Show("El campo tipo de Equipo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
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

        private void LlenarCamposTipoEquipo(int idTipoEquipo)
        {
            try
            {
                DataModel.TipoEquipos te;

                {
                    te = dao.GetTipoEquipo(idTipoEquipo);
                    txtId.Text = te.Id.ToString();
                    txtTipoEquipo.Text = te.Descripcion;
                    cmbEstado.SelectedValue = te.Estado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposTipoEquipo(DataModel.TipoEquipos te)
        {
            try
            {
                txtId.Text = te.Id.ToString();
                txtTipoEquipo.Text = te.Descripcion;
                cmbEstado.SelectedValue = te.Estado;
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
                    DataModel.TipoEquipos te = new DataModel.TipoEquipos();

                    te.Descripcion = txtTipoEquipo.Text;
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);

                    dao.InsertTipoEquipo(te);
                    dao.Submit();
                    MessageBox.Show("Registro agregado exitosamente");
                    LlenarCamposTipoEquipo(te.Id);
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
                        errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar un tipo de equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.TipoEquipos te = new DataModel.TipoEquipos();

                    te.Id = Convert.ToInt32(txtId.Text);
                    te.Descripcion = txtTipoEquipo.Text;
                    te.Estado = Convert.ToInt32(cmbEstado.SelectedValue);

                    dao.EditTipoEquipo(te);
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
                    errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar un tipo de equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtId.Text);

               
                    dao.DeleteTipoEquipo(id);
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
            IdTipoEquipo = 0;
            LlenarCamposTipoEquipo(new DataModel.TipoEquipos());
        }
    }
}
