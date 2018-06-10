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

namespace GestorAudioVisuales.Empleados
{
    public partial class CtrlListaEmpleados : UserControl
    {
        public static CtrlListaEmpleados _userCtrlListaEmpleados;
        public static string titulo { get { return "Lista de Empleados"; } }
        public static CtrlListaEmpleados userCtrlListaEmpleados
        {
            get
            {
                if (_userCtrlListaEmpleados == null)
                {
                    _userCtrlListaEmpleados = new CtrlListaEmpleados();
                }
                return _userCtrlListaEmpleados;
            }
        }
        public CtrlListaEmpleados()
        {
            InitializeComponent();
        }

        protected void CargarEmpleados()
        {
            EmpleadoDAO dao = new EmpleadoDAO();
            {
                gridEmpleados.DataSource = dao.LoadEmpleados();
            }
        }

        private void CtrlListaEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarCriteriosBusqueda();


          
        }
     
        private void CargarCriteriosBusqueda()
        {
            EmpleadoDAO dao = new EmpleadoDAO();
            {
                cbmCriterio.DataSource = dao.LoadCriteriosBusqueda();
                cbmCriterio.DisplayMember = "Name";
            }
        }
        private void gridEmpleados_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridEmpleados.Rows[gridEmpleados.CurrentRow.Index].Cells[0].Value);
            CtrlEmpleados.IdEmpleado = id;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            EmpleadoDAO dao = new EmpleadoDAO();
            {
                gridEmpleados.DataSource = dao.LoadEmpleados(cbmCriterio.SelectedItem.ToString(), txtBuscar.text);
                txtBuscar.text = string.Empty;
            }
        }
    }
}
