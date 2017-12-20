using System;
using System.Collections.Generic;

namespace ImagePortal.Core.Infrastructure
{
    public class ApiResult<T>
    {
        public T Data { get; set; }

        private string _redirectUrl;
        //private readonly List<ResultFeedback> _feedback = new List<ResultFeedback>();
        private int _redirectDelay;
        //public ResultFeedback[] FeedbackList => _feedback.ToArray();
        public string RedirectUrl => _redirectUrl;
        public int RedirectDelay => _redirectDelay;

        /// <summary>
        /// Adds feedback to the response.
        /// Allows chaining by returning the same instance of ApiResult.
        /// </summary>
        /// <typeparam name="TFeedback">Type of the feedback to show</typeparam>
        /// <returns>Returns same instance of ApiResult to allow for fluent chaining.</returns>
        //[TsIgnore]
        //public ApiResult<T> WithFeedback<TFeedback>() where TFeedback : IFeedback
        //{
        //    var inst = (TFeedback)(typeof(TFeedback)).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null).Invoke(null);
        //    return WithFeedback(inst);
        //}

        /// <summary>
        /// Adds feedback to the response.
        /// Allows chaining by returning the same instance of ApiResult.
        /// </summary>
        /// <param name="feedbackItem">Message to return to the user.</param>
        /// <returns>Returns same instance of ApiResult to allow for fluent chaining.</returns>
        //[TsIgnore]
        //public ApiResult<T> WithFeedback(IFeedback feedbackItem)
        //{
        //    Check.IsNotNull(feedbackItem, nameof(feedbackItem));

        //    //Hydration
        //    var feedbackRepo = DependencyResolver.Current.GetService<IFeedbackRepository>();
        //    feedbackItem = feedbackRepo.Get(feedbackItem.Alias);
        //    //end hydration

        //    string feedbackLevel = "";
        //    switch (feedbackItem.FeedbackLevel)
        //    {
        //        case FeedbackLevel.Info: feedbackLevel = "info"; break;
        //        case FeedbackLevel.Success: feedbackLevel = "success"; break;
        //        case FeedbackLevel.Warning: feedbackLevel = "warning"; break;
        //        case FeedbackLevel.Error: feedbackLevel = "error"; break;
        //    }
        //    _feedback.Add(new ResultFeedback
        //    {
        //        Headline = feedbackItem.Headline,
        //        Message = feedbackItem.HtmlContent,
        //        CssClass = feedbackLevel,
        //        DurationInMilliseconds = feedbackItem.DurationInMilliseconds
        //    });
        //    return this;
        //}

        /// <summary>
        /// Notifies the system to redirect user to given URL. 
        /// Overrides any previously set reditect URL.
        /// </summary>
        /// <param name="url">Url to direct the user to.</param>
        /// <param name="delayInMs">Offers an optional delay to the redirect.</param>
        /// <returns>Returns same instance of ApiResult to allow for fluent chaining.</returns>
        //[TsIgnore]
        public ApiResult<T> RedirectToUrl(string url, int delayInMs = 0)
        {
            _redirectUrl = url;
            _redirectDelay = delayInMs;
            return this;
        }
    }
}
