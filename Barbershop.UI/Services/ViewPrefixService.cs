namespace Barbershop.UI.Services
{
    /// <summary>
    /// Генерация префикса кона по его типу.
    /// </summary>
    internal class ViewPrefixService
    {
        private static Dictionary<Type, string> _prefixes;

        static ViewPrefixService()
        {
            _prefixes = new Dictionary<Type, string>();
        }

        public static string Get<T>()
        {
            if (_prefixes.TryGetValue(typeof(T), out var prefix))
            {
                return prefix;
            }

            return string.Empty;
        }
    }
}
