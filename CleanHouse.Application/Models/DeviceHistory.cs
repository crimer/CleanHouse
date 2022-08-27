using System.Collections.Generic;

namespace CleanHouse.Application.Models
{
    public class DeviceHistory
    {
        public IEnumerable<DeviceData> Devices { get; set; }
    }
}
