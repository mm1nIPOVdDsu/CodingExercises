using Microsoft.VisualStudio.TestTools.UnitTesting;

using RickAndMorty.Data.Entities;

namespace RickAndMorty.Data.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var context = new RmDbContext();
            var repository = await context.Set<CharacterEntity>();
        }
    }
}
