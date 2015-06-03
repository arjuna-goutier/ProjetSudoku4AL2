using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    public static class IEnumerablesExtensions
    {
        public delegate bool Condition<T>(T t);
        public delegate bool initialize<T>();
        public static bool UniqueValues<T>(this IEnumerable<T> values, IEqualityComparer<T> comparer = null)
        {
            HashSet<T> set = new HashSet<T>(comparer);
            foreach (T item in values)
                if (!set.Add(item))
                    return false;
            return true;
        }

        public static IEnumerable<IEnumerable<T>> SplitWhen<T>(this IEnumerable<T> source,Condition<T> condition) {
            int countToSkip = 0;
            List <IEnumerable<T>> toReturn = new List<IEnumerable<T>>();
            while (countToSkip < source.Count()) {
                IEnumerable<T> value = source.Skip(countToSkip).TakeWhile((t) => !condition(t));
                if(value.Any())
                    toReturn.Add(value);
                countToSkip += value.Count() + 1;
            }
            return toReturn;
        }
        
        public static IEnumerable<IEnumerable<T>> SplitBy<T>(this IEnumerable<T> source, int span) {
            for (int countToSkip = 0; countToSkip < source.Count(); countToSkip += span)
                yield return source.Skip(countToSkip).Take(span);
        }
        
        private static IEnumerable<T> Sub<T>(this IEnumerable<T> source, int begin, int count) {
            return source.Skip(begin).Take(count);
        }

        public static T[][] ToArrayArray<T>(this IEnumerable<IEnumerable<T>> source) {
            return source.Select(line => line.ToArray()).ToArray();
        }
    }
}
