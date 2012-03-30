using System;
using System.Net;
using System.Net.NetworkInformation;
using RestSharp;
using RestSharp.Deserializers;
using VkWP.Exceptions;
using VkWP.Helpers;

namespace VkWP.Client
{
    public partial class VkClient
    {
        private RestClient _restClient;
        private RequestHelper _requestHelper;
        public static AccessInfoBag AccessInfo { get; set; }
        private volatile bool _active;
        public bool Active
        {
            get { return this._active; }
        }

        public VkClient(string clientId, string scope, string display)
        {
            _restClient = new RestClient("https://api.vk.com/");
            _restClient.ClearHandlers();
            _restClient.AddHandler("*", new JsonDeserializer());
            _requestHelper = new RequestHelper();
            AccessInfo = new AccessInfoBag();
            ClientId = clientId;
            Scope = scope;
            Display = display;
        }

        public void Start(AccessInfoBag accessInfo)
        {
            if (this._active)
            {
                return;
            }

            if (accessInfo == null)
            {
                return;
            }
            this._active = true;

            AccessInfo = accessInfo;
        }

        public void Stop()
        {
            if (!this._active)
            {
                return;
            }
            this._active = false;
            AccessInfo = null;
            AccessInfoStore.Clear();
        }

        private void ExecuteAsync(RestRequest request, Action<RestResponse> success, Action<VkException> failure)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                failure(new VkException
                {
                    StatusCode = HttpStatusCode.BadGateway
                });
            else
                _restClient.ExecuteAsync(request, (Action<RestResponse>)(response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK) failure(new VkException((RestResponseBase)response));
                    else success(response);
                }));
        }

        private void ExecuteAsync<T>(RestRequest request, Action<T> success, Action<VkException> failure) where T : new()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                failure(new VkException
                {
                    StatusCode = HttpStatusCode.BadGateway
                });
            else
            {
                _restClient.ExecuteAsync<T>(request, (Action<RestResponse<T>>)(response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK) failure(new VkException((RestResponseBase)response));
                    else success(response.Data);
                }));
            }
        }
    }
}
