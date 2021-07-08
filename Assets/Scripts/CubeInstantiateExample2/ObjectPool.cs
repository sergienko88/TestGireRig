using System;
using System.Collections.Generic;
using UnityEngine;

namespace Test.CubeInstantiator
{
    [Serializable]
    public class ObjectPool<T> where T : MonoBehaviour
    {
        private T _prefabObject;
        private List<T> _unusableObjects = new List<T>();
        private List<T> _buzyObjects = new List<T>();

        public ObjectPool(T prefabObject, int quantity = 5)
        {
            if (prefabObject == null)
            {
                Debug.Log("ObjectPool can't create pool of [" + typeof(T) + "]: prefab is null");
            }

            _prefabObject = prefabObject;
            T tempObj;
            for (int i = 0; i < quantity; i++)
            {
                tempObj = GameObject.Instantiate(_prefabObject);
                _unusableObjects.Add(tempObj);
                tempObj.gameObject.SetActive(false);
            }
        }

        public T Get()
        {
            if (_prefabObject == null)
            {
                throw new Exception("Pool of [" + typeof(T) + "] is not initialized: prefab is null");
            }

            if (_unusableObjects.Count == 0)
            {
                _unusableObjects.Add(UnityEngine.Object.Instantiate(_prefabObject));
            }

            T nesessaryObj = _unusableObjects[0];
            _unusableObjects.Remove(nesessaryObj);
            _buzyObjects.Add(nesessaryObj);
            return nesessaryObj;
        }

        public void Recycle(T obj)
        {
            _buzyObjects.Remove(obj);
            _unusableObjects.Add(obj);
        }
    }
}