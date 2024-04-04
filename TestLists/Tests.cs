using LinkedListLibrary;
namespace TestLists
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestAdd1()
        {
            LinkList<string> result = new LinkList<string>();
            result.Add("a");

            LinkList<string> list = new LinkList<string>() { "a" };

            Assert.AreEqual(list.Contains("a"), result.Contains("a"));
        }
        [TestMethod]
        public void TestAdd2() 
        {
            LinkList<string> result = new LinkList<string>();
            result.Add("prev");

            Assert.IsTrue(result.Contains("prev"));
        }
        [TestMethod]
        public void TestAdd3()
        {
            LinkList<string> result = new LinkList<string>();
            result.Add("prev");
            result.Add("word");
            result.Add("mist");
            result.Add("more");

            Assert.IsTrue(result.Contains("prev") && result.Contains("word") && result.Contains("mist") && result.Contains("more"));
        }
        [TestMethod]
        public void TestDelete1()
        {
            LinkList<string> result = new LinkList<string>() { "prev" };

            Assert.IsTrue(result.Remove("prev"));
        }
        [TestMethod]
        public void TestDelete2()
        {
            LinkList<string> result = new LinkList<string>() { "prev", "mist", "link" };

            Assert.IsTrue(result.Remove("prev") && result.Remove("mist") && result.Remove("link"));
        }
        [TestMethod]
        public void TestDelete3()
        {
            LinkList<string> result = new LinkList<string>();

            Assert.IsFalse(result.Remove("prev"));
        }
        [TestMethod]
        public void TestClear()
        {
            LinkList<string> result = new LinkList<string>() { "prev", "mist", "link" };
            result.Clear();

            Assert.IsFalse(result.Contains("prev") && result.Contains("mist") && result.Contains("link"));
        }
        [TestMethod]
        public void TestCount()
        {
            LinkList<string> result = new LinkList<string>() { "prev", "mist", "link" };

            Assert.AreEqual(3, result.Count);
        }
        [TestMethod]
        public void TestEmpty()
        {
            LinkList<string> result = new LinkList<string>() { "prev", "mist", "link" };

            Assert.IsFalse(result.IsEmpty);
        }
        [TestMethod]
        public void TestContains1()
        {
            LinkList<string> result = new LinkList<string>() { "prev", "mist", "link" };

            Assert.IsTrue(result.Contains("prev") && result.Contains("mist") && result.Contains("link"));
        }
        [TestMethod]
        public void TestContains2()
        {
            LinkList<string> result = new LinkList<string>();

            Assert.IsFalse(result.Contains("prev") && result.Contains("mist") && result.Contains("link"));
        }
    }
}