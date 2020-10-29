#define UseFileValueProperty

using System;
using System.IO;
using System.Linq;


#region Description
/*
 * Тема: Сериализация объектов, атрибуты.
 * Цель: закрепить у слушателей практические навыки и теоретические знания о сериализации.
 *       Научиться использовать  принципы объектно-ориентированного программирования. 
 */
#endregion

namespace Meeting_12
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileValueProperty : Attribute
    {
        //---------------------------------------------------------------------
        public FileValueProperty(string file){}
        //---------------------------------------------------------------------
        public static string StringValue(string propertyName, Type classType)
        {
            foreach (var prop in classType.GetProperties())
                if (prop.Name == propertyName)
                    foreach (var attr in prop.CustomAttributes)
                        if (attr.AttributeType == typeof(FileValueProperty))
                        {
                            using Stream stream = new FileStream
                            (
                                attr.ConstructorArguments.First().Value.ToString(), 
                                FileMode.Open
                            );
                            using TextReader textReader = new StreamReader(stream);

                            return textReader.ReadLine();
                        }
            return null;
        }
        //---------------------------------------------------------------------
    }
    public class MyClass
    {
        //---------------------------------------------------------------------
        public MyClass(string name, int age, DateTime birthday)
        {
            _name = name;
            _age = age;
            _birthday = birthday;
        }
        //---------------------------------------------------------------------
        #if UseFileValueProperty
        [FileValueProperty(file: "Name.ini")]
        #endif
        public string Name 
        {
            get => FileValueProperty.StringValue(propertyName: nameof(Name), classType: GetType()) ?? _name;
            set => _name = value;
        } private string _name;
        //---------------------------------------------------------------------
        #if UseFileValueProperty
        [FileValueProperty(file: "Age.ini")]
        #endif
        public int Age
        {
            get
            {
                string s = FileValueProperty.StringValue(propertyName: nameof(Age), classType: GetType());
                if (s != null && int.TryParse(s, out var n)) return n;
                return _age;
            }
            set => _age = value;
        } private int _age;
        //---------------------------------------------------------------------
        #if UseFileValueProperty
        [FileValueProperty(file: "Birthday.ini")]
        #endif
        public DateTime Birthday
        {
            get
            {
                string s = FileValueProperty.StringValue(propertyName: nameof(Birthday), classType: GetType());
                if (s != null && DateTime.TryParse(s, out var d)) return d;
                return _birthday;
            }
            set => _birthday = value;
        } private DateTime _birthday;
        //---------------------------------------------------------------------
    }

    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass("Arthur", 0, new DateTime(2020, 9, 26));

            Console.WriteLine(myClass.Name);
            Console.WriteLine(myClass.Age);
            Console.WriteLine(myClass.Birthday.ToShortDateString());

            Console.Read();
        }
    }
}
