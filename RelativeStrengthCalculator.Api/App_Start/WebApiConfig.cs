﻿// --------------------------------
// <copyright file="WebApiConfig.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

#pragma warning disable 1591
namespace RelativeStrengthCalculator.Api
{
    using System.Web.Http;
    using System.Web.Mvc;

    using global::RelativeStrengthCalculator.Api.MediaFormatters;

    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
            config.Formatters.Add(new ScoreFormatter());
            config.Formatters.Add(new CoefficientFormatter());
            config.EnableCors();

            // Make web api object use camelCase on the client and PascalCase on the server
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            AreaRegistration.RegisterAllAreas();
        }
    }
}