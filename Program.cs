using Linq.Models;
using System.Text.Json;
using Linq.Db;

using (HttpClient client = new HttpClient())
{
    try
    {

        var listArtits = new ArtistaDao();

        new ArtistaDao().create(new Artist("Rocky", "Rap"){ Picture = "Picture"});

        //connection.Open();
        //Console.WriteLine(connection.State);

        var artists = listArtits.Listall();

        foreach (var artist in artists)
        {
            Console.WriteLine(artist);
        }

        return;

        string response = await client.GetStringAsync("https://guilhermeonrails.github.io/api-csharp-songs/songs.json");
        var musics = JsonSerializer.Deserialize<List<Musics>>(response)!;

        var byNames = from music in musics
                      where (music.Duration / 100) > 300
                      orderby music.Name
                      select music.Name;


        //LinqQuery.FilterByGenre("hip hop", musics);
        //Console.WriteLine(response);
        //LinqQuery.ListAllGenre(musics);
        LinqQuery.FindByArtistName("Post Malone", musics);


    }
    catch(Exception ex)
    {

        Console.WriteLine(ex.Message); 
    }

}



