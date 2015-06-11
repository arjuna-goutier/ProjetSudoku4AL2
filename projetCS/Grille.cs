using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetCS
{
    public static class Matrices
    {
        public static T[,] initialyze<T>(int width, int height, Func<T> initialise) {
            T[,] toReturn = new T[width,height];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < height; ++x)
                    toReturn[x, y] = initialise();
             return toReturn;
        }
        public static T[,] initialyze<T>(int width, int height, Func<int,int,T> initialise) {
            T[,] toReturn = new T[width, height];
            for (int y = 0; y < height; ++y)
                for (int x = 0; x < height; ++x)
                    toReturn[x, y] = initialise(x,y);
            return toReturn;
        }
    }

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
                        //utilisation de la division pour pouvoir arrondir a la bonne region
                        regions.Values[x / areaLength, y / areaLength].Add(grille[y][x]);

                return from cells in regions
                       select new CellGroup(cells);
            }
        }
        private IEnumerable<CellGroup> allGroups {
            get {
                return lines.Concat(columns).Concat(areas);
            }
        }
        public bool IsValid {
            get {
                return allGroups.All((group) => group.IsValid);
            }
        }

        public Grille(string name, DateTime creationTime,char[] possibleValues,  char[][] grille) {
            if (grille.Length == 0)
                throw new InvalidGrilleException("The grid is empty");
            if (grille.Length != grille[0].Length)
                throw new InvalidGrilleException("The grid is not a square");
            if (!grille.All(line => line.Count() == grille[0].Length))
                throw new InvalidGrilleException("All lines are not of the same size");
            if (Math.Sqrt((double)grille.Length) % 1 != 0)
                throw new InvalidGrilleException("Cannot form valid areas with this size(need to have an integer squarer root)");
            if (!grille.All(line => line.All(c => possibleValues.Contains(c))))
                throw new InvalidGrilleException("All values are not in possible values");
            
            this.possibleValues = possibleValues;
            this.grille = grille.SelectWithCoordinate((value,x,y) => new Case(x,y,value))
                                .ToArrayArray();
            this.Name = name;
            this.CreationDate = creationTime;
        }
    }
    public class InvalidGrilleException : Exception {
        public InvalidGrilleException(string message) : base(message) {}
    }
}
