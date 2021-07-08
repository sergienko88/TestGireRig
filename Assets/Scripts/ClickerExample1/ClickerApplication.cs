using UnityEngine;

namespace Test.Clicker
{
    public class ClickerApplication : MonoBehaviour
    {
        [SerializeField]
        private ClickerView _clickerView;
        public ClickerView ClickerView
        {
            get
            {
                return _clickerView;
            }
        }

        public ClickerController ClickerController { get; private set; }
        public ClickerModel ClickerModel { get; private set; }



        private void Start()
        {
            ClickerModel = new ClickerModel();
            ClickerController = new ClickerController(ClickerModel, ClickerView);
        }
    }
}