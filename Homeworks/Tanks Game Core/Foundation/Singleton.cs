namespace Tanks_Game_Core
{
    public class Singleton<T> where T : class, new()
    {
        private static T instance;
        public static T Instance {
            get
            {
                if (instance == null)
                    instance = new T();
                return instance;
            }
            private set => instance = value;
        }
    }
}