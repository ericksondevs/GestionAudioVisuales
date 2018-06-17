using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.TipoEquipo;

namespace GestorAudioVisuales.Equipos.TipoEquipos
{
    public partial class CtrlListaTipoEquipos : UserControl
    {
        TipoEquipoDAO dao = new TipoEquipoDAO();
        public static CtrlListaTipoEquipos _userCtrlListaTipoEquipos;
        public static string titulo { get { return "Lista de tipo de Equipos"; } }
        public static CtrlListaTipoEquipos userCtrlListaTipoEquipos
        {
            get
            {
                if (_userCtrlListaTipoEquipos == null)
                {
                    _userCtrlListaTipoEquipos = new CtrlListaTipoEquipos();
                }
                return _userCtrlListaTipoEquipos;
            }
        }

        public CtrlListaTipoEquipos()
        {
            InitializeComponent();
        }

        private void CtrlListaTipoEquipos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarTipoEquipos();
                CargarCriteriosBusqueda();
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
                gridTipoEquipo.DataSource = dao.LoadTipoEquipos(cmbCriterio.SelectedItem.ToString(), txtBuscar.text);
                txtBuscar.text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void CargarTipoEquipos()
        {
            try
            {
                gridTipoEquipo.DataSource = dao.LoadTipoEquipos();
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

        private void gridTipoEquipo_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gridTipoEquipo.Rows[gridTipoEquipo.CurrentRow.Index].Cells[0].Value);
                CtrlTipoEquipos.IdTipoEquipo = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
