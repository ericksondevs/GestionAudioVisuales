using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel;
using DataModel.DAO.Empleado;
using DataModel.DAO.TandaLabor;
using DataModel.DAO.EstadosDAO;
using DataModel.Validadores;

namespace GestorAudioVisuales.Empleados
{
    public partial class CtrlEmpleados : UserControl
    {
        public static int IdEmpleado;

        public static CtrlEmpleados _userCtrlEmpleado;
        public static string titulo { get { return "Gestión de Empleados"; } }
        public static CtrlEmpleados userCtrlEmpleado
        {
            get
            {
                if (_userCtrlEmpleado == null)
                {
                    _userCtrlEmpleado = new CtrlEmpleados();
                }
                return _userCtrlEmpleado;

            }
        }

        public CtrlEmpleados()
        {
            InitializeComponent();

            if (IdEmpleado != 0)
            {
                LlenarCamposEmpleado(IdEmpleado);
            }
        }
        private void CtrlEmpleados_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                // BtnEliminar.Enabled = false;
                // BtnModificar.Enabled = false;
            }
            CargarEstados();
            CargarTandas();

            if (IdEmpleado != 0)
            {
                LlenarCamposEmpleado(IdEmpleado);
            }
        }
        private void CargarTandas()
        {
            TandaLaborDAO dao = new TandaLaborDAO();
            var data = dao.LoadTandas();
            cmbTanda.DataSource = data;
            cmbTanda.DisplayMember = "Tanda";
            cmbTanda.ValueMember = "Id";
        }

        private void CargarEstados()
        {
            EstadoDAO dao = new EstadoDAO();
            var data = dao.LoadEstados(2);
            cmbEstado.DataSource = data;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "Id";
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

            if (string.IsNullOrEmpty(cmbTanda.Text))
            {
                cmbTanda.Focus();
                errorProvider1.SetError(cmbTanda, MessageBox.Show("El campo tanda es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(txtFechaIngreso.Value.ToString()))
            {
                txtFechaIngreso.Focus();
                errorProvider1.SetError(txtFechaIngreso, MessageBox.Show("El campo fecha es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
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
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos() == 0)
                {
                    DataModel.Empleados emp = new DataModel.Empleados();

                    emp.Nombre = txtNombre.Text;
                    emp.IdTandaLabor = Convert.ToInt16(cmbTanda.SelectedValue);
                    emp.Estado = Convert.ToInt16(cmbEstado.SelectedValue);
                    emp.Cedula = txtCedula.Text.Replace("-", "");
                    emp.FechaIngreso = txtFechaIngreso.Value;

                    EmpleadoDAO dao = new EmpleadoDAO();
                    {
                        dao.InsertEmpleado(emp);
                        dao.Submit();
                        MessageBox.Show("Registro agregado exitosamente");

                        LlenarCamposEmpleado(emp.Id);
                        // panelForm.Refresh();
                    }
                    errorProvider1.Clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LlenarCamposEmpleado(DataModel.Empleados emp)
        {
            try
            {
                EmpleadoDAO dao = new EmpleadoDAO();
                {
                    txtId.Text = emp.Id.ToString();
                    txtNombre.Text = emp.Nombre;
                    cmbTanda.SelectedValue = emp.IdTandaLabor;
                    cmbEstado.SelectedValue = emp.Estado;
                    txtCedula.Text = emp.Cedula;
                    txtFechaIngreso.Value = emp.FechaIngreso;
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposEmpleado(int id)
        {
            try
            {
                DataModel.Empleados emp;
                EmpleadoDAO dao = new EmpleadoDAO();
                {
                    emp = dao.LoadEmpleado(id);
                    txtId.Text = id.ToString();
                    txtNombre.Text = emp.Nombre;
                    cmbTanda.SelectedValue = emp.IdTandaLabor;
                    cmbEstado.SelectedValue = emp.Estado;
                    txtCedula.Text = emp.Cedula;
                    txtFechaIngreso.Value = emp.FechaIngreso;
                }
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
                        errorProvider1.SetError(txtCedula, MessageBox.Show("Debe seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Empleados emp = new DataModel.Empleados();

                    emp.Id = Convert.ToInt32(txtId.Text);
                    emp.Nombre = txtNombre.Text;
                    emp.IdTandaLabor = Convert.ToInt16(cmbTanda.SelectedValue);
                    emp.Estado = Convert.ToInt16(cmbEstado.SelectedValue); ;
                    emp.Cedula = txtCedula.Text.Replace("-", ""); ;
                    emp.FechaIngreso = txtFechaIngreso.Value;

                    EmpleadoDAO dao = new EmpleadoDAO();
                    {
                        dao.EditEmpleado(emp);
                        dao.Submit();
                        MessageBox.Show("Registro modificado exitosamente");
                    }
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
                    errorProvider1.SetError(txtCedula, MessageBox.Show("Debe seleccionar un empleado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtId.Text);

                EmpleadoDAO dao = new EmpleadoDAO();
                {
                    dao.DeleteEmpleado(id);
                    dao.Submit();
                    MessageBox.Show("Registro eliminado exitosamente");
                LimpiarCampos();

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            IdEmpleado = 0;
            LlenarCamposEmpleado(new DataModel.Empleados() { FechaIngreso = DateTime.Now });
        }
    }
}
