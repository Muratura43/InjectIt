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

        [TestMethod]
        public void CanResolveTypesWithoutDefaultConstructor()
        {
            var container = new Container();
            container.For<ILogger>().Use<SqlServerLogger>();
            container.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();

            var repository = container.Resolve<IRepository<Employee>>();

            Assert.AreEqual(typeof(SqlRepository<Employee>), repository.GetType());
        }
    }
}
