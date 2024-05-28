using Microsoft.AspNetCore.Http;

namespace Uni_FMI.Bookify.Core.Business.Utils
{
    internal class ConvertPhotoService : IConvertPhotoService
    {
        public async Task<byte[]> ConvertToByteArray(IFormFile file, CancellationToken cancellationToken)
        {
            byte[] content = [];

            if (file.Length <= 0) return content;

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream, cancellationToken);
            content = memoryStream.ToArray();

            return content;
        }
    }
}
