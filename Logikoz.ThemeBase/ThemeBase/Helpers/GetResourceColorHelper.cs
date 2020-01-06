using Logikoz.ThemeBase.Enums;

using Xamarin.Forms;

namespace Logikoz.ThemeBase.Helpers
{
    public class GetResourceColorHelper
    {
        /// <summary>
        /// Obtem a <see cref="Color"/> de um determinado resource.
        /// </summary>
        public static (Color? color, bool result) GetResourceColor(ColorsEnum resource)
        {
            if (Application.Current.Resources.TryGetValue(resource.ToString(), out object color))
                return ((Color)color, true);

            return (null, false);
        }
    }
}