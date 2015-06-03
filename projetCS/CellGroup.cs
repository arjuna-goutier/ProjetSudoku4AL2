using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projetCS;
namespace projetCS
{
    class CellGroup
    {
        private IEnumerable<Case> cells;
        public CellGroup(IEnumerable<Case> cells) {
            this.cells = cells;
        }
        public CellGroup(params Case[] cells):this(cells as IEnumerable<Case>) {
        }

        //regarde si toute les cellules sont identiques
        public bool IsValid {
            get {
                return cells.UniqueValues(new CellValueComparator());
            }
        }
        public override string ToString() {
            return cells.Aggregate("",(s,cell) => s + String.Format("Value : {0} X : {1} Y : {2} \n",cell.Value,cell.X,cell.Y));
        }
    }
}
