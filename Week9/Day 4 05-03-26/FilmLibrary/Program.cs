using System;
using System.Collections.Generic;
using System.Linq;

public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }
}

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        films.RemoveAll(f => f.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    }

    public List<IFilm> GetFilms() => films;

    public List<IFilm> SearchFilms(string query)
    {
        return films.Where(f => f.Title.Contains(query) || f.Director.Contains(query)).ToList();
    }

    public int GetTotalFilmCount() => films.Count;
}

class Program
{
    static void Main(string[] args)
    {
        IFilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film { Title = "Inception", Director = "Christopher Nolan", Year = 2010 });
        library.AddFilm(new Film { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014 });
        library.AddFilm(new Film { Title = "Avatar", Director = "James Cameron", Year = 2009 });

        
        Console.WriteLine("All Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

       
        Console.WriteLine("\nSearch Results for 'Nolan':");
        var searchResults = library.SearchFilms("Nolan");
        foreach (var film in searchResults)
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }

        
        library.RemoveFilm("Avatar");

       
        Console.WriteLine($"\nTotal Films After Removal: {library.GetTotalFilmCount()}");

     
        Console.WriteLine("\nRemaining Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} - {film.Director} ({film.Year})");
        }
    }
}