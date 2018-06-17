using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Empleado;
using DataModel.DAO.Equipo;
using DataModel.DAO.Usuario;
using DataModel.DAO.EstadosDAO;
using DataModel.DAO.Renta;

namespace GestorAudioVisuales.Prestamos
{
    public partial class CtrlPrestamos : UserControl
    {
        public static int IdPrestamo;
        RentaDAO dao = new RentaDAO();

        public static CtrlPrestamos _userCtrlPrestamos;
        public static string titulo { get { return "Gestión de Préstamos y Devoluciones"; } }
        public static CtrlPrestamos userCtrlEquipo
        {
            get
            {
                if (_userCtrlPrestamos == null)
                {
                    _userCtrlPrestamos = new CtrlPrestamos();
                }
                return _userCtrlPrestamos;
            }
        }

        public CtrlPrestamos()
        {
            InitializeComponent();

            if (cmbEstado.SelectedItem == "")
            {
                txtFechaDevolucion.BackColor = Color.LightGray;
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstado.SelectedItem == "")
            {
                txtFechaDevolucion.Enabled = true;
                txtFechaDevolucion.BackColor = Color.LightGray;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {
                    DataModel.Rentas eq = new DataModel.Rentas();

                    eq.IdEmpleado = Convert.ToInt16(cmbEmpleado.SelectedValue);
                    eq.IdEquipo = Convert.ToInt16(cmbEquipo.SelectedValue);
                    eq.IdUsuario = Convert.ToInt16(cmbUsuario.SelectedValue);
                    eq.FechaPrestamo = txtFechaPrestamo.Value;
                    eq.Estado = Convert.ToInt16(cmbEstado.SelectedValue);
                    eq.FechaDevolucion = txtFechaDevolucion.Value;
                    eq.Comentario = txtComentario.Text;

                 
                        dao.InsertRenta(eq);
                        dao.Submit();
                        MessageBox.Show("Registro agregado exitosamente");

                        LlenarCamposRenta(eq.NoPrestamo);

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

                    if (string.IsNullOrEmpty(txtNoPrestamo.Text) && txtNoPrestamo.Text != "0")
                    {
                        txtNoPrestamo.Focus();
                        errorProvider1.SetError(txtNoPrestamo, MessageBox.Show("Debe seleccionar una renta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Rentas eq = new DataModel.Rentas();
                    
                    eq.NoPrestamo = Convert.ToInt32(txtNoPrestamo.Text);

                    eq.IdEmpleado = Convert.ToInt16(cmbEmpleado.SelectedValue);
                    eq.IdEquipo = Convert.ToInt16(cmbEquipo.SelectedValue);
                    eq.IdUsuario = Convert.ToInt16(cmbUsuario.SelectedValue);
                    eq.FechaPrestamo = txtFechaPrestamo.Value;
                    eq.Estado = Convert.ToInt16(cmbEstado.SelectedValue);
                    eq.FechaDevolucion = txtFechaDevolucion.Value;
                    eq.Comentario = txtComentario.Text;

                 
                        dao.EditRenta(eq);
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
                if (string.IsNullOrEmpty(txtNoPrestamo.Text) && txtNoPrestamo.Text != "0")
                {
                    txtNoPrestamo.Focus();
                    errorProvider1.SetError(txtNoPrestamo, MessageBox.Show("Debe seleccionar una renta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtNoPrestamo.Text);

                
                    dao.DeleteRenta(id);
                    dao.Submit();
                    MessageBox.Show("Registro eliminado exitosamente");
                    LimpiarCampos();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            IdPrestamo = 0;
            LlenarCamposRenta(new DataModel.Rentas());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CtrlPrestamos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarEmpleados();
                CargarEquipos();
                CargarUsuarios();
                CargarEstados();

                if (IdPrestamo != 0)
                {
                    LlenarCamposRenta(IdPrestamo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarEmpleados()
        {
            EmpleadoDAO dao = new EmpleadoDAO();
            var data = dao.LoadEmpleados();
            cmbEmpleado.DataSource = data;
            cmbEmpleado.DisplayMember = "Descripcion";
            cmbEmpleado.ValueMember = "Id";
        }

        private void CargarEquipos()
        {
            EquipoDAO dao = new EquipoDAO();
            var data = dao.LoadEquipo();
            cmbEquipo.DataSource = data;
            cmbEquipo.DisplayMember = "Descripcion";
            cmbEquipo.ValueMember = "Id";
        }

        private void CargarUsuarios()
        {
            UsuarioDAO dao = new UsuarioDAO();
            var data = dao.LoadUsuarios();
            cmbUsuario.DataSource = data;
            cmbUsuario.DisplayMember = "Descripcion";
            cmbUsuario.ValueMember = "Id";
        }

        private void CargarEstados()
        {
            EstadoDAO dao = new EstadoDAO();
            var data = dao.LoadEstados(3);
            cmbEstado.DataSource = data;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "Id";
        }

        private int ValidarCampos()
        {
            int flag = 0;

            if (string.IsNullOrEmpty(cmbEmpleado.SelectedText))
            {
                cmbEmpleado.Focus();
                errorProvider1.SetError(cmbEmpleado, MessageBox.Show("El campo empleado es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbEquipo.SelectedText))
            {
                cmbEquipo.Focus();
                errorProvider1.SetError(cmbEquipo, MessageBox.Show("El campo equipo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbUsuario.SelectedText))
            {
                cmbUsuario.Focus();
                errorProvider1.SetError(cmbUsuario, MessageBox.Show("El campo usuario es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(txtFechaPrestamo.Text))
            {
                txtFechaPrestamo.Focus();
                errorProvider1.SetError(txtFechaPrestamo, MessageBox.Show("El campo fecha préstamo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (cmbEstado.SelectedItem == "")
            {
                if (string.IsNullOrEmpty(txtFechaDevolucion.Text))
                {
                    txtFechaDevolucion.Focus();
                    errorProvider1.SetError(txtFechaDevolucion, MessageBox.Show("El campo fecha devolución es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    flag = 1;
                }
            }

            if (string.IsNullOrEmpty(cmbEstado.Text))
            {
                cmbEstado.Focus();
                errorProvider1.SetError(cmbEstado, MessageBox.Show("El campo estado es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            return flag;
        }

        private void LlenarCamposRenta(int idRenta)
        {
            try
            {
                DataModel.Rentas eq;

                eq = dao.GetRenta(idRenta);

                txtNoPrestamo.Text = eq.NoPrestamo.ToString();
                cmbEmpleado.SelectedValue = eq.IdEmpleado;
                cmbEquipo.SelectedValue = eq.IdEquipo;
                cmbUsuario.SelectedValue = eq.IdUsuario;
                txtFechaPrestamo.Value = eq.FechaPrestamo;
                cmbEstado.SelectedValue = eq.Estado;
                txtFechaDevolucion.Value = eq.FechaDevolucion;
                txtComentario.Text = eq.Comentario;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposRenta(DataModel.Rentas eq)
        {
            try
            {
                    txtNoPrestamo.Text = eq.NoPrestamo.ToString();
                    cmbEmpleado.SelectedValue = eq.IdEmpleado;
                    cmbEquipo.SelectedValue = eq.IdEquipo;
                    cmbUsuario.SelectedValue = eq.IdUsuario;
                    txtFechaPrestamo.Value = eq.FechaPrestamo;
                    cmbEstado.SelectedValue = eq.Estado;
                    txtFechaDevolucion.Value = eq.FechaDevolucion;
                    txtComentario.Text = eq.Comentario;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
