## Krok 0. Przygotowania ##

1. Utwórz projekt o nazwie `UlamekAsClassLib` typu Class Library (.NET Standard) oraz solution o nazwie `UlamekAsClass` (zaznacz _check box_ wymuszający tworzenie folderu dla _solution_).
    > .NET Standard jest formalną specyfikacją .NET API wspólną dla wszystkich implementacji środowiska .NET (.NET Framework, .NET Core, ...). Stosowane do projektowania bibliotek klas, dla zapewnienia kompatybilności ze wszystkimi implementacjami .NET.

    > W ramach Twojego _solution_ będziesz korzystał z wielu projektów - m. in. projektu testującego (UnitTests) czy projektu z aplikacją próbną. Zatem powinieneś mieć _solution_ z możliwością utworzenia wielu projektów.

2. W projekcie `UlamekAsClassLib` Zmień default'ową nazwę klasy z `Class1.cs`    na `Ulamek.cs`. W tym pliku będziesz tworzyć kod.

3. Dodaj do _solution_ projekt typu *Unit Tests*. Nadaj mu nazwę `UlamekAsClassUnitTest`. W klasach tego projektu tworzyć będziesz kod testów jednostkowych dla projektu `UlamekAsClassLib`, zaś uruchamiać je w _Test Explorer_.
   > Wykorzystujemy domyślne środowisko testów jednostkowych Microsoft MSTest v2.
   > Środowisko to ~~wymaga~~ (zalecane jest), aby projekt bazował na .NET Framework. Wybierz .NET Framework 4.7.2 lub wyższy.

   Dodaj referencję do projektu `UlamekAsClassLib`.

4. W _solution_ utwórz jeszcze jeden projekt typu _Console application (.NET Framework)_
   o nazwie `UlamekConsoleAppDemo`. (Wybierz .NET Framework 4.7.2 lub wyższy). Uczyń ten projekt aktywnym.

   W projekcie tym będziesz zapisywał proste fragmenty kodu testującego projektowaną klasę.

   Dodaj referencję do projektu `UlamekAsClassLib` oraz wpisz w wygenerowanym `Program.cs`:

   ````csharp
   using UlamekAsClassLib;
   using static System.Console;
   ````

    > Dyrektywa `using static` pozwala na odwołania bezpośrednie do składników
    > wskazanego typu. W naszym przypadku zamiast pisać `Console.WriteLine("abc")` 
    > będziemy mogli napisać `WriteLine("abc")`.

    > Zwróć uwagę, w jakiej przestrzeni nazw zdefininiowana jest klasa `Ulamek` (domyślnie nazwa projektu - czyli `UlamekAsClassLib`).

   Sprawdź poprawność konfiguracji, uruchamiając program (okienko konsoli wyskoczy i zamknie się, ponieważ w `Main()` nie ma nic ciekawego.

5. Oprócz testowania projektowanej klasy za pomocą testów jednostkowych
   oraz aplikacji konsolowej, możesz korzystać z interaktywnego środowiska C# (https://channel9.msdn.com/Events/Visual-Studio/Connect-event-2015/103).

[Początek](README.md) | [Krok następny](step01.md)
