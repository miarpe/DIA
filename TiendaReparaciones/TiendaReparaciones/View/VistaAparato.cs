using System;
using TiendaReparaciones.Core;
using TiendaReparaciones.Core.Aparatos;

namespace TiendaReparaciones.View
{
    using System.Windows.Forms;
    using System.Drawing;
    public class VistaAparato : Form
    {
        private string tipo;
        private RegistroReparaciones reparaciones;

        public VistaAparato(String t, RegistroReparaciones r)
        {
            tipo = t;
            reparaciones = r;
            Build();
        }

        public void Build()
        {
            var pnlPrincipal = new Panel {Dock = DockStyle.Fill};
            pnlPrincipal.SuspendLayout();

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Dock = DockStyle.Top
            };
            
            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Dock = DockStyle.Top
            };
            btnGuardar.DialogResult = DialogResult.OK;
            btnCancelar.DialogResult = DialogResult.Cancel;

            var lblNumSerie = new Label
            {
                Text = "Numero Serie",
                Dock = DockStyle.Top
            };

            tbNumSerie = new TextBox
            {
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Top
            };
            
            var lblModelo = new Label
            {
                Text = "Modelo",
                Dock = DockStyle.Top
            };

            tbModelo = new TextBox
            {
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Top,
            };
            
            var lblHoras = new Label
            {
                Text = "Horas Reparacion",
                Dock = DockStyle.Top
            };

            nudHoras = new NumericUpDown
            {
                
                TextAlign = HorizontalAlignment.Right,
                Dock = DockStyle.Top
            };
            pnlPrincipal.Controls.Add(btnGuardar);
            pnlPrincipal.Controls.Add(btnCancelar);
            pnlPrincipal.Controls.Add(this.tbNumSerie);
            pnlPrincipal.Controls.Add(lblNumSerie);
            pnlPrincipal.Controls.Add(this.tbModelo);
            pnlPrincipal.Controls.Add(lblModelo);
            pnlPrincipal.Controls.Add(this.nudHoras);
            pnlPrincipal.Controls.Add(lblHoras);
            

            switch (tipo)
            {
                case "radio":
                    VistaRadio(pnlPrincipal);
                    break;
                case "televisor":
                    VistaTelevisor(pnlPrincipal);
                    break;
                case "reproductor":
                    VistaReproductor(pnlPrincipal);
                    break;
                case "adaptador":
                    VistaAdaptador(pnlPrincipal);
                    break;
            }

            btnGuardar.Click += (sender, args) => GuardarDatos();
            pnlPrincipal.ResumeLayout(false);
            Controls.Add(pnlPrincipal);
            MinimumSize = new Size(400,320);
            
        }

        public void VistaRadio(Panel panel)
        {
            var lblRadio = new Label
            {
                Text = "Bandas soportadas ",
                Dock = DockStyle.Top
            };

            tbRadio = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Right
            };
            
            panel.Controls.Add(tbRadio);
            panel.Controls.Add(lblRadio);
        }
        
        public void VistaTelevisor(Panel panel)
        {
            var lblTelevisor = new Label
            {
                Text = "Pulgadas ",
                Dock = DockStyle.Top
            };

            tbTelevisor = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Right
            };
            
            panel.Controls.Add(tbTelevisor);
            panel.Controls.Add(lblTelevisor);
        }
        
        public void VistaReproductor(Panel panel)
        {
            cbBlueRay = new CheckBox
            {
                Dock = DockStyle.Top,
                Tag = "false",
                Text = "BlueRay",
                Checked = false
            };
            
            cbGrabacion = new CheckBox
            {
                Dock = DockStyle.Top,
                Tag = "false",
                Text = "Grabacion",
                Checked = false
            };
            
            var lblReproductor = new Label
            {
                Text = "Minutos grabacion ",
                Dock = DockStyle.Top
            };

            tbReproductor = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Right,
                Text = "0"
            };
            
            panel.Controls.Add(tbReproductor);
            panel.Controls.Add(lblReproductor);
            panel.Controls.Add(cbBlueRay);
            panel.Controls.Add(cbGrabacion);
        }
        
        public void VistaAdaptador(Panel panel)
        {
            var lblAdaptador = new Label
            {
                Text = "Minutos grabacion ",
                Dock = DockStyle.Top
            };

            tbAdaptador = new TextBox
            {
                Dock = DockStyle.Top,
                TextAlign = HorizontalAlignment.Right,
                Text = "0"
            };
            
            panel.Controls.Add(this.tbAdaptador);
            panel.Controls.Add(lblAdaptador);
        }

        public void GuardarDatos()
        {
            switch (tipo)
            {
                case "radio":
                    Aparato radio = new Radio(tbNumSerie.Text,tbModelo.Text,tbRadio.Text);
                    reparaciones.Add(Reparacion.crea(radio, Convert.ToDouble(this.nudHoras.Text)));
                    break;
                case "televisor":
                    Aparato televisor = new Televisor(tbNumSerie.Text,tbModelo.Text,Convert.ToInt32(tbTelevisor.Text));
                    reparaciones.Add(Reparacion.crea(televisor, Convert.ToDouble(this.nudHoras.Text)));
                    break;
                case "reproductor":
                    Aparato reproductor = new Reproductor(tbNumSerie.Text,tbModelo.Text,Convert.ToBoolean(cbBlueRay.Checked), Convert.ToBoolean(cbGrabacion.Checked),Convert.ToInt32(tbReproductor.Text));
                    reparaciones.Add(Reparacion.crea(reproductor, Convert.ToDouble(this.nudHoras.Text)));
                    break;
                case "adaptador":
                    Aparato adaptador = new Adaptador(tbNumSerie.Text,tbModelo.Text,Convert.ToInt32(tbAdaptador.Text));
                    reparaciones.Add(Reparacion.crea(adaptador, Convert.ToDouble(this.nudHoras.Text)));
                    break;
                    
            }
        }
        
        
        public TextBox tbRadio;
        public TextBox tbTelevisor;
        public TextBox tbReproductor;
        public TextBox tbAdaptador;
        
        private CheckBox cbGrabacion;
        private CheckBox cbBlueRay;

        private NumericUpDown nudHoras;
        public TextBox tbNumSerie;
        public TextBox tbModelo;
    }
}