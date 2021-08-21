using TiendaReparaciones.Core;

namespace TiendaReparaciones.View
{
    using System.Windows.Forms;
    using System.Drawing;
    public class DlgInserta : Form
    {
        private RegistroReparaciones reparaciones;

        public DlgInserta(RegistroReparaciones r)
        {
            reparaciones = r;
            Build();
        }

        public void Build()
        {
            var pnlInserta = new TableLayoutPanel{ Dock = DockStyle.Fill};
            pnlInserta.SuspendLayout();

            var btnRadio = new Button()
            {
                Text = "Radio",
                Dock = DockStyle.Top
            };

            var btnTelevisor = new Button()
            {
                Text = "Televisor",
                Dock = DockStyle.Top
            };
            
            var btnReproductor = new Button()
            {
                Text = "Reproductor",
                Dock = DockStyle.Top
            };
            
            var btnAdaptador = new Button()
            {
                Text = "Adaptador",
                Dock = DockStyle.Top
            };
            
            var btnOk = new Button()
            {
                Text = "Ok",
                Dock = DockStyle.Bottom
            };
            
            btnOk.DialogResult = DialogResult.OK;

            btnRadio.Click += (sender, args) => IntroducirAparato("radio");
            btnTelevisor.Click += (sender, args) => IntroducirAparato("televisor");
            btnReproductor.Click += (sender, args) => IntroducirAparato("reproductor");
            btnAdaptador.Click += (sender, args) => IntroducirAparato("adaptador");

            pnlInserta.Controls.Add(btnRadio);
            pnlInserta.Controls.Add(btnTelevisor);
            pnlInserta.Controls.Add(btnReproductor);
            pnlInserta.Controls.Add(btnAdaptador);
            pnlInserta.Controls.Add(btnOk);
            
            pnlInserta.ResumeLayout(false);
            Controls.Add(pnlInserta);
            MinimumSize = new Size(400,300);
        }
        private void IntroducirAparato( string tipo)
        {
            var VistaAparato = new VistaAparato(tipo, reparaciones);
            VistaAparato.ShowDialog();
        }

        
    }
}