using System;

namespace Test.CubeInstantiator
{
    [Serializable]
    public struct CubeData
    {
        public float Speed { get; private set; }
        public float PathLength { get; private set; }

        public CubeData(float speed, float pathLength)
        {
            Speed = speed;
            PathLength = pathLength;
        }
    }
}