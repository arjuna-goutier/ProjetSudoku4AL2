using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    //une sourcouche a la matrice pour hériter d'IEnumerable
    class Matrix<T> : IEnumerable<T>
    {
        public delegate T initialise();
        public T[,] Values{get; private set;}

        public Matrix(int height, int width,initialise initialise = null) {
            Values = new T[width,height];
            if (initialise == null) return;

            for (int y = 0; y < height; ++y)
                for (int x = 0; x < height; ++x)
                    Values[x, y] = initialise();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return new WholeMatrixEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return new WholeMatrixEnumerator(this);
        }
        //enumerator de matrice
        abstract class MatrixEnumerator : IEnumerator<T> {
            protected int x = 0;
            protected int y = 0;
            protected Matrix<T> source;
            public T Current {
                get { return source.Values[x, y]; }
            }

            object System.Collections.IEnumerator.Current {
                get { return source.Values[x, y]; }
            }
            public abstract bool MoveNext();
            public abstract void Reset();
            public MatrixEnumerator(Matrix<T> source,int x = 0, int y = 0) {
                this.source = source;
                this.x = x;
                this.y = y;
            }

            public void Dispose() {
                source = null;
            }


        }
        class WholeMatrixEnumerator:MatrixEnumerator {
            public WholeMatrixEnumerator(Matrix<T> source) :
                base(source: source) { }

            public override bool MoveNext() {
                if (x < source.Values.GetUpperBound(0))
                    ++x;
                else {
                    x = 0;
                    ++y;
                }
                return y <= source.Values.GetUpperBound(1);
            }
            public override void Reset() {
                x = 0;
                y = 0;
            }
        }
    }
}
