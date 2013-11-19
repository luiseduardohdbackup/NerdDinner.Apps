using NerdDinner.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        using (JsonReader reader = new JsonTextReader(sr))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            var list = serializer.Deserialize<List<Dinner>>(reader);
                            success(list);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                error(exception);
            }
        }
    }
}
