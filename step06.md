## Krok 6. Rozszerzenia klasy `Ulamek`

W kroku tym poznasz mechanizmy rozszerzania funkcjonalności wcześniej zrealizowanej (i zamkniętej) klasy.

Wykonuj zadania w podanej kolejności.

### Zadania do wykonania

1. Zastanów się nad możliwością rozszerzenia typu `Ulamek` na typ `UlamekPro` przez dziedziczenie, wprowadzając dodatkową funkcjonalność:

    > mieszana reprezentacja tekstowa ułamka (znak, część całkowita, spacja, część ułamkowa zapisana w formie ułamka właściwego)
    > ```[znak][część całkowita] «licznik»/«mianownik»```
    > np. `-2 3/4` dla ułamka niewłaściwego, ale dla ułamka właściwego `3/4`.

    Spróbuj wykonać to zadanie, ale w innym projekcie typu _class library_.

2. Zamknij klasę `Ulamek` uniemożliwiając jej dziedziczenie. UWAGA: zamykając klasę projekt z poprzedniego punktu nie będzie się kompilował.

3. Rozszerz klasę `String` o metodę `ToUlamek()`, konwertującą obiekt typu `string` na obiekt typu `Ulamek`. Wykorzystaj stosowną metodę zaimplementowaną w klasie `Ulamek`.

4. W projekcie _Console App_ utwórz klasę `UlamekExtensions` w pliku `UlamekExtensions.cs`. Zaimplementuj w niej metodę rozszerzającą typ `Ulamek` odwracającą ułamek (tworzenie nowego ułamka, w którym licznik zamienia się z mianownikiem). Przykład użycia: `(new Ulamek("2/3")).Odwroc()` zwróci ułamek `3/2`.

5. Zaimplementuj metodę rozszerzającą `Pow` podnoszącą ułamek do podanej potęgi. Przykład użycia: `(new Ulamek("2/3")).Pow(2)` zwróci ułamek `4/9`.

6. W klasie `UlamekExtensions` dodaj metodę umożliwiającą obliczanie średniej arytmetycznej dla potencjalnie wielu argumentów typu `Ulamek`. Dodaj również metodę `List<Ulamek> Range(Ulamek lowerBound, Ulamek upperBound, Ulamek step)` generującą ciąg arytmetyczny ułamków począwszy od `lowerBound` z krokiem `step` tak, aby nie przekroczyć `upperBound`. Musisz przewidzieć różne sytuacje (lista pusta, ciąg rosnący lub malejący, zapętlanie się procesu generowania ciągu, ...).

7. Sprawdź, czy można w C# rozszerzać typ o nowe przeciążone operatory, konstruktory, _properties_ (te funkcjonalności pojawiły się w zapowiedziach realizacji już w C# 5).

#### Podpowiedzi

1. Poczytaj o [zamykaniu klasy](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sealed).

1. Poczytaj o [metodach rozszerzających](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods).



[Początek](README.md) | [Krok poprzedni](step05.md) | [Krok następny](step07.md)