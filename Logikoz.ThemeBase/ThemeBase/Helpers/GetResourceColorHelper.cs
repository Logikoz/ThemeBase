using Logikoz.ThemeBase.Enums;

using Xamarin.Forms;

namespace Logikoz.ThemeBase.Helpers
{
    public class GetResourceColorHelper
    {
        public (Color? color, bool result) GetResourceColor(ColorsEnum resource)
        {
            if (Application.Current.Resources.TryGetValue(resource.ToString(), out object color))
                return ((Color)color, true);

            return (null, false);
        }
    }
}