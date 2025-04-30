// Import necessary namespaces
using Newtonsoft.Json;
using SaphetyToDDL.Lib.Models;

// Initialize the SaphetyToDDL engine
var saphetyToDDL = new SaphetyToDDL.Lib.SaphetyToDDL();

// Setup JSON serialization settings (ignore nulls)
var serializeOptions = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

Console.WriteLine("=== Parsing SAPHETY Sample File ===");

// Parse SAPHETY sample XML into internal model
var itemTransactionSaphety = saphetyToDDL.Parse(SaphetyToDDL.Console.Properties.Resources.saphetySampleFile1);

// Serialize parsed object into JSON (pretty-printed)
var serializeJsonSaphety = JsonConvert.SerializeObject(itemTransactionSaphety, Formatting.Indented, serializeOptions);

Console.WriteLine("--- SAPHETY Parsed JSON ---");
Console.WriteLine(serializeJsonSaphety);
Console.WriteLine();

Console.WriteLine("=== Parsing DDL Sample File ===");

// Deserialize DDL sample JSON into ItemTransaction
var itemTransactionDdl = JsonConvert.DeserializeObject<ItemTransaction>(serializeJsonSaphety);

// Map DDL ItemTransaction into an Invoice object
var invoiceSaphety = SaphetyToDDL.Lib.SaphetyToDDL.MapFromDdl(itemTransactionDdl);

// Serialize Invoice object into XML format
var serializeXmlDdl = SaphetyToDDL.Lib.SaphetyToDDL.SerializeInvoiceToXml(invoiceSaphety);

Console.WriteLine("--- DDL Mapped and Serialized to XML ---");
Console.WriteLine(serializeXmlDdl);
Console.WriteLine();

Console.WriteLine("=== Done. Press any key to exit ===");
Console.ReadLine();