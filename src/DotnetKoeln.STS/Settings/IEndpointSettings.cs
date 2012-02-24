using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DotnetKoeln.STS.Services;

namespace DotnetKoeln.STS.Settings
{
    public interface IEndpointSettings
    {
        IEnumerable<string> ActiveEndpoints { get; }
        IEnumerable<string> PassiveEndpoints { get; }
    }

    public class EndpointSettings : IEndpointSettings
    {
        readonly IActionUrlBuilder urlBuilder;

        public EndpointSettings(IActionUrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        public IEnumerable<string> ActiveEndpoints
        {
            get
            {
                yield return urlBuilder.GetActionUrl("Index", "Token");
            }
        }

        public IEnumerable<string> PassiveEndpoints
        {
            get { yield break; }
        }
    }
}