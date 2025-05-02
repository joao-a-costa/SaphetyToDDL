# Saphety to DDL

[![NuGet Version](https://img.shields.io/nuget/v/SaphetyToDDL.Lib.svg)](https://www.nuget.org/packages/SaphetyToDDL.Lib/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/SaphetyToDDL.Lib.svg)](https://www.nuget.org/packages/SaphetyToDDL.Lib/)

The Saphety to DDL  is a .NET library for parsing Saphety invoices from XML format and converting them into accounting domain-driven objects, with the ability to serialize them into JSON format. This library offers a seamless solution for developers needing to integrate Saphety invoice parsing and conversion functionalities into their .NET applications.

## Features

- **Effortless XML Parsing**: Easily parse Saphety invoices contained within XML files and map them to accounting domain-driven objects.
  
- **Flexible Serialization**: Serialize accounting domain-driven objects into JSON format, providing flexibility in data interchange and storage.

- **Customization Options**: Tailor JSON serialization with customizable settings such as NullValueHandling.

## Installation

Install the package via NuGet Package Manager Console:

```bash
Install-Package SaphetyToDDL
```

## Usage

1. **Adding CustomDataGridView to your Form:**

    ```csharp
    using Newtonsoft.Json;

    // Parse Saphety invoice XML file and map it to an ItemTransaction object
    var itemTransaction = SaphetyToDDL.Lib.SaphetyToDDL.Parse(SaphetyToDDL.Console.Properties.Resources.SaphetySampleFile);
    
    // Define JSON serialization options
    var serializeOptions = new JsonSerializerSettings
    {
        NullValueHandling = NullValueHandling.Ignore,
    };
    
    // Serialize the item transaction object to JSON format
    var serializeJson = JsonConvert.SerializeObject(itemTransaction, Formatting.Indented, serializeOptions);
    
    // Output serialized JSON
    Console.WriteLine(serializeJson);
    ```

## Contributing

Contributions are welcome! Please follow these guidelines:

1. Fork the repository.
2. Create a branch: `git checkout -b feature/your-feature`.
3. Commit your changes: `git commit -m 'Add some feature'`.
4. Push to the branch: `git push origin feature/your-feature`.
5. Open a pull request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Special thanks to contributors and users for their valuable feedback.

---

Feel free to explore and extend the functionality of SaphetyToDDL for your WinForms applications! If you encounter any issues or have suggestions, please open an issue on the [GitHub repository](https://github.com/joao-a-costa/SaphetyToDDL/issues).
