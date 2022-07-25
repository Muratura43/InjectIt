using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InjectIt.Test
{
    [TestClass]
    public class IoCTests
    {
        [TestMethod]
        public void CanResolveTypes()
        {
            var container = new Container();
            container.For<ILogger>().Use<SqlServerLogger>();

            var logger = container.Resolve<ILogger>();

            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }
    }
}
