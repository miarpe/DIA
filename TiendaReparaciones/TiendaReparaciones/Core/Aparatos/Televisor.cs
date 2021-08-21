namespace TiendaReparaciones.Core.Aparatos
{
    public class Televisor : Aparato
    {
        protected const int costeHoraTelevisor = 10;

        public Televisor(string nS, string model, int pulgadas)
            : base(nS, model, costeHoraTelevisor)
        {
            this.Pulgadas = pulgadas;
        }

        public override string ToString()
        {
            return base.ToString() + " pulgadas: " + this.Pulgadas;
        }

        public int Pulgadas
        {
            get;
            set;
        }
    }
}