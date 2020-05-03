using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace tdd_taxi
{
    [TestClass]
    public class TaxiTest
    {
        private string schema = "M:int,T:int";

        [TestMethod]
        public void TaxiTestMethod()
        {
            Taxi taxi = new Taxi(schema, "-M 1 -T 0");
            Assert.AreEqual(taxi.GetValue("M"), 1);
            Assert.AreEqual(taxi.GetValue("T"), 0);
            Assert.AreEqual(taxi.GetTaxiMeterResult("-M 1 -T 0"), 6);
            Assert.AreEqual(taxi.GetTaxiMeterResult("-M 3 -T 0"), 7);
            Assert.AreEqual(taxi.GetTaxiMeterResult("-M 10 -T 0"), 13);
            Assert.AreEqual(taxi.GetTaxiMeterResult("-M 2 -T 3"), 7);

            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
            filePath = filePath.Substring(0, filePath.LastIndexOf('\\'));
            var strs = File.ReadLines(filePath + @"\resources\testData.txt");         

            foreach(var str in strs)
            {
                string[] values = str.Split(',');

                if (null != values && values.Count() > 1)
                {
                    int M = getNumberInt(values[0]);
                    int T = getNumberInt(values[1]);

                    int ret = taxi.GetTaxiMeterResult("-M " + M.ToString() + " -T " + T.ToString());

                    Console.WriteLine("收费" + ret + "元/n");
                }
            }
        }

        private int getNumberInt(string str)
        {
            int result = 0;
            if (str != null && str != string.Empty)
            {
                // 正则表达式剔除非数字字符（不包含小数点.）
                str = Regex.Replace(str, @"[^\d.\d]", "");
                // 如果是数字，则转换为decimal类型
                if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
                {
                    result = int.Parse(str);
                }
            }
            return result;
        }
    }
}
