using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPFinal
{
    public partial class FormPrincipal : Form
    {
        private TextBoxBase CajaTextoActual;

        public FormPrincipal()
        {
            InitializeComponent();
        }

        // Mover pantalla al arrastrar desde título
        private bool mouseApretado;
        private Point lugarAnterior;

        private void panelTitular_MouseDown(object sender, MouseEventArgs e)
        {
            mouseApretado = true;
            lugarAnterior = e.Location;
        }

        private void panelTitular_MouseUp(object sender, MouseEventArgs e)
        {
            mouseApretado = false;
        }

        private void panelTitular_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseApretado)
        {
                this.Location = new Point(
                    (this.Location.X - lugarAnterior.X) + e.X, (this.Location.Y - lugarAnterior.Y) + e.Y);

                this.Update();
            }
        }

        private void buttonCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarIngresoDni();
            CargarTeclado();
        }

        private void CargarIngresoDni()
        {
            if (!panelTexto.Controls.Contains(ucDni.Instancia))
            {
                panelTexto.Controls.Add(ucDni.Instancia);
                ucDni.Instancia.Dock = DockStyle.Fill;
                ucDni.Instancia.BringToFront();
                CajaTextoActual = ucDni.CajaTexto;
                ucDni.BotonSiguiente = buttonSiguiente;
            }
            else
            {
                ucDni.Instancia.BringToFront();
            }

            buttonSiguiente.Click += buttonSiguientePin_Click;
        }

        private void CargarTeclado()
        {
            if (!panelEntrada.Controls.Contains(ucNumpad.Instancia))
            {
                panelEntrada.Controls.Add(ucNumpad.Instancia);
                ucNumpad.Instancia.Dock = DockStyle.Fill;
                ucNumpad.Instancia.BringToFront();
            }
            else
            {
                ucNumpad.Instancia.BringToFront();
            }
            ucNumpad.CajaTexto = CajaTextoActual;
        }

        private void buttonSiguientePin_Click(object sender, EventArgs e)
        {
            EsconderTextoPrevio();
            CargarIngresoPin();
            CargarTeclado();
        }

        private void CargarIngresoPin()
        {
            buttonSiguiente.Click -= buttonSiguientePin_Click;

            if (!panelTexto.Controls.Contains(ucPin.Instancia))
            {
                panelTexto.Controls.Add(ucPin.Instancia);
                ucPin.Instancia.Dock = DockStyle.Fill;
                ucPin.Instancia.BringToFront();
                CajaTextoActual = ucPin.CajaTexto;
                ucPin.BotonSiguiente = buttonSiguiente;
            }
            else
            {
                ucDni.Instancia.BringToFront();
            }

            buttonSiguiente.Click += buttonSiguienteLogin_Click;
        }

        private void EsconderTextoPrevio()
        {
            foreach (Control c in panelTexto.Controls)
            {
                c.Enabled = false;
                c.Visible = false;
            }
        }

        private void EsconderPanelesPrevios()
        {
            foreach (Control c in panelContenido.Controls)
            {
                c.Enabled = false;
                c.Visible = false;
            }
        }

        private void buttonSiguienteLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login");
            EsconderPanelesPrevios();
            //CargarOperaciones();
        }
    }
}
