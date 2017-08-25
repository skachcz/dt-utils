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
        public string Filename { get; set; }
        public string FilePath { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateAccessed { get; set; }
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Constructor based on file path
        /// </summary>
        /// <param name="filePath"></param>
        public DateFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found", filePath);
            }

            FilePath = filePath;

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
            fileInfo.IsReadOnly = false; // abychom mohli menit atributy

            Filename = fileInfo.Name;
            DateCreated = fileInfo.CreationTime;
            DateAccessed = fileInfo.LastAccessTime;
            DateModified = fileInfo.LastWriteTime;
        }

        public void WriteDateAttributes()
        {

            File.SetCreationTime(FilePath, DateCreated);
            File.SetLastWriteTime(FilePath, DateModified);
            File.SetLastAccessTime(FilePath, DateAccessed);
        }


    }
}
