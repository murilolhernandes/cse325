using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
  public static void Initialize(IServiceProvider serviceProvider)
  {
    using (var context = new MvcMovieContext(
      serviceProvider.GetRequiredService<
      DbContextOptions<MvcMovieContext>>()))
    {
      // Look for any movies.
      if (context.Movie.Any())
      {
        return; // DB has been seeded
      }
      context.Movie.AddRange(
        new Movie
        {
          Title = "When Harry Met Sally",
          ReleaseDate = DateTime.Parse("1989-2-12"),
          Genre = "Romantic Comedy",
          Price = 7.99M,
          Rating = "R"
        },
          new Movie
        {
          Title = "Ghostbusters ",
          ReleaseDate = DateTime.Parse("1984-3-13"),
          Genre = "Comedy",
          Price = 8.99M,
          Rating = "G"
        },
        new Movie
        {
          Title = "Ghostbusters 2",
          ReleaseDate = DateTime.Parse("1986-2-23"),
          Genre = "Comedy",
          Price = 9.99M,
          Rating = "G"
        },
        new Movie
        {
          Title = "Rio Bravo",
          ReleaseDate = DateTime.Parse("1959-4-15"),
          Genre = "Western",
          Price = 3.99M,
          Rating = "R"
        },
        new Movie
        {
          Title = "The Bourne Identity",
          ReleaseDate = DateTime.Parse("2002-6-6"),
          Genre = "Thriller/Action",
          Price = 5.99M,
          Rating = "PG-13"
        },
        new Movie
        {
          Title = "Batman Begins",
          ReleaseDate = DateTime.Parse("2005-6-15"),
          Genre = "Action/Crime",
          Price = 2.99M,
          Rating = "PG-13"
        },
        new Movie
        {
          Title = "Inception",
          ReleaseDate = DateTime.Parse("2010-7-13"),
          Genre = "Sci-fi/Action",
          Price = 6.99M,
          Rating = "PG-13"
        }
      );
      context.SaveChanges();
    }
  }
}