## **FlowaX - Das funktionale Result-Framework für C#**  
<img src="https://github.com/pat2381/FlowaX/blob/master/Doc/Logo.png" width="80" height="80"> 

[![NuGet Version](https://img.shields.io/nuget/v/FlowaX.svg)](https://www.nuget.org/packages/FlowaX)  [![NuGet Downloads](https://img.shields.io/nuget/dt/FlowaX.svg)](https://www.nuget.org/packages/FlowaX)  [![MIT License](https://img.shields.io/github/license/pat2381/FlowaX.svg)](https://github.com/pat2381/FlowaX/blob/main/LICENSE)  

---

## **🌟 Projektbeschreibung**  

**FlowaX** ist ein funktionales, leichtgewichtiges und erweiterbares **Result-Framework** für C#. Es bietet eine **robuste Fehlerbehandlung**, **asynchrone Unterstützung** und **funktionale API-Erweiterungen** wie **`Map`**, **`Bind`**, **`Match`** und vieles mehr.  

Mit **FlowaX** kannst du **Exceptions vermeiden**, **Ergebnisse sicher verwalten** und **Clean-Code-Prinzipien** umsetzen. Entwickle **zuverlässige und testbare Anwendungen** mit einer **klar strukturierten API**.

---

## **🚀 Features**  

✔️ **Polymorphes Design:** `Success<T>` und `Failure<T>` für präzise Fehler- und Erfolgsverarbeitung  
✔️ **Funktionale Erweiterungen:** `Map`, `Bind`, `Match`, `OnSuccess`, `OnFailure`  
✔️ **Asynchrone Unterstützung:** `BindAsync`, `MapAsync`, `FromAsync` für `Task<Result<T>>`  
✔️ **Optionale Werte:** Unterstützung für `Maybe<T>`  
✔️ **Automatisches Exception-Handling:** Vermeide `try-catch`-Blöcke durch `From`-Methoden  
✔️ **Unit-Test-Unterstützung:** Perfekt für xUnit, NUnit und MSTest

---

## **📦 Installation**  

### **.NET CLI:**  
```bash
dotnet add package FlowaX
```
oder

```csharp
PM> Install-Package FlowaX
```
## **📚 Verwendungsbeispiele**
## 1. Einfacher Erfolg und Fehler:
```csharp
using FlowaX.Core;

var success = Result<int>.Success(42);
var failure = Result<int>.Failure("Ein Fehler ist aufgetreten.");

Console.WriteLine(success.IsSuccess);  // True
Console.WriteLine(failure.Error);     // "Ein Fehler ist aufgetreten"
```
## 2. Funktionale Verarbeitung:
```csharp
using FlowaX.Core;
using FlowaX.Extensions;

var result = Result<int>.Success(10)
    .Map(x => x * 2)          // Verdopple den Wert
    .Bind(x => Result<int>.Success(x + 5)) // Füge 5 hinzu
    .Match(
        onSuccess: value => $"Ergebnis: {value}",
        onFailure: error => $"Fehler: {error}"
    );

Console.WriteLine(result);  // "Ergebnis: 25"

```
## 3. Asynchrone Verarbeitung:
```csharp
using FlowaX.Core;

Result<int> result = Result<int>.From(() =>
{
    // Simulierte Operation mit Fehler
    if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
    {
        throw new InvalidOperationException("Keine Operation an Sonntagen!");
    }
    return 100;
});

Console.WriteLine(result.IsSuccess ? $"Ergebnis: {result.Value}" : $"Fehler: {result.Error}");

```

## **🌍 Lizenz**
Dieses Projekt steht unter der MIT-Lizenz. Siehe LICENSE für Details.




