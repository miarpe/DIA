namespace TiendaReparaciones.Core.Aparatos
{
    public class Radio: Aparato
    {
        protected const int costeHoraRadio = 5;

        public Radio(string nS, string model, string banda)
            : base(nS, model, costeHoraRadio)
        {
            this.Banda = banda;
        }

        public override string ToString()
        {
            return base.ToString() + " banda: " + this.Banda;
        }

        public string Banda
        {
            get;
            set;
        }
    }
}