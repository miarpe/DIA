using TiendaReparaciones.View;

namespace TiendaReparaciones
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var vista = new VistaPrincipal();
            
            vista.Show();
            System.Windows.Forms.Application.Run(vista);
        }
    }
}