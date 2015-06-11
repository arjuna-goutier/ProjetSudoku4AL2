using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace projetCS
{
    public class SudokuReader
    {
        private readonly IFileReader reader;
        private const int NameIndex= 0;
        private const int DateIndex = 1;
        private const int PossibleValuesIndex = 2;
        private const int GrilleStartIndex = 3;

        public SudokuReader(IFileReader fileReader) {
            this.reader = fileReader;
        }

        public IEnumerable<Grille> readAll(string path) {
            if (reader.Exists(path) == false)
                throw new FileNotFoundException("MSG_ERREURNOFICHIER");
            return from Grille in seperateGrille(reader.ReadAllLines(path))
                   select toGrille(Grille);
        }

        private IEnumerable<IEnumerable<string>> seperateGrille(IEnumerable<string> lines) {
            return lines.SplitWhen(x => x.StartsWith("-"));
        }

        private Grille toGrille(IEnumerable<string> lines) {
            try {
                return new Grille(
                    name: lines.ElementAt(NameIndex),
                    creationTime: DateTime.Parse(lines.ElementAt(DateIndex)),
                    possibleValues: lines.ElementAt(PossibleValuesIndex).ToArray(),
                    grille: lines.Skip(GrilleStartIndex).ToArrayArray()
                );
            }
            catch (InvalidGrilleException e) {
                throw new InvalidSudokuFileException("MSG_ERREURFICHIERINCORRECT");
            }
        }
    }

    public interface IFileReader {
        IEnumerable<string> ReadAllLines(string path);
        bool Exists(string path);
    }

    public class FileReader:IFileReader {
        public IEnumerable<string> ReadAllLines(string path) {
            return File.ReadAllLines(path);
        }

        public bool Exists(string path) {
            return File.Exists(path);
        }
    }

    public class InvalidSudokuFileException : Exception {
        public InvalidSudokuFileException(string message) : base(message) { }
    }
}