using System;
using VkWP.Exceptions;
using VkWP.Models;

namespace VkWP.Client
{
    public partial class VkClient
    {
        public void GetNewsfeed(Action<FeedItemList> success, Action<VkException> failure)
        {
            ExecuteAsync<FeedItemList>(_requestHelper.CreateGetNewsfeedRequest(AccessInfo.Uid), success, failure);
        }
    }
}
