using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Marcas;
using DataModel.DAO.Modelo;
using DataModel.DAO.TecnoConexion;
using DataModel.DAO.EstadosDAO;
using DataModel.DAO.TipoEquipo;
using DataModel.DAO.Equipo;

namespace GestorAudioVisuales.Equipos
{
    public partial class CtrlEquipos : UserControl
    {
        public static int IdEquipo;

        public static CtrlEquipos _userCtrlEquipo;
        public static string titulo { get { return "Gestión de Equipos"; } }
        public static CtrlEquipos userCtrlEquipo
        {
            get
            {
                if (_userCtrlEquipo == null)
                {
                    _userCtrlEquipo = new CtrlEquipos();
                }
                return _userCtrlEquipo;
            }
        }

        public CtrlEquipos()
        {
            InitializeComponent();
        }

        private void CtrlEquipos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTipoEquipo();
                CargarMarcas();
                CargarModelos();
                CargarTecnoConexion();
                CargarEstados();

                if (IdEquipo != 0)
                {
                    LlenarCamposEquipo(IdEquipo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarMarcas()
        {
            MarcasDAO dao = new MarcasDAO();
            var data = dao.LoadMarcas();
            cmbMarca.DataSource = data;
            cmbMarca.DisplayMember = "Descripcion";
            cmbMarca.ValueMember = "Id";
        }

        private void CargarModelos()
        {
            ModeloDAO dao = new ModeloDAO();
            var data = dao.LoadModelos();
            cmbModelo.DataSource = data;
            cmbModelo.DisplayMember = "Descripcion";
            cmbModelo.ValueMember = "Id";
        }

        private void CargarTecnoConexion()
        {
            TecnoConexionDAO dao = new TecnoConexionDAO();
            var data = dao.LoadTecnoConexions();
            cmbConexion.DataSource = data;
            cmbConexion.DisplayMember = "Descripcion";
            cmbConexion.ValueMember = "Id";
        }

        private void CargarEstados()
        {
            EstadoDAO dao = new EstadoDAO();
            var data = dao.LoadEstados(3);
            cmbEstado.DataSource = data;
            cmbEstado.DisplayMember = "Descripcion";
            cmbEstado.ValueMember = "Id";
        }

        private void CargarTipoEquipo()
        {
            TipoEquipoDAO dao = new TipoEquipoDAO();
            var data = dao.LoadTipoEquipos();
            cmbTipoEquipo.DataSource = data;
            cmbTipoEquipo.DisplayMember = "Descripcion";
            cmbTipoEquipo.ValueMember = "Id";
        }

        private int ValidarCampos()
        {
            int flag = 0;

            if (string.IsNullOrEmpty(cmbTipoEquipo.Text))
            {
                cmbTipoEquipo.Focus();
                errorProvider1.SetError(cmbTipoEquipo, MessageBox.Show("El campo tipo de Equipo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbConexion.Text))
            {
                cmbConexion.Focus();
                errorProvider1.SetError(cmbConexion, MessageBox.Show("El campo tecnologia de conexión es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbMarca.Text))
            {
                cmbMarca.Focus();
                errorProvider1.SetError(cmbMarca, MessageBox.Show("El campo marca es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(cmbModelo.Text))
            {
                cmbModelo.Focus();
                errorProvider1.SetError(cmbModelo, MessageBox.Show("El campo modelo es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(txtSerial.Text))
            {
                txtSerial.Focus();
                errorProvider1.SetError(txtSerial, MessageBox.Show("El campo No.Serial es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                flag = 1;
            }

            if (string.IsNullOrEmpty(txtServiceTag.Text))
            {
                txtServiceTag.Focus();
                errorProvider1.SetError(txtServiceTag, MessageBox.Show("El campo Service tag es obligatorio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
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

        private void LlenarCamposEquipo(int idEquipo)
        {
            try
            {
                DataModel.Equipos eq;
                EquipoDAO dao = new EquipoDAO();
                {
                    eq = dao.GetEquipo(idEquipo);
                    txtId.Text = eq.Id.ToString();
                    txtDescripcion.Text = eq.Descripcion;
                    cmbEstado.SelectedValue = eq.Estado;
                    cmbModelo.SelectedValue = eq.IdMarca;
                    cmbModelo.SelectedValue = eq.IdModelo;
                    cmbEstado.SelectedValue = eq.IdTipoEquipo;
                    cmbConexion.SelectedValue = eq.IdTipoTecnologiaConexion;
                    txtSerial.Text = eq.No_Serial.ToString();
                    txtServiceTag.Text = eq.Service_tag;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LlenarCamposEquipo(DataModel.Equipos eq)
        {
            try
            {
                EquipoDAO dao = new EquipoDAO();
                {
                    txtId.Text = eq.Id.ToString();
                    txtDescripcion.Text = eq.Descripcion;
                    cmbEstado.SelectedValue = eq.Estado;
                    cmbModelo.SelectedValue = eq.IdMarca;
                    cmbModelo.SelectedValue = eq.IdModelo;
                    cmbEstado.SelectedValue = eq.IdTipoEquipo;
                    cmbConexion.SelectedValue = eq.IdTipoTecnologiaConexion;
                    txtSerial.Text = eq.No_Serial.ToString();
                    txtServiceTag.Text = eq.Service_tag;
                }
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
                    DataModel.Equipos eq = new DataModel.Equipos();
                    
                    eq.Descripcion = txtDescripcion.Text;
                    eq.Estado = Convert.ToInt32(cmbEstado.SelectedValue);
                    eq.IdMarca = Convert.ToInt32(cmbMarca.SelectedValue);
                    eq.IdModelo = Convert.ToInt32(cmbModelo.SelectedValue);
                    eq.IdTipoEquipo = Convert.ToInt32(cmbTipoEquipo.SelectedValue);
                    eq.IdTipoTecnologiaConexion = Convert.ToInt32(cmbConexion.SelectedValue);
                    eq.No_Serial = Convert.ToInt32(txtSerial.Text);
                    eq.Service_tag = txtServiceTag.Text;

                    EquipoDAO dao = new EquipoDAO();
                    {
                        dao.InsertEquipo(eq);
                        dao.Submit();
                        MessageBox.Show("Registro agregado exitosamente");

                        LlenarCamposEquipo(eq.Id);
                        // panelForm.Refresh();
                    }
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
                        errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar un equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                        return;
                    }

                    DataModel.Equipos eq = new DataModel.Equipos();

                    eq.Id = Convert.ToInt32(txtId.Text);
                    eq.Descripcion = txtDescripcion.Text;
                    eq.Estado = Convert.ToInt32(cmbEstado.SelectedValue);
                    eq.IdMarca = Convert.ToInt32(cmbModelo.SelectedValue);
                    eq.IdModelo = Convert.ToInt32(cmbModelo.SelectedValue);
                    eq.IdTipoEquipo = Convert.ToInt32(cmbEstado.SelectedValue);
                    eq.IdTipoTecnologiaConexion = Convert.ToInt32(cmbConexion.SelectedValue);
                    eq.No_Serial = Convert.ToInt32(txtSerial.Text);
                    eq.Service_tag = txtServiceTag.Text;

                    EquipoDAO dao = new EquipoDAO();
                    {
                        dao.EditEquipo(eq);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtId.Text) && txtId.Text != "0")
                {
                    txtId.Focus();
                    errorProvider1.SetError(txtId, MessageBox.Show("Debe seleccionar un equipo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error).ToString());
                    return;
                }
                int id = Convert.ToInt32(txtId.Text);

                EquipoDAO dao = new EquipoDAO();
                {
                    dao.DeleteEquipo(id);
                    dao.Submit();
                    MessageBox.Show("Registro eliminado exitosamente");
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            IdEquipo = 0;
            LlenarCamposEquipo(new DataModel.Equipos());
        }
    }
}
