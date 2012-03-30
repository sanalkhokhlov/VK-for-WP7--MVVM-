using System;
using VkWP.Exceptions;
using VkWP.Models;

namespace VkWP.Client
{
    public partial class VkClient
    {
        public void GetMainViewInfo(Action<MainViewInfo> success, Action<VkException> failure)
        {
            ExecuteAsync<MainViewInfo>(_requestHelper.CreateGetMainViewInfo(), success, failure);
        }
    }
}
