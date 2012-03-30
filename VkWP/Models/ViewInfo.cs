using System.Collections.Generic;

namespace VkWP.Models
{
    public class MainViewInfo
    {
        public List<ProfileItem> User { get; set; }
        public StatusResponse Status { get; set; }
        public FeedItemList News { get; set; }
        public MainViewInfo Response { get; set; }
        public RestSharp.RestResponse Notifications { get; set; }
    }
}
