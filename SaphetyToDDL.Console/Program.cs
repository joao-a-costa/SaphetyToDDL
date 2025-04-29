using Newtonsoft.Json;

var saphetyToDDL = new SaphetyToDDL.Lib.SaphetyToDDL();
var itemTransaction = saphetyToDDL.Parse(SaphetyToDDL.Console.Properties.Resources.saphetySampleFile1);
var itemtransactionSaphety = saphetyToDDL.ItemTransactionSaphety;


/// <summary>
/// JSON serialization options.
/// </summary>
var serializeOptions = new JsonSerializerSettings
{
    NullValueHandling = NullValueHandling.Ignore,
};

/// <summary>
/// Serialize the item transaction object to JSON format.
/// </summary>
var serializeJson = JsonConvert.SerializeObject(itemTransaction, Formatting.Indented, serializeOptions);
//var serializeJson = JsonConvert.SerializeObject(itemTransaction, Formatting.Indented);

Console.WriteLine(serializeJson);
Console.ReadLine();