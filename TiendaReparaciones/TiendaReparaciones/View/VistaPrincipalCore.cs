namespace TiendaReparaciones.View
{
    using System.Windows.Forms;
    using Core;
    
    public partial class VistaPrincipal : Form
    {
        public const int ColNum = 0;
        public const int ColTipo = 1;
        public const int ColNumSerie = 2;
        public const int ColHoras = 3;
        public const int ColCoste = 4;

        public VistaPrincipal()
        {
            this.Build();
            this.reparaciones = RegistroReparaciones.RecuperarXml();
        }

        public void Salir()
        {
            this.reparaciones.GuardaXml();
            this.Dispose(true);
        }

        private void Actualiza()
        {
            this.ActualizaLista(0);
        }
        
        private void Inserta()
        {
            var dlgInserta = new DlgInserta(reparaciones);

            if (dlgInserta.ShowDialog() == DialogResult.OK)
            {
                this.Actualiza();
            }
        }

        private void ActualizaLista(int numCol)
        {
            int numRecorridos = this.reparaciones.Count;

            for (int i = numCol; i < numRecorridos; i++)
            {
                if (this.grdLista.Rows.Count <= i)
                {
                    this.grdLista.Rows.Add();
                }
                this.ActualizaFilaDeLista(i);
            }

            int numExtra = this.grdLista.Rows.Count - numRecorridos;
            for (; numExtra > 0; --numExtra)
            {
                this.grdLista.Rows.RemoveAt(numRecorridos);
            }

            return;
        }

        private void ActualizaFilaDeLista(int numFila)
        {
            if (numFila < 0 || numFila > this.grdLista.Rows.Count)
            {
                throw new System.ArgumentOutOfRangeException("Fila fuera de rango: " + nameof(numFila));
            }

            DataGridViewRow fila = this.grdLista.Rows[numFila];
            Reparacion reparacion = this.reparaciones[numFila];

            fila.Cells[ColNum].Value = (numFila + 1).ToString().PadLeft(4, ' ');
            fila.Cells[ColTipo].Value = reparacion.AparatoReparacion.GetType().ToString().Split('.')[3];
            fila.Cells[ColNumSerie].Value = reparacion.AparatoReparacion.NumSerie;
            fila.Cells[ColHoras].Value = reparacion.HorasReparacion;
            fila.Cells[ColCoste].Value = reparacion.CosteReparacion;

            foreach (DataGridViewCell cell in fila.Cells)
            {
                cell.ToolTipText = reparacion.ToString();
            }

            return;
        }

        private void FilaSeleccionada()
        {
            int fila = System.Math.Max(0, this.grdLista.CurrentRow.Index);

            if (this.reparaciones.Count > fila)
            {
                this.tbDetalle.Text = this.reparaciones[fila].ToString();
                this.tbDetalle.SelectionStart = this.tbDetalle.Text.Length;
                this.tbDetalle.SelectionLength = 0;
            }
            else
            {
                this.tbDetalle.Clear();
            }

            return;
        }
        
        private RegistroReparaciones reparaciones;
        
    }
}