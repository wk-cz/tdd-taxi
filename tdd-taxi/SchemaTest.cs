using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace tdd_taxi
{
    [TestClass]
    public class SchemaTest
    {
        [TestMethod]
        public void Test_int()
        {
            Schema schema = new Schema("M:int");
            Assert.AreEqual(schema.GetValue("M", "8"), 8);
        }
    }
}
