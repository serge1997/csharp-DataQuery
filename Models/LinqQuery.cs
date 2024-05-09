using System.Linq;
using System.Text;


namespace Linq.Models;

internal class LinqQuery
{
    public static void FilterByGenre(string genre, List<Musics> musics)
    {
        var data = from music in musics
                   where music.Genre == genre
                   orderby music.Genre descending
                   select music;

        if (data?.Count() < 1)
        {
            throw new ArgumentException(nameof(genre), $"This genre {genre} don't exists ");
        }
        
        foreach (var item in data)
        {
            Console.WriteLine($"Artist: {item.Artist}");
            Console.WriteLine($"Music title: {item.Name}");
            Console.WriteLine($"Genre: {item.Genre}");
            Console.WriteLine("\n");
        }

    }

    public static void ListAllGenre(List<Musics> musics)
    {
        if ( musics?.Count() > 0 )
        {
            var genres = musics.OrderBy(genre => genre.Genre)
                .Select(genre => genre.Genre)
                .Distinct()
                .ToList();


            foreach (var item in genres)
            {
                Console.WriteLine($"- Genre: {item}");
            }
        }
    }

    public static void FindByArtistName(string name, List<Musics> musics)
    {
        if ( musics?.Count() > 0 )
        {
            var artist = musics.OrderBy(title => title.Name)
                .Select(title => title)
                .Where(title => title.Artist == name)
                .DistinctBy(title => title.Name)
                .ToList();

            foreach ( var art in artist )
            {
                Console.WriteLine($"Artist: {art.Artist}");
                Console.WriteLine($"Title: {art.Name}");
            }
        }
    }
}
