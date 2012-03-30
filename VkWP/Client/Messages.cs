using System;
using VkWP.Exceptions;
using RestSharp;

namespace VkWP.Client
{
    public partial class VkClient
    {
        public void GetDialogs(string count, Action<RestResponse> success, Action<VkException> failure)
        {
            var request = _requestHelper.CreateGetDialogsRequest("0", count, "0");
            ExecuteAsync(request, success, failure);
        }

        public void GetDialogsHistory(string uid, string count, Action<RestResponse> success, Action<VkException> failure)
        {
            var request = _requestHelper.CreateGetDialogsHistoryRequest(uid,"0", count, "0");
            ExecuteAsync(request, success, failure);
        }

        public void GetDialogsChatHistory(string chatId, string count, Action<RestResponse> success, Action<VkException> failure)
        {
            var request = _requestHelper.CreateGetDialogsHistoryRequest(chatId, "0", count, "0");
            ExecuteAsync(request, success, failure);
        }
    }
}
