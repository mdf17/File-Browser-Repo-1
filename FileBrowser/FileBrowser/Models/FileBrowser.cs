using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Spire.PdfViewer.Forms;
using Spire.PdfViewer.Drawing;

namespace FileBrowser.Models
{
    public class FileBrowser
    {
        public List<string> Files { get; set; }
        public string CurrentFile { get; set; }

        //public PdfDocumentViewer DocViewer = new PdfDocumentViewer();


    }
}