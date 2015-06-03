using System;
using projetCS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.IO;
namespace TestProjetCS1
{
    [TestClass]
    public class SudReaderTest
    {
        [TestMethod]
        public void TestMethod1() {
            var grilles = SudokuReader.readAll(".\\Fichier de sudoku résolution (version du 15 04 2015).sud");
        }
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException),
            "le fichie n'existe pas")]
        public void NoFileFail()
        {
            var grilles = SudokuReader.readAll(".\\inexistant.sud");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidSudokuFileException),
            "le fichier est invalide")]
        public void BadFileFail()
        {
            var grilles = SudokuReader.readAll(".\\Fichier_Invalide.sud").ToArray();
        }
    }
}
