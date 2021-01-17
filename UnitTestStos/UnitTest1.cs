using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stos;
using System;

namespace UnitTestProjectStos
{
    [TestClass]
    public class UnitTestStosChar
    {
        private IStos<char> stos;
        private Random rnd = new Random();
        //zwraca znak ASCII o kodzie z zakresu 33..126
        private char RandomElement => (char)rnd.Next(33, 126);

        // s.create ==> s.IsEmpty==true
        [TestMethod]
        public void IsEmpty_PoUtworzeniuStosJestPusty()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);
        }

        // s.create.Push(e) ==> s.IsEmpty==false
        [TestMethod]
        public void IsEmpty_PoUtworzeniuIDodaniuElementuStosNieJestPusty()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            Assert.IsFalse(stos.IsEmpty);
        }

        // s.Pop( s.Push(e) ) == s
        [TestMethod]
        public void PushPop_StosSieNieZmienia()
        {
            stos = new StosWTablicy<char>();
            stos.Push(RandomElement);
            stos.Push(RandomElement);

            char[] tabPrzed = stos.ToArray();
            char e = RandomElement;
            stos.Push(e);
            stos.Pop();
            char[] tabPo = stos.ToArray();

            CollectionAssert.AreEqual(tabPrzed, tabPo);
        }

        // s.Peek( s.Push(e) ) == e
        [TestMethod]
        public void Peek_ZwracaOstatnioWstawionyElement()
        {
            stos = new StosWTablicy<char>();
            char e = RandomElement;

            stos.Push(e);

            Assert.AreEqual(stos.Peek, e);
        }

        // s.create.Peek ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PeekDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // s.create.Pop() ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void PopDlaPustegoStosu_ZwracaWyjatek_StosEmptyException()
        {
            stos = new StosWTablicy<char>();
            Assert.IsTrue(stos.IsEmpty);

            char c = stos.Peek;
        }

        // TrimExcess() ==> throw StosEmptyException
        [TestMethod]
        [ExpectedException(typeof(StosEmptyException))]
        public void TrimExcess_PustegoStosu_StosEmptyException()
        {
            var f = new StosWTablicy<int>();
            f.TrimExcess();
        }

        // TrimExcess() valid
        [TestMethod]
        [DataRow(8)]
        [DataRow(15)]
        [DataRow(3)]
        [DataRow(59)]
        [DataRow(200)]
        [DataRow(130)]
        public void TrimExcess_Test_Method(int elements)
        {
            var g = new StosWTablicy<int>(elements);
            for (int i = 0; i < elements; ++i)
            {
                g.Push(i);
            }
            g.TrimExcess();
            Assert.AreEqual(elements, (int)Math.Floor(g.GetTabLength() * 0.9));
        }

        [TestMethod]
        public void Indexer_Test_Tablica()
        {
            stos = new StosWTablicy<char>();
            var element = RandomElement;
            stos.Push(element);
            Assert.AreEqual(stos[0], element);
        }

        [TestMethod]
        public void Indekser_Test_Lista()
        {
            stos = new StosWLiscie<char>();
            var element = RandomElement;
            stos.Push(element);
            Assert.AreEqual(stos[0], element);
        }
    }
}
