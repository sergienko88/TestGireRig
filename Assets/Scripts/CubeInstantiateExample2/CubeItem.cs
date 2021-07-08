using System;
using UnityEngine;

namespace Test.CubeInstantiator
{
    public class CubeItem : MonoBehaviour
    {
        public CubeData CubeData { get; set; }
        public event Action OnCubeDestroy;
        private Vector3 _startPosition;

        public void SetDefaultTransformData(Vector3 startPos, Quaternion startRotation)
        {
            transform.position = startPos;
            _startPosition = startPos;
            transform.rotation = startRotation;
        }

        private void Update()
        {
            transform.position += transform.forward * CubeData.Speed * Time.deltaTime;
            if (Vector3.Distance(_startPosition, transform.position) > CubeData.PathLength)
            {                
                OnCubeDestroy?.Invoke();
                OnCubeDestroy = null;
            }
        }
    }
}