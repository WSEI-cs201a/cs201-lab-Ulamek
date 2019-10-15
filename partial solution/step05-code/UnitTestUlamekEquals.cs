using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UlamekAsClassLib;


namespace UlamekAsClassUnitTest
{
    /// <summary>
    /// Klasa testująca poprawność implementacji równości ułamków
    /// </summary>
    [TestClass]
    public class UnitTestUlamekEquals
    {

        #region Testy implementacji przeciażenia Equals(object)

        [TestMethod]
        public void Equals_Argument_Null_zwraca_False()
        {
            Assert.IsFalse((new Ulamek()).Equals(null));
        }

        [TestMethod]
        public void Equals_Argument_InnyTyp_zwraca_False()
        {
            Ulamek u = new Ulamek();
            var anonymousTypeVariable = new { licznik = 0, mianownik = 1 };
            Assert.IsFalse(u.Equals(anonymousTypeVariable));
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 2, true)]
        [DataRow(1, 2, 2, 4, true)]
        [DataRow(0, 2, 0, 3, true)]
        [DataRow(2, 1, 4, 2, true)]
        [DataRow(1, 2, 2, 3, false)]
        [DataRow(1, -2, -1, 2, true)]
        public void Equals_OK(long u1Licznik, long u1Mianownik, long u2Licznik, long u2Mianownik, bool wynik)
        {
            Ulamek u1 = new Ulamek(u1Licznik, u1Mianownik);
            Ulamek u2 = new Ulamek(u2Licznik, u2Mianownik);
            Assert.AreEqual(wynik, u1.Equals((object)u2));
        }


        /// <summary>
        /// Test zwrotności: `x.Equals(x)` zwraca `true`
        /// </summary>
        [TestMethod]
        public void Equals_Zrotnosc_TenSamObiekt()
        {
            Ulamek u = new Ulamek();
            Assert.IsTrue(u.Equals((object)u));
        }

        /// <summary>
        /// Test zwrotności: `x.Equals(x)` zwraca `true`
        /// </summary>
        [TestMethod]
        public void Equals_Zrotnosc_TakiSamObiekt()
        {
            Ulamek u = new Ulamek(1, 2);
            Ulamek v = new Ulamek(1, 2);
            Assert.IsTrue(u.Equals(v));
        }


        /// <summary>
        /// Test symetrii: `x.Equals(y)` zwraca tę samą wartość, co `y.Equals(x)`
        /// </summary>
        [TestMethod]
        public void Equals_Symetria_PoprawneDane()
        {
            Ulamek x = new Ulamek(1, 2);
            Ulamek y = new Ulamek(x.Licznik, x.Mianownik);
            Assert.IsTrue(x.Equals(y));
            Assert.IsTrue(y.Equals(x));
        }

        /// <summary>
        /// Test symetrii: `x.Equals(y)` zwraca tę samą wartość, co `y.Equals(x)`
        /// </summary>
        [TestMethod]
        public void Equals_Symetria_ZleDane()
        {
            Ulamek x = new Ulamek(1, 2);
            Ulamek y = new Ulamek(1, 3);
            Assert.IsFalse(x.Equals(y));
            Assert.IsFalse(y.Equals(x));
        }

        /// <summary>
        /// Test przechodniosci: jeżeli `x.Equals(y)` zwraca `true` oraz `y.Equals(z))` zwraca `true`, wtedy `x.Equals(z)` zwraca `true`
        /// </summary>
        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 2)]
        [DataRow(1, 2, 2, 4, 3, 6)]
        [DataRow(-1, 2, 2, -4, -3, 6)]
        public void Equals_Przechodniosc_PoprawneDane(int u1l, int u1m, int u2l, int u2m, int u3l, int u3m)
        {
            Ulamek x = new Ulamek(u1l, u1m);
            Ulamek y = new Ulamek(u2l, u2m);
            Ulamek z = new Ulamek(u3l, u3m);

            Assert.IsTrue(x.Equals(y));
            Assert.IsTrue(y.Equals(z));
            Assert.IsTrue(x.Equals(z));
        }

        /// <summary>
        /// Test przechodniosci: jeżeli `x.Equals(y)` zwraca `true` oraz `y.Equals(z))` zwraca `true`, wtedy `x.Equals(z)` zwraca `true`
        /// Logika: zdanie: ( (p ⇒ q) ⇔ (¬p ∨ q) )  jest tautologią (zamiana implikacji na alternatywę)
        /// Zdanie (a ∧ b ⇒ c), gdzie a oznacza `x.Equals(y)`, b oznacza `y.Equals(z)`, zaś c oznacza `x.Equals(z)`
        /// zapiszemy w równoważny sposób, bez użycia implikacji: ¬(a ∧ b) ∨ c
        /// czyli (z prawa de Morgana): ¬a ∨ ¬b ∨ c
        /// Pozostaje w teście sprawdzić, czy dla dowlnych danych testowych zdanie to jest zawsze prawdziwe.
        /// Jeśli nie - to powodem bedzie wadliwa implementacja `Equals`
        /// </summary>
        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 2)]
        [DataRow(1, 2, 2, 4, 3, 6)]
        [DataRow(-1, 2, 2, -4, -3, 6)]
        [DataRow(1, 2, -1, 2, 1, 2)]
        [DataRow(1, 2, 1, 3, 1, 3)]
        [DataRow(1, 2, 1, 2, 1, 3)]
        public void Equals_Przechodniosc_ZPrawLogiki_DowolneDane(int u1l, int u1m, int u2l, int u2m, int u3l, int u3m)
        {
            Ulamek x = new Ulamek(u1l, u1m);
            Ulamek y = new Ulamek(u2l, u2m);
            Ulamek z = new Ulamek(u3l, u3m);

            Assert.IsTrue( !x.Equals(y) || !y.Equals(z) || x.Equals(z) );
        }

        #endregion

        #region  Testy przeciążonego operatora ==

        [DataTestMethod]
        [DataRow(1, 2, 1, 2, true)]
        [DataRow(1, 2, 2, 4, true)]
        [DataRow(0, 2, 0, 3, true)]
        [DataRow(2, 1, 4, 2, true)]
        [DataRow(1, 2, 2, 3, false)]
        public void OperatorRownosci_OK(long u1Licznik, long u1Mianownik, long u2Licznik, long u2Mianownik, bool wynik)
        {
            Ulamek u1 = new Ulamek(u1Licznik, u1Mianownik);
            Ulamek u2 = new Ulamek(u2Licznik, u2Mianownik);
            Assert.AreEqual(wynik, u1 == u2);
        }

        [TestMethod]
        public void OperatorRownosci_LewyArgumentNull_False()
        {
            Ulamek lewy = null;
            Ulamek prawy = Ulamek.ZERO;
            Assert.IsFalse(lewy == prawy);
        }

        [TestMethod]
        public void OperatorRownosci_PrawyArgumentNull_False()
        {
            Ulamek prawy = null;
            Ulamek lewy = Ulamek.ZERO;
            Assert.IsFalse(lewy == prawy);
        }

        [TestMethod]
        public void OperatorRownosci_ObaArgumentyNull_True()
        {
            Ulamek prawy = null;
            Ulamek lewy = null;
            Assert.IsTrue(lewy == prawy);
        }

        [TestMethod]
        public void OperatorRownosci_ArgumentyTenSamObiekt_True()
        {
            Ulamek u = new Ulamek(1, 2);
            Assert.IsTrue( u == (object)u);
        }

        [TestMethod]
        public void OperatorRownosci_Symetria_True()
        {
            Ulamek u = new Ulamek(1, 2);
            Ulamek v = new Ulamek(1, 2);
            Assert.IsTrue(u == v && v == u);
        }

        [DataTestMethod]
        [DataRow(1, 2, 1, 2, 1, 2)]
        [DataRow(1, 2, 2, 4, 3, 6)]
        [DataRow(-1, 2, 2, -4, -3, 6)]
        [DataRow(1, 2, -1, 2, 1, 2)]
        [DataRow(1, 2, 1, 3, 1, 3)]
        [DataRow(1, 2, 1, 2, 1, 3)]
        public void OperatorRownosci_Przechodniosc_ZPrawLogiki_DowolneDane(int u1l, int u1m, int u2l, int u2m, int u3l, int u3m)
        {
            Ulamek u1 = new Ulamek(u1l, u1m);
            Ulamek u2 = new Ulamek(u2l, u2m);
            Ulamek u3 = new Ulamek(u3l, u3m);

            Assert.IsTrue(u1 != u2 || u2 != u3 || u1 == u3 );
        }

        #endregion

    }
}
