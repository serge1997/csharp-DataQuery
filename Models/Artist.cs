namespace Linq.Models;


class Artist
{
    public string Name { get; }
    public string Bio { get; }
    public string Picture { get; set; }
    public string Id { get; set; }


    public Artist(string name, string bio)
    {
        Name = name;
        Bio = bio;
    }

    public override string ToString()
    {
        return $@"
            Id: {Id}
            Name: {Name}
            Bio: {Bio}";
    }

}