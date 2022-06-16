using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.Core.Service
{
    public class CacheMarker : IEquatable<CacheMarker>
    {
        public string City { get; }
        public DateTime Timestamp { get; }

        public CacheMarker(string city)
        {
            City = city.ToUpper();
            Timestamp = DateTime.Now;
        }

        public bool Equals(CacheMarker other)
        {
            if (City == other.City && Timestamp.Subtract(other.Timestamp).Hours <= 1)
            {
                return true;
            }

            return false;
        }
    }
}
