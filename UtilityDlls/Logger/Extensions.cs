using System;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.IO.Compression;

namespace Logger
{
    public static class Extensions
    {
        /// <summary>
        /// Зажимает файл GZip-ом
        /// </summary>
        /// <param name="fi">зажимаемый файл</param>
        public static void Compress(this FileInfo fi)
        {
            // Get the stream of the source file.
            using (var inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((fi.Attributes
                    & FileAttributes.Hidden)
                    != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (var outFile = new FileStream(fi.FullName + ".gz", FileMode.Create))
                    {
                        using (var compress =
                            new GZipStream(outFile,
                            CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(compress);
                        }
                    }
                }
            }
            fi.Delete();
        }
    }
}

