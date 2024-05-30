using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Uni_FMI.Bookify.Core.Business.Contracts;

namespace Uni.FMI.Bookify.API.Controllers
{
    [ApiController]
    [Route("api/ApartmentImage")]
    [EnableCors]
    public class ApartmentImageController(IApartmentImageService imageService) : ControllerBase
    {
        [HttpGet(nameof(GetApartmentImage))]
        public ActionResult GetApartmentImage(Guid imageId)
        {
            var imageResponse = imageService.GetById(imageId);

            return File(imageResponse.Content, imageResponse.Extension);
        }

        [HttpPost("UploadPhoto")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> UploadPhoto([FromForm] IFormFileCollection request, CancellationToken cancellationToken = default)
        {
            var files = HttpContext.Request.Form.Files;

            var uploadedPhotos = await imageService.Upload(files, cancellationToken);

            return Ok(uploadedPhotos);
        }

        [HttpDelete(nameof(Delete))]
        public ActionResult Delete(Guid id)
        {
            imageService.Delete(id);
return Ok();
        }
    }
}
