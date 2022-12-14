using Lab1;
using Lab1.JsonModels;
using Newtonsoft.Json;

var input = File.ReadAllText("../../../input.json");
var inputDeserialized =
    JsonConvert.DeserializeObject<SimplexTaskModel>(input, new Newtonsoft.Json.Converters.StringEnumConverter());

if (inputDeserialized is null)
{
    throw new ArgumentException("Input format is incorrect.");
}

var (system, function) = inputDeserialized.GetEntity();

var method = new SimplexMethod();

var result = inputDeserialized.Mode is Mode.Minimize
    ? method.Minimize(function, system)
    : method.Maximize(function, system);

var output = JsonConvert.SerializeObject(result);
File.WriteAllText("../../../output.json", output);