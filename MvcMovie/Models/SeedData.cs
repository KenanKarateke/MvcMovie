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
            // Eğer zaten film varsa, ekleme.
            if (context.Movie.Any())
            {
                return;
            }

            context.Movie.AddRange(
                new Movie
                {
                    Title = "The Crow",
                    ReleaseDate = DateTime.Parse("2025-2-28"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 9.90M
                },
                new Movie
                {
                    Title = "The Killer's Game",
                    ReleaseDate = DateTime.Parse("2025-3-8"),
                    Genre = "Action",
                    Rating = "R",
                    Price =12.00M
                },
                new Movie
                {
                    Title = "Speak No Evil",
                    ReleaseDate = DateTime.Parse("2025-3-6"),
                    Genre = "Horror",
                    Rating = "R",
                    Price = 12.00M
                },
                new Movie
                {
                    Title = "Back In Action",
                    ReleaseDate = DateTime.Parse("2025-4-3"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 9.90M
                },
                new Movie
                {
                    Title = "Venom: The Last Dance",
                    ReleaseDate = DateTime.Parse("2025-4-1"),
                    Genre = "Scientific",
                    Rating = "R",
                    Price = 11.90M
                }


            );

            context.SaveChanges();
        }
    }
}
