# AdventureWorks Database SP Delay Custom

This repository contains a C# console application that demonstrates how to add a stored procedure (SP) named `delayCustom` to the AdventureWorks database. The stored procedure introduces a delay of 10 seconds using the command `WAITFOR DELAY '00:00:10';`.

## Table of Contents
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [File Structure](#file-structure)
- [Contributing](#contributing)
- [License](#license)

## Prerequisites

- Microsoft Visual Studio 2017 or later
- .NET Framework 4.5.2 or later
- Access to the AdventureWorks database

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/adventureworks-delay-custom.git
   ```
2. Open the solution file `ConsoleApp1.sln` in Visual Studio.
3. Restore any NuGet packages if prompted.

## Usage

1. Compile the application in Visual Studio.
2. Run the application. It will execute the `ExecuteAsync` method and then wait for 10 seconds.
3. To add the stored procedure to the AdventureWorks database, execute the following SQL command in your SQL Server Management Studio:
   ```sql
   CREATE PROCEDURE delayCustom
   AS
   BEGIN
       WAITFOR DELAY '00:00:10';
   END
   ```

## File Structure

.
├── ConsoleApp1
│   ├── App.config
│   ├── Clase.cs
│   ├── ConsoleApp1.csproj
│   ├── Program.cs
│   └── Properties
│       └── AssemblyInfo.cs
├── ConsoleApp1.sln
└── .vs (Visual Studio configuration files)

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
