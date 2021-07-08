using System;

namespace Test.Clicker
{
    public class ClickerModel
    {
        public Action<int> OnClickCountChange;

        private int _clickCount;
        public int ClickCount
        {

            get
            {
                return _clickCount;
            }

            set
            {
                _clickCount = value;
                OnClickCountChange?.Invoke(_clickCount);
            }
        }
    }
}
