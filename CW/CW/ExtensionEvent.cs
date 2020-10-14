using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CW
{
    static class ExtensionEvent
    {
        //public static TDelegate RemoveAll<TDelegate>(this TDelegate @event) where TDelegate : Delegate
        //{
        //    foreach (dynamic @delegate in @event.GetInvocationList())
        //        @event -= @delegate;

        //    return @event;
        //}

        public static TDelegate Sort<TDelegate, TClass>(this TDelegate @event, IComparer<TClass> comparer)
            where TDelegate : Delegate
            where TClass    : class
        {
            Delegate[] array = @event.GetInvocationList();
            @event = null;

            TClass[] arrayClass = new TClass[array.Length];

            for (int i = 0; i < array.Length; i++)
                arrayClass[i] = (TClass)array[i].Target;

            Array.Sort(arrayClass, comparer);

            TDelegate[] arrayNew = new TDelegate[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (arrayClass[i].Equals(array[j].Target))
                    {
                        arrayNew[i] = (TDelegate)array[j];
                        break;
                    }
                }
            }

            foreach (var d in arrayNew)
                @event += (dynamic)d;
            
            return @event;
        }
    }
}
