using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    public partial class ucOperaciones : UserControl
    {
        private static ucOperaciones _instancia;

        private static String _dni;
        private static String _pin;

        public static String Dni { set { _dni = value; } }
        public static String Pin { set { _pin = value; } }

        public static Control Contenedor { get; set; }

        public ucOperaciones()
        {
            InitializeComponent();
        }

        public static ucOperaciones Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ucOperaciones();
                }
                return _instancia;
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void buttonBlanquearPin_Click(object sender, EventArgs e)
        {

            CargarTarjetas();
        }

        private void buttonConsultarSaldo_Click(object sender, EventArgs e)
        {

        }

        private void buttonUltimosMovimientos_Click(object sender, EventArgs e)
        {

        }

        private void CargarTarjetas()
        {

        }
    }
}
