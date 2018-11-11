## Krok 2. Równość ułamków ##

Krok ten będzie miał niewiele zadań do wykonania (literalnie), ale jest prawdopodobnie najtrudniejszy.


Wykonuj zadania w podanej kolejności.

### Zadania do wykonania

1. W projekcie _Class library_ dodaj nową klasę. Plik nazwij `UlamekEquals.cs`. 

2. Zmień nazwę klasy na `Ulamek`. Dodaj słowo kluczowe `partial` przed `class`. Korzystasz z funkcjonalności dzielenia klasy na wiele plików [`partial class`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods). Rozbudowę klasy `Ulamek` w zakresie tego kroku przeprowadzisz w tym pliku.

3. W projekcie z testami jednostkowymi utwórz plik o nazwie `UnitTestUlamekEquals.cs`. Możesz to wykonać kolejno poleceniami: *Add > New Item .. > Basic Unit Test*. testy jednostkowe związane z implementacją równości ułamków zapisz w tym pliku.

4. Opracuj odpowiednie przeciążenie metody `Equals()`. Równocześnie MUSISZ przeciążyć `GetHashCode()`.

5. Zaimplementuj interfejs `IEquatable<Ulamek>`.

6. Zaimplementuj statyczną wersję metody `Equals` o sygnaturze:
    ````charp
    public static bool Equals(Ulamek u1, Ulamek u2)
    ````
7. Zaimplementuj przeciążenie operatora `==`. Będziesz MUSIAŁ równocześnie zaimplementować przeciążenie operatora `!=`.

8. Wszystkie powyższe metody muszą być wzajemnie spójne!

9. Opracuj testy jednostkowe


### Podpowiedzi

1. Poczytaj o przeciążaniu `Equals` w C#:
  
  * https://github.com/loganfranken/overriding-equals-in-c-sharp

  * https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/equality-operators

  * https://docs.microsoft.com/en-us/dotnet/api/system.object.equals

2. Poczytaj o implementowaniu interfejsu [`IEquatable<T>`](https://docs.microsoft.com/en-US/dotnet/api/system.iequatable), a w szczególności o metodzie [`IEquatable<T>.Equals(T)`](https://docs.microsoft.com/pl-pl/dotnet/api/system.iequatable)
  
3. _Równość_ jest relacją równoważności (ściśle zdefiniowane pojęcie matematyczne), spełnia zatem nastepujące warunki:

    a. `x.Equals(x)` zwraca `true` //zwrotność
   
    b. `x.Equals(y)` zwraca tę samą wartość, co `y.Equals(x)` //symetria
   
    c. jeżeli `x.Equals(y)` zwraca `true` oraz `y.Equals(z))` zwraca `true`, wtedy `x.Equals(z)` zwraca `true` //przechodniość

    d. `x.Equals(y)` zwraca `true` jesli oba `x` oraz `y` są `NaN` (dla typów liczbowych)

    e. `x.Equals(null)` zwraca `false`

    Podane warunki przydadzą Ci się do opracowania testów jednostkowych Twojej implementacji równości ułamków.

   > Info: Dwa ułamki są sobie równe, jeżeli należą do tej samej _klasy równoważności_ względem relacji równości (też pojęcie _stricte_ matematyczne). Oznacza to, że np. 2/4 == 1/2. Ale tym problemem nie musimy się przejmować, ponieważ nasza implementacja przewiduje upraszczanie ułamków. Stąd, porównywanie ułamków może odbyć się _pole po polu_, jak domyślnie dla typów strukturalnych.

4. Przeanalizuj i ustal różnice między trzema sposobami porównywania:

    * `object.ReferenceEquals(object objA, object objB)`
    * `objA.Equals(objB)`
    * `objA == objB`

5. Co to jest [`NullReferenceException`](https://docs.microsoft.com/pl-pl/dotnet/api/system.nullreferenceexception). Kiedy się może pojawić?

5. Przeanalizuj porównywanie do `null`:
    * `if( x == null ) ...`
    * `if( x is null ) ...`
    * `if( x.Equals(null) ) ...`
    * `if( object.ReferenceEquals( x, null ) ...`
    
    Zwróć uwagę na ukryte niebezpieczeństwa.

6. Porównywać możesz obiekty tego samego typu (czasami dopuszczalne dla podtypu). Jak sprawdzić, czy dwa obiekty są tego samego typu?
  Przeanalizuj poniższy kod:
    ````csharp
    //jakie są różnice (czy są)
    if (!(obj is Ulamek)) return false;
    if (obj.GetType() != typeof(Ulamek)) return false;
    if (this.GetType() != obj.GetType()) return false;
    if (!object.ReferenceEquals(this.GetType(), obj.GetType())) return false;
    ````
7. Dodatkowo (częste pytania egzaminacyjne):
  
    * jaka jest różnica między operatorem `is` oraz `as`
    
    * co zwraca operator `typeof`, o co metoda `GetType()`
    
    * czym jest `Type`




[Początek](README.md) | [Krok poprzedni](step01.md) | [Krok następny](step03.md)