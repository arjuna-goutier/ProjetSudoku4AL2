using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projetCS
{
    public class Program
    {
        public static void Main(string[] args) {
            new SudokuManager(new FileReader()).DisplayValidity();
        }
    }
}
