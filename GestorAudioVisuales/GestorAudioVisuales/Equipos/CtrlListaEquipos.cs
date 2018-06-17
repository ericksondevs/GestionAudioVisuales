using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Equipo;

namespace GestorAudioVisuales.Equipos
{
    public partial class CtrlListaEquipos : UserControl
    {
        EquipoDAO dao = new EquipoDAO();

        public static CtrlListaEquipos _userCtrlListaEquipos;
        public static string titulo { get { return "Lista de Equipos"; } }
        public static CtrlListaEquipos userCtrlListaEquipos
        {
            get
            {
                if (_userCtrlListaEquipos == null)
                {
                    _userCtrlListaEquipos = new CtrlListaEquipos();
                }
                return _userCtrlListaEquipos;
            }
        }

        public CtrlListaEquipos()
        {
            InitializeComponent();
        }

        protected void CargarEquipos()
        {
            try
            {
                gridEquipo.DataSource = dao.LoadEquipo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo recuperar la información. " + ex.Message);
            }
        }

        private void CtrlListaEquipos_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            CargarCriteriosBusqueda();
        }

        private void CargarCriteriosBusqueda()
        {
            cmbCriterio.DataSource = dao.LoadCriteriosBusqueda();
            cmbCriterio.DisplayMember = "Name";
        }

        private void gridEquipo_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridEquipo.Rows[gridEquipo.CurrentRow.Index].Cells[0].Value);
            CtrlEquipos.IdEquipo = id;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridEquipo.DataSource = dao.LoadEquipos(cmbCriterio.SelectedItem.ToString(), txtBuscar.text);
            txtBuscar.text = string.Empty;
        }
    }
}
