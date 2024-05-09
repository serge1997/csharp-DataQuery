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
}
