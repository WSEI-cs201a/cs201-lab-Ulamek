using System;
using System.Collections.Generic;
using System.Text;

namespace UlamekAsClassLib
{
    public partial class Ulamek : IConvertible
    {
        //implicit - automatyczna konwersja z long na Ulamek (wtedy, kiedy tak wynika z kodu)
        static public implicit operator Ulamek(long value) => new Ulamek(value);

        //explicit - rzutowanie z Ulamka na long
        static public explicit operator long(Ulamek u) => u.licznik / u.mianownik;

        // rzutowanie z ułamka na `double`
        static public explicit operator double(Ulamek u) => (double)u.licznik / u.mianownik;

        // rzutowanie z `double` na `Ulamek`
        static public explicit operator Ulamek(double value) => new Ulamek( value );


        //parsowanie
        // public static Ulamek Parse(string napis) => throw new NotImplementedException();
        // public static bool TryParse(string napis, out Ulamek result) => throw new NotImplementedException();


        // === implementacja interfejsu IConvertible ===
        public long ToInt64(IFormatProvider provider) => (long)this;

        // pozostałe konwersje nie są zaimplementowane
        public TypeCode GetTypeCode()
        {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            throw new NotImplementedException();
        }


    }
}
