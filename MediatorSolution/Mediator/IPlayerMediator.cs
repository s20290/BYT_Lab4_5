interface IPlayerMediator{
    void registerPlayer(Player player);
    void registerAttack(Weapon weapon);
    bool wasPlayerHit();
    void setHitOrNot(bool status);
}