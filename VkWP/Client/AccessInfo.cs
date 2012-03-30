using System.IO.IsolatedStorage;

namespace VkWP.Client
{
    public class AccessInfoBag
    {
        public string Token { get; set; }
        public string Uid { get; set; }
    }

    public static class AccessInfoStore
    {
        private const string Tokenkey = "tokenkey";
        private const string Uidkey = "uidkey";

        public static void Save(AccessInfoBag obj)
        {
            IsolatedStorageSettings.ApplicationSettings[Tokenkey] = obj.Token;
            IsolatedStorageSettings.ApplicationSettings[Uidkey] = obj.Uid;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }

        public static AccessInfoBag Load()
        {
            string token;
            string uid;

            if (!IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>(Tokenkey, out token))
            {
                return null;
            }

            if (!IsolatedStorageSettings.ApplicationSettings.TryGetValue<string>(Uidkey, out uid))
            {
                return null;
            }

            return new AccessInfoBag
            {
                Token = token,
                Uid = uid
            };
        }

        public static void Clear()
        {
            IsolatedStorageSettings.ApplicationSettings[Tokenkey] = null;
            IsolatedStorageSettings.ApplicationSettings[Uidkey] = null;
            IsolatedStorageSettings.ApplicationSettings.Save();
        }
    }

    public partial class VkClient
    {
        public virtual bool OAuthCallbackConfirmed { get; set; }
        public static string ClientId = "";
        public static string AuthUri = "http://api.vk.com/oauth/authorize";
        public static string LogoutUri = "http://api.vk.com/oauth/logout";
        public static string RedirectUri = "http://api.vk.com/blank.html";
        public static string Display = "";
        public static string Scope = "";
        public static string ResponseType = "token";

        public string GetAuthUrl()
        {
            return string.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}&display={4}&response_type={5}", AuthUri, ClientId, RedirectUri, Scope, Display, ResponseType);
        }

        public string GetLogoutUrl()
        {
            return string.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}&display={4}&response_type={5}", LogoutUri, ClientId, RedirectUri, Scope, Display, ResponseType);
        }
    }
}
