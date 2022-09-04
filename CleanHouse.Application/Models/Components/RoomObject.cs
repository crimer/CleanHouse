using CleanHouse.Application.Helpers;

namespace CleanHouse.Application.Models.Components
{
    public class RoomObject : Bindable
    {
        public string Name { get => Get<string>(); set => Set(value); }
        public string IconSource { get => Get<string>(); set => Set(value); }

        public RoomObject(string name, string icon)
        {
            Name = name;
            IconSource = icon;
        }
    }
}
