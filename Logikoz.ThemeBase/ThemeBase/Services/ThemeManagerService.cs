using Logikoz.ThemeBase.Enums;
using Logikoz.ThemeBase.Themes;

using Plugin.Settings;

using System.Collections.Generic;

using Xamarin.Forms;

namespace Logikoz.ThemeBase.Services
{
    public class ThemeManagerService
    {
        public static void ChangeTheme(ThemeEnum theme, string key = "SelectedTheme")
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                CrossSettings.Current.AddOrUpdateValue(key, (int)theme);

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

        public static ThemeEnum CurrentTheme(string key = "SelectedTheme") => (ThemeEnum)CrossSettings.Current.GetValueOrDefault(key, (int)ThemeEnum.Light);
    }
}