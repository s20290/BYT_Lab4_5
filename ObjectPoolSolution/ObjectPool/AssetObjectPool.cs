using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPool
{

    class AssetObjectPool:ObjectPool
    {
        private Dictionary<int,AssetObject> assetObjects;
        public AssetObjectPool(List<int> size) : base(size)
        {
            EnvironmentSize = size;
            assetObjects = new Dictionary<int, AssetObject>();
        }
        private void FillAssetObjects()
        {
            List<Dictionary<int, AssetObject>> dictionaries = new List<Dictionary<int, AssetObject>>{ LockedObject, UnlockedObject };
            assetObjects = dictionaries.SelectMany(x => x)
                    .ToDictionary(x => x.Key, y => y.Value);
        }
        public override void CreateAsset(List<int> coor)
        {
            Console.WriteLine("Creating new asset object..");
            var newAsset = new AssetObject(coor);
            Console.WriteLine(newAsset.AssetId);
            UnlockedObject.Add(newAsset.AssetId,newAsset);
        }

        public override bool IsObjectStillNeeded(AssetObject assetObject)
        {
            FillAssetObjects();
            AssetObject tmpObject;
            bool hasValue = assetObjects.TryGetValue(assetObject.AssetId, out tmpObject);
            if (hasValue)
            {
                return tmpObject.AssetNeeded;
            }
            Console.WriteLine("Key has no value stored");
            return false;
        }

        public override void RemoveAsset(AssetObject assetObject)
        {
            if (IsObjectStillNeeded(assetObject))
            {
                Console.WriteLine("Object is still needed");
                return;
            }
            UnlockedObject.Remove(assetObject.AssetId);
            LockedObject.Remove(assetObject.AssetId);
            Console.WriteLine($"Removed asset: {assetObject.AssetId}" );
        }

        public override void SetObjectUsage(bool need, AssetObject assetObject)
        {
            FillAssetObjects();
            AssetObject tmpObject;
            bool hasValue = assetObjects.TryGetValue(assetObject.AssetId, out tmpObject);
            if (hasValue)
            {
                tmpObject.AssetNeeded = need;
            }
            else
            {
                Console.WriteLine("Key has no value stored");
            }
        }

        public override bool WithinEnvironment(AssetObject assetObject)
        {
            FillAssetObjects();
            AssetObject tmpObject;
            bool hasValue = assetObjects.TryGetValue(assetObject.AssetId, out tmpObject);
            if (hasValue)
            {
                int assetXCoord = tmpObject.Coordinates[0],
                    assetYCoord = tmpObject.Coordinates[1];

                int minWidthHeight = 0,
                    maxWidth = EnvironmentSize[0],
                    maxHeight = EnvironmentSize[1];

                bool withinEnvironment = assetXCoord >= minWidthHeight && assetXCoord <= maxWidth
                    && assetYCoord >= minWidthHeight && assetYCoord <= maxHeight
                    ? true : false;
                if (withinEnvironment)
                {
                    Console.WriteLine("Asset is within the environment");
                    return withinEnvironment;
                }
                Console.WriteLine("Asset is not within the environment");
                return withinEnvironment;
            }
            
            Console.WriteLine("Key has no value stored");
            return false;
        }
    }
}
