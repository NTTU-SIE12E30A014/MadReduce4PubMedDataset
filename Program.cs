//#define NORMAL
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab0
{
#if NORMAL
    class Program
    {
        static void Main(string[] args)
        {
            Regex titlePattern = new Regex("<ArticleTitle>([^<]+)</ArticleTitle>");
            string[] files = Directory.GetFiles(@"..\..\data");
            int maxLength = int.MinValue;
            string maxTitle = null;
            foreach (var zipPath in files)
            {
                using (FileStream originalFileStream = new FileInfo(zipPath).OpenRead())
                using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                using (StreamReader sr = new StreamReader(decompressionStream))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        Match m = titlePattern.Match(line);
                        if (m.Success)
                        {
                            if (maxLength < m.Groups[1].Length)
                            {
                                maxTitle = m.Groups[1].Value;
                                maxLength = maxTitle.Length;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("{0}: {1}", maxTitle, maxLength);
        }
    }
#endif
}
