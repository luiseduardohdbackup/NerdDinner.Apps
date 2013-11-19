using NerdDinner.Core;
using System;
using System.Collections.Generic;

namespace NerdDinner.Mobile.Services
{
    public interface INerdDinnerService
    {
        void GetFeedItems(Action<List<Dinner>> success, Action<Exception> error);
    }
}
