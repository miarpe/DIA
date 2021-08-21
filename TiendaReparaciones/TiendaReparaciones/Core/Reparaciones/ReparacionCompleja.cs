using System;

namespace TiendaReparaciones.Core.Reparaciones
{
    public class ReparacionCompleja : Reparacion
    {
        
        public ReparacionCompleja(Aparato aparato, double horas)
        {
            this.AparatoReparacion = aparato;
            this.HorasReparacion = horas;
            this.CosteReparacion = CalcularCosteReparacion();
        }

        public override double CalcularCosteReparacion()
        {
            double toret = this.costeBase;
            double costeAparato = 1.25 * Convert.ToDouble(AparatoReparacion.CosteHora);
            int mediasHoras = Convert.ToInt32((HorasReparacion * 60) / 30);//cantidad de medias horas de reparacion

            return toret + (costeAparato / 2) * mediasHoras;
        }

        public override string ToString()
        {
            return base.ToString() + "horas reparacion: " + this.HorasReparacion + ",coste reparacion en euros: " + this.CosteReparacion;
        }
    }
}