# Euro Checksums (Prüfsummen Euro)

A Windows desktop app that checks whether a euro banknote serial number is valid, and looks up which country and printing works it came from.

It handles both banknote generations:

| Series | Serial format | Example layout |
| --- | --- | --- |
| First series (2002) | 1 letter + 11 digits | `X12345678901` |
| Europa series (2013+) | 2 letters + 10 digits | `UA1234567890` |

For each banknote you enter the **serial number** and the **printer code** (6 characters, starting with a letter). The app then:

- checks that both have the right format,
- validates the serial number's check digit,
- shows the issuing country (first series) or the printing works with its city and country,
- warns when that printer's notes are no longer in circulation.

The interface is available in **German, English and Norwegian**. All texts come from the database, so adding a language takes no code changes.

## How the check digit works

Letters count by alphabet position (A = 1 … Z = 26), digits count as themselves.

- **First series:** add the letter's value to the first 10 digits. The check digit (the 12th character) is `8 − (sum mod 9)`, where a result of 0 is written as 9.
- **Europa series:** add both letters' values to the first 9 digits. The check digit is `7 − (sum mod 9)`, where 0 is written as 9 and −1 as 8.

## Architecture

```
┌──────────────────────┐   SOAP / WCF    ┌──────────────────────┐   EF6   ┌──────────────┐
│ EuroPrüfziffern      │ ──────────────▶ │ EuroServiceCF        │ ──────▶ │ SQL Server   │
│ WPF client (.NET 6)  │                 │ WCF service (.NET Fx)│         │ EuroDB       │
└──────────────────────┘                 └──────────────────────┘         └──────────────┘
```

| Folder | What it is |
| --- | --- |
| `Euro/EuroPrüfziffern` | WPF client (.NET 6, [Material Design in XAML](https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit)). Talks to the service through the generated `ServiceReference1`. |
| `Euro/EuroServiceCF` | WCF service using Entity Framework 6 **code-first**. This is the service the client uses. |
| `Euro/EuroService` | Earlier WCF service using EF6 **database-first** (EDMX). Kept for reference; `EuroServiceCF` still uses its shared contract types (`IService1`, `PrinteryData`). |
| `database/schema.sql` | Drops and creates all tables. |
| `database/seed.sql` | Languages, countries, cities, printers, series codes and UI texts. |
| `database/DB.vpp` | Visual Paradigm model of the database. |

## Getting started

### Requirements

- Windows
- Visual Studio 2022 with the *ASP.NET and web development* and *.NET desktop development* workloads (WCF services need .NET Framework 4.7.2)
- .NET 6 SDK
- SQL Server (LocalDB, Express, Developer or a Docker container)

### 1. Set up the database

Create a database called `EuroDB`, then run the scripts in order:

```powershell
sqlcmd -S localhost -d EuroDB -i database/schema.sql
sqlcmd -S localhost -d EuroDB -i database/seed.sql
```

### 2. Configure the connection

The connection string is currently set in the constructor in `Euro/EuroServiceCF/EuroContext.cs` (and in `Euro/EuroServiceCF/Web.config`). Change it to point at your SQL Server instance.

### 3. Run the service

Open `Euro/Euro.sln` in Visual Studio. NuGet packages are restored on build.

The client expects the service at `http://localhost/EuroServiceCF/Service1.svc`. Host `EuroServiceCF` there in local IIS (Visual Studio needs to run as administrator for this), or change the endpoint in `Euro/EuroPrüfziffern/Connected Services/ServiceReference1/Reference.cs`.

### 4. Run the client

Set `EuroPrüfziffern` as the startup project and start it.

## Credits

- App icon from [icon-icons.com](https://icon-icons.com/) (`cash_icon-icons.com_51090.ico`)
- Built as a school project at HTL Perg

## License

[MIT](LICENSE) © 2023 Fabian Herndl
