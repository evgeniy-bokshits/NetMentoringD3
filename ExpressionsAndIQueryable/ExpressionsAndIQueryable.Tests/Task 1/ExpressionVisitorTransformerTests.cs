using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_1;

namespace ExpressionsAndIQueryable.Tests.Task_1
{
    [TestClass]
    public class ExpressionVisitorTransformerTests
    {
        [TestMethod]
        public void Transform_ShouldConvertToIncrement_Test()
        {
            Expression<Func<double, double>> source = (x) => x + 1.0;

            var actual = new ExpressionVisitorTransformer().VisitAndConvert(source, "");

            Assert.AreEqual("x => Increment(x)", actual?.ToString());
        }

        [TestMethod]
        public void Transform_ShouldConvertToDecrementTest()
        {
            Expression<Func<int, int>> source = (x) => x - 1;

            var actual = new ExpressionVisitorTransformer().VisitAndConvert(source, "");

            Assert.AreEqual("x => Decrement(x)", actual?.ToString());
        }

        [TestMethod]
        public void Transform_ShouldNotConvert_WhenExpressionIsNotContainValueToConvert_Test()
        {
            Expression<Func<int, int>> source = (x) => x - 2;

            var actual = new ExpressionVisitorTransformer().VisitAndConvert(source, "");

            Assert.AreEqual("x => (x - 2)", actual?.ToString());
        }

        [TestMethod]
        public void Transform_ShouldConvertToConstant_WhebParameterIsExist_Test()
        {
            Expression<Func<int, int, int, int>> source = (a, b, c) => a + b + c;

            var actual = new ExpressionVisitorTransformer().Transform(source, new Dictionary<string, object>
            {
                { "a", 1993 },
                { "c", 2020 }
            });

            Assert.AreEqual("b => 1993 + b + 2020", actual?.ToString().Replace("(", "").Replace(")", ""));
        }
    }
}
