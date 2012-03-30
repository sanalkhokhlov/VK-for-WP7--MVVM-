using System;
using VkWP.Exceptions;
using VkWP.Models;
using RestSharp;

namespace VkWP.Client
{
    public partial class VkClient
    {
        public void GetPlacesAround(string latitude, string longitude, string radius, Action<RestResponse> success, Action<VkException> failure)
        {
            var request = _requestHelper.CreateGetPlacesRequest(latitude, longitude, radius);
            ExecuteAsync(request, success, failure);
        }


        public void GetPlaceById(string places, Action<PlaceItemList> success, Action<VkException> failure)
        {
            var request = _requestHelper.CreateGetPlaceByIdRequest(places);
            ExecuteAsync(request, success, failure);
        }
    }
}
