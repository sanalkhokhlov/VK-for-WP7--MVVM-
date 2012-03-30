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
using VkWP.Exceptions;
using VkWP.Models;

namespace VkWP.Client
{
    public partial class VkClient
    {
        public void GetProfiles(string uids, Action<ProfileItemList> success, Action<VkException> failure)
        {
            var request = _requestHelper.CreateGetProfilesRequest(uids);
            ExecuteAsync(request, success, failure);
        }
    }
}
