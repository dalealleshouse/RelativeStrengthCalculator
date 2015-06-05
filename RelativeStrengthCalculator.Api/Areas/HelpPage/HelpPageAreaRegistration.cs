// --------------------------------
// <copyright file="HelpPageAreaRegistration.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/30/2015</date>
// ---------------------------------

#pragma warning disable 1591
namespace RelativeStrengthCalculator.Api.Areas.HelpPage
{
    using System.Web.Http;
    using System.Web.Mvc;

    using global::RelativeStrengthCalculator.Api.Areas.HelpPage.App_Start;

    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName => "HelpPage";

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute("ResourceModel", "Help/ResourceModel/{modelName}", new { controller = "Help", action = "ResourceModel", modelName = UrlParameter.Optional });
            context.MapRoute("HelpPage_Default", "Help/{action}/{apiId}", new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}