// --------------------------------
// <copyright file="CoefficientFormatter.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/31/2015</date>
// ---------------------------------

#pragma warning disable 1591

namespace RelativeStrengthCalculator.Api.MediaFormatters
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    using global::RelativeStrengthCalculator.Api.Models;
    using global::RelativeStrengthCalculator.Api.Properties;

    public class CoefficientFormatter : MediaTypeFormatter
    {
        public CoefficientFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        public override bool CanReadType(Type type) => false;

        public override bool CanWriteType(Type type) => typeof(CoefficientDto) == type;

        public override async Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var score = value as CoefficientDto;

            if (score != null)
            {
                var html = string.Format(Resources.results, ResultFormatter.BuildResultHtml(score));

                using (var writer = new StreamWriter(writeStream))
                {
                    await writer.WriteAsync(html);
                }
            }
            else
            {
                await base.WriteToStreamAsync(type, value, writeStream, content, transportContext);
            }
        }
    }
}