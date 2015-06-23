using CanrumRPG.Engine;

namespace CanrumRPG.Items
{
    public class MagisStone : Consumable
    {
        public MagisStone(Position position) 
                    : base(position, "Magic Stone", 0, 20, 100, 100)
        {
        }
    }
}
