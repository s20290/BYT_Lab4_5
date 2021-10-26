using System;
using System.Collections.Generic;

namespace ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            AssetObjectPool aop = new AssetObjectPool(new List<int> { 800,400});
            aop.CreateAsset(new List<int> { 394, 321 });
            aop.CreateAsset(new List<int> { 441, 21 });
            aop.CreateAsset(new List<int> { 364, 131 });
            aop.CreateAsset(new List<int> { 593, 121 });

            //taking out any object
            AssetObject a1 = aop.TakeOutAssetObject(2);
            Console.WriteLine(a1.AssetId);

            //object cannot be taken out because it is already taken out
            AssetObject a2 = aop.TakeOutAssetObject(2);
            if (a2 == null)
            {
                Console.WriteLine("Null");
            }

            //putting back asset to pool
            aop.PutBackAssetObject(a1);

            a2 = aop.TakeOutAssetObject(2);
            if (a2 != null)
            {
                Console.WriteLine("I'm not null "+a2.AssetId);
            }

            //telling pool that this object is not needed
            aop.SetObjectUsage(false, a1);

            //removing the object from pool
            aop.RemoveAsset(a1);
            a1 = aop.TakeOutAssetObject(2);

            if (a1 == null)
            {
                Console.WriteLine("Null");
            }

        }
    }
}
