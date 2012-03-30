using RestSharp;

namespace VkWP.Helpers
{
    public class RequestHelper
    {
        #region place
        public RestRequest CreateGetPlacesRequest(string latitude, string longitude, string radius)
        {
            return new RestRequest(
                    string.Format("/method/places.search?access_token={0}&latitude={1}&longitude={2}&radius={3}", Client.VkClient.AccessInfo.Token, latitude, longitude, radius), Method.GET) { RequestFormat = DataFormat.Json };
        }

        public RestRequest CreateGetPlaceByIdRequest(string places)
        {

            return new RestRequest(string.Format("/method/places.getById?access_token={0}&places={1}", Client.VkClient.AccessInfo.Token, places), Method.GET) { RequestFormat = DataFormat.Json };
        }
        #endregion

        public RestRequest CreateGetNewsfeedRequest(string uid)
        {
            return new RestRequest(string.Format("/method/newsfeed.get?access_token={0}&count=20&uid={1}&filters=post,photo,photo_tag", Client.VkClient.AccessInfo.Token, uid), Method.GET) { RequestFormat = DataFormat.Json };
        }

        public RestRequest CreateGetMainViewInfo()
        {
            return new RestRequest("/method/execute?access_token=" +
                Client.VkClient.AccessInfo.Token + "&code=return{" +
                                   "\"user\":API.getProfiles({uids:" + Client.VkClient.AccessInfo.Uid + ",fields:\"photo_medium\"})," +
                                   "\"status\":API.status.get()," +
                                   "\"news\":API.newsfeed.get({filters:\"post\",count:20})," +
                                   "\"notifications\":API.notifications.get({filters:\"wall\"})" +
                                   "};", Method.GET) { RequestFormat = DataFormat.Json };
        }

        public RestRequest CreateGetNotificationRequest()
        {
            return new RestRequest(string.Format("/method/notifications.get?access_token={0}&filters=wall", Client.VkClient.AccessInfo.Token), Method.GET) { RequestFormat = DataFormat.Json };
        }

        #region Profile
        public RestRequest CreateGetProfilesRequest(string uids)
        {
            return new RestRequest("/method/users.get?access_token=" + Client.VkClient.AccessInfo.Token + "&uids=" + uids + "&fields=photo_medium", Method.GET) { RequestFormat = DataFormat.Json };
        }
        #endregion

        #region Messages
        public RestRequest CreateGetDialogsRequest(string offset, string count, string previewLength)
        {
            return new RestRequest("/method/messages.getDialogs?access_token=" + Client.VkClient.AccessInfo.Token + "&count=" + count, Method.GET) { RequestFormat = DataFormat.Json };
        }

        public RestRequest CreateGetDialogsHistoryRequest(string uid, string offset, string count, string previewLength)
        {
            return new RestRequest("/method/messages.getHistory?access_token=" + Client.VkClient.AccessInfo.Token + "&count=" + count + "&uid=" + uid, Method.GET) { RequestFormat = DataFormat.Json };
        }

        public RestRequest CreateGetDialogsChatHistoryRequest(string chatId, string offset, string count, string previewLength)
        {
            return new RestRequest("/method/messages.getHistory?access_token=" + Client.VkClient.AccessInfo.Token + "&count=" + count + "&chat_id=" + chatId, Method.GET) { RequestFormat = DataFormat.Json };
        }
        #endregion

        #region Friends

        public RestRequest CreateGetFriendsRequest()
        {
            return new RestRequest(string.Format("/method/friends.get?access_token={0}&uid={1}&fields=uid,first_name,last_name,photo&order=hints",Client.VkClient.AccessInfo.Token,Client.VkClient.AccessInfo.Uid), Method.GET) {RequestFormat = DataFormat.Json};
        }

        #endregion
    }
}
