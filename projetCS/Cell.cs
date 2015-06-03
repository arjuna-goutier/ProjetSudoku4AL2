using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    public class Case
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public char Value { get; private set; }

        public Case(int x, int y, char value) {
            X = x;
            Y = y;
            Value = value;
        }
    }

    class CellValueComparator : IComparer<Case>, IEqualityComparer<Case>{
        int IComparer<Case>.Compare(Case c1, Case c2) {
            return c1.Value.CompareTo(c2.Value);
        }

        bool IEqualityComparer<Case>.Equals(Case c1, Case c2) {
            return c1.Value == c2.Value;
        }

        int IEqualityComparer<Case>.GetHashCode(Case c) {
            return c.Value.GetHashCode();
        }
    }
}
