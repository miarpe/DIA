using System;

namespace TiendaReparaciones.Core.Aparatos
{
    public class Reproductor : Aparato
    {
        protected const int costeHoraReproductor = 10;

        public Reproductor(string nS, string model, Boolean blueRay, Boolean grabacion, int minutosGrabacion)
            : base(nS, model, costeHoraReproductor)
        {
            this.BlueRay = blueRay;
            this.Grabacion = grabacion;

            if (grabacion)
            {
                this.MinutosGrabacion = minutosGrabacion;
            }
            else
            {
                this.MinutosGrabacion = 0;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " grabacion: " + this.Grabacion + " Min. grabacion: " + this.MinutosGrabacion;
        }
        
        public Boolean BlueRay
        {
            get; set;
        }

        public Boolean Grabacion
        {
            get; set;
        }

        public int MinutosGrabacion
        {
            get; set;
        }
                
    }
}