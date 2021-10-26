using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{
    abstract class ObjectPool

    {
        protected Dictionary<int, AssetObject> LockedObject { get; set; }
        protected Dictionary<int, AssetObject> UnlockedObject { get; set; }
        protected List<int> EnvironmentSize { get; set; }
        public ObjectPool(List<int> size)
        {
            EnvironmentSize = size;
            LockedObject = new Dictionary<int, AssetObject>();
            UnlockedObject = new Dictionary<int, AssetObject>();
        }

        public abstract void CreateAsset(List<int> coor);
        public abstract void RemoveAsset(AssetObject assetObject);
        public abstract bool WithinEnvironment(AssetObject assetObject);
        public abstract bool IsObjectStillNeeded(AssetObject assetObject);
        public abstract void SetObjectUsage(bool need, AssetObject assetObject);

        public AssetObject TakeOutAssetObject(int id)
        {
            AssetObject tmpObject;
            bool hasValue = UnlockedObject.TryGetValue(id, out tmpObject);
            if (hasValue)
            {
                UnlockedObject.Remove(tmpObject.AssetId);
                LockedObject.Add(tmpObject.AssetId, tmpObject);
                return tmpObject;
            }
            Console.WriteLine("Key has no value stored");
            return null;
        }
        public void PutBackAssetObject(AssetObject assetObject)
        {
            AssetObject tmpObject;
            bool hasValue = LockedObject.TryGetValue(assetObject.AssetId, out tmpObject);
            if (hasValue)
            {
                LockedObject.Remove(tmpObject.AssetId);
                UnlockedObject.Add(tmpObject.AssetId, tmpObject);
                return;
            }
            Console.WriteLine("Key has no value stored");
        }
    }
}
