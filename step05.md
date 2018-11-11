## Krok 5. Konwersje ##

W tym etapie zdefiniujesz mechanizmy konwersji ułamków do innych typów - konwersje automatyczne i rzutowanie.


Wykonuj zadania w podanej kolejności.

### Zadania do wykonania

1. W projekcie _Class library_ dodaj nową klasę. Plik nazwij `UlamekConversion.cs`. 

2. Zmień nazwę klasy na `Ulamek`. Dodaj słowo kluczowe `partial` przed `class`. Korzystasz z funkcjonalności dzielenia klasy na wiele plików [`partial class`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods). Rozbudowę klasy `Ulamek` w zakresie tego kroku przeprowadzisz w tym pliku.

3. W projekcie z testami jednostkowymi utwórz plik o nazwie `UnitTestUlamekConversion.cs`. Możesz to wykonać kolejno poleceniami: *Add > New Item .. > Basic Unit Test*. testy jednostkowe związane z implementacją równości ułamków zapisz w tym pliku.

4. Zaimplementuj konwersję automatyczną z typów liczbowych całkowitych (`byte`, ..., `uint`..., `long`) na `Ulamek` Zrealizujesz to za pomocą przeciążenia operatora odpowiedniego typu z uzyciem słowa kluczowego `implicit`.

5. Zaimplementuj konwersję jawną z typu `Ulamek` na pozostałe typy liczbowe z użyciem słowa kluczowego `explicit`. Będą to konwersje z utratą dokładności.

#### Podpowiedzi

1. Poczytaj [o konwersjach ogólnie](https://docs.microsoft.com/en-US/dotnet/csharp/programming-guide/statements-expressions-operators/using-conversion-operators) oraz o konwersjach [domyślnych](https://docs.microsoft.com/en-US/dotnet/csharp/language-reference/keywords/implicit) i [jawnych](https://docs.microsoft.com/en-US/dotnet/csharp/language-reference/keywords/explicit).

2. Raczej nie stosuje się konwersji jawnych i niejawnych dla `string` - od tego są dostarczane dedykowane metody.

[Początek](README.md) | [Krok poprzedni](step04.md) | [Krok następny](step06.md)