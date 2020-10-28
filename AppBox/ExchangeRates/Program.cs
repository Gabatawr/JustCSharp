using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace ExchangeRates
{
    static class Program
    {
        private static void Download(string file, string url)
        {
            using WebClient client = new WebClient();
            client.DownloadFile(url, file);
        }
        public class Banks : IEnumerable<Banks.Bank>
        {
            //-----------------------------------------------------------------
            private readonly List<Bank> array = new List<Bank>();
            //-----------------------------------------------------------------
            public Banks(string file)
            {
                using XmlReader xmlR = XmlReader.Create(new StreamReader(file, Encoding.UTF8));

                xmlR.IsStartElement("exchange");
                while (xmlR.Read() && xmlR.IsStartElement("currency"))
                {
                        xmlR.Read(); xmlR.ReadStartElement();
                    int id = int.Parse(xmlR.Value);
                        xmlR.Read(); xmlR.ReadEndElement();

                        xmlR.Read(); xmlR.ReadStartElement();
                    string bank = xmlR.Value;
                        xmlR.Read(); xmlR.ReadEndElement();

                        xmlR.Read(); xmlR.ReadStartElement();
                    double rate = double.Parse(xmlR.Value, new NumberFormatInfo {NumberDecimalSeparator = "."});
                        xmlR.Read(); xmlR.ReadEndElement();

                        xmlR.Read(); xmlR.ReadStartElement();
                    string currency = xmlR.Value;
                        xmlR.Read(); xmlR.ReadEndElement();

                        xmlR.Read(); xmlR.ReadStartElement();
                    string date = xmlR.Value;
                        xmlR.Read(); xmlR.ReadEndElement();

                    xmlR.ReadEndElement();

                    array.Add(new Bank(id, bank, rate, currency, date));
                }
            }
            //-----------------------------------------------------------------
            public IEnumerator<Bank> GetEnumerator()
            {
                foreach (var bank in array) yield return bank;
            }
            IEnumerator IEnumerable.GetEnumerator() { return array.GetEnumerator(); }
            //-----------------------------------------------------------------
            public class Bank
            {
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                private readonly int _id;
                private readonly string _bank;

                public double Rate { get; private set; }

                private readonly string _currency;
                private readonly string _date;
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                public Bank(int id, string bank, double rate, string currency, string date)
                {
                    _id = id;
                    _bank = bank;
                    Rate = rate;
                    _currency = currency;
                    _date = date;
                }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                public override string ToString()
                {
                    return $"{_date}   " +
                           $"{_currency}   " +
                           $"{Rate, -10}\t" +
                           $"{_bank}";
                }
                //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            }
            //-----------------------------------------------------------------
        }

        static void Main()
        {
            Download("exchange.xml", "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            Banks banks = new Banks("exchange.xml");

            Console.OutputEncoding = Encoding.UTF8;
            foreach (var bank in banks)
            {
                if (bank.Rate > 10)
                    Console.WriteLine(bank);
            }

            Console.Read();
        }
    }
}
