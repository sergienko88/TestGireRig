using UnityEngine;
using UnityEngine.UI;

namespace Test.CubeInstantiator
{
    public class CubeSpawnerUI : MonoBehaviour
    {
        [SerializeField]
        private CubeSpawner _cubeSpawner;

        [SerializeField]
        private InputField _spawnTimeInputField;

        [SerializeField]
        private InputField _nextSpeedInputField;
        
        [SerializeField]
        private InputField _pathLengthInputField;

        private void Start()
        {
            _spawnTimeInputField?.onValueChanged.AddListener(OnSpawnTimeChange);
            _nextSpeedInputField?.onValueChanged.AddListener(OnSpeedChange);
            _pathLengthInputField?.onValueChanged.AddListener(OnPathLengthChange);

            _spawnTimeInputField.text = "1";
            _nextSpeedInputField.text = "1";
            _pathLengthInputField.text = "50";
        }

        private void OnSpawnTimeChange(string spawnTimeParam)
        {
            if(float.TryParse(spawnTimeParam, out float spawnTimeResult))
            {
                _cubeSpawner.SetSpawnTime(spawnTimeResult);
            }
            else
            {
                Debug.Log("Can't parse spawn time param");
            }
        }

        private void OnSpeedChange(string speedParam)
        {
            if (float.TryParse(speedParam, out float speedParamResult))
            {
                _cubeSpawner.SetSpeedParam(speedParamResult);
            }
            else
            {
                Debug.Log("Can't parse speed param");
            }
        }

        private void OnPathLengthChange(string lengthParam)
        {
            if (float.TryParse(lengthParam, out float lengthParamResult))
            {
                _cubeSpawner.SetPathLengthParam(lengthParamResult);
            }
            else
            {
                Debug.Log("Can't parse path length param");
            }
        }

        ~CubeSpawnerUI()
        {
            _spawnTimeInputField?.onValueChanged.RemoveAllListeners();
        }
    }
}