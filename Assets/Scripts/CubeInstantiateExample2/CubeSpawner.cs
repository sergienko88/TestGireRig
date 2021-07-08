using UnityEngine;

namespace Test.CubeInstantiator
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField]
        private CubeItem _cubePrefab;

        private ObjectPool<CubeItem> _cubePool;

        private float _timer;
        private float _spawnTime;
        private float _nextCubePathLength;
        private float _nextCubeSpeed;

        private void Start()
        {
            _cubePool = new ObjectPool<CubeItem>(_cubePrefab);
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer > _spawnTime)
            {
                _timer = 0;
                SpawnCube();
            }
        }

        private void SpawnCube()
        {
            var tmpCube = _cubePool.Get();
            tmpCube.SetDefaultTransformData(transform.position, Quaternion.Euler(0f, Random.Range(0f, 360f), 0f));
            tmpCube.CubeData = new CubeData(_nextCubeSpeed, _nextCubePathLength);
            tmpCube.OnCubeDestroy += ()=> {
                _cubePool.Recycle(tmpCube);
                tmpCube.gameObject.SetActive(false);
            };
            tmpCube.gameObject.SetActive(true);
        }

        public void SetSpawnTime(float spawnTime)
        {
            _spawnTime = spawnTime;
        }

        public void SetPathLengthParam(float pathLength)
        {
            _nextCubePathLength = pathLength;
        }

        public void SetSpeedParam(float speed)
        {
            _nextCubeSpeed = speed;
        }
    }
}