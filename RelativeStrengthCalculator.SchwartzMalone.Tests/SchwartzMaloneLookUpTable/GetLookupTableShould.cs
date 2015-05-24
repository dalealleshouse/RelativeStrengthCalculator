namespace RelativeStrengthCalculator.SchwartzMalone.Tests.SchwartzMaloneLookUpTable
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using SchwartzMaloneLookUpTable = SchwartzMalone.SchwartzMaloneLookUpTable;

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
            this.TestDecendingValueTable(table);
        }

        [TestMethod]
        public void MaleCoefficientsShouldBeDecending()
        {
            var table = SchwartzMaloneLookUpTable.GetLookupTable(Sex.Male).ToList();
            this.TestDecendingValueTable(table);
        }

        private void TestDecendingValueTable(IEnumerable<KeyValuePair<double, decimal>> dictionary)
        {
            var table = dictionary.ToList();

            for (var i = 0; i < table.Count - 1; i++)
            {
                Assert.IsTrue(
                    table[i].Value > table[i + 1].Value,
                    string.Format("Value at index {0} is lower than the value at index {1} - {2}, {3}", i, i + 1, table[i].Value, table[i + 1].Value));

                Assert.IsTrue(
                    table[i].Key < table[i + 1].Key,
                    string.Format("Index {0} is greater than index {1} - {2}, {3}", i, i + 1, table[i].Key, table[i + 1].Key));
            }
        }
    }
}