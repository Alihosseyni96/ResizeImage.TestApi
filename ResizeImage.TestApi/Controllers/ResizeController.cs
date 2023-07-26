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
        public async Task<FileContentResult> ResizeImage([FromForm]ResizeImageOptionsDto req)
        {
            var res = await _resizeImageService.ResizeImage(req);
            //var res = await _resizeImageService.ResizeImage(new ResizeImageOptionsDto()
            //{
            //    File = req,
            //    MaxHeight = 100,
            //    MaxWeidth = 100,
            //    Quality = 50
            //});
            return File(res.DocAsBytes, res.ContentType, false);
        }


    }
}
