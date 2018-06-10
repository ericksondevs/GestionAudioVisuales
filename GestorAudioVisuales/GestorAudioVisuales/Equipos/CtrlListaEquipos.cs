using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorAudioVisuales.Equipos
{
    public partial class CtrlListaEquipos : UserControl
    {
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

    }
}
