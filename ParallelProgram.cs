//#define PARALLEL
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
#if PARALLEL
    class ParallelProgram
    {
        static void Main(string[] args)
        {
            Regex reg = new Regex("<ArticleTitle>([^<]+)</ArticleTitle>");
            string[] files = Directory.GetFiles(@"..\..\data");
            int maxLength = int.MinValue;
            string maxTitle = null;
            Parallel.ForEach(files, (zipPath) =>
            {
                using (FileStream originalFileStream = new FileInfo(zipPath).OpenRead())
                using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                using (StreamReader sr = new StreamReader(decompressionStream))
                {
                    while (sr.Peek() != -1)
                    {
                        string line = sr.ReadLine();
                        Match m = reg.Match(line);
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
            });
            
            Console.WriteLine("{0}: {1}", maxTitle, maxLength);
        }
    }
#endif
}
