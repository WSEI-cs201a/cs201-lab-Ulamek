using System;
using System.Collections.Generic;
using System.Text;

namespace UlamekAsClassLib
{
    public partial class Ulamek : IEquatable<Ulamek>
    {
        // przeciążenie Equals() z Object
        public override int GetHashCode()
        {
            //unchecked
            //{
            //    return (licznik.GetHashCode() * 17) ^ mianownik.GetHashCode();
            //}
            return (licznik, mianownik).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // Czy obj jest null - z definicji Equals
            //if (Object.ReferenceEquals(null, obj)) return false;
            if (obj is null) return false; //równoważne ReferenceEquals
            //if (obj == null) return false; // potencjalnie źle - a co, jeśli zmienimy definicję operatora ==

            // Czy obiekt jest tym samym obiektem - oczywiste true
            if (Object.ReferenceEquals(this, obj)) return true;

            //jakie są różnice
            if (!(obj is Ulamek)) return false;
            if (obj.GetType() != typeof(Ulamek)) return false;
            if (this.GetType() != obj.GetType()) return false;
            if (!object.ReferenceEquals(this.GetType(), obj.GetType())) return false;

            Ulamek u = obj as Ulamek;

            return (licznik == u.licznik && mianownik == u.mianownik);
        }

        // Implementacja Equals z IEquatable<Ulamek>
        public bool Equals(Ulamek other)
        {
            //return (other == null) ? false : (licznik == other.licznik && mianownik == other.mianownik); //błąd, użycie == dla porównania obiektów
            return (other is null) ? false : (licznik == other.licznik && mianownik == other.mianownik);
        }

        public static bool operator ==(Ulamek lewy, Ulamek prawy)
        {
            if (object.ReferenceEquals(lewy, prawy)) return true; //lewy i prawy to ten sam obiekt, uwzględnia oba argumenty null
            //if(lewy is null && prawy is null) return true; // por. powyzej

            if (prawy is null || lewy is null) return false;

            return lewy.Equals(prawy);
        }

        public static bool operator !=(Ulamek lewy, Ulamek prawy) => !(lewy == prawy);

        public static bool Equals(Ulamek u1, Ulamek u2) => (u1 == u2);
    }

}
