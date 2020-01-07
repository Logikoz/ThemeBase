using Logikoz.ThemeBase.Enums;
using Logikoz.ThemeBase.Themes;

using Plugin.Settings;

using System.Collections.Generic;

using Xamarin.Forms;

namespace Logikoz.ThemeBase.Services
{
    public class ThemeManagerService
    {
        /// <summary>
        /// Define um novo tema para a aplicaçao.
        /// </summary>
        /// <param name="theme">O <see cref="ThemeEnum"/> que deseja adicionar.</param>
        public static void ChangeTheme(ThemeEnum theme)
        {
            ChangeTheme(theme, theme switch
            {
                ThemeEnum.Light => new LightDefaultTheme(),
                ThemeEnum.Dark => new DarkDefaultTheme(),
                _ => new LightDefaultTheme()
            });
        }

        /// <summary>
        /// Define um novo tema para a aplicaçao.
        /// </summary>
        /// <param name="theme">O tema que deseja adicionar.</param>
        /// <param name="enum">O <see cref="ThemeEnum"/> referente ao novo tema que será adicionado, por padrao é <see cref="ThemeEnum.Custom"/>.</param>
        public static void ChangeTheme(ResourceDictionary theme, ThemeEnum @enum = ThemeEnum.Custom) => ChangeTheme(@enum, theme);

        private static void ChangeTheme(ThemeEnum @enum, ResourceDictionary theme)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();

                CrossSettings.Current.AddOrUpdateValue("CurrentTheme", (int)@enum);

                mergedDictionaries.Add(theme);
            }
        }
    }
}