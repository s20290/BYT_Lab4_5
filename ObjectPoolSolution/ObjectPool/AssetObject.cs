using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPool
{
    class AssetObject
    {
        static int nextId;
        public int AssetId { get; set; }
        public bool AssetNeeded { get; set; }
        public List<int> Coordinates { get; set; }
        public AssetObject(List<int> coor)
        {
            AssetId = Interlocked.Increment(ref nextId);
            Coordinates = coor;
            AssetNeeded = true;
        }
    }
}
