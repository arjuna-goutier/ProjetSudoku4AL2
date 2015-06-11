using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    //une sourcouche a la matrice pour hériter d'IEnumerable, et pouvoir utiliser les méthodes d'extension associées
    class Matrix<T> : IEnumerable<T>
    {
        public T[,] Values{get; private set;}
        public int Height { get; private set; }
        public int Width { get; private set; }
        public T At(int x, int y) {
            return Values[x,y];
        }

        public Matrix(int height, int width, Func<T> initialise = null) {
            Values = new T[width,height];
            if (initialise == null) return;
            this.Height = height;
            this.Width = width;
            
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < width; ++x)
                    Values[x, y] = initialise();
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator() {
            return new WholeMatrixEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return new WholeMatrixEnumerator(this);
        }
        public IEnumerable<IEnumerable<T>> Lines {
            get {
                for (int i = 0; i < Height; ++i)
                    yield return new LineMatrixEnumerable(this,i);
            }
        }
        public IEnumerable<IEnumerable<T>> columns {
            get {
                for (int i = 0; i < Height; ++i)
                    yield return new ColumnMatrixEnumerable(this, i);
            }
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
                if (x >= source.Values.GetUpperBound(0))
                {
                    x = 0;
                    ++y;
                    return y <= source.Values.GetUpperBound(1);
                }
                ++x;
                return true;        //puisque la ligne n'etait pas terminée, c'est forcement vrai
            }
            public override void Reset() {
                x = 0;
                y = 0;
            }
        }
        class ColumnMatrixEnumerator : MatrixEnumerator {
            public ColumnMatrixEnumerator(Matrix<T> source,int x) :
                base(source: source,x: x) { }

            public override bool MoveNext() {
                return ++y <= source.Values.GetUpperBound(1);
            }
            public override void Reset() {
                y = 0;
            }
        }
        class LineMatrixEnumerable : IEnumerable<T> {
            Matrix<T> source;
            int y;
            public LineMatrixEnumerable(Matrix<T> source, int y) {
                this.source = source;
                this.y = y;
            }


            public IEnumerator<T> GetEnumerator() {
                return new LineMatrixEnumerator(source, y);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return new LineMatrixEnumerator(source, y);
            }
        }
        class ColumnMatrixEnumerable: IEnumerable<T> {
            Matrix<T> source;
            int x;
            public ColumnMatrixEnumerable(Matrix<T> source, int x) {
                this.source = source;
                this.x = x;
            }


            public IEnumerator<T> GetEnumerator() {
                return new ColumnMatrixEnumerator(source, x);
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
                return new ColumnMatrixEnumerator(source, x);
            }
        }
        class LineMatrixEnumerator : MatrixEnumerator {
            public LineMatrixEnumerator(Matrix<T> source, int y) :
                base(source: source,y: y) { }

            public override bool MoveNext() {
                return ++x <= source.Values.GetUpperBound(0);
            }
            public override void Reset() {
                x = 0;
            }
        }
    }
}
