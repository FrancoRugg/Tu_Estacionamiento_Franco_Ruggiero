using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Tu_Estacionamiento_Services.Services;

namespace Tu_Estacionamiento_Franco_Ruggiero
{
    public partial class frmLogs : Form
    {
        public frmLogs()
        {
            InitializeComponent();
        }
        LogsService logsService = new LogsService();
        private void frmLogs_Load(object sender, EventArgs e)
        {
            cmbFiltro.SelectedIndex = 0;
        }
        private void grdDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (grdDatos.Columns[e.ColumnIndex].Name == "Accion_Realizada")
            {
                DataGridViewRow row = grdDatos.Rows[e.RowIndex];
                string Action = row.Cells["Accion_Realizada"].Value?.ToString();

                if (Action == "CLICK")
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#aeeeee");
            }
                else if (Action == "INSERT")
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#b2f2b2");  //66cdaa
                }
                else if (Action == "UPDATE")
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ffb347");//ffc107 
                }
                else
                {
                    row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#ff9999");
                }
            }
        }

        private void cmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltro.Text == "TODOS")
            {
                grdDatos.DataSource = logsService.GetLogs();
            }
            else
            {
                string filtro = cmbFiltro.Text;
                if (cmbFiltro.Text != "TODOS")
                {
                    grdDatos.DataSource = logsService.BuscarPorFiltro("Accion_Realizada", filtro);
                }
            }
        }
        public static void ExportarHTML(DataGridView datagrid, string path)
        {
            StringBuilder sb = new StringBuilder();//Clase a utilizar si quiero generar un objeto con texto

            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append("<style>");
            sb.Append("table {width 100%; border-collapse: collapse; }");
            sb.Append("th, td {border: solid 1px black; padding: 8px; text-align: left; }");
            sb.Append("th {background-color: #f2f2f2; }");
            sb.Append("</style>");
            sb.Append("</head>");
            sb.Append("<body>");

            sb.Append("<table>");

            sb.Append("<tr>");
            foreach (DataGridViewColumn column in datagrid.Columns)
            {
                sb.AppendFormat("<td>{0}</th>", column.HeaderText);
            }
            sb.Append("</tr>");

            foreach (DataGridViewRow row in datagrid.Rows)
            {
                if (row.IsNewRow) continue;
                sb.Append("<tr>");

                foreach (DataGridViewCell cell in row.Cells)
                {

                    sb.AppendFormat("<td>{0}</th>", cell.Value?.ToString() ?? string.Empty);
                }

                sb.Append("</tr>");
            }


            sb.Append("</table>");

            sb.Append("</body>");
            sb.Append("</html>");

            File.WriteAllText(path, sb.ToString());//Te pega todo el contenido agregado

            MessageBox.Show("Reporte Exportado Correctamente!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Install-Package itext7
        //Install-Package itext7.bouncycastle.adapter
        public static void ExportarPDF(DataGridView datagrid, string path)
        {
            //using (PdfWriter writer = new PdfWriter(path))
            PdfWriter writer = new PdfWriter(path);
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);

                Table table = new Table(datagrid.Columns.Count);
                foreach (DataGridViewColumn column in datagrid.Columns)
                {
                    table.AddHeaderCell(new Cell().Add(new Paragraph(column.HeaderText)));
                }

                foreach (DataGridViewRow row in datagrid.Rows)
                {
                    if (row.IsNewRow) continue;

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(cell.Value?.ToString() ?? string.Empty)));
                    }
                }

                document.Add(table);
            }

            MessageBox.Show("Reporte Exportado Correctamente a PDF!", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void descargarDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//captura la ruta del escritorio
            string archivo = Path.Combine(deskPath, "ReporteLogs.html");

            ExportarHTML(grdDatos, archivo);
        }

        private void exportarPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string deskPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string archivo = Path.Combine(deskPath, "ReporteLogs.pdf");

            ExportarPDF(grdDatos, archivo);
        }
    }
}
