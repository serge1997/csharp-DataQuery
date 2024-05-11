using Linq.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Db;

internal class ArtistaDao
{

    public void create(Artist artist)
    {
        BeforeSave(artist);
        using var connection = new Connection().GetConnection();
        connection.Open();

        string sqlQuery = "INSERT INTO artists (Nome, Bio, Picture) VALUES(@name, @bio, @picture)";

        SqlCommand cmd = new SqlCommand(sqlQuery, connection);
        cmd.Parameters.AddWithValue("@name", artist.Name);
        cmd.Parameters.AddWithValue("@bio", artist.Bio);
        cmd.Parameters.AddWithValue("@picture", artist.Picture);

        if ( cmd.ExecuteNonQuery() > 0 )
        {
            Console.WriteLine($"Linha afetadas: {cmd.ExecuteNonQuery()}");
        }
    }

    public void BeforeSave(Artist artist)
    {
        using var connection = new Connection().GetConnection();
        connection.Open();

        string sqlQuery = $"SELECT * FROM artists WHERE Nome = '{artist.Name}'";
        SqlCommand cmd = new SqlCommand( sqlQuery, connection);

        using SqlDataReader reader = cmd.ExecuteReader();

        while( reader.Read() )
        {
            string Name = Convert.ToString(reader["Nome"])!;
            if ( Name.Length > 0)
            {
                throw new ArgumentException(nameof(artist), "Artist name already exist ");
            }
        }
    }

    public IEnumerable<Artist> Listall()
    {
        var listOfArtists = new List<Artist>();

        using var connection = new Connection().GetConnection();
        connection.Open();

        string sqlQuery = "SELECT * FROM artists";
        SqlCommand command = new SqlCommand(sqlQuery, connection);
        using SqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            string Name = Convert.ToString(reader["Nome"])!;
            string Bio = Convert.ToString(reader["Bio"])!;
            string Id = Convert.ToString(reader["Id"])!;
            Artist artists = new(Name, Bio)
            {
                Id = Id
            };

            listOfArtists.Add(artists);
        }

        return listOfArtists;
    }
}
