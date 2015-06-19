namespace CanrumRPG.Interfaces
{
    using Characters;

    public interface IAttack
    {
        int AttackRating { get; set; }

        int DefenseRating { get; set; }

        int CritChance { get; set; }

        int BlockChance { get; set; }
        
        void Attack(Character target);
    }
}
