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

namespace GestorAudioVisuales.Marcas
{
    public partial class CtrlListaMarcas : UserControl
    {
        MarcasDAO dao = new MarcasDAO();

        public static CtrlListaMarcas _userCtrlListaMarcas;
        public static string titulo { get { return "Lista de Marcas"; } }
        public static CtrlListaMarcas userCtrlListaMarcas
        {
            get
            {
                if (_userCtrlListaMarcas == null)
                {
                    _userCtrlListaMarcas = new CtrlListaMarcas();
                }
                return _userCtrlListaMarcas;
            }
        }

        public CtrlListaMarcas()
        {
            InitializeComponent();
        }

        private void CtrlListaMarcas_Load(object sender, EventArgs e)
        {
            try
            {
                CargarMarcas();
                CargarCriteriosBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void CargarMarcas()
        {
            try
            {
                gridMarcas.DataSource = dao.LoadMarcas();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                
                gridMarcas.DataSource = dao.LoadMarcas(cmbCriterio.SelectedItem.ToString(), txtBuscar.text);
                txtBuscar.text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridMarcas_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gridMarcas.Rows[gridMarcas.CurrentRow.Index].Cells[0].Value);
                CtrlMarcas.IdMarca = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
