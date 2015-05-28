// --------------------------------
// <copyright file="GetLookupTableShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>05/24/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.SchwartzMalone.Tests.SchwartzMaloneLookUpTable
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchwartzMaloneLookUpTable = global::RelativeStrengthCalculator.SchwartzMalone.SchwartzMaloneLookUpTable;

    [TestClass]
    public class GetLookupTableShould
    {
        [TestMethod]
        public void BuildMenTableFromResource()
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(Sex.Male);
            Assert.IsNotNull(table);
            Assert.AreEqual(1630, table.Count);
        }

        [TestMethod]
        public void BuildWomensTableFromResource()
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(Sex.Female);
            Assert.IsNotNull(table);
            Assert.AreEqual(1000, table.Count);
        }

        [TestMethod]
        public void FemaleCoefficientsShouldBeDecending()
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(Sex.Female).ToList();
            TestDecendingValueTable(table);
        }

        [TestMethod]
        public void MaleCoefficientsShouldBeDecending()
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(Sex.Male).ToList();
            TestDecendingValueTable(table);
        }

        private static void TestDecendingValueTable(IEnumerable<KeyValuePair<double, decimal>> dictionary)
        {
            var table = dictionary.ToList();

            for (var i = 0; i < table.Count - 1; i++)
            {
                Assert.IsTrue(
                    table[i].Value > table[i + 1].Value,
                    $"Value at index {i} is lower than the value at index {i + 1} - {table[i].Value}, {table[i + 1].Value}");

                Assert.IsTrue(table[i].Key < table[i + 1].Key, $"Index {i} is greater than index {i + 1} - {table[i].Key}, {table[i + 1].Key}");
            }
        }
    }
}