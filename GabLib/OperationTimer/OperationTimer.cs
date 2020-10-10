using System;
using System.Diagnostics;

namespace Gab
{
    namespace OperationTimer 
    {
        /// <summary>
        /// Вспомогательный класс для профилирования участка кода
        /// выполняет измерения времени выполнения
        /// и подсчет количества сборок мусора
        /// <author>
        /// https://github.com/Gololobov-Sergey
        /// </author>
        /// </summary>
        public sealed class OperationTimer : IDisposable
        {
            private readonly long _startTime;
            private readonly string _text;
            private readonly int _collectionCount;

            public OperationTimer(string text)
            {
                OperationTimer.PrepareForOperation();
                _text = text;
                _collectionCount = GC.CollectionCount(0);
                _startTime = Stopwatch.GetTimestamp();
            }

            /// <summary>
            /// Вызывается при разрушении объекта
            /// Выводит:
            /// значение времени, прошедшего с момента
            /// создания объекта до момента его удаления
            /// количество выполненных сборок мусора,
            /// выполненных за это время
            /// </summary>
            public void Dispose() => Console.WriteLine(string.Format("{0}\t{1:0.00} секунды(сборок мусора {2})",
                (object) _text,
                (object) ((double) (Stopwatch.GetTimestamp() - _startTime) / (double) Stopwatch.Frequency),
                (object) (GC.CollectionCount(0) - _collectionCount)));

            /// <summary>
            ///  Метод удаляются все неиспользуемые объекты
            ///  Это надо для "чистоты эксперимента",
            ///  т.е. чтобы сборка мусора происходила только
            ///  для объектов, которые будут создаваться
            ///  в профилируемом блоке кода
            /// </summary>
            private static void PrepareForOperation()
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }
    }
}
