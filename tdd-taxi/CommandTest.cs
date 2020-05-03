using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tdd_taxi
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        public void Test_has_value()
        {
            Command command = new Command("-M 1 -T 1");
            Assert.AreEqual(command.GetValue("M"), 1);
            Assert.AreEqual(command.GetValue("T"), 1);
        }
        [TestMethod]
        public void Test_has_no_value()
        {
            Command command = new Command("-M 3 -T");
            Assert.AreEqual(command.GetValue("M"), 3);
            Assert.AreEqual(command.GetValue("T"), null);
        }
        [TestMethod]
        public void Test_has_negative()
        {
            Command command = new Command("-M -1 -T 2");
            Assert.AreEqual(command.GetValue("M"), -1);
            Assert.AreEqual(command.GetValue("T"), 2);
        }
    }
}
