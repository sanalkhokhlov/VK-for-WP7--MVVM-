using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace VkWP.Helpers
{
    /// <summary>
    ////Преобразует спецсимволы и некоторые HTML теги
    /// </summary>
    public static class HtmlDecoder
    {
        /// <summary>
        /// Декодирует печатные символы ASCII и теги html
        /// </summary>
        /// <param name="html">Строка для преобразования</param>
        /// <returns>Декодировання строка</returns>
        public static string Decode(string html)
        {
            string result = string.Empty;
            if (html != null)
            {
                result = HttpUtility.HtmlDecode(html.Replace("<br>", "\n"));
            }
            return result;
        }

    }
}
