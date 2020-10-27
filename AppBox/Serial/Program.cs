using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serial
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryFormatter bf = new BinaryFormatter();

            using (Stream stream = File.Create("file.binary"))
            {
                Payment paymentSave = new Payment(1000, 31, 100);
                Console.WriteLine(paymentSave);

                bf.Serialize(stream, paymentSave);
            }
            Console.WriteLine();

            using (Stream stream = File.OpenRead("file.binary"))
            {
                Payment paymentLoad = bf.Deserialize(stream) as Payment;
                Console.WriteLine(paymentLoad);
            }
            Console.Read();
        }
    }
}
