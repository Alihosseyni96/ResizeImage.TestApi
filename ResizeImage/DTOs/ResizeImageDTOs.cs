using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.DTOs
{
    public class RatioDto
    {
        public int Height { get; set; }
        public int Weidth { get; set; }
        public Image Image { get; set; }
        public string? ContentType { get; set; }
    }

    public class DocumentResizeResultDto
    {
        public byte[]? DocAsBytes { get; set; } = null;
        public string? ContentType { get; set; } = null;
        public bool? IsSuccessful { get; set; } = true;
        public string? ErrorMessage { get; set; } = null;
    }

    public class ResizeImageOptionsDto
    {
        [Required(ErrorMessage ="فایل را ارسال کنید")]
        public IFormFile File  { get; set; }
        public int? MaxHeight { get; set; } = 150;
        public int? MaxWeidth { get; set; } = 150;

        //[MaxLength(100 , ErrorMessage ="محدوده این عدد  بین 1 تا 100 است ")]
        //[MinLength(1 , ErrorMessage = "محدوده این عدد  بین 1 تا 100 است ")]
        public int Quality { get; set; }
    }

}

