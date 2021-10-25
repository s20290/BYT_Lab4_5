using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
{
    class Player
    {
        private List<int> coordinates;
        public void setCoordinates(List<int> coor)
        {
            Console.WriteLine($"Setting new coordinates: [{coor[0]},{coor[1]}]");
            this.coordinates = coor;
        }
        public Memento saveMemento()
        {
            Console.WriteLine("Saving memento");
            return new Memento(this.coordinates);
        }
        public void rollBackMemento(Memento memento)
        {
            this.coordinates = memento.getCoordinates();
            Console.WriteLine($"Rolled back to coordinates: [{coordinates[0]},{coordinates[1]}]");
        }
    }
}
