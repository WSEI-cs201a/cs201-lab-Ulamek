## Krok 5. Konwersje

W tym etapie zdefiniujesz mechanizmy konwersji ułamków do innych typów - konwersje automatyczne i rzutowanie.

Wykonuj zadania w podanej kolejności.

### Zadania do wykonania

1. W projekcie _Class library_ dodaj nową klasę. Plik nazwij `UlamekConversion.cs`.

2. Zmień nazwę klasy na `Ulamek`. Dodaj słowo kluczowe `partial` przed `class`. Korzystasz z funkcjonalności dzielenia klasy na wiele plików [`partial class`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods). Rozbudowę klasy `Ulamek` w zakresie tego kroku przeprowadzisz w tym pliku.

3. W projekcie z testami jednostkowymi utwórz plik o nazwie `UnitTestUlamekConversion.cs`. Możesz to wykonać kolejno poleceniami: *Add > New Item .. > Basic Unit Test*. Testy jednostkowe związane z implementacją równości ułamków zapisz w tym pliku.

4. Zaimplementuj konwersję automatyczną z typów liczbowych całkowitych (`byte`, ..., `uint`..., `long`) na `Ulamek`. Zrealizujesz to za pomocą przeciążenia operatora odpowiedniego typu z użyciem słowa kluczowego `implicit`.

5. Zaimplementuj konwersję jawną z typu `Ulamek` na pozostałe typy liczbowe z użyciem słowa kluczowego `explicit`. Będą to konwersje z utratą dokładności.

6. Uruchom wszystkie testy jednostkowe. Jest pewne prawdopodobieństwo, że wprowadzając do klasy mechanizmy domyślnych konwersji, niektóre z nich mogą teraz nie zostać zaliczone.

7. Nierozsądnym byłoby dostarczanie konwersji niejawnej z `double` na `Ulamek`. Poprzednio zrealizowałeś to w [kroku 1](step01.md) za pomocą konstruktora `Ulamek(double)` (w nomenklaturze C++ nazywa się go konstruktorem konwertującym). Zamiana liczby, np. `2.124267` na odpowiadający jej ułamek jest to procesem złożonym i czasami pracochłonnym. Wprowadzenie niejawnego działania konwersji spowoduje co prawda bardziej zwarty i ładniejszy zapis wyrażeń arytmetycznych (np. `Ulamek.POLOWA + 2.73415` ), ale kodujący może nie zwrócić uwagi na fakt długotrwałego obliczania takiego wyrażenia. Zatem, zdefiniuj jawną konwersję z `double` na `Ulamek`. Kodujący świadomie będzie musiał rzutować.

8. Opracuj stosowne testy jednostkowe dla konwersji liczbowych.

9. Przenieś kod implementujący `Ulamek Parse(string)` oraz `bool TryParse(string, out Ulamek)` który realizowałeś w [kroku 1](step01.md) do tej części klasy. raczej tu jest jego miejsce.

10. Statyczna klasa [`System.Convert`](https://docs.microsoft.com/en-us/dotnet/api/system.convert?view=netstandard-2.0) zbiera wszystkie metody konwertujące z jednego typu do innego. Na przykład [`Convert.ToInt64()`](https://docs.microsoft.com/en-us/dotnet/api/system.convert.toint64?view=netstandard-2.0). Załóżmy, że naszym celem jest dołączenie do tej listy jeszcze jednej pozycji: `Convert.ToInt64(Ulamek)` (czyli konwersji z `Ulamek` na `long`). Jest to możliwe za pomocą implementacji interfejsu `IConvertible`. Zaimplementuj tę konwersję (pozostałe pozostaw z `NotImplementedException`).

#### Podpowiedzi

1. Poczytaj [o konwersjach ogólnie](https://docs.microsoft.com/en-US/dotnet/csharp/programming-guide/statements-expressions-operators/using-conversion-operators) oraz o konwersjach [domyślnych](https://docs.microsoft.com/en-US/dotnet/csharp/language-reference/keywords/implicit) i [jawnych](https://docs.microsoft.com/en-US/dotnet/csharp/language-reference/keywords/explicit). Wprowadzenie konwersji nie wymaga implementowania jakiegokolwiek interfejsu.

2. Poczytaj o implementacji interfejsu [`IConvertible`](https://docs.microsoft.com/en-Us/dotnet/api/system.iconvertible?view=netstandard-2.0). Dołączanie do klasy `Convert` metod konwersji własnych typów na typy tam predefiniowane jest trochę pokrętne. Najpierw wartość `Ulamka` musi być przekonwertowana na `double`, a następnie odpowiednią metodą z `Convert` na właściwy typ. Aby zaimplementować interfejs musimy napisać kod dla kilkunastu (kilkudziesięciu) metod. Zaletą takiej implementacji jest fakt, iż z naszej klasy można korzystać w standardowy sposób.

3. Raczej nie stosuje się konwersji jawnych i niejawnych dla `string` - od tego są dostarczane dedykowane metody (`Parse` oraz `TryParse`).

[Początek](README.md) | [Krok poprzedni](step04.md) | [Krok następny](step06.md)