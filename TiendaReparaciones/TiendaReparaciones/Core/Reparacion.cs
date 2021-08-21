using TiendaReparaciones.Core.Reparaciones;

namespace TiendaReparaciones.Core
{
    public abstract class Reparacion
    {

        protected int costeBase = 10;

        public static Reparacion crea(Aparato aparato, double horas)
        {
            Reparacion toret;
            if (horas <= 1)
            {
                toret = new SustitucionPiezas(aparato, horas);
            }
            else
            {
                toret = new ReparacionCompleja(aparato, horas);
            }

            return toret;
        }
        public abstract double CalcularCosteReparacion();

        public override string ToString()
        {
            string tipo = AparatoReparacion.GetType().ToString().Split('.')[3];
            return string.Format (" (aparato: {0} , horas reparacion {1})",
                tipo, HorasReparacion);
        }

        public double HorasReparacion
        {
            get; set;
        }

        public Aparato AparatoReparacion
        {
            get; set;
        }

        public double CosteReparacion
        {
            get; set;
        }
    }
}