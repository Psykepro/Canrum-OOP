namespace CanrumRPG.Interfaces
{
    using System.Collections.Generic;

    using CanrumRPG.Items;

    public interface IInventory
    {
        List<Item> Inventory { get; set; }
    }
}