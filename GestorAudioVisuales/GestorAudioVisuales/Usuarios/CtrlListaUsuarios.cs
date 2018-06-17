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

namespace GestorAudioVisuales.Usuarios
{
    public partial class CtrlListaUsuarios : UserControl
    {
        UsuarioDAO dao = new UsuarioDAO();

        public static CtrlListaUsuarios _userCtrlListaUsuarios;
        public static string titulo { get { return "Lista de Usuarios"; } }
        public static CtrlListaUsuarios userCtrlListaUsuarios
        {
            get
            {
                if (_userCtrlListaUsuarios == null)
                {
                    _userCtrlListaUsuarios = new CtrlListaUsuarios();
                }
                return _userCtrlListaUsuarios;
            }
        }

        public CtrlListaUsuarios()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            gridUsuarios.DataSource = dao.LoadUsuarios(cbmCriterio.SelectedItem.ToString(), txtBuscar.text);
            txtBuscar.text = string.Empty;
        }

        private void gridUsuarios_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells[0].Value);
            CtrlUsuarios.IdUsuario = id;
        }

        protected void CargarUsuarios()
        {
            try
            {

                gridUsuarios.DataSource = dao.LoadUsuarios();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CtrlListaUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                CargarUsuarios();
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
                cbmCriterio.DataSource = dao.LoadCriteriosBusqueda();
                cbmCriterio.DisplayMember = "Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
