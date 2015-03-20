using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using FileBrowser.Filters;

namespace FileBrowser.Controllers
{
    [Log]
    public class FileBrowserController : Controller
    {
        //
        // GET: /FileBrowser/
        public ActionResult Index()
        {
            var filebrowser = new FileBrowser.Models.FileBrowser()
            {
                Files = GetSubDirectories(),
            };

            ViewBag.filebrowser = filebrowser;
            
            return View(filebrowser);
        }

        public ActionResult DisplayPdf(string currentFile)
        {
            Response.Clear();
            Response.ContentType = "application/pdf";
            string filename = GetLongFileName(currentFile);
            Response.WriteFile(filename);
            return View();
        }

        public List<string> GetSubDirectories()
        {
            string root = @"C:\pdf";
            List<string> dirs = new List<string>();
            // Get all subdirectories
            string[] subdirectoryEntries = Directory.GetDirectories(root);
            // Loop through them to see if they have any other subdirectories
            foreach (string subdirectory in subdirectoryEntries)
                LoadSubDirs(subdirectory, ref dirs);
            return dirs;
        }
        public string GetLongFileName(string filename)
        {
            string root = @"C:\pdf\";
            string longFile = root;
            string[] subdirs = Directory.GetDirectories(root);
            foreach(string dir in subdirs)
            {
                string[] files = Directory.GetFiles(dir);
                foreach(string file in files)
                {
                    if(file == filename)
                    {
                        longFile = longFile + dir + @"\" + filename;
                        break;
                    }
                }
            }
            return longFile;
        }
        private void LoadSubDirs(string dir, ref List<string> dirs)
        {
            string[] files = Directory.GetFiles(dir);
            string[] subdirectoryEntries = Directory.GetDirectories(dir);
            foreach(string file in files)
            {
                string simpleFile = Path.GetFileNameWithoutExtension(file);
                dirs.Add(simpleFile);
            }
            foreach (string subdirectory in subdirectoryEntries)
            {
                LoadSubDirs(subdirectory, ref dirs);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

    }
}
