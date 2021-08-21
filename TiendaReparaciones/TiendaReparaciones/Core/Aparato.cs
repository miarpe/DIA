namespace TiendaReparaciones.Core {
    public abstract class Aparato
    {
        public Aparato(string numSerie, string modelo,int costeHora )
        {
            this.NumSerie=numSerie;
            this.Modelo=modelo;
            this.CosteHora = costeHora;
        }
        
        public override string ToString()
        {
            return string.Format(" (nº serie: {0} , modelo: {1} y coste reparacion/hora: {2} )",
                NumSerie, Modelo, CosteHora);
        }

        public string NumSerie
        {
            get; set;
        }

        public string Modelo
        {
            get; set;
        }

        public int CosteHora
        {
            get; set;
        }
    }
}