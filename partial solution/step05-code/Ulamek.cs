using System;
using System.Numerics;

namespace UlamekAsClassLib
{
    public partial class Ulamek
    {

        // stałe - inicjowane w deklaracji (lepiej)
        public static readonly Ulamek MaxValue = new Ulamek(long.MaxValue, 1, upraszczanie: false);
        public static readonly Ulamek MinValue = new Ulamek(long.MinValue, 1, upraszczanie: false);

        // stałe - inicjowane w statycznym konstruktorze (poprawnie, ale mniej wydajnie)
        public static readonly Ulamek ZERO;
        public static readonly Ulamek JEDEN;
        public static readonly Ulamek POLOWA;


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

        // statyczny konstruktor, inicjujący stałe ułamki
        // w tym przypadku nie jest wymagany i wskazany
        // składniki `ZERO`, ... można zainicjować w ich deklaracji
        static Ulamek()
        {
            ZERO = new Ulamek(0, 1, upraszczanie: false);
            JEDEN = new Ulamek(1, 1, upraszczanie: false);
            POLOWA = new Ulamek(1, 2, upraszczanie: false);
        }

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

        /// <summary>
        /// Kontruktor konwertujący poprawnie uformowany napis napis na ułamek.
        /// </summary>
        /// <remarks>
        /// Poprawny zapis ułamka to opcjonalnie znak, następnie licznik, później ukośnik 
        /// i na końcu wartość mianownika, np. "-3/5".
        /// Funkcja jest komplementarna do <c>ToString()</c>, tzn. jeśli utworzysz ułamek, 
        /// następnie wyeksportujesz go do postaci tekstowej i ponownie utworzysz ułamek na jej podstawie, 
        /// to otrzymasz "taki sam" ułamek.
        /// </remarks>
        /// <param name="napis">poprawnie uformowany napis opisujący ułamek</param>
        /// <exception cref="FormatException">zgłaszane, jeśli <c>napis</c> nie jest poprawnie uformowany</exception>
        /// <exception cref="DivideByZeroException">zgłaszane przy próbie utworzenia ułamka o mianowniku zerowym</exception>
        /// <exception cref="OverflowException">zgłaszane przy próbie utworzenia ułamka o zbyt duzymi mianowniku lub liczniku</exception>
        /// <exception cref="ArgumentNullException">zgłaszane przy próbie utworzenia ułamka, gdy <c>napis</c> jest <c>null</c></exception>
        public Ulamek(string napis) => throw new NotImplementedException();


        // Tworzy ułamek z liczby zmiennoprzecinkowej typu double
        // np. dla `liczba = 12.1234` ulamek postaci `121234/10000`
        public Ulamek(double liczba) => throw new NotImplementedException();

        // Tworzy ułamek z liczby zmiennoprzecinkowej typu float
        // np. dla `liczba = 12.1234` ulamek postaci `121234/10000`
        //public Ulamek(float liczba) : this( (double)liczba ) {} // UWAGA: nie potrzebne, bo następuje automatyczna konwersja float -> double


        // Tworzy ułamek z liczby zmiennoprzecinkowej typu decimal
        // np. dla `liczba = 12.1234` ulamek postaci `121234/10000`
        public Ulamek(decimal liczba) => throw new NotImplementedException();

        #endregion


        #region Konwersje

        public static Ulamek Parse(string s) => throw new NotImplementedException();

        public static bool TryParse(string s, out Ulamek result) => throw new NotImplementedException();

        public double ToDouble() => (double)licznik/mianownik;
        
        public float ToSingle() => (float)ToDouble();

        public decimal ToDecimal() => throw new NotImplementedException();


        #endregion

        public override string ToString() => (mianownik == 1) ? $"{Licznik}" : $"{Licznik}/{mianownik}";






    }
}
