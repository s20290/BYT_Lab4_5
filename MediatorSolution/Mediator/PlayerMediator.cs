
class PlayerMediator: IPlayerMediator
{
    private Player player;
    private Weapon weapon;
    private bool playerStatus;

    void IPlayerMediator.registerPlayer(Player player)
    {
        this.player = player;
    }

    void IPlayerMediator.registerAttack(Weapon weapon)
    {
        this.weapon = weapon;
    }

    public bool wasPlayerHit()
    {
        return playerStatus;
    }

    public void setHitOrNot(bool status)
    {
        this.playerStatus = status;
    }
}