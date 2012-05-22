using System;
using System.Net;


namespace VkWP.Helpers
{
    /// <summary>
    ////Performs various transofmations over text
    /// </summary>
    public static class TextPreprocessor
    {
        /// <summary>
        /// Decodes printable ASCII characters and some HTML tags
        /// </summary>
        /// <param name="html">String to be decoded</param>
        /// <returns>Decoded string</returns>
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
