using Microsoft.AspNetCore.Http;

namespace Uni_FMI.Bookify.Core.Business.Utils;

public interface IConvertPhotoService
{
    Task<byte[]> ConvertToByteArray(IFormFile file, CancellationToken cancellationToken);
}