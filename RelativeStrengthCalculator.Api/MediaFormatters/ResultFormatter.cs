// --------------------------------
// <copyright file="ResultFormatter.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/31/2015</date>
// ---------------------------------

#pragma warning disable 1591

namespace RelativeStrengthCalculator.Api.MediaFormatters
{
    using global::RelativeStrengthCalculator.Api.Models;

    public static class ResultFormatter
    {
        public static string BuildResultHtml(ScoreDto score)
            =>
                $@"<td>{score.Id}</td>
                    <td>{score.Sex}</td>
                    <td>{score.BodyWeight:##.#####}</td>
                    <td>{score.Weight:##.#####}</td>
                    <td>{score.Coefficient:##.#####}</td>
                    <td>{score.Score:##.#####}</td>";

        public static string BuildResultHtml(CoefficientDto co)
            =>
                $@"<td>{co.Id}</td>
                    <td>{co.Sex}</td>
                    <td>{co.BodyWeight:##.#####}</td>
                    <td>{co.Weight:##.#####}</td>
                    <td>{co.Coefficient:##.#####}</td>
                    <td>&nbsp;</td>";
    }
}