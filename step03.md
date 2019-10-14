## Krok 3. Operacje arytmetyczne

W kroku tym zdefiniujesz podstawowe działania arytmetyczne i operacje matematyczne na ułamkach.

Kod z tego etapu prawdopodobnie zrefaktoryzujesz po zrealizowaniu etapu związanego z konwersjami.

Wykonuj zadania w podanej kolejności.

### Zadania do wykonania

1. W projekcie _Class library_ dodaj nową klasę. Plik nazwij `UlamekArithmetic.cs`. 

2. Zmień nazwę klasy na `Ulamek`. Dodaj słowo kluczowe `partial` przed `class`. Korzystasz z funkcjonalności dzielenia klasy na wiele plików [`partial class`](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods). Rozbudowę klasy `Ulamek` w zakresie tego kroku przeprowadzisz w tym pliku.

3. W projekcie z testami jednostkowymi utwórz plik o nazwie `UnitTestUlamekArithmetic.cs`. Możesz to wykonać kolejno poleceniami: *Add > New Item .. > Basic Unit Test*. testy jednostkowe związane z implementacją równości ułamków zapisz w tym pliku.

4. Utwórz publiczną metodę o sygnaturze
    ```csharp
    public Ulamek Plus(Ulamek inny)
    ```
    realizującą operację dodawania ułamków.

    Próba dodania `null` skutkuje zgłoszeniem wyjątku `ArgumentException`.

5. Utwórz publiczną statyczną metodę o sygnaturze
    ```csharp
    public static Ulamek Suma(Ulamek u1, Ulamek u2)
    ```
    realizującą operację obliczania sumy dwóch ułamków.

    Próba sumowania `null` skutkuje zgłoszeniem wyjątku `ArgumentException`.

6. Zmodyfikuj metodę `Suma` tak, aby mogła przyjąć wiele argumentów (ale co najmniej 2).

7. Zdefiniuj przeciążenie operatora `+`.

8. Zrób to samo dla pozostałych operatorów arytmetycznych dwuargumentowych (`-`, `*`, `/`, `%`) oraz jednoargumentowego `-` (znak przeciwny).

9. Zaimplementuj dla ułamka wybrane metody z `System.Math`
    * `Abs`
    * `Sign`
    * `Floor`
    * `Ceiling`
    * `Max`
    * `Pow`

10. Oczywiście opracuj stosowne testy jednostkowe dla tych nowych funkcjonalności

### Podpowiedzi

1. Aby przekazać do metody wiele argumentów użyj słowa kluczowego [params](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/params).

2. Przeczytaj [dokumentację](https://docs.microsoft.com/en-US/dotnet/csharp/programming-guide/statements-expressions-operators/overloadable-operators) na temat przeciążania operatorów.

3. Klasa [System.Math](https://docs.microsoft.com/pl-pl/dotnet/api/system.math?view=netframework-4.7.2).

[Początek](README.md) | [Krok poprzedni](step02.md) | [Krok następny](step04.md)