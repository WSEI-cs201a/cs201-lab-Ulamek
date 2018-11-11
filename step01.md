## Krok 1. Podstawowa funkcjonalność ##

W kroku tym zdefiniujesz podstawową funkcjonalność projektowanego typu.

Wykonuj zadania w podanej kolejności.

### Zadania do wykonania - część 1

1. W projekcie typu _Class Library_ utwórz publiczną klasę `Ulamek` (w pliku `Ulamek.cs`).

2. Zdefiniuj pola klasy (`licznik`, `mianownik`) jako wartości typu `long`.

3. Zapewnij odpowiedni poziom hermetyzacji (pola są `private`, wartości licznika i mianownika są udostępniane publicznie za pomocą gettersów `Licznik` oraz `Mianownik`).

4. Pamiętaj, aby zapewnić niezmienniczość obiektów typu `Ulamek`.

5. Dostarcz konstruktory:
 
    a. domyślny - wartość domyslna ułamka to `0`, a dokładnie `0/1`,

    b. dwuargumentowy - inicjujący ułamek o dowlnych wartościach licznika i mianownika,

        > UWAGA: obiekt typu `Ulamek` o zerowym mianowniku nie istnieje - nie możesz dopuścić do jego utworzenia.

    c. jednoargumentowy - konwertujący liczbę całkowitą do postaci ułamka (np. `2` na `2/1`).

    Opracuj testy jednostkowe weryfikujące poprawność działania konstruktorów oraz _gettersów_.

6. Przyjmij, że tekstową reprezentacją ułamka jest postać: 
    
    `[znak]<<licznik>>/<<mianownik>>`

    na przykład `-2/3` lub `-7/2`, ale nie `2/-3` oraz nie `1 1/2`. 

    Opracuj odpowiednie przeciążenie metody `ToString()`.
    
    Opracuj testy jednostkowe weryfikujące poprawność reprezentacji tekstowej ułamka.

7. Zapewnij, aby ułamek zapamiętany był w postaci nieskracalnej (licznik i mianownik są względnie pierwsze). Opracuj testy jednostkowe weryfikujące tę funkcjonalność.


#### Podpowiedzi - część 1

1. _Niezmienniczość_ obiektów zapewnisz słowem kluczowym [readonly](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/readonly) (po to zresztą zostało wprowadzone do języka). Jesli jednak ustanowi ono zbyt duże restrykcje, będziesz musiał zadbać o nie wykonywanie żadnych zmian w zainicjowanych polach klasy i udostępniać je jedynie do odczytu.

2. Implementacja konstruktorów - możesz utworzyć trzy przeciążone konstruktory:

    ````csharp
    Ulamek() { ... }
    Ulamek(long licznik) { ... }
    Ulamek(long licznik, long mianownik) { ... }
    ````
    oczywiście je łańcuchując w odpowiedni sposób. Ale możesz również skorzystać z mechanizmu [parametrów opcjonalnych](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments).

3. Dla uproszczenia zapisu, tam gdzie nie jest to zbyt skomplikowane, wykorzystuj [notację lambda](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/lambda-expressions).

4. Upraszczając ułamki skorzystasz z algorytmu Euklidesa obliczania NWD (ang. _GCD_). Nie znajdziesz go w klasie [`System.Math`](https://msdn.microsoft.com/en-us/library/system.math). Zatem:

    * albo zaimplementujesz go samodzielnie, np na podstawie informacji z [Wikibooks](https://pl.wikibooks.org/wiki/Kody_%C5%BAr%C3%B3d%C5%82owe/Algorytm_Euklidesa#C/C++,_C#,_Java)
        > UWAGA: przed użyciem, sprawdź poprawność działania tego algorytmu dla rozwiązania Twojego problemu -> jak zachowuje się dla liczb o różnych znakach.

    * albo skorzystasz z tego, dostarczonego w klasie [`System.Numerics.BigInteger`](https://msdn.microsoft.com/en-us/library/system.numerics.biginteger.greatestcommondivisor(v=vs.110).aspx).

    Proces upraszczania należy umieścić w konstruktorach po to, by zapamiętany ułamek był już nieskracalny.

5. Upraszczanie jest działaniem potencjalnie pochłaniającym czas (patrz: [Algorytm Euklidesa](https://pl.wikipedia.org/wiki/Algorytm_Euklidesa)) - w przypadku dużych liczb budujących ułamek. Rozważ możliwość selektywnego włączania lub wyłączania tego procesu. Możesz to zrealizować, poprzez zdefiniowanie prywatnego konstruktora, np:
    ````csharp
    private Ulamek(long licznik, long mianownik, bool upraszczanie)
    {
        // ...
        if( upraszczanie )
        {
            // ... wywołanie algorytmu NWD i uproszczenie ułamka
        }
        // ...
    }
    ````
    Z tego konstruktora zawsze będziesz korzystał budując ułamki wewnątrz projektowanej klasy, pozostałe konstruktory - z domyślnie włączonym upraszczaniem - udostępnisz światowi zewnętrznemu.  

6. Aby zapewnić niemożliwość operowania na obiektach typu `Ulamek`, których `mianownik` byłby zerowy, w konstruktorach musisz zgłosić wyjątek, np. `DivideByZeroException`.


7. Ponieważ testów jednostkowy dla Twojej klasy będzie dużo, rozbij je na wiele klas i plików. Dla potrzeb testowania podstawowej funkcjonalności z tego kroku, zmień nazwę klasy testującej np. na `UnitTestConstruction`.

8. Aby usprawnić proces testowania, zamiast metody testującej z atrybutem `[TestMethod]` zastosuj atrybut `[DataTestMethod]` z podaniem w kolejnych, niższych wierszach przykładowych zestawów testowych:

    ````csharp
    [DataTestMethod]
    [DataRow(1, 3, 1, 3)]
    [DataRow(3, 1, 3, 1)]
    [DataRow(0, 2, 0, 1)]
    public void Konstruktor_PoprawneDaneBezUpraszczania_OK(long licznik, long mianownik, long expextedLicznik, long expectedMianownik)
    {
        // arrange - realizowane jako DataRow

        // act
        Ulamek u = new Ulamek(licznik, mianownik);

        // assert
        Assert.AreEqual(u.Licznik, expextedLicznik);
        Assert.AreEqual(u.Mianownik, expectedMianownik); 
    }
    ````

### Zadania do wykonania - część 2

Funkcjonalności z tej części mogą być zrealizowane już teraz, ale w niektórych przypadkach łatwiej będzie je zdefiniować równolegle, w kolejnych krokach (np. po implementacji _równości ułamków_) - lub obecny kod później zrefaktoryzować.

1. Zaimplementuj konstruktor tworzący ułamek na podstawie tekstowej jego reprezentacji, tzn. `new Ulamek("-2/3") --> licznik = -2, mianownik = 3`. Konstruktor ten powinien być działaniem odwrotnym do metody `ToString()`, tzn. jeśli utworzysz ułamek, następnie wyeksportujesz go do postaci tekstowej i ponownie utworzysz ułamek na jej podstawie, to otrzymasz "taki sam" ułamek:
    ````csharp
    var u = new Ulamek(1,2);
    var s = u.ToString();
    var v = new Ulamek(s);
    // u oraz v są "takie same"
    ````

2. Wzorując się na typie `long` (formalnie [`System.Int64`](https://docs.microsoft.com/en-us/dotnet/api/system.int64?view=netframework-4.7.2)) zaimplementuj metody `Parse(string)` oraz `TryParse(string, long)`, które przetwarzają poprawnie uformowany napis do ułamka.

3. Zastanów się i zaimplementuj zgłaszanie odpowiednich wyjątków.

4. Wzorując się na typie `long` dodaj do klasy stałe `MaxValue` oraz `MinValue`.

5. Dodaj do typu stałe: `ZERO` - reprezentującą ułamek `0/1`, `JEDEN` - reprezentującą ułamek `1/1` oraz `POLOWA` - reprezentującą ułamek `1/2`.

6. Zaimplementuj konwersję Ułamka do typu `double` (`ToDouble()`), `float` (`ToSingle()`) oraz `decimal` (`ToDecimal()`).

7. Zaimplementuj konstruktor `Ulamek(double)` oraz `Ulamek(decimal)` tak, aby korespondował z wcześniej opracowanymi konwersjami do tych typów.

8. Zaimplementuj konwersję Ułamka do typu `long` - z utratą informacji - będzie to wyznaczenie częsci całkowitejj z dzielenia.

9. Utwórz stosowne testy jednostkowe weryfikujące poprawność opracowanych metod.


#### Podpowiedzi - część 2

1. Do konwersji z `string` do `Ulamek` będziesz musiał parsować napis. Rozważ zastosowanie metody [string.Split](https://docs.microsoft.com/pl-pl/dotnet/csharp/how-to/parse-strings-using-split). Możesz również zastosować [wyrażenia regularne (REGEX)](https://docs.microsoft.com/pl-pl/dotnet/standard/base-types/regular-expressions).

2. Zadania dotyczące konwersji na inne typy liczbowe powtórzysz przy implementacji operatorów konwesji jawnej (rzutowanie) i niejawnej, w kolejnych krokach.

3. W języku C# stałe definiowane są za pomocą słowa kluczowego [`const`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const). Definiowana stała musi być jasno określona lub możliwa do ustalenia jeszcze w trakcie kompilacji. W naszym przypadku zasymulujesz działanie stałej zmienną tylko do odczytu (prawdopodobnie użyjesz `public static readonly`).



[Początek](Readme.md) | [Krok poprzedni](step00.md) | [Krok następny](step02.md)