namespace CanrumRPG.Interfaces
{
    using System.Collections.Generic;

    using Items;

    public interface IInventory
    {
        List<Item> Inventory { get; set; }
    }
}