using GestorAudioVisuales.Equipos;
using GestorAudioVisuales.Empleados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorAudioVisuales.Prestamos;
using GestorAudioVisuales.Seguridad;
using GestorAudioVisuales.Equipos.TipoEquipos;
using GestorAudioVisuales.Marcas;
using GestorAudioVisuales.Modelos;
using GestorAudioVisuales.TecnoConexion;
using GestorAudioVisuales.Usuarios;

namespace GestorAudioVisuales
{
    public partial class Principal : MetroFramework.Forms.MetroForm
    {
        public event EventHandler ListItemSelected;

        public static Principal _Principal;
        public static Principal FrmPrincipal
        {
            get
            {
                if (_Principal == null)
                {
                    _Principal = new Principal();
                }
                return _Principal;
            }
        }

        public Principal()
        {
            InitializeComponent();
        }

        void toggle(object sender)
        {
            btnEmpleados.selected = false;
            btnEmpleados.Normalcolor = Color.FromArgb(14, 77, 146);
            btnEquipos.selected = false;
            btnEquipos.Normalcolor = Color.FromArgb(14, 77, 146);
            btnMarcas.selected = false;
            btnMarcas.Normalcolor = Color.FromArgb(14, 77, 146);
            btnModelos.selected = false;
            btnModelos.Normalcolor = Color.FromArgb(14, 77, 146);
            btnPrestamos.selected = false;
            btnPrestamos.Normalcolor = Color.FromArgb(14, 77, 146);
            btnTecno.selected = false;
            btnTecno.Normalcolor = Color.FromArgb(14, 77, 146);
            btnUsuarios.selected = false;
            btnUsuarios.Normalcolor = Color.FromArgb(14, 77, 146);

            btnTipoEquipo.selected = false;
            btnTipoEquipo.Normalcolor = Color.FromArgb(14, 77, 146);

            ((Bunifu.Framework.UI.BunifuFlatButton)sender).selected = true;

            ((Bunifu.Framework.UI.BunifuFlatButton)sender).Normalcolor = Color.FromArgb(15, 82, 186);

            equipoToolStripMenuItem.Visible = true;

            if (((Bunifu.Framework.UI.BunifuFlatButton)sender).Text == "Equipos" || ((Bunifu.Framework.UI.BunifuFlatButton)sender).Text == "Tipo de Equipos")
            {
                btnTipoEquipo.Visible = true;
            }
            else
            {
                btnTipoEquipo.Visible = false;
            }
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            ShowListPrestamosUserControl();
            toggle(sender);

        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            ShowListEquiposUserControl();

            toggle(sender);
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            ShowListMarcasUserControl();
            toggle(sender);
        }

        private void btnModelos_Click(object sender, EventArgs e)
        {
            ShowListModelosUserControl();
            toggle(sender);
        }

        private void btnTecno_Click(object sender, EventArgs e)
        {
            ShowListTecnoConexionsUserControl();
            toggle(sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            ShowListUsuariosUserControl();
            toggle(sender);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            ShowListEmpleadosUserControl();
            toggle(sender);
        }


        private void Principal_Load(object sender, EventArgs e)
        {
            equipoToolStripMenuItem.Visible = false;
            cmbOpcionesUsuario.SelectedIndex = 0;
         
        }


        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnEquipos.selected)
            {
                ShowEquiposUserControl();
            }
            else if (btnEmpleados.selected)
            {
                ShowEmpleadosUserControl();
            }
            else if (btnPrestamos.selected)
            {
                ShowPrestamosUserControl();
            }
            else if (btnTipoEquipo.selected)
            {
                ShowTipoEquiposUserControl(); 
            }
            else if (btnMarcas.selected)
            {
                ShowMarcasUserControl(); 
            }
            else if (btnModelos.selected)
            {
                ShowModelosUserControl(); 
            }
            else if (btnTecno.selected)
            {
                ShowTecnoConexionUserControl();
            }
            else if (btnUsuarios.selected)
            {
                ShowUsuariosUserControl();
            }
            else
            {
                panelUserControl.Controls.Clear();
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnEquipos.selected)
            {
                ShowEquiposUserControl();
            }
            else if (btnEmpleados.selected)
            {
                ShowEmpleadosUserControl();
            }
            else if (btnPrestamos.selected)
            {
                ShowPrestamosUserControl();
            }
            else if (btnTipoEquipo.selected)
            {
                ShowTipoEquiposUserControl();
            }
            else if (btnMarcas.selected)
            {
                ShowMarcasUserControl();
            }
            else if (btnModelos.selected)
            {
                ShowModelosUserControl();
            }
            else if (btnTecno.selected)
            {
                ShowTecnoConexionUserControl();
            }
            else if (btnUsuarios.selected)
            {
                ShowUsuariosUserControl();
            }
        }

        private void listaDeEquiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnEquipos.selected)
            {
                ShowListEquiposUserControl();
            }
            else if (btnEmpleados.selected)
            {
                ShowListEmpleadosUserControl();
            }
            else if (btnPrestamos.selected)
            {
                ShowListPrestamosUserControl();
            }
            else if (btnTipoEquipo.selected)
            {
                ShowListEquiposUserControl();
            }
            else if (btnMarcas.selected)
            {
                ShowListMarcasUserControl();
            }
            else if (btnModelos.selected)
            {
                ShowListModelosUserControl();
            }
            else if (btnTecno.selected)
            {
                ShowListTecnoConexionsUserControl();
            }
            else if (btnUsuarios.selected)
            {
                ShowListUsuariosUserControl();
            }
        }

        private void ShowListPrestamosUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaPrestamos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaPrestamos.titulo;
        }

        private void ShowPrestamosUserControl(bool? modificar = false)
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlPrestamos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlPrestamos.titulo;
        }

        private void ShowListEmpleadosUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaEmpleados();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaEmpleados.titulo;
        }

        private void ShowEmpleadosUserControl(bool? modificar = false)
        {

            panelUserControl.Controls.Clear();

            var userControl = new CtrlEmpleados();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlEmpleados.titulo;
        }

        private void ShowEquiposUserControl()
        {
            panelUserControl.Controls.Clear();
            
            var userControl = new CtrlEquipos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlEquipos.titulo;
        }

        private void ShowListEquiposUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaEquipos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaEquipos.titulo;
        }

        private void ShowTipoEquiposUserControl()
        {
            panelUserControl.Controls.Clear();
            
            var userControl = new CtrlTipoEquipos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlTipoEquipos.titulo;
        }

        private void ShowListTipoEquiposUserControl()
        {
            panelUserControl.Controls.Clear();
            
            var userControl = new CtrlListaTipoEquipos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();
            
            lblTitulo.Text = CtrlListaTipoEquipos.titulo;
        }

        private void ShowMarcasUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlMarcas();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlMarcas.titulo;
        }

        private void ShowListMarcasUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaMarcas();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaMarcas.titulo;
        }

        private void ShowModelosUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlModelos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlModelos.titulo;
        }

        private void ShowListModelosUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaModelos();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaModelos.titulo;
        }

        private void ShowTecnoConexionUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlTecnoConexion();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlTecnoConexion.titulo;
        }

        private void ShowListTecnoConexionsUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaTecnoConexion();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaTecnoConexion.titulo;
        }

        private void ShowUsuariosUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlUsuarios();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlUsuarios.titulo;
        }

        private void ShowListUsuariosUserControl()
        {
            panelUserControl.Controls.Clear();

            var userControl = new CtrlListaUsuarios();

            panelUserControl.Controls.Add(userControl);
            userControl.Dock = DockStyle.Fill;
            userControl.BringToFront();

            lblTitulo.Text = CtrlListaUsuarios.titulo;
        }

        private void cmbOpcionesUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOpcionesUsuario.SelectedIndex == 1)
            {
                Login.FrmLogin.Show();
                this.Hide();
            }
            if (cmbOpcionesUsuario.SelectedIndex == 3)
            {
                Application.Exit();
            }

            if (cmbOpcionesUsuario.SelectedIndex == 2)
            {
                this.Hide();
            }
        }

        private void btnTipoEquipo_Click(object sender, EventArgs e)
        {
            ShowListTipoEquiposUserControl();
            toggle(sender);
        }
    }
}
