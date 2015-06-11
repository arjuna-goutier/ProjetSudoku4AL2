using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    class SudokuManager
    {
        private FileReader fileReader;
        public SudokuManager(FileReader fileReader) {
            this.fileReader = fileReader;
        }

        public void DisplayValidity() {
            try {
                Console.WriteLine("Enter the file's path : ");
                string path = Console.ReadLine();
                SudokuReader reader = new SudokuReader(fileReader);
                
                foreach (Grille grille in reader.readAll(path))
                    Console.WriteLine("{0} is {1}", grille.Name, grille.IsValid ? "valid" : "not valid");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
