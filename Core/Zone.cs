using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarkovTools.Core
{
    internal class Zone
    {
        public string zoneId { get; set; }
        public string zoneName { get; set; }
        public string zoneLocation { get; set; }
        public string zoneType { get; set; }
        public ZoneTransform position { get; set; }
        public ZoneTransform rotation { get; set; }
        public ZoneTransform scale { get; set; }
    }

    internal class ZoneTransform
    {
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }

        public ZoneTransform(string x, string y, string z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
