// /*
// * PROJECT:    TheCoderForge.Demo.ApplicationInfo.Tests
// * NAME:        TestMetaData.cs
// */

using TheCoderForge.Demo.ApplicationInfo.AppInfoLib;

namespace TheCoderForge.Demo.ApplicationInfo.Tests
{
    [TestClass]
    public class TestMetaData
    {
        [TestMethod]
        public void MetaData_FullName()
        {
            MetaData metaData = new MetaData();
            string actual = metaData.FullName;
            string expected = "TheCoderForge.Demo.ApplicationInfo.AppInfoLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";

            Assert.AreEqual(expected, actual);
        }
    }
}