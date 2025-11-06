using Newtonsoft.Json;
using SaphetyToDDL.Lib.Models;
using System;

class Program
{
    static void Main(string[] args)
    {
        var saphetyToDDL = new SaphetyToDDL.Lib.SaphetyToDDL();
        var serializeOptions = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== SAPHETY / DDL Conversion Console ===");
            Console.WriteLine("Select an option:");
            Console.WriteLine("1) Parse SAPHETY XML and convert to DDL");
            Console.WriteLine("2) Parse DDL JSON and convert to XML Invoice");
            Console.WriteLine("3) Parse DDL JSON sample string and convert to XML Invoice");
            Console.WriteLine("0) Exit");
            Console.Write("> ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ProcessSaphety(saphetyToDDL, serializeOptions);
                    break;

                case "2":
                    ProcessDdl(saphetyToDDL, serializeOptions);
                    break;

                case "3":
                    ProcessDdlFromString(saphetyToDDL, serializeOptions);
                    break;

                case "0":
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid option. Press Enter to try again...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void ProcessSaphety(SaphetyToDDL.Lib.SaphetyToDDL saphetyToDDL, JsonSerializerSettings serializeOptions)
    {
        Console.WriteLine("\n=== Parsing SAPHETY Sample File ===");

        var itemTransactionSaphety = saphetyToDDL.Parse(SaphetyToDDL.Console.Properties.Resources.saphetySampleFile1);
        var serializeJsonSaphety = JsonConvert.SerializeObject(itemTransactionSaphety, Formatting.Indented, serializeOptions);

        Console.WriteLine("--- SAPHETY Parsed JSON ---");
        Console.WriteLine(serializeJsonSaphety);

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }

    static void ProcessDdl(SaphetyToDDL.Lib.SaphetyToDDL saphetyToDDL, JsonSerializerSettings serializeOptions)
    {
        Console.WriteLine("\n=== Parsing SAPHETY Sample File First to get DDL JSON ===");
        var itemTransactionSaphety = saphetyToDDL.Parse(SaphetyToDDL.Console.Properties.Resources.saphetySampleFile1);
        var serializeJsonSaphety = JsonConvert.SerializeObject(itemTransactionSaphety, Formatting.Indented, serializeOptions);

        var itemTransactionDdl = JsonConvert.DeserializeObject<ItemTransaction>(serializeJsonSaphety);

        Console.WriteLine("--- Mapping to Invoice and Serializing to XML ---");
        var invoiceSaphety = SaphetyToDDL.Lib.SaphetyToDDL.MapFromDdl(itemTransactionDdl);
        var serializeXmlDdl = SaphetyToDDL.Lib.SaphetyToDDL.SerializeInvoiceToXml(invoiceSaphety);

        Console.WriteLine("--- DDL Mapped XML Output ---");
        Console.WriteLine(serializeXmlDdl);

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
    static void ProcessDdlFromString(SaphetyToDDL.Lib.SaphetyToDDL saphetyToDDL, JsonSerializerSettings serializeOptions)
    {
        Console.WriteLine("\n=== Parsing DDL JSON Sample String ===");

        // Read raw JSON text from resources
        var ddlJsonString = SaphetyToDDL.Console.Properties.Resources.dllSampleString2;

        Console.WriteLine("--- Loaded DDL JSON ---");
        Console.WriteLine(ddlJsonString);

        // Map JSON string to invoice
        Console.WriteLine("\n--- Mapping JSON to Invoice and Serializing to XML ---");
        var invoiceSaphety = SaphetyToDDL.Lib.SaphetyToDDL.MapFromDdlString(ddlJsonString);

        // Serialize to XML
        var serializeXmlDdl = SaphetyToDDL.Lib.SaphetyToDDL.SerializeInvoiceToXml(invoiceSaphety);

        Console.WriteLine("--- DDL Mapped XML Output ---");
        Console.WriteLine(serializeXmlDdl);

        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}