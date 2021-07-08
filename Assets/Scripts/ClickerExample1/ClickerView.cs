using UnityEngine;
using UnityEngine.UI;

namespace Test.Clicker
{
    public class ClickerView : MonoBehaviour
    {

        [SerializeField]
        private Button _clickButton;

        public Button ClickButton
        {
            get
            {
                return _clickButton;
            }
        }

        [SerializeField]
        private Text _clickTextCount;

        public void SetClickCountData(int counts)
        {
            if (_clickTextCount != null)
            {
                _clickTextCount.text = counts.ToString();
            }
        }
    }
}
