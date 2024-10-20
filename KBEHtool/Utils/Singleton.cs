namespace KBEHtool.Utils
{

    public class Singleton<T> where T : new()
    {
        private static T _instance;

        /// <summary>
        /// 单例模式需要实例化
        /// </summary>
        public static T instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

    }
}