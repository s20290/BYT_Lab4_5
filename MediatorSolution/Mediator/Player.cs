using System;

class Player: IAction{
    
    public IPlayerMediator PlayerMediator { get; set; }
    public Player(IPlayerMediator playerMediator){
        this.PlayerMediator = playerMediator;
        
    }
    public void hitPlayer(){
        if (this.PlayerMediator.wasPlayerHit())
        {
            Console.WriteLine("Player was hit");
            this.PlayerMediator.setHitOrNot(true);
        }else{
            Console.WriteLine("Player survives");
        }
    }
}