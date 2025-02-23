using System;
using static System.Net.WebRequestMethods;

class HttpHandler {
    private string URL;
    public HttpHandler(string URL){
        this.URL = URL;
    }
    public async Task<string> Fetch()
    {
        using HttpClient client = new HttpClient();
        try
        {
            string res = await client.GetStringAsync(URL);
            Console.WriteLine("eseguito il get");
            if(res != null)
            {
                Console.WriteLine("res non � nullo");
                string Print = res.ToString();
                return Print;

            }
            else { 
                Console.WriteLine("Non stampato");
                return null;
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine("entrati nell errore");
            Console.WriteLine(ex.Message);
        }
        return null;
    }


}