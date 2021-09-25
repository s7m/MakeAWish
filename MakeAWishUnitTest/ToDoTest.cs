using System;
using System.Threading.Tasks;
using MakeAWish.Controllers;
using MakeAWish.Repository;
using NUnit.Framework;

namespace MakeAWishUnitTest
{
    [TestFixture]
    class ToDoTest
    {
        ToDoRepository _repo;
        [SetUp]
        public void Init()
        {
            _repo = new ToDoRepository();
        }

        [Test]
        public void UpdateTask_Save_ReturnsOne()
        {
            //var result =  _repo.UpdateTask(42, "Unit Test", "work", "green");
            //result.Wait();
            //Assert.AreEqual(result, 1);
        }

        [Test]
        void TestIndex_PassNullUser_Redirect()
        {

        }


    }
}
