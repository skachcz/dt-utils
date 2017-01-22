using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtLib
{
    public class DateFile
    {
        public string Filename;
        public DateTime DateCreated { get; set; }
        public DateTime DateAccessed { get; set; }
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Constructor based on file path
        /// </summary>
        /// <param name="filePath"></param>
        public DateFile(string filePath)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filePath);
                setPars(fileInfo);
            }

            catch(Exception ex)
            {
                // error
                bool err = true;
            }
        }

        /// <summary>
        /// constructor based on FileInfo object
        /// </summary>
        /// <param name="fileInfo"></param>
        public DateFile(FileInfo fileInfo)
        {
            setPars(fileInfo);
        }

        /// <summary>
        /// private method for setting class properties
        /// </summary>
        /// <param name="fileInfo"></param>
        private void setPars(FileInfo fileInfo)
        {
            Filename = fileInfo.Name;
            DateCreated = fileInfo.CreationTime;
            DateAccessed = fileInfo.LastAccessTime;
            DateModified = fileInfo.LastWriteTime;
        }


    }
}
