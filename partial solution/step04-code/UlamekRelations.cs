using System;
using System.Collections.Generic;
using System.Text;

namespace UlamekAsClassLib
{
    // Fragment klasy odpowiedzialny za porównywanie ułamków
    public partial class Ulamek : IComparable, IComparable<Ulamek>
    {
        // operatory relacyjne
        public int CompareTo(object obj)
        {
            if (obj is null) return +1;

            if (obj.GetType() != typeof(Ulamek))
                throw new ArgumentException();

            Ulamek u = obj as Ulamek;
            return Math.Sign(this.licznik * u.mianownik - this.mianownik * u.licznik);
        }

        public int CompareTo(Ulamek other)
        {
            return this.CompareTo((object)other);
        }

        public static bool operator >(Ulamek lewy, Ulamek prawy)
        {
            throw new NotImplementedException();
            //TODO: niekompatybilność: null < u, u < null, null > u, u > null
            // https://stackoverflow.com/questions/17025900/override-compareto-what-to-do-with-null-case

            if (lewy is null)
                throw new ArgumentException();

            return lewy.CompareTo(prawy) > 0;
        }

        public static bool operator <(Ulamek lewy, Ulamek prawy)
        {
            throw new NotImplementedException();
            //TODO niekompatybilność: null < u, u < null, null > u, u > null
            // https://stackoverflow.com/questions/17025900/override-compareto-what-to-do-with-null-case

            if (lewy is null)
                throw new ArgumentException();

            return lewy.CompareTo(prawy) < 0;
        }

        // ToDo: public static bool operator <=
        // ToDO: public static bool operator >=
    }
}
