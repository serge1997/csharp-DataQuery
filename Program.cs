using Linq.Models;
using System.Text.Json;

using (HttpClient client = new HttpClient())
{
    try
    {
     
        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musics = JsonSerializer.Deserialize<List<Musics>>(response)!;

        var byNames = from music in musics
                      where (music.Duration / 100) > 300
                      orderby music.Name
                      select music.Name;


        LinqQuery.FilterByGenre("hip hop", musics);
        //Console.WriteLine(response);


    }catch(Exception ex)
    {

        Console.WriteLine(ex.Message); 
    }
}



