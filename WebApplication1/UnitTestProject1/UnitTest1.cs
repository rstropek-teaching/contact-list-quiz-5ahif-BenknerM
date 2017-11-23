using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication1.Services;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void testGetByID()
        {
            int id = 2;
            PersonRepository repo = new PersonRepository();
            Assert.IsNotNull(repo.GetById(id));
        }

        [TestMethod]
        public void testGetByList()
        {
            
            PersonRepository repo = new PersonRepository();
            Assert.IsNotNull(repo.GetList());
        }
    }
}
