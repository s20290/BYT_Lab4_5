using System;
using System.Collections.Generic;

namespace MementoPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Memento> mementos = new List<Memento>();
            Player player = new Player();
            player.setCoordinates(new List<int> { 5, 2 });
            mementos.Add(player.saveMemento());
            player.setCoordinates(new List<int> { 1, 2 });
            mementos.Add(player.saveMemento());
            player.setCoordinates(new List<int> { 6, 21 });
            mementos.Add(player.saveMemento());
            player.setCoordinates(new List<int> { 54, 23 });
            mementos.Add(player.saveMemento());
            player.rollBackMemento(mementos[2]);
        }
    }
}
