using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    class Ayudante
    {
        private Ayudante() { }

        private static TextBoxBase _cajaTextoActual;

        public static void EsconderContenidoPanel(Panel p)
        {
            foreach (Control c in p.Controls)
            {
                c.Enabled = false;
                c.Visible = false;
            }
        }

        public static void CargarTeclado(Panel p)
        {
            if (!p.Controls.Contains(ucNumpad.Instancia))
            {
                p.Controls.Add(ucNumpad.Instancia);
                ucNumpad.Instancia.Dock = DockStyle.Fill;
                ucNumpad.Instancia.BringToFront();
            }
            ucNumpad.CajaTexto = _cajaTextoActual;
        }

        public static void CargarIngresoDni(Panel p, ButtonBase b)
        {
            if (!p.Controls.Contains(ucDni.Instancia))
            {
                p.Controls.Add(ucDni.Instancia);
                ucDni.Instancia.Dock = DockStyle.Fill;
                ucDni.Instancia.BringToFront();
                ucDni.BotonSiguiente = b;
                _cajaTextoActual = ucDni.CajaTexto;
            }
        }

        public static void CargarIngresoPin(Panel p, ButtonBase b)
        {
            if (!p.Controls.Contains(ucPin.Instancia))
            {
                p.Controls.Add(ucPin.Instancia);
                ucPin.Instancia.Dock = DockStyle.Fill;
                ucPin.Instancia.BringToFront();
                ucPin.BotonSiguiente = b;
                _cajaTextoActual = ucPin.CajaTexto;
            }
        }

        public static void CargarOperaciones(Panel p)
        {
            if (!p.Controls.Contains(ucOperaciones.Instancia))
            {
                p.Controls.Add(ucOperaciones.Instancia);
                ucOperaciones.Instancia.Dock = DockStyle.Fill;
                ucOperaciones.Instancia.BringToFront();
                ucOperaciones.Dni = ucDni.CajaTexto.Text;
                ucOperaciones.Pin = ucPin.CajaTexto.Text;
                ucOperaciones.Contenedor = p;
                _cajaTextoActual = null;
            }
        }
    }
}
