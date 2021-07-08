namespace boxingV2
{
    interface ISomeInterface
    {
        void Call();
    }
    struct SomeStruct : ISomeInterface
    {
        public void Call()
        { 
        
        }
    }
    class SomeClass
    {
        public void Run()
        {
            var someStruct = new SomeStruct();
            SomeMethod(someStruct);
        }
        public void SomeMethod(SomeStruct param)
        {
            param.Call();
        }
    }
}