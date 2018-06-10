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

namespace GestorAudioVisuales
{
    public partial class Principal : MetroFramework.Forms.MetroForm
    {

        public Principal()
        {
            InitializeComponent();
        }

        void toggle(object sender)
        {
            btnEmpleados.selected = false;
            btnEquipos.selected = false;
            btnMarcas.selected = false;
            btnModelos.selected = false;
            btnPrestamos.selected = false;
            btnTecno.selected = false;
            btnUsuarios.selected = false;
            ((Bunifu.Framework.UI.BunifuFlatButton)sender).selected = true;
            equipoToolStripMenuItem.Visible = true;
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            toggle(sender);

        }

        private void btnEquipos_Click(object sender, EventArgs e)
        {
            ShowListEquiposUserControl();

            toggle(sender);
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            toggle(sender);
        }

        private void btnModelos_Click(object sender, EventArgs e)
        {
            toggle(sender);
        }

        private void btnTecno_Click(object sender, EventArgs e)
        {
            toggle(sender);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
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
            else
            {
                panelUserControl.Controls.Clear();
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (btnEquipos.selected)
            {
                ShowListEquiposUserControl();
            }
            else if (btnEmpleados.selected)
            {
                ShowEmpleadosUserControl();
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
            if (!panelUserControl.Controls.Contains(CtrlEquipos.userCtrlEquipo))
            {
                panelUserControl.Controls.Add(CtrlEquipos.userCtrlEquipo);
                CtrlEquipos.userCtrlEquipo.Dock = DockStyle.Fill;
                CtrlEquipos.userCtrlEquipo.BringToFront();
            }
            else
            {
                CtrlEquipos.userCtrlEquipo.BringToFront();
            }
            lblTitulo.Text = CtrlEquipos.titulo;
        }

        private void ShowListEquiposUserControl()
        {
            if (!panelUserControl.Controls.Contains(CtrlListaEquipos.userCtrlListaEquipos))
            {
                panelUserControl.Controls.Add(CtrlListaEquipos.userCtrlListaEquipos);
                CtrlListaEquipos.userCtrlListaEquipos.Dock = DockStyle.Fill;
                CtrlListaEquipos.userCtrlListaEquipos.BringToFront();
            }
            else
            {
                CtrlListaEquipos.userCtrlListaEquipos.BringToFront();
            }
            lblTitulo.Text = CtrlListaEquipos.titulo;
        }
    }
}
