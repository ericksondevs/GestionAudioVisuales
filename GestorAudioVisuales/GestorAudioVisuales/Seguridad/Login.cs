using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorAudioVisuales.Seguridad
{
    public partial class Login : Form
    {
        public static Login _Login;
        public static Login FrmLogin
        {
            get
            {
                if (_Login == null)
                {
                    _Login = new Login();
                }
                return _Login;
            }
        }

        public Login()
        {
            InitializeComponent();
           
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            CargarFormPrincipal();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarFormPrincipal();
            }
        }

        private void CargarFormPrincipal()
        {
            Principal.FrmPrincipal.Show();

            this.Hide();
        }
    }
}
