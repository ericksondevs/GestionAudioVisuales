using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Usuario;
using DataModel.Validadores;
using DataModel.DAO.EstadosDAO;
using DataModel.DAO.TipoPersona;
using DataModel.DAO.TipoUsuario;

namespace GestorAudioVisuales.Usuarios
{
    public partial class CtrlUsuarios : UserControl
    {
        public static int IdUsuario;
        UsuarioDAO dao = new UsuarioDAO();

        public static CtrlUsuarios _userCtrlUsuarios;
        public static string titulo { get { return "Gestión de Usuarios"; } }
        public static CtrlUsuarios user_userCtrlUsuarios
        {
            get
            {
                if (_userCtrlUsuarios == null)
                {
                    _userCtrlUsuarios = new CtrlUsuarios();
                }
                return _userCtrlUsuarios;

            }
        }

        public CtrlUsuarios()
        {
            InitializeComponent();
        }

        private void LlenarCamposUsuario(DataModel.Usuarios emp)
        {
            try
            {
                txtId.Text = emp.Id.ToString();

                txtNombre.Text = emp.Nombre;
                cmbTipoPersona.SelectedValue = emp.IdTipoPersona;
                cmbUsuario.SelectedValue = emp.IdTipoUsuario;
                txtNoCarnet.Text = emp.No_Carnet.ToString();
                cmbEstado.SelectedValue = emp.Estado;
                txtCedula.Text = emp.Cedula;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposUsuario(int id)
        {
            try
            {
                DataModel.Usuarios emp;

                emp = dao.GetUsuario(id);
                txtId.Text = emp.Id.ToString();

                txtNombre.Text = emp.Nombre;
                cmbTipoPersona.SelectedValue = emp.IdTipoPersona;
                cmbUsuario.SelectedValue = emp.IdTipoUsuario;
                txtNoCarnet.Text = emp.No_Carnet.ToString();
                cmbEstado.SelectedValue = emp.Estado;
                txtCedula.Text = emp.Cedula;

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
                    DataModel.Usuarios emp = new DataModel.Usuarios();

                    emp.Nombre = txtNombre.Text;
                    emp.IdTipoPersona = Convert.ToInt16(cmbTipoPersona.SelectedValue);
                    emp.IdTipoUsuario = Convert.ToInt16(cmbUsuario.SelectedValue);
                    emp.No_Carnet = Convert.ToInt32(txtNoCarnet.Text);
                    emp.Estado = Convert.ToInt16(cmbEstado.SelectedValue);
                    emp.Cedula = txtCedula.Text.Replace("-", "");


                    dao.InsertUsuario(emp);
                    dao.Submit();
                    MessageBox.Show("Registro agregado exitosamente");

                    LlenarCamposUsuario(emp.Id);
                    // panelForm.Refresh();
                }
                errorProvider1.Clear();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {

                    if (string.IsNullOrEmpty(txtId.Text) && txtId.Text != "0")
                    {
                        txtId.Focus();
                        errorProvider1.SetError(txtCedula, MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Usuarios emp = new DataModel.Usuarios();

                    emp.Id = Convert.ToInt32(txtId.Text);

                    emp.Nombre = txtNombre.Text;
                    emp.IdTipoPersona = Convert.ToInt16(cmbTipoPersona.SelectedValue);
                    emp.IdTipoUsuario = Convert.ToInt16(cmbUsuario.SelectedValue);
                    emp.No_Carnet = Convert.ToInt32(txtNoCarnet.Text);
                    emp.Estado = Convert.ToInt16(cmbEstado.SelectedValue);
                    emp.Cedula = txtCedula.Text.Replace("-", "");


                    dao.EditUsuario(emp);
                    dao.Submit();
                    MessageBox.Show("Registro modificado exitosamente");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text) && txtId.Text != "0")
            {
                txtId.Focus();
                errorProvider1.SetError(txtCedula, MessageBox.Show("Debe seleccionar un usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                return;
            }
            int id = Convert.ToInt32(txtId.Text);
          
                dao.DeleteUsuario(id);
                dao.Submit();
                MessageBox.Show("Registro eliminado exitosamente");
                LimpiarCampos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            IdUsuario = 0;
            LlenarCamposUsuario(new DataModel.Usuarios());
        }

        private int ValidarCampos()
        {
            int flag = 0;
            if (string.IsNullOrEmpty(txtCedula.Text))
            {
                txtCedula.Focus();
                errorProvider1.SetError(txtCedula, MessageBox.Show("El campo cédula es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            else if (!ValidadorCedula.valida_cedula(txtCedula.Text))
            {
                txtCedula.Focus();
                errorProvider1.SetError(txtCedula, MessageBox.Show("La cédula ingresada es inválida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                txtCedula.Focus();
                errorProvider1.SetError(txtNombre, MessageBox.Show("El campo nombre es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            
            if (string.IsNullOrEmpty(cmbUsuario.SelectedItem.ToString()))
            {
                cmbUsuario.Focus();
                errorProvider1.SetError(cmbUsuario, MessageBox.Show("El campo usuario es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }
            
            if (string.IsNullOrEmpty(cmbTipoPersona.SelectedItem.ToString()))
            {
                cmbTipoPersona.Focus();
                errorProvider1.SetError(cmbTipoPersona, MessageBox.Show("El campo tipo persona es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
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

        private void CtrlUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTipoUsuario();
                CargarTipoPersonas();
                CargarEstados();
               
                if (IdUsuario != 0)
                {
                    LlenarCamposUsuario(IdUsuario);
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

        private void CargarTipoPersonas()
        {
            TipoPersonaDAO dao = new TipoPersonaDAO();
            cmbTipoPersona.DataSource = dao.loadTipoPersonas();
            cmbTipoPersona.DisplayMember = "Descripcion";
            cmbTipoPersona.ValueMember = "Id";
        }

        private void CargarTipoUsuario()
        {
            TipoUsuarioDAO dao = new TipoUsuarioDAO();
            cmbUsuario.DataSource = dao.loadTipoUsuarios();
            cmbUsuario.DisplayMember = "Descripcion";
            cmbUsuario.ValueMember = "Id";
        }
    }
}
