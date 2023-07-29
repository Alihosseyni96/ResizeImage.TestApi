using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResizeImage.DTOs;
using ResizeImage.Services;

namespace ResizeImage.TestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ResizeController : ControllerBase
    {
        private readonly ResizeImageService _resizeImageService;

        public ResizeController(ResizeImageService resizeImageService)
        {
            _resizeImageService = resizeImageService;
        }

        [HttpPost]
        public async Task<FileContentResult> ResizeImage(IFormFile filefile)
        {
            var s = filefile.OpenReadStream();

            var res = await _resizeImageService.ResizeImage(new ResizeSteamImageDto()
            {
                FileAsStream = s,
                MaxHeight = 100,
                MaxWeidth = 100,
                Quality = 50,
                ContentType = filefile.ContentType
            });

            s.Dispose();
            return File(res.DocAsBytes, res.ContentType, false);
        }

        [HttpPost]
        public async Task<FileContentResult> ResizeImageFormFile(IFormFile file)
        {
            var res = await _resizeImageService.ResizeImage(new ResizeFormFileImageDto()
            {
                File = file,
                MaxHeight = 50,
                MaxWeidth = 50,
                Quality = 45
            });
            return File(res.DocAsBytes, res.ContentType, false);
        }

        [HttpPost]
        public async Task<FileContentResult> ResizeImageByteArray(IFormFile file)
        {
            var s = new MemoryStream();
            file.CopyTo(s);
            var byteArray = s.ToArray();
            s.Dispose();
            var res = await _resizeImageService.ResizeImage(new ResizeByteArrayImageDto()
            {
                ContentType = file.ContentType,
                File = byteArray,
                MaxHeight = 50,
                MaxWeidth = 50,
                Quality = 35
            });
            return File(res.DocAsBytes, res?.ContentType, false);
        }


    }
}
