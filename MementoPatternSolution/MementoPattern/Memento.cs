using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class Memento
    {
        private List<int> coordinates;
        public Memento(List<int> coor)
        {
            this.coordinates = coor;
        }
        public List<int> getCoordinates()
        {
            return this.coordinates;
        }
    }
}
