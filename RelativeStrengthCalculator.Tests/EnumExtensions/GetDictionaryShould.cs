// --------------------------------
// <copyright file="GetDictionaryShould.cs">
// Copyright (c) 2015 All rights reserved.
// </copyright>
// <author>dallesho</author>
// <date>06/06/2015</date>
// ---------------------------------

namespace RelativeStrengthCalculator.Tests.EnumExtensions
{
    using System;
    using System.Linq;

    using AssertExLib;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using EnumExtensions = global::RelativeStrengthCalculator.EnumExtensions;

    internal struct Test : IConvertible
    {
        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }
    }

    [TestClass]
    public class GetDictionaryShould
    {
        [TestMethod]
        public void ThrowIfTypeIsNotAnEnum()
        {
            AssertEx.Throws<InvalidOperationException>(() => { EnumExtensions.GetDictionary<Test>(); });
        }

        [TestMethod]
        public void GetDictionaryWithoutInvalid()
        {
            var result = EnumExtensions.GetDictionary<Sex>();

            Assert.AreEqual(2, result.Count());
            Assert.IsNotNull(result.FirstOrDefault(v => v.Key == 1));
            Assert.IsNotNull(result.FirstOrDefault(v => v.Value == "Male"));
            Assert.IsNotNull(result.FirstOrDefault(v => v.Key == 2));
            Assert.IsNotNull(result.FirstOrDefault(v => v.Value == "Female"));
        }
    }
}