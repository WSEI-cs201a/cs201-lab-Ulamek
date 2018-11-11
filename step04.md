## Krok 4. Porównywanie ułamków ##

W tym etapie zdefiujesz mechanizmy porównywania ułamków.


Wykonuj zadania w podanej kolejności.

### Zadania do wykonania
 
1. W projekcie _Class library_ dodaj nową klasę. Plik nazwij `UlamekRelations.cs`. 

2. Zmień nazwę klasy na `Ulamek`. Dodaj słowo kluczowe `partial` przed `class`. Korzystasz z funkcjonalności dzielenia klasy na wiele plików [`partial class`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods). Rozbudowę klasy `Ulamek` w zakresie tego kroku przeprowadzisz w tym pliku.

3. W projekcie z testami jednostkowymi utwórz plik o nazwie `UnitTestUlamekRelations.cs`. Możesz to wykonać kolejno poleceniami: *Add > New Item .. > Basic Unit Test*. testy jednostkowe związane z implementacją równości ułamków zapisz w tym pliku.

4. Zaimplementuj interfejs [`IComparable`](https://docs.microsoft.com/pl-pl/dotnet/api/system.icomparable?view=netframework-4.7.2). Jego implementacja powinna być spójna z `Equals`.

5. Zaimplementuj interfejs [`IComparable<Ulamek>`](https://docs.microsoft.com/pl-pl/dotnet/api/system.icomparable-1?view=netstandard-2.0). Jego implementacja powinna być spójna z `Equals<Ulamek>` oraz poprzednim krokiem.

6. Zdefiniuj przeciążenie operatorów relacyjnych (`<`, `<=`, `>`, `>=`).

7. Napisz testy jednostkowe weryfikujące poprawność tych nowych funkcjonalności.


#### Podpowiedzi

1. Poczytaj na temat IComparable oraz IComparer (https://www.c-sharpcorner.com/uploadfile/yougerthen/using-icomparable-and-icomparer-to-compare-objects/).

2. Implementując metodę [`CompareTo()`](https://docs.microsoft.com/pl-pl/dotnet/api/system.icomparable.compareto) musisz spełnić następujące warunki:

>For objects A, B and C, the following must be true:
>
>* A.CompareTo(A) must return zero.
> 
> * If A.CompareTo(B) returns zero, then B.CompareTo(A) must return zero.
> 
> * If A.CompareTo(B) returns zero and B.CompareTo(C) returns zero, then A.CompareTo(C) must return zero.
> 
> * If A.CompareTo(B) returns a value other than zero, then B.CompareTo(A) must return a value of the opposite sign.
> 
> * If A.CompareTo(B) returns a value x not equal to zero, and B.CompareTo(C) returns a value y of the same sign as x, then A.CompareTo(C) must return a value of the same sign as x and y.



[Początek](Readme.md) | [Krok poprzedni](step03.md) | [Krok następny](step05.md)