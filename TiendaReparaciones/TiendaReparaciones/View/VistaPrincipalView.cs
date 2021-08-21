namespace TiendaReparaciones.View
{
    using System.Windows.Forms;
    using System.Drawing;
    
    public partial class VistaPrincipal
    {

        private void BuildMenu()
        {
          this.mPrincipal = new MainMenu();
          
          this.mArchivo = new MenuItem("&Archivo");
          this.mEditar = new MenuItem("&Editar");
          
          this.opSalir = new MenuItem("&Salir");
          this.opSalir.Click += (sender, e) => this.Salir();

          this.opInsertar = new MenuItem("&Insertar");
          this.opInsertar.Click += (sender, e) => this.Inserta();

          this.mArchivo.MenuItems.Add(opSalir);
          this.mEditar.MenuItems.Add(opInsertar);

          this.mPrincipal.MenuItems.Add(this.mArchivo);
          this.mPrincipal.MenuItems.Add(this.mEditar);
          this.Menu = mPrincipal;
        }

        private Panel BuildPanelDetalle()
        {
            var pnlDetalle = new Panel{Dock = DockStyle.Bottom};
            pnlDetalle.SuspendLayout();

            this.tbDetalle = new TextBox()
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font(FontFamily.GenericMonospace, 12),
                ForeColor = Color.Navy,
                BackColor = Color.LightGray
            };
            
            pnlDetalle.Controls.Add(this.tbDetalle);
            pnlDetalle.ResumeLayout(false);
            return pnlDetalle;
        }
        
        private Panel BuildPanelLista()
        {
            var pnlLista = new Panel();
            pnlLista.SuspendLayout();
            pnlLista.Dock = DockStyle.Fill;

            this.grdLista = new DataGridView()
            {
                Dock = DockStyle.Fill,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                MultiSelect = false,
                AllowUserToAddRows = false,
                EnableHeadersVisualStyles = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            
            this.grdLista.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            this.grdLista.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            
            var textCellTemplate0 = new DataGridViewTextBoxCell();
            var textCellTemplate1 = new DataGridViewTextBoxCell();
            var textCellTemplate2 = new DataGridViewTextBoxCell();
            var textCellTemplate3 = new DataGridViewTextBoxCell();
            var textCellTemplate4 = new DataGridViewTextBoxCell();
            
            textCellTemplate0.Style.BackColor = Color.LightGray;
            textCellTemplate0.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.BackColor = Color.Wheat;
            textCellTemplate1.Style.ForeColor = Color.Black;
            textCellTemplate1.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            textCellTemplate2.Style.BackColor = Color.Wheat;
            textCellTemplate2.Style.ForeColor = Color.Black;
            textCellTemplate3.Style.BackColor = Color.Wheat;
            textCellTemplate3.Style.ForeColor = Color.Black;
            textCellTemplate4.Style.BackColor = Color.Wheat;
            textCellTemplate4.Style.ForeColor = Color.Black;
            
            var column0 = new DataGridViewTextBoxColumn {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate0,
                HeaderText = "#",
                Width = 50,
                ReadOnly = true
            };
            
            var column1 = new DataGridViewTextBoxColumn {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate1,
                HeaderText = "Tipo",
                Width = 50,
                ReadOnly = true
            };
            
            var column2 = new DataGridViewTextBoxColumn {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate2,
                HeaderText = "NumSerie",
                Width = 50,
                ReadOnly = true
            };
            
            var column3 = new DataGridViewTextBoxColumn {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate3,
                HeaderText = "Horas",
                Width = 50,
                ReadOnly = true
            };
            
            var column4 = new DataGridViewTextBoxColumn {
                SortMode = DataGridViewColumnSortMode.NotSortable,
                CellTemplate = textCellTemplate4,
                HeaderText = "Coste",
                Width = 50,
                ReadOnly = true
            };
            
            this.grdLista.Columns.AddRange( new DataGridViewColumn[] {
                column0, column1, column2, column3, column4
            } );


            this.grdLista.SelectionChanged +=
                                        (sender, e) => this.FilaSeleccionada();
            pnlLista.Controls.Add( this.grdLista );
            pnlLista.ResumeLayout( false );
            return pnlLista;
        }

        private void BuildStatus()
        {
            this.sbStatus = new StatusBar{Dock = DockStyle.Bottom};
            this.Controls.Add(sbStatus);
        }

        private void Build()
        {
            this.BuildStatus();
            this.BuildMenu();
            this.BuildPanelLista();
            
            this.SuspendLayout();
            this.pnlPrincipal = new Panel()
            {
                Dock = DockStyle.Fill
            };
            
            this.pnlPrincipal.SuspendLayout();
            this.Controls.Add(pnlPrincipal);
            this.pnlPrincipal.Controls.Add(this.BuildPanelLista());
            this.pnlPrincipal.Controls.Add(this.BuildPanelDetalle());
            this.pnlPrincipal.ResumeLayout(false);
            
            this.MinimumSize = new Size(600,400);
            this.Resize += (obj, e) => this.ResizeWindow();
            this.Text = "Reparaciones Arias";
            
            this.ResumeLayout(true);
            this.ResizeWindow();
            this.Closed += (sender, e) => this.Salir();
            this.Shown += (sender, e) => this.Actualiza();
        }

        private void ResizeWindow()
        {
            int width = this.pnlPrincipal.ClientRectangle.Width;

            this.grdLista.Width = width;

            this.grdLista.Columns[ColNum].Width = (int) System.Math.Floor(width * .05);
            this.grdLista.Columns[ColTipo].Width = (int) System.Math.Floor(width * .10);
            this.grdLista.Columns[ColNumSerie].Width = (int) System.Math.Floor(width * .30);
            this.grdLista.Columns[ColHoras].Width = (int) System.Math.Floor(width * .30);
            this.grdLista.Columns[ColCoste].Width = (int) System.Math.Floor(width * .25);
        }
        
        private MainMenu mPrincipal;
        private MenuItem mArchivo;
        private MenuItem mEditar;
        private MenuItem opSalir;
        private MenuItem opInsertar;

        private Panel pnlPrincipal;
        private StatusBar sbStatus;
        private TextBox tbDetalle;
        private DataGridView grdLista;
    }
    
}