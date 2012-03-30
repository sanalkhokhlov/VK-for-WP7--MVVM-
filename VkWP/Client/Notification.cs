using System;
using RestSharp;
using VkWP.Exceptions;

namespace VkWP.Client
{
    public partial class VkClient
    {
        public void GetNotifications(Action<RestResponse> success, Action<VkException> failure)
        {
            ExecuteAsync(_requestHelper.CreateGetNotificationRequest(), success, failure);
        }
    }
}
