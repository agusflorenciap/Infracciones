using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocios;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace Web
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelCod.Text = ((OrdenPago)Session["OrdenPago"]).Cod.ToString();
            LabelImporte.Text = ((OrdenPago)Session["OrdenPago"]).Imp.ToString();
            LabelFecha.Text = ((OrdenPago)Session["OrdenPago"]).Fecha.ToString();


        }

        protected void ButtonBuscar_Click(object sender, EventArgs e) //imprimir PDF
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename =OrdenDePago.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            PanelPDF.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 10f);
            HTMLWorker htmlParser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            pdfDoc.Open();
            htmlParser.Parse(sr);
            pdfDoc.Close();

            Response.Write(pdfDoc);
            Response.End();
        }
    }
}