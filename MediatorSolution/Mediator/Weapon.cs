using System;

class Weapon: IAction{
    public IPlayerMediator PlayerMediator { get; set; }
    public Weapon(IPlayerMediator playerMediator){
        this.PlayerMediator = playerMediator;
        this.PlayerMediator.setHitOrNot(true);
    }
    public void hitPlayer(){
        Console.WriteLine("Attacking");
        this.PlayerMediator.setHitOrNot(false);
    }
}