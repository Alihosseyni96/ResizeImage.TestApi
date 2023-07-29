using Microsoft.AspNetCore.Http;
using ResizeImage.DTOs;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Services
{
    public class ResizeImageService
    {

        public  async Task<DocumentResizeResultDto> ResizeImage(ResizeImageOptionsDto req)
        {
            try
            {
                var ration = ResizeRation(req);
                var options = new ResizeOptions()
                {
                    Size = new Size(width: ration.Weidth, height: ration.Height),
                    Sampler = KnownResamplers.Lanczos3,
                    Compand = true,
                    Mode = ResizeMode.Stretch,

                };
                ration.Image.Mutate(x => x.Resize(options));

                var encoder = new JpegEncoder()
                {
                    Quality = req.Quality

                };

                byte[] imageAsByteArray;

                using (var ms = new MemoryStream())
                {

                    ration.Image.Save(ms, encoder);
                    ms.Position = 0;
                    imageAsByteArray = ms.ToArray();
                }
                return new DocumentResizeResultDto() { ContentType = req.ContentType, DocAsBytes = imageAsByteArray };

            }
            catch (Exception )
            {
                return new DocumentResizeResultDto()
                {
                    ContentType = null,
                    DocAsBytes = null,
                    IsSuccessful = false,
                    ErrorMessage = "فایل ارسال شده عکس نمی باشد"
                };
            }

        }




        private RatioDto ResizeRation(ResizeImageOptionsDto options)
        {
            RatioDto ration;

            var img = Image.Load(options.FileAsStream);


            if (img.Width > options.MaxWeidth || img.Height > options.MaxHeight)
            {
                double widthRation = (double)img.Width / (double)options.MaxHeight;
                double heightRation = (double)img.Height / (double)options.MaxWeidth;

                //double ratio = Math.Max(widthRation, heightRation);
                int newWidth = (int)(img.Width / widthRation);
                int newHeight = (int)(img.Height / heightRation);
                ration = new RatioDto() { Height = newHeight, Weidth = newWidth, Image = img  , ContentType = options.ContentType};
            }
            else
            {
                ration = new RatioDto() { Height = img.Height, Weidth = img.Width, Image = img, ContentType = options.ContentType };
            }

            return ration;
        }

    }


}
