namespace ApiTest
{
    public struct ApiSetup<T> { }

    public class Api
    {
        public ApiSetup<T> For<T>(T obj)
        {
            return new ApiSetup<T>();
        }
    }

    public interface ISomeInterfaceA { }
    public interface ISomeInterfaceB { }

    public class ObjectA : ISomeInterfaceA { }

    public class ObjectB : ISomeInterfaceB { }

    class SomeClass
    {
        public void Setup()
        {
            Api apiObject = new Api();
            apiObject.For(new ObjectA()).SetupObjectA();
            apiObject.For(new ObjectB()).SetupObjectB();
        }
    }

    public static class SetupObjectExtention
    {
        public static void SetupObjectA<T>(this ApiSetup<T> api) where T : ObjectA
        {

        }

        public static void SetupObjectB<T>(this ApiSetup<T> api) where T : ObjectB
        {

        }
    }
}