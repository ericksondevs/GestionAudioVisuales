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

namespace GestorAudioVisuales.TecnoConexion
{
    public partial class CtrlListaTecnoConexion : UserControl
    {
        TecnoConexionDAO dao = new TecnoConexionDAO();

        public static CtrlListaTecnoConexion _userCtrlListaTecnoConexion;
        public static string titulo { get { return "Lista de Tecnologías de Conexión"; } }
        public static CtrlListaTecnoConexion user_userCtrlListaTecnoConexion
        {
            get
            {
                if (_userCtrlListaTecnoConexion == null)
                {
                    _userCtrlListaTecnoConexion = new CtrlListaTecnoConexion();
                }
                return _userCtrlListaTecnoConexion;
            }
        }

        public CtrlListaTecnoConexion()
        {
            InitializeComponent();
        }

        private void CtrlListaTecnoConexion_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTecnoConexion();
                CargarCriteriosBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CargarCriteriosBusqueda()
        {
            try
            {
                cmbCriterio.DataSource = dao.LoadCriteriosBusqueda();
                cmbCriterio.DisplayMember = "Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void CargarTecnoConexion()
        {
            try
            {
                gridTecnoConexion.DataSource = dao.LoadTecnoConexions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                gridTecnoConexion.DataSource = dao.LoadTecnoConexions(cmbCriterio.SelectedItem.ToString(), txtBuscar.text);
                txtBuscar.text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CtrlListaTecnoConexion_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gridTecnoConexion.Rows[gridTecnoConexion.CurrentRow.Index].Cells[0].Value);
                CtrlTecnoConexion.IdTecnoConexion = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
