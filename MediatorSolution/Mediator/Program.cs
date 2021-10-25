using System;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayerMediator playerMediator = new PlayerMediator();
            Player player = new Player(playerMediator);
            Weapon weapon = new Weapon(playerMediator);
            weapon.hitPlayer();
            player.hitPlayer();
            
        }
    }
}
