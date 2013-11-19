using NerdDinner.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization.Json;

namespace NerdDinner.Mobile.Services
{
    class NerdDinnerService : INerdDinnerService
    {
        void INerdDinnerService.GetFeedItems(Action<List<Core.Dinner>> success, Action<Exception> error)
        {
            var url = "http://nerddinnerofficial.azurewebsites.net/api/dinners";

            var request = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                request.BeginGetResponse(result => ProcessResponse(success, error, request, result), null);
            }
            catch (Exception exception)
            {
                error(exception);
            }
        }
        private void ProcessResponse(Action<List<Dinner>> success, Action<Exception> error, HttpWebRequest request, IAsyncResult result)
        {
            try
            {
                var response = request.EndGetResponse(result);
                using (var stream = response.GetResponseStream())
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Dinner>));
                    var list = jsonSerializer.ReadObject(stream) as List<Dinner>;
                    success(list);
                }
            }
            catch (Exception exception)
            {
                error(exception);
            }
        }
    }
}
