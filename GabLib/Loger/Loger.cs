using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;


namespace Gab
{
    #region Description
    /*
     * Тема: Взаимодействие с файловой системой.
     * Цель: Закрепить у слушателей практические навыки и теоретические знания о классах, обеспечивающих работу с файловой системой.
     *       Научиться использовать принципы объектно-ориентированного программирования.
     */
    #endregion

    namespace Loger
    {
        public static class Loger
        {
            //---------------------------------------------------------------------
            public enum MessageType
            {
                Error,
                Exception,
                Text,
                Info,
                Warning
            }
            //---------------------------------------------------------------------
            public static string LogFile    { get; set; } = "log.txt";
            public static string ConfigFile { get; set; } = "config.ini";
            //---------------------------------------------------------------------
            private static readonly List<string> Fields;
            private static readonly string[]     Pattern;
            //---------------------------------------------------------------------
            private delegate void D(StreamWriter sw, string msg, MessageType type);
            private static event  D WriteLine;
            //---------------------------------------------------------------------
            static Loger()
            {
                using Stream fs = new FileStream(ConfigFile, FileMode.Open);
                TextReader tr = new StreamReader(fs);

                string str = tr.ReadToEnd();
                fs.Position = 0;

                Fields = Regex.Matches(str, @"\[.*?\]").Cast<Match>().Select(m => m.Value).ToList();
                for (var i = 0; i < Fields.Count; i++)
                {
                    if (Fields[i] == "[Pattern]") Fields.RemoveAt(i);
                    else Fields[i] = Fields[i].Trim('[', ']');
                }

                while (true)
                {
                    str = tr.ReadLine();
                    if (str != null && str.Contains("[Pattern]"))
                    {
                        var dic = new Dictionary<int, string>(Fields.Count);
                        foreach (var field in Fields)
                        {
                            int ind = str.IndexOf(field, StringComparison.Ordinal);
                            if (ind != -1) dic.Add(ind, field);
                        }

                        Pattern = dic.OrderBy(i => i.Key)
                                     .ToDictionary(i => i.Key, i => i.Value)
                                     .Values
                                     .ToArray();

                        for (int i = 0; i < Pattern.Length; i++)
                        {
                            if (Pattern[i] == "DateTime")
                                WriteLine += delegate(StreamWriter sw, string msg, MessageType type)
                                            { sw.Write(DateTime.Now.ToString(CultureInfo.InvariantCulture)); };

                            else if (Pattern[i] == "Type")
                                WriteLine += delegate(StreamWriter sw, string msg, MessageType type)
                                            { sw.Write(type.ToString()); };

                            else if (Pattern[i] == "Message")
                                WriteLine += delegate(StreamWriter sw, string msg, MessageType type) 
                                            { sw.Write(msg); };


                            if (i != Pattern.Length - 1)
                                WriteLine += delegate(StreamWriter sw, string msg, MessageType type)
                                            { sw.Write(" : "); };
                        }

                        break;
                    }
                }
            }
            //---------------------------------------------------------------------
            public static void Write(string msg, MessageType type)
            {
                using StreamWriter sw = new StreamWriter(LogFile, true);
                WriteLine.Invoke(sw, msg, type);
                sw.WriteLine();
            }
            //---------------------------------------------------------------------
        }
    }
}
