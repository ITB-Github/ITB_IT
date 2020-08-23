using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HardDrive
{
    internal class HDAccess
    {
        string baseFolder = System.AppDomain.CurrentDomain.BaseDirectory;
        private string[] pptEx = new string[] {
            "ppt", ".pot", ".pps", ".pptx", ".pptm", ".potx" ,".potm" ,".ppam" ,".ppsx" ,".ppsm" ,".sldx", ".sldm" ,".pdf"
        };

        

        internal string LoadPowerpointFiles()
        {
            return LoadFilesWithListExtension(pptEx);
        }


        private string[] musicEx = new string[]
        {
           
            ".3gp",".aa",".aac",".aax",".act",".aiff",".alac",".amr",".ape",".au",".awb",".dct",".dss",".dvf",".flac",".gsm",".iklax",".ivs",".m4a",".m4b",".m4p",".mmf",".mp3",".mpc",".msv",".nmf",".ogg", ".oga", ".mogg",".opus",".ra", ".rm",".raw",".rf64",".sln",".tta",".voc",".vox",".wav",".wma",".wv",".webm",".8svx",".cda"

        };
        internal string LoadMusicFiles()
        {
            return LoadFilesWithListExtension(musicEx);
            //throw new NotImplementedException();
        }

        private string[] videoEx = new string[]
        { 
            ".webm",".mkv",".flv",".flv",".vob",".ogv",".ogg",".drc",".gif",".gifv",".mng",".avi",".MTS",".M2TS",".TS",".mov", ".qt",".wmv",".yuv",".rm",".rmvb",".viv",".asf",".amv",".mp4", ".m4p", ".m4v",".mpg", ".mp2", ".mpeg", ".mpe", ".mpv",".mpg", ".mpeg", ".m2v",".m4v",".svi",".3gp",".3g2",".mxf",".roq",".nsv",".flv", ".f4v", ".f4p", ".f4a" ,".f4b"
        };
        
        internal string LoadVideoFiles()
        {
            //throw new NotImplementedException();
            return LoadFilesWithListExtension(videoEx);
        }


        string LoadFilesWithListExtension(string[] list)
        {
            string filesInJson = "[";
            DirectoryInfo dirInfo = new DirectoryInfo(baseFolder);
            var fileinfos = dirInfo.GetFiles("*.*");
            //throw new NotImplementedException();
            for (int i = 0; i < fileinfos.Length; i++)
            {
                if (!hasExtensionInList(list, fileinfos[i].FullName))
                    continue;

                string fileInJson = "{";

                fileInJson += "\'";
                fileInJson += "Id";
                fileInJson += "\'";
                fileInJson += ":";
                fileInJson += "\'";
                fileInJson += i;
                fileInJson += "\'";
                fileInJson += ",";

                fileInJson += "\'";
                fileInJson += "FileName";
                fileInJson += "\'";
                fileInJson += ":";
                fileInJson += "\'";
                fileInJson += fileinfos[i].Name;
                fileInJson += "\'";
                fileInJson += ",";

                fileInJson += "\'";
                fileInJson += "Path";
                fileInJson += "\'";
                fileInJson += ":";
                fileInJson += "\'";
                fileInJson += fileinfos[i].FullName;
                fileInJson += "\'";
                fileInJson += "";

                fileInJson += "}";

                
                fileInJson += ",";
                

                filesInJson += fileInJson;
            }
            if(filesInJson.LastIndexOf(",") > 0)
                filesInJson =  filesInJson.Remove(filesInJson.Length - 1);
            filesInJson += "]";
            filesInJson = filesInJson.Replace("\\", "\\\\");
            return filesInJson;
        }

        bool hasExtensionInList(string[] list, string fileName)
        {
            foreach(string str in list)
            {
                if (fileName.Contains(str))
                    return true;
            }

            return false;
        }

        string imagePath = "Landing.jpg";
        internal byte[] GetImageToDisplay()
        {
            //throw new NotImplementedException();
            if (!(File.Exists(imagePath)))
                return null;
            return File.ReadAllBytes(imagePath);
        }
    }
}
