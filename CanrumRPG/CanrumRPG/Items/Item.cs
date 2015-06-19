namespace CanrumRPG.Items
{
    using global::CanrumRPG.Engine;
    using global::CanrumRPG.Enums;

    public abstract class Item : GameObject
    {
        protected Item(Position position, string name)
            : base(position, MapMarkers.T, name)
        {
            this.ItemState = ItemState.Available;
        }

        public ItemState ItemState { get; set; }
    }
}
