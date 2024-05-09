using System.Text;
using System.Text.Json.Serialization;

namespace Linq.Models;

class Musics
{
    [JsonPropertyName("song")]
    public string? Name { get; set; }

    [JsonPropertyName("artist")]
    public string? Artist { get; set; }

    [JsonPropertyName("duration_ms")]
    public int? Duration { get; set; }

    [JsonPropertyName("genre")]
    public string? Genre { get; set; }


    public string ShowMusicData()
    {
        var data = new StringBuilder();
        data.AppendLine("Title\t\t\tArtist\t\t\tDuration(s)\t\tGenre");
        data.AppendLine($"{Name}\t{Artist}\t{Duration}\t\t{Genre}");


        return data.ToString();
    }
}