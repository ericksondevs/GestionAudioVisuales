using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataModel.DAO.Modelo;

namespace GestorAudioVisuales.Modelos
{
    public partial class CtrlListaModelos : UserControl
    {
        ModeloDAO dao = new ModeloDAO();

        public static CtrlListaModelos _userCtrlListaModelo;
        public static string titulo { get { return "Lista de Modelos"; } }
        public static CtrlListaModelos user_userCtrlListaModelos
        {
            get
            {
                if (_userCtrlListaModelo == null)
                {
                    _userCtrlListaModelo = new CtrlListaModelos();
                }
                return _userCtrlListaModelo;
            }
        }

        public CtrlListaModelos()
        {
            InitializeComponent();
        }

        private void gridModelos_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(gridModelos.Rows[gridModelos.CurrentRow.Index].Cells[0].Value);
                CtrlModelos.IdModelo = id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void CtrlListaModelos_Load(object sender, EventArgs e)
        {
            try
            {
                CargarModelos();
                CargarCriteriosBusqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected void CargarModelos()
        {
            try
            {
                gridModelos.DataSource = dao.LoadModelos();
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

                gridModelos.DataSource = dao.LoadModelos(cmbCriterio.SelectedItem.ToString(), txtBuscar.text);
                txtBuscar.text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
