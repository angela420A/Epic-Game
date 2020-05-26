using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Epic_Game.Service
{
    public class OperationResult
    {
        public bool isSuccess { get; set; }
        public Exception exception { get; set; }
    }

    public static class OperationResultHelper{
        public static string WriteLog(this OperationResult value) {
            if (value.exception != null)
            {
                string path = DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss");
                path.Concat(".txt");
                File.WriteAllText(path, value.exception.ToString());
                return path;
            }
            else
            {
                return "didn't save file";
            }
        }
    }
}