namespace Test.Clicker
{
    public class ClickerController
    {
        public ClickerModel ClickerModel { get; private set; }

        public ClickerView ClickerView { get; private set; }

        public ClickerController(ClickerModel clickerModel, ClickerView clickerView)
        {
            ClickerModel = clickerModel;
            ClickerView = clickerView;

            ClickerView.ClickButton?.onClick.AddListener(OnButtonClick);
            ClickerModel.OnClickCountChange += OnClickCountChange;
        }

        private void OnButtonClick()
        {
            ClickerModel.ClickCount++;
        }

        private void OnClickCountChange(int clickCount)
        {
            ClickerView.SetClickCountData(clickCount);
        }

        ~ClickerController()
        {
            ClickerView.ClickButton?.onClick.RemoveAllListeners();
            ClickerModel.OnClickCountChange -= OnClickCountChange;
        }
    }
}