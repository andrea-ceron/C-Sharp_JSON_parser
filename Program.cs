using Microsoft.VisualBasic;
using System.Text;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

string URL = "https://www.istat.it/wp-content/themes/EGPbs5-child/contanomi/nati/index2022.php?type=list&limit=200&year=2022";
HttpHandler x = new(URL);
string? JsonString = await x.Fetch();
if(JsonString == null)
{
    Console.WriteLine("Non è stato possible fare niente");
    return;
}


try
{
    if (JsonString.StartsWith("callback(") && JsonString.EndsWith(");") && JsonString != null)
    {
        int length = JsonString.Length-11;
        JsonString = JsonString.Substring(9, length);
        //Console.WriteLine(JsonString);

        string newjson = @"{
            ""years"": [2022],
            ""0"": [
                {""year"": 2022, ""name"": ""MATIAS"", ""count"": 112, ""gender"": ""m"", ""percent"": 0.055319569297639},
                {""year"": 2022, ""name"": ""ANTHONY"", ""count"": 109, ""gender"": ""m"", ""percent"": 0.053837795120024}
            ],
            ""1"": [
                {""year"": 2022, ""name"": ""ATENA"", ""count"": 108, ""gender"": ""f"", ""percent"": 0.056808618077765},
                {""year"": 2022, ""name"": ""CELINE"", ""count"": 108, ""gender"": ""f"", ""percent"": 0.056808618077765}
            ]
        }";


        var data = JsonSerializer.Deserialize<GenderNames>(JsonString);
        Console.WriteLine("\nYears:");
        foreach (var y in data.Years)
        {
            Console.WriteLine($"Anno: {y}");
        }

        Console.WriteLine("\nMale:");
        foreach (var male in data.Male)
        {
            Console.WriteLine($"Name: {male.Name}, Count: {male.Count}, Percent: {male.Percent}");
        }

        Console.WriteLine("\nFemale:");
        foreach (var female in data.Female)
        {
            Console.WriteLine($"Name: {female.Name}, Count: {female.Count}, Percent: {female.Percent}");
        }

    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}




class GenderNames
{
    [JsonPropertyName("years")]
    public IList<int> Years { get; set; }

    [JsonPropertyName("0")]
    public IList<ISTAT_Details> Male { get; set; }

    [JsonPropertyName("1")]
    public IList<ISTAT_Details> Female { get; set; }

};



class ISTAT_Details 
{
    [JsonPropertyName("1year")]
    public int Year { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("gender")]
    public char Gender { get; set; }

    [JsonPropertyName("percent")]
    public double Percent { get; set; }





};