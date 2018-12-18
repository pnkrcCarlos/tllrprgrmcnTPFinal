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
            Application.Exit();
        }

        private void buttonMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            Ayudante.CargarIngresoDni(panelTexto, buttonSiguiente);
            Ayudante.CargarTeclado(panelEntrada);

            buttonSiguiente.Click += buttonSiguientePin_Click;
        }

        private void buttonSiguientePin_Click(object sender, EventArgs e)
        {
            Ayudante.EsconderContenidoPanel(panelTexto);
            Ayudante.CargarIngresoPin(panelTexto, buttonSiguiente);
            Ayudante.CargarTeclado(panelEntrada);

            buttonSiguiente.Click -= buttonSiguientePin_Click;
            buttonSiguiente.Click += buttonSiguienteLogin_Click;
        }

        private void buttonSiguienteLogin_Click(object sender, EventArgs e)
        {
            Ayudante.EsconderContenidoPanel(panelContenido);
            Ayudante.CargarOperaciones(panelContenido);
        }

    }
}
