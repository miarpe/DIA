namespace TiendaReparaciones.Core.Aparatos
{
    public class Adaptador : Aparato
    {
        protected const int costeHoraAdaptador = 5;

        public Adaptador(string nS, string model, int min)
            : base(nS, model, costeHoraAdaptador)
        {
            this.MinGrabacion = min;
        }

        public override string ToString()
        {
            return base.ToString() + " Min. grabacion: " + this.MinGrabacion;
        }

        public int MinGrabacion
        {
            get; set;
        }
    }
}