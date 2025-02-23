using Microsoft.VisualBasic;
using System.Text;
using System;
using System.Text.Json;

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
    if (JsonString.StartsWith("callback") && JsonString.EndsWith(");"))
    {
        Console.WriteLine(JsonString.Length);
        int length = JsonString.Length-11;
        Console.WriteLine(length);
        JsonString = JsonString.Substring(9, length);
        JsonString = JsonString + ";";
        //Console.WriteLine(JsonString);
        List<ISTAT_Details>? y = JsonSerializer.Deserialize<List<ISTAT_Details>>(JsonString);
        //Console.WriteLine(y[0].Year);
    }

}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}




class GenderNames
{
    private List<int>? _year;
    private List<ISTAT_Details> _male;
    private List<ISTAT_Details> _female;


    public List<int>? Years
    {
        get {
            return _year;
        }  // Getter
        set {
            _year = value;
        } // Setter
    }

    public List<ISTAT_Details> Male
    {
        get { return _male; }  // Getter
        set => _male=value;  // Setter
    }

    public List<ISTAT_Details> Female
    {
        get { return _female; }  // Getter
        set { _female = value; } // Setter
    }




};



class ISTAT_Details 
{
    private int _year;
    private string _name;
    private int _count;
    private bool _gender ;
    private double _percentage;

    public int Year
    {
        get { return _year; }  // Getter
        set { _year = value; } // Setter
    }

    public string Name
    {
        get { return _name; }  // Getter
        set { _name = value; } // Setter
    }

    public int Count
    {
        get { return _count; }  // Getter
        set { _count = value; } // Setter
    }

    public bool Gender
    {
        get { return _gender; }  // Getter
        set { _gender = value; } // Setter
    }

    public double Percentage
    {
        get { return _percentage; }  // Getter
        set { _percentage = value; } // Setter
    }


};