using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using System.IO;
namespace ConvertJpegToPdfUsingItextSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            convertJpegToPDFUsingItextSharp();
        }
        private void convertJpegToPDFUsingItextSharp()
        {
           
            iTextSharp.text.Document Doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A2, 10, 10, 10, 10);
            //Store the document on the desktop
            string PDFOutput = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Output.pdf");
            PdfWriter writer = PdfWriter.GetInstance(Doc, new FileStream(PDFOutput, FileMode.Create, FileAccess.Write, FileShare.Read));

            //Open the PDF for writing
            Doc.Open();

            string Folder = "C:\\Images";
            foreach (string F in System.IO.Directory.GetFiles(Folder, "*.tif"))
            {
                //Insert a page
                Doc.NewPage();
                //Add image
                Doc.Add(new iTextSharp.text.Jpeg(new Uri(new FileInfo(F).FullName)));
            }

            //Close the PDF
            Doc.Close();

        }
    }
}
