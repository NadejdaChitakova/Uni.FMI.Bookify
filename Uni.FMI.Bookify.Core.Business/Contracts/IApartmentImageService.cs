using Microsoft.AspNetCore.Http;
using Uni.FMI.Bookify.Core.Models.Models.Response;

namespace Uni_FMI.Bookify.Core.Business.Contracts;

public interface IApartmentImageService
{
    ApartmentImageResponse? GetById(Guid imageId);

    Task<List<Guid>> Upload(IFormFileCollection files, CancellationToken cancellationToken);

    void Delete(Guid id);
}