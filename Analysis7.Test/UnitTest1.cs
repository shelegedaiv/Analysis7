using System;
using Analysis7.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analysis7.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var model = new ModelStarter();
            model.Groups[0].RiskEvents[0].ExpertProbabilities[0].Value = 0.88;
            model.Events[0].ExpertProbabilities[0].Value = 0.99;

        }
    }
}
