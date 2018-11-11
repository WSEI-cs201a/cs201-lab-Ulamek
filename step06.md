## Krok 6. Rozszerzenia klasy `Ulamek` ##

W kroku tym poznasz mechanizmy rozszerzania funkcjonalności wcześniej zrealizowanej (i zamkniętej) klasy.


Wykonuj zadania w podanej kolejności.

### Zadania do wykonania

1. Zastanów się nad możliwością rozszerzenia typu `Ulamek` na typ `UlamekPro` przez dziedziczenie, wprowadzając dodatkową funkcjonalność: 

    mieszana reprezentacja tekstowa ułamka (znak, część całkowita, spacja, część ułamkowa zapisana w formie ułamka właściwego)
    
    ````[znak][część całkowita] <<licznik>>/<<mianownik>>````

    np. `-2 3/4` dla ułamka niewłaściwego, ale dla ułamka właściwego `3/4`.

2. Zamknij klasę `Ulamek` uniemożliwiając jej dziedziczenie.

3. Rozszerz klasę `String` o metodę `ToUlamek()`, konwertującą obiekt typu `string` na obiekt typu `Ulamek`.

4. W projekcie _Console App_ utwórz klasę `UlamekExtensions` w pliku `UlamekExtensions.cs`. Zaimplementuj w niej metodę rozszerzającą typ `Ulamek` o obliczanie średniej arytmetycznej dla potencjalnie wielu argumentów.

5. Sprawdź, czy można w C# rozszerzać typ o nowe przeciążone operatory.

#### Podpowiedzi

1. Poczytaj o [zamykaniu klasy](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/sealed).

1. Poczytaj o [metodach rozszerzających](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/extension-methods).



[Początek](README.md) | [Krok poprzedni](step05.md) | [Krok następny](step07.md)