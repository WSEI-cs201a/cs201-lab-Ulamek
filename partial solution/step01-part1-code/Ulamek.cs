using System;
using System.Numerics;

namespace UlamekAsClassLib
{
    public class Ulamek
    {
        // pola
        private readonly long licznik = 0;
        private readonly long mianownik = 1;


        /// <summary>
        /// Zwraca licznik ułamka
        /// </summary>
        public long Licznik => licznik; // notacja wprowadzona w C# 6


        /// <summary>
        /// Zwraca mianownik ułamka (różny od 0)
        /// </summary>
        public long Mianownik => mianownik; // notacja wprowadzona w C# 6

        #region Blok konstruktorów

        // Konstruktor prywatny z dodatkowym parametrem `upraszczanie`.
        // Jesli wiadomo, że tworzony ułamek nie wymaga uproszczenia, `upraszczanie = false`
        // Proces upraszczania ułamka jest potencjalnie pracochłunny (dla duzych liczb budujących ułamek)
        private Ulamek(long licznik, long mianownik, bool upraszczanie)
        {
            if (mianownik == 0)
                throw new DivideByZeroException("ułamek o mianowniku 0 nie istnieje");

            if (mianownik == 1)
            {
                (this.licznik, this.mianownik) = (licznik, 1); // C# 7.x 
                return;
            }

            if (licznik == 0)
            {
                (this.licznik, this.mianownik) = (0, 1); // C# 7.x 
                return;
            }

            normalizujZnak(ref licznik, ref mianownik);  // wywołanie funkcji wewnętrznej, C# 7.2
            //this.normalizuj(ref licznik, ref mianownik); // wywołanie metody prywatnej klasy
            this.licznik = licznik;
            this.mianownik = (licznik == 0) ? 1 : mianownik;

            if (upraszczanie)
            {
                long NWD = (long)BigInteger.GreatestCommonDivisor(this.licznik, this.mianownik);
                (this.licznik, this.mianownik) = (this.licznik / NWD, this.mianownik / NWD);
            }

            // === funkcja wewnętrzna - C# 7.2 ===
            void normalizujZnak(ref long l, ref long m) =>  (l, m) = (Math.Sign(l * m) * Math.Abs(l), Math.Abs(m));

        } //koniec konstruktora prywatnego

        /// <summary>
        /// Tworzy ułamek w postaci nieskracalnej
        /// </summary>
        /// <remarks>
        /// <para>Konstruktor z parametrami opcjonalnymi.</para> 
        /// <para>W przypadku braku argumentów tworzy ułamek <c>0/1</c>, który ma wartość liczbową <c>0</c> (domyslną dla typu).</para>
        /// <para>W przypadku jednego argumentu konwertuje liczbę całkowitą do postaci ułamka, 
        /// o podanym liczniku i mianowniku równym <c>1</c>.</para>
        /// <para>W przypadku podania dwóch argumentów:</para>
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// jeśli drugi argument jest zerowy lub wywołano konstruktor z parametrem nazwanym <c>new Ulamek(mianownik: 0)</c>, 
        /// następuje próba utworzenia ułamka o mianowniku = 0. 
        /// Zgłaszany jest wtedy wyjątek <c>DivideByZeroException</c>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// jesli drugi argument jest niezerowy, uruchamiany jest proces normalizacji znaku 
        /// (znak ułamka zawsze jest w liczniku) oraz upraszczanie z wykorzystaniem algorytmu Euklidesa wyznaczania NWD
        /// zaimplementowanego w <c><see cref="BigInteger.GreatestCommonDivisor(BigInteger, BigInteger)"/></c>. 
        /// Proces ten może być czasochłonny.
        /// </description>
        /// </item>
        /// </list>
        /// 
        /// </remarks>
        /// <param name="licznik">licznik ułamka</param>
        /// <param name="mianownik">mianownik ułamka, wartość niezerowa</param>
        /// <exception cref="DivideByZeroException">zgłaszane przy próbie utworzenia ułamka o mianowniku zerowym</exception>
        public Ulamek(long licznik = 0, long mianownik = 1) : this(licznik, mianownik, true)
        { }


        // metoda upraszcza ułamek i normalizuje znak
        // (znak ułamka w liczniku)
        private void normalizuj(ref long l, ref long m)
        {
            // kod juniorski
            if (l * m < 0)
            {
                l = (-1) * Math.Abs(l);
                m = Math.Abs(m);
            }
            else
            {
                l = Math.Abs(l);
                m = Math.Abs(m);
            }

            long NWD = (long)BigInteger.GreatestCommonDivisor(l, m);

            l /= NWD;
            m /= NWD;
        }

        #endregion


        public override string ToString() => (mianownik == 1) ? $"{Licznik}" : $"{Licznik}/{mianownik}";


    }
}
