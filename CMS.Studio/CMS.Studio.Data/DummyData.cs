using CMS.Studio.Domain.Entities;
using CMS.Studio.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Bogus;

namespace CMS.Studio.Data;

public static class DummyData
{
    public static void SeedDatabase(DbContext context)
    {
        GenerateUsers(context, 20);
        GeneratePhotos(context, 20);
        GenerateAlbums(context, 20);
        GenerateOutfits(context, 10);
        GenerateServices(context, 20);
        GenerateAlbumXPhotos(context, 10);
        GenerateOutfitXPhotos(context, 10);
    }

    private static void GenerateOutfits(DbContext context, int count)
    {
        if (!context.Set<Outfit>().Any())
        {
            var outfitFaker = new Faker<Outfit>()
                .RuleFor(o => o.Id, f => Guid.NewGuid())
                .RuleFor(o => o.Type, f => f.PickRandom(new[] { "Dress", "Suit", "Casual", "Formal", "Traditional" }))
                .RuleFor(o => o.Name, f => f.Commerce.ProductName())
                .RuleFor(o => o.Size, f => f.PickRandom(new[] { "XS", "S", "M", "L", "XL", "XXL" }))
                .RuleFor(o => o.Price, f => f.Finance.Amount(50, 500))
                .RuleFor(o => o.Color, f => f.Commerce.Color())
                .RuleFor(o => o.Description, f => f.Lorem.Paragraph())
                .RuleFor(o => o.CreatedDate, f => f.Date.Past(2))
                .RuleFor(o => o.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(o => o.IsDeleted, f => false);

            // Generate outfits
            var outfits = outfitFaker.Generate(count);

            // Pick a common creator email (assuming this field exists)
            var commonUserEmail = context.Set<User>().FirstOrDefault()?.Email;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var outfit in outfits)
            {
                outfit.CreatedBy = commonUserEmail;
                outfit.LastUpdatedBy = commonUserEmail;
            }

            context.Set<Outfit>().AddRange(outfits);
            context.SaveChanges();
        }
    }


    private static void GenerateUsers(DbContext context, int count)
    {
        if (!context.Set<User>().Any())
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Username, f => f.Internet.UserName())
                .RuleFor(u => u.Password, f => f.Internet.Password())
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.ImageUrl, f => f.Internet.Avatar())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Dob, f => f.Date.Past(30))
                .RuleFor(u => u.Address, f => f.Address.FullAddress())
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(u => u.Status, f => f.PickRandom<UserStatus>())
                .RuleFor(u => u.Role, f => f.PickRandom<Role>())
                .RuleFor(u => u.CreatedDate, f => f.Date.Past(2))
                .RuleFor(u => u.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(u => u.IsDeleted, f => false);

            // Generate users
            var users = userFaker.Generate(count);

            // Pick a common email
            var commonUserEmail = users.Count > 0 ? users.First().Email : null;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var user in users)
            {
                user.CreatedBy = commonUserEmail;
                user.LastUpdatedBy = commonUserEmail;
            }

            context.Set<User>().AddRange(users);
            context.SaveChanges();
        }
    }

    private static void GenerateServices(DbContext context, int count)
    {
        if (!context.Set<Service>().Any())
        {
            var serviceFaker = new Faker<Service>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.Title, f => f.Commerce.ProductName())
                .RuleFor(s => s.Description, f => f.Lorem.Paragraph())
                .RuleFor(s => s.Type, f => f.Commerce.Categories(1).First())
                .RuleFor(s => s.Src, f => f.Image.PicsumUrl())
                .RuleFor(s => s.CreatedDate, f => f.Date.Past(2))
                .RuleFor(s => s.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(s => s.IsDeleted, f => false);

            // Generate services
            var services = serviceFaker.Generate(count);

            // Pick a common creator email (assuming this field exists)
            var commonUserEmail = context.Set<User>().FirstOrDefault()?.Email;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var service in services)
            {
                service.CreatedBy = commonUserEmail;
                service.LastUpdatedBy = commonUserEmail;
            }

            context.Set<Service>().AddRange(services);
            context.SaveChanges();
        }
    }


    private static void GenerateAlbums(DbContext context, int count)
    {
        if (!context.Set<Album>().Any())
        {
            var albumFaker = new Faker<Album>()
                .RuleFor(a => a.Id, f => Guid.NewGuid())
                .RuleFor(a => a.Title, f => f.Lorem.Sentence(3, 3))
                .RuleFor(a => a.Description, f => f.Lorem.Paragraph())
                .RuleFor(a => a.Background, f => f.Image.PicsumUrl())
                .RuleFor(a => a.CreatedDate, f => f.Date.Past(2))
                .RuleFor(a => a.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(a => a.IsDeleted, f => false);

            // Generate albums
            var albums = albumFaker.Generate(count);

            // Pick a common creator email (assuming this field exists)
            var commonUserEmail = context.Set<User>().FirstOrDefault()?.Email;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var album in albums)
            {
                album.CreatedBy = commonUserEmail;
                album.LastUpdatedBy = commonUserEmail;
            }

            context.Set<Album>().AddRange(albums);
            context.SaveChanges();
        }
    }


    private static void GeneratePhotos(DbContext context, int count)
    {
        if (!context.Set<Photo>().Any())
        {
            var photoFaker = new Faker<Photo>()
                .RuleFor(p => p.Id, f => Guid.NewGuid())
                .RuleFor(p => p.Title, f => f.Lorem.Sentence(3, 3))
                .RuleFor(p => p.Description, f => f.Lorem.Paragraph())
                .RuleFor(p => p.Src, f => f.Image.PicsumUrl())
                .RuleFor(p => p.Href, f => f.Internet.Url())
                .RuleFor(p => p.Tag, f => f.Lorem.Word())
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(2))
                .RuleFor(p => p.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(p => p.IsDeleted, f => false);

            // Generate photos
            var photos = photoFaker.Generate(count);

            // Pick a common creator email (assuming this field exists)
            var commonUserEmail = context.Set<User>().FirstOrDefault()?.Email;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var photo in photos)
            {
                photo.CreatedBy = commonUserEmail;
                photo.LastUpdatedBy = commonUserEmail;
            }

            context.Set<Photo>().AddRange(photos);
            context.SaveChanges();
        }
    }
    
    private static void GenerateAlbumXPhotos(DbContext context, int count)
    {
        if (!context.Set<AlbumXPhoto>().Any())
        {
            var albumXPhotoFaker = new Faker<AlbumXPhoto>()
                .RuleFor(axp => axp.Id, f => Guid.NewGuid())
                .RuleFor(axp => axp.PhotoId, f => f.PickRandom(context.Set<Photo>().Select(p => p.Id).ToList()))
                .RuleFor(axp => axp.AlbumId, f => f.PickRandom(context.Set<Album>().Select(a => a.Id).ToList()))
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(2))
                .RuleFor(p => p.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(p => p.IsDeleted, f => false);

            var albumXPhotos = albumXPhotoFaker.Generate(count);
            
            var commonUserEmail = context.Set<User>().FirstOrDefault()?.Email;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var albumXPhoto in albumXPhotos)
            {
                albumXPhoto.CreatedBy = commonUserEmail;
                albumXPhoto.LastUpdatedBy = commonUserEmail;
            }
            
            context.Set<AlbumXPhoto>().AddRange(albumXPhotos);
            context.SaveChanges();
        }
    }
    
    private static void GenerateOutfitXPhotos(DbContext context, int count)
    {
        if (!context.Set<OutfitXPhoto>().Any())
        {
            var outfitXPhotoFaker = new Faker<OutfitXPhoto>()
                .RuleFor(oxp => oxp.Id, f => Guid.NewGuid())
                .RuleFor(oxp => oxp.PhotoId, f => f.PickRandom(context.Set<Photo>().Select(p => p.Id).ToList()))
                .RuleFor(oxp => oxp.OutfitId, f => f.PickRandom(context.Set<Outfit>().Select(o => o.Id).ToList()))
                .RuleFor(p => p.CreatedDate, f => f.Date.Past(2))
                .RuleFor(p => p.LastUpdatedDate, f => f.Date.Recent())
                .RuleFor(p => p.IsDeleted, f => false);

            var outfitXPhotos = outfitXPhotoFaker.Generate(count);
            
            var commonUserEmail = context.Set<User>().FirstOrDefault()?.Email;

            // Set CreatedBy and UpdatedBy to the common email
            foreach (var outfitXPhoto in outfitXPhotos)
            {
                outfitXPhoto.CreatedBy = commonUserEmail;
                outfitXPhoto.LastUpdatedBy = commonUserEmail;
            }
            
            context.Set<OutfitXPhoto>().AddRange(outfitXPhotos);
            context.SaveChanges();
        }
    }




}