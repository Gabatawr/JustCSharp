using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

#region Description
/*
 * С страницы http://finance.i.ua/ (сохранить файл как html страницу).
 * Выполнить экспорт курса доллара по всем банкам.
 * Из input файла забрать только необходимую ин­формацию о названии банка, курсе покупки и продажи и записать ее в output.xml файл.
 */
#endregion

namespace Meeting_10
{
    public static class Task1
    {
        //---------------------------------------------------------------------
        private static void Download(string file, string url)
        {
            using WebClient client = new WebClient();
            client.DownloadFile(url, file);
        }
        //---------------------------------------------------------------------
        private static string GetBuffer(string file)
        {
            using Stream fs = new FileStream(file, FileMode.Open);
            using StreamReader reader = new StreamReader(fs);
            return reader.ReadToEnd();
        }
        //---------------------------------------------------------------------
        public static void Run()
        {
            string file = "index.html";
            string url = "http://finance.i.ua/";

            Download(file, url);
            string buffer = GetBuffer(file);
            using StringReader reader = new StringReader(buffer);

            int countBank = Regex.Matches(buffer, @"<option value=.\d+.").Count;
            var bankNames = new Dictionary<int, string>(countBank);
            int bankNameMax = 0;

            Dictionary<int, (double buy, double sell)> bankRates = null;
            for (string s; true;)
            {
                s = reader.ReadLine();
                if (s.Contains("converter.rates"))
                {
                    var r = Regex.Matches(s, @".\d+.:{.*?}}");
                    bankRates = new Dictionary<int, (double buy, double sell)>(r.Count);

                    foreach (Match item in r)
                    {
                        int id = int.Parse(Regex.Match(item.Value, @".\d+.:{").Value.Trim('"',':','{'));

                        string tmp = Regex.Match(item.Value, @".USD.*?}").Value;
                        double buy  = double.Parse(Regex.Match(tmp, @"\d*\.\d*,").Value.TrimEnd(',').Replace('.', ','));
                        double sell = double.Parse(Regex.Match(tmp, @"\d*\.\d*}").Value.TrimEnd('}').Replace('.', ','));

                        bankRates.Add(id, (Math.Round(buy, 2), Math.Round(sell, 2)));
                    }
                }
                else if (Regex.IsMatch(s, @"<option value=.\d+."))
                {
                    string tmp =       Regex.Match(s,   @".\d+.>.*?<").Value;
                    string name =      Regex.Match(tmp, @">.*?<")     .Value.Trim('>', '<');
                    int id = int.Parse(Regex.Match(tmp, @".\d+.")     .Value.Trim('"', '"'));

                    bankNames.Add(id, name);

                    if (name.Length > bankNameMax) bankNameMax = name.Length;
                    if (bankNames.Count == countBank) break;
                }
            }

            var bankArray = new List<(string Name, double buy, double sell)>(bankNames.Count);
            foreach (var bankName in bankNames)
                bankArray.Add
                (
                    (bankName.Value
                    ,bankRates[bankName.Key].buy
                    ,bankRates[bankName.Key].sell)
                );

            Console.WriteLine(" Bank:".PadRight(bankNameMax + 2) 
                            + "buy:".PadRight(6)
                            + "sell:" + "\n ".PadRight(bankNameMax + 14, '\''));

            foreach (var bank in bankArray)
            {
                Console.WriteLine($" {bank.Name}".PadRight(bankNameMax + 2) 
                                + $"{bank.buy}".PadRight(6) 
                                + $"{bank.sell}");
            }
        }
        //---------------------------------------------------------------------
    }
}
