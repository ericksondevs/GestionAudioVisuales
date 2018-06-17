using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Renta;

namespace GestorAudioVisuales.Prestamos
{
    public partial class CtrlListaPrestamos : UserControl
    {
        RentaDAO dao = new RentaDAO();
        public static CtrlListaPrestamos _userCtrlListaPrestamos;
        public static string titulo { get { return "Renta y devoluciones"; } }
        public static CtrlListaPrestamos userCtrlListaPrestamos
        {
            get
            {
                if (_userCtrlListaPrestamos == null)
                {
                    _userCtrlListaPrestamos = new CtrlListaPrestamos();
                }
                return _userCtrlListaPrestamos;
            }
        }

        public CtrlListaPrestamos()
        {
            InitializeComponent();
        }

        protected void CargarRentas()
        {
            try
            {
                gridRenta.DataSource = dao.LoadRenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo recuperar la información. " + ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridRenta.DataSource = dao.LoadRentas(cmbCriterio.SelectedItem.ToString(), txtBuscar.text);
            txtBuscar.text = string.Empty;
        }

        private void CtrlListaPrestamos_Load(object sender, EventArgs e)
        {
            CargarRentas();
            CargarCriteriosBusqueda();
        }

        private void CargarCriteriosBusqueda()
        {
            cmbCriterio.DataSource = dao.LoadCriteriosBusqueda();
            cmbCriterio.DisplayMember = "Name";
        }

        private void gridRenta_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridRenta.Rows[gridRenta.CurrentRow.Index].Cells[0].Value);
            CtrlPrestamos.IdPrestamo = id;
        }
    }
}
