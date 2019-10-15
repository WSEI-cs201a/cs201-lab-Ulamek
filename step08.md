## Krok 8. Propozycja zadań i problemów do rozwiązania

1. Wykorzystując opracowaną klasę spróbuj rozwiązać elementarnie proste problemy na SPOJ:
   * [SIMPLE - Make It Simple](https://www.spoj.com/problems/SIMPLE/)
   * [SUMFRAC - Sum of fractions](https://www.spoj.com/problems/SUMFRAC/)

2. W ramach nowego projektu, opracuj **strukturę** `Ulamek` (wariant _immutable_). Twój kod będzie wymagał tylko kilku drobnych modyfikacji. Dowiesz się w praktyce, jaka jest różnica między strukturą a klasą.

3. W ramach nowego projektu opracuj strukturę `Ulamek` (wariant _immutable_), ale bazującą na wewnętrznej reprezentacji ułamka w formie niedokładnej - jako wartość typu [`decimal`](https://docs.microsoft.com/en-us/dotnet/api/system.decimal?view=netstandard-2.0).

   ```csharp
   class Ulamek
   {
      private readonly decimal value;
      public long Licznik => throw new NotImplementedException(); // get
      public long Mianownik => throw new NotImplementedException(); // get

      // konstruktory
      public Ulamek( long licznik, long mianownik )
      {
         if( mianownik != 0)
            value = (decimal)licznik/mianownik;
         else
            throw new DivideByZeroException("ułamek o mianowniku 0 nie istnieje");
      }
      // ...
   }
   ```

   W zasadzie zadanie to polega na opakowaniu (ang. _wrapping_, _wrapper class_) typu `decimal` tak, aby przez odbiorcę widziany był jako typ ułamka (pary liczb: licznik i mianownik, o określonych właściwościach i operacjach). Oczywiście trzeba bezie wykonać pracę związaną z przeciążeniami operatorów i - w szczególności - poprawnym zdefiniowaniem `Equals`. Ponieważ reprezentacja jest niedokładna, prawdopodobnie wprowadzisz parametr określający dokładność reprezentacji (i dokładność obliczeń). Np. pytając się, czy `u == v` oczekujesz odpowiedzi, że są równe z dokładnością do np. 10 miejsc po przecinku. Zastosowanie `decimal` wobec `double` zdecydowanie poprawia dokładność reprezentacji i obliczeń.

4. W ramach nowego projektu, opracuj **strukturę** `BigUlamek`, gdzie licznik i mianownik są typu [`BigInteger`](https://docs.microsoft.com/en-Us/dotnet/api/system.numerics.biginteger?view=netstandard-2.0).
Taką klasę możesz wykorzystać do obliczeń dokładnych na ułamkach, nie obawiając się o przekroczenie zakresu.

   Ze względów wydajnościowych przyjmij, że ułamek reprezentowany będzie w strukturze zmienniczej, **bez upraszczania** w momencie tworzenia (jedynie normalizacja znaku). Zadbaj, aby po utworzeniu, jedyną operacją modyfikującą ułamek była metoda `public void Uprosc()` jawnie wywoływana przez użytkownika typu wtedy, kiedy będzie chciał mieć ułamek w najprostszej postaci. W takiej sytuacji inaczej będzie zaprogramowane przesłonięcie `Equals` (dwa ułamki są równe `a/b == c/d` wtedy i tylko wtedy, gdy `b ≠ 0`, `d ≠ 0` oraz `ad == bc` ). W podobny sposób definiowane są operatory relacyjne. Rozważ niejawne uruchamianie `Uprosc()` w sytuacjach potencjalnie zbyt dużego "rozrostu" ułamka (licznika i mianownika). Np. jeśli liczba cyfr licznika lub mianownika przekroczy - powiedzmy - 10, automatycznie włącza się upraszczanie.

   UWAGA: instancje `BigUlamek` w zasadzie będą _immutable_ (z wyjątkiem upraszczania - jawnego lub automatycznego). Ale niestety, wyjątki te powodują, że instancje typu nie są _thread safe_, są wrażliwe na wielodostęp. Jeśli w trakcie upraszczania zmieniona zostanie wartość licznika i będziemy jeszcze tuż przed zmianą mianownika, a w tym samym czasie inny wątek odczyta instancję, to otrzyma on błędne dane. Rozwiązaniem będzie zabezpieczenie wrażliwego fragmentu kodu przed wielodostępem. Zobacz: [lock statement](https://docs.microsoft.com/pl-pl/dotnet/csharp/language-reference/keywords/lock-statement).

5. Wyzwanie: Wiedząc, co to są ułamki, jak się je reprezentuje i jak wykonuje się na nich obliczenia, spróbuj rozwiązać klasyczne problemy na SPOJ:
   * [ENUMRTNL - Enumeration of rationals](https://www.spoj.com/problems/ENUMRTNL/)
   * [GNUM - Guess number!](https://www.spoj.com/problems/GNUM/)

[Początek](README.md) | [Krok poprzedni](step07.md) |
