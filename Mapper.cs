//#define MAPPER
#if MAPPER
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab0
{
    class Mapper
    {
        static void Main(string[] args)
        {
            string line;
            string year = null;
            string title = null;
            Regex yearP = new Regex(@"<Year>(\d+)</Year>");
            Regex titleP = new Regex("<ArticleTitle>([^<]+)</ArticleTitle>");
            while ((line = Console.ReadLine()) != null)
            {
                // 可以透過如下的方式取得年與標題的資訊
                // year = yearP.Match(line).Groups[1].Value;
                // Match m = titleP.Match(line);
                if (m.Success)
                {
                    title = m.Groups[1].Value;                    
                }
            }
        }
    }
}
#endif