using Logikoz.ThemeBase.Enums;
using Logikoz.ThemeBase.Themes;

using Plugin.Settings;

using System.Collections.Generic;

using Xamarin.Forms;

namespace Logikoz.ThemeBase.Services
{
    public class ThemeManagerService
    {
        public static void ChangeTheme(ThemeEnum theme)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                CrossSettings.Current.AddOrUpdateValue("SelectedTheme", (int)theme);

                mergedDictionaries.Add(
                    theme switch
                    {
                        ThemeEnum.Light => new LightDefaultTheme(),
                        ThemeEnum.Dark => new DarkDefaultTheme(),
                        _ => new LightDefaultTheme()
                    });
            }
        }

        public static void LoadTheme() => ChangeTheme(CurrentTheme());

        public static ThemeEnum CurrentTheme() => (ThemeEnum)CrossSettings.Current.GetValueOrDefault("SelectedTheme", (int)ThemeEnum.Light);
    }
}