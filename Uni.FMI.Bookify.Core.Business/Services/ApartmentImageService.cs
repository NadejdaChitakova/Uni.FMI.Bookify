using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Uni.FMI.Bookify.Core.Models.Models.Response;
using Uni.FMI.Bookify.Insrastructure.Models.DbEntities;
using Uni_FMI.Bookify.Core.Business.Contracts;
using Uni_FMI.Bookify.Core.Business.Utils;

namespace Uni_FMI.Bookify.Core.Business.Services
{
    public sealed class ApartmentImageService(DbContext dbContext,
        IMapper mapper,
        IConvertPhotoService convertPhotoService) : IApartmentImageService
    {
        public ApartmentImageResponse? GetById(Guid imageId)
        {
            var query = dbContext.Set<ApartmentImage>()
                .Where(x => x.Id == imageId);

            return mapper.ProjectTo<ApartmentImageResponse>(query)
                .FirstOrDefault();
        }

        public async Task<List<Guid>> Upload(IFormFileCollection files, CancellationToken cancellationToken)
        {
            List<ApartmentImage> images = new();

            foreach (var file in files) { 

                byte[] content = await convertPhotoService.ConvertToByteArray(file, cancellationToken);
                
                images.Add(new ApartmentImage()
                {
                    Id = new Guid(),
                    Extension = file.ContentType,
                    Content = content
                });
            }

await dbContext.Set<ApartmentImage>()
    .AddRangeAsync(images, cancellationToken);

await dbContext.SaveChangesAsync(cancellationToken);

        return images.Select(x=> x.Id).ToList();
        }

        public void Delete(Guid id)
        {
            var image = dbContext.Set<ApartmentImage>()
                .FirstOrDefault(x => x.Id == id);

            if (image != null)
            {
                dbContext.Set<ApartmentImage>()
                    .Remove(image);
            }
        }
    }
    }

