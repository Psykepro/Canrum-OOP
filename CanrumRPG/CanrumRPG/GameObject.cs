namespace CanrumRPG
{
    using System;

    using Engine;

    using Enums;

    using Exceptions;

    public abstract class GameObject
    {
        private Position position;

        private char mapMarker;

        private string name;

        protected GameObject(Position position, MapMarkers mapMarker, string name)
        {
            this.Position = position;
            this.MapMarker = mapMarker;
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be null, empty or whitespace.");
                }

                this.name = value;
            }
        }

        public Position Position
        {
            get
            {
                return this.position;
            }

            set
            {
                if (value.X < 0 
                    || value.Y < 0 
                    || value.X >= GameEngine.MapWidth
                    || value.Y >= GameEngine.MapHeight)
                {
                    throw new ObjectOutOfBoundsException("Specified coordinates are outside map.");
                }

                this.position = value;
            }
        }

        public MapMarkers MapMarker
        {
            get
            {
                MapMarkers marker = default(MapMarkers);
                switch (this.mapMarker)
                {
                    case 'P':
                        marker = MapMarkers.P;
                        break;
                    case 'E':
                        marker = MapMarkers.E;
                        break;
                    case 'T':
                        marker = MapMarkers.T;
                        break;
                }

                return marker;
            }

            set
            {
                switch (value)
                {
                    case MapMarkers.P:
                        this.mapMarker = 'P';
                        break;
                    case MapMarkers.E:
                        this.mapMarker = 'E';
                        break;
                    case MapMarkers.T:
                        this.mapMarker = 'T';
                        break;
                }
            }
        }
    }
}
