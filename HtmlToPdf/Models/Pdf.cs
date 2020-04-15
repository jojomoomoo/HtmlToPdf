using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Web.Mvc;
using System.IO;

namespace HtmlToPdf.Models
{
    public class Pdf
    {
        public FileStreamResult HtmlToPdf(Html Html)
        {
            var memoryStream = new MemoryStream();
            var doc = new Document();          
            var pw = PdfWriter.GetInstance(doc, memoryStream);
                        
            pw.CloseStream = false;
            doc.Open();
                        
            var tbl = new PdfPTable(1);
            var cell = new PdfPCell();

            List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader("<html><head></head><body>" + Html.Code + "</body></html>"), null);

            doc.NewPage();

            foreach (var htmlElement in htmlarraylist)
            {
                doc.Add(htmlElement);
            }
                        
            doc.Close();

            byte[] byteInfo = memoryStream.ToArray();
            memoryStream.Write(byteInfo, 0, byteInfo.Length);
            memoryStream.Position = 0;

            return new FileStreamResult(memoryStream, "application/pdf");
        }
    }
}