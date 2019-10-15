using System;
using System.Collections.Generic;
using System.Text;

namespace UlamekAsClassLib
{
    /// <summary>
    /// Część klasy definiująca operacje arytmetyczne na ułamkach
    /// </summary>
    public partial class Ulamek
    {
        #region dodawanie
        public Ulamek Plus(Ulamek inny)
            => (inny == null) ?
                    throw new ArgumentException() :
                    new Ulamek(this.Licznik * inny.mianownik + this.mianownik * inny.Licznik,
                               this.mianownik * inny.mianownik,
                               upraszczanie: true);

        private static Ulamek Suma(Ulamek u1, Ulamek u2)
            => (u1 == null) ? throw new ArgumentException() : u1.Plus(u2);

        // rozbudowana wersja poprzedniego kodu
        public static Ulamek Suma(Ulamek u1, Ulamek u2, params Ulamek[] lista)
        {
            if (u1 is null || u2 is null)
                throw new ArgumentException();

            if (lista is null)
                return u1.Plus(u2);

            Ulamek suma = u1.Plus(u2);
            foreach (var u in lista)
            {
                if (u is null)
                    throw new ArgumentException();

                suma = suma.Plus(u);
            }
            return suma;
        }

        public static Ulamek operator +(Ulamek u1, Ulamek u2) => Suma(u1, u2);

        public static Ulamek operator ++(Ulamek u) => u + Ulamek.JEDEN;
        #endregion dodawanie



        #region odejmowanie
        // jednoargumentowy minus, ułamek przeciwny
        public static Ulamek operator -(Ulamek u)
            => (u is null) ?
                  throw new ArgumentException()
                : new Ulamek(-1 * u.licznik, u.mianownik, upraszczanie: false);

        // zaimplementuj pozostałe opracje odejmowania

        #endregion

        // zaimplementuj pozostałe operacje arytmetyczne: mnozenie, dzielenie

        // zaimplementuj wybrane metody z `System.Math`, np. Abs, Sign, Floor, Ceiling, Max, Pow

    }
}
