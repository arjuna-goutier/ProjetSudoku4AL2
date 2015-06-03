using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{

    public class Grille
    {
        public  DateTime CreationDate { get; private  set; }
        public string Name { get; private set; }
        private readonly Case[][] grille;
        private readonly char[] possibleValues;

        private IEnumerable<CellGroup> lines {
            get {
                return from ligne in grille
                       select new CellGroup(ligne);
            }
        }
        private IEnumerable<CellGroup> columns {
            get {
                for (int i = 0; i < grille[0].Length; ++i)
                    yield return new CellGroup(grille.Select(line => line.ElementAt(i)).ToArray());
            }
        }
        private IEnumerable<CellGroup> areas {
            get {
                int areaLength = (int) Math.Sqrt((double) grille.Length);
                Matrix<List<Case>> regions= new Matrix<List<Case>>(areaLength,areaLength,() => new List<Case>(grille.Length));
                for(int y = 0 ; y < grille.Count() ; ++y)
	                for(int x = 0 ; x < grille[y].Count() ; ++x)
                        regions.Values[x / areaLength, y / areaLength].Add(grille[y][x]);
                return regions.Select(cells => new CellGroup(cells));
            }
        }
        private IEnumerable<CellGroup> allGroups {
            get {
                return lines.Concat(columns).Concat(areas);
            }
        }

        public Grille(string name, DateTime creationTime,char[] possibleValues,  char[][] grille) {
            if (grille.Length == 0)
                throw new InvalidGrilleException("The grid is empty");
            if (grille.Length != grille[0].Length)
                throw new InvalidGrilleException("All lines are not of the same size");
            if (!grille.All(line => line.Count() == grille[0].Length))
                throw new InvalidGrilleException("The grid is not a square");
            if (Math.Sqrt((double)grille.Length) % 1 != 0)
                throw new InvalidGrilleException("Cannot form valid areas with this size");
            if (!grille.All(line => line.All(c => possibleValues.Contains(c))))
                throw new InvalidGrilleException("All values are not in possible values");
            
            this.possibleValues = possibleValues;
            this.grille = grille.Select((line,y) => line.Select((value,x) => new Case(x,y,value)).ToArray()).ToArray();
            this.Name = name;
            this.CreationDate = creationTime;
        }
        
        public bool IsValid {
            get {
                return allGroups.All((group) => group.IsValid);
            }
        }
    }
    public class InvalidGrilleException : Exception {
        public InvalidGrilleException(string message)
            : base(message) { }
    }

}
