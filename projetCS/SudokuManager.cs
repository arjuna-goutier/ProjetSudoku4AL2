using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    static class SudokuManager
    {
        public static void DisplayValidity()
        {
            try {
                Console.WriteLine("Enter the file's path : ");
                string path = Console.ReadLine();
                foreach (Grille grille in SudokuReader.readAll(path))
                    Console.WriteLine("{0} is {1}", grille.Name, grille.IsValid ? "valid" : "not valid");
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
