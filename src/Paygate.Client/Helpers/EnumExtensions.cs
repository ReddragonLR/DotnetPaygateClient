/*
 * Reference: https://www.c-sharpcorner.com/code/323/how-do-i-get-description-of-enum.aspx
 */

using System.ComponentModel;

namespace Paygate.Client.Helpers
{
    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
