// ********************************************************
// The use of this source code is licensed under the terms
// of the MIT License (https://opensource.org/licenses/MIT)
// ********************************************************

using AstroTogether.BackEnd.DB;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using C = AstroTogether.Common;
using DB = AstroTogether.BackEnd.DB;

namespace AstroTogether.BackEnd;

public static class ClubEndpoints
{
    public static void MapClubEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Club")
            .WithTags(nameof(Club))
            .WithOpenApi();

        group.MapGet("/", async (AstroTogetherContext db) =>
            {
                return await db.Clubs.ToListAsync();
            })
            .WithName("GetAllClubs");

        group.MapGet("/{id}", async Task<Results<Ok<C.Club>, NotFound>> (Guid clubid, AstroTogetherContext db) =>
            {
                var club = await db.Clubs.AsNoTracking()
                    .FirstOrDefaultAsync(model => model.ClubId == clubid);

                if (club is null)
                    return TypedResults.NotFound();

                return TypedResults.Ok(new C.Club()
                {
                    City = club.City,
                    ClubId = club.ClubId,
                    Country = club.Country,
                    Name = club.Name,
                    Region = club.Region,
                    Status = club.Status,
                    Website = new Uri(club.Website)
                });
            })
            .WithName("GetClubById");

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid clubid, C.Club club, AstroTogetherContext db, IValidator<C.Club> validator) =>
            {
                var result = validator.Validate(club);

                //if (!result.IsValid)
                //    return Results.ValidationProblem(result.ToDictionary());

                var affected = await db.Clubs
                    .Where(model => model.ClubId == clubid)
                    .ExecuteUpdateAsync(setters => setters
                        .SetProperty(m => m.ClubId, club.ClubId)
                        .SetProperty(m => m.Name, club.Name)
                        .SetProperty(m => m.Status, club.Status)
                        .SetProperty(m => m.City, club.City)
                        .SetProperty(m => m.Region, club.Region)
                        .SetProperty(m => m.Country, club.Country)
                        .SetProperty(m => m.Website, club.Website.AbsoluteUri));

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("UpdateClub");

        group.MapPost("/", async (C.Club club, AstroTogetherContext db, IValidator<C.Club> validator) =>
            {
                var result = validator.Validate(club);

                if (!result.IsValid)
                    return Results.ValidationProblem(result.ToDictionary());

                db.Clubs.Add(new Club()
                {
                    City = club.City,
                    ClubId = club.ClubId,
                    Country = club.Country,
                    Name = club.Name,
                    Region = club.Region,
                    Status = club.Status,
                    Website = club.Website.AbsoluteUri
                });

                await db.SaveChangesAsync();

                return TypedResults.Created(
                    $"/api/Club/{club.ClubId}", club);
            })
            .WithName("CreateClub");

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid clubid, AstroTogetherContext db) =>
            {
                var affected = await db.Clubs
                    .Where(model => model.ClubId == clubid)
                    .ExecuteDeleteAsync();

                return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
            })
            .WithName("DeleteClub");
    }
}