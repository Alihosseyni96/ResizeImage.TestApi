using Microsoft.Extensions.DependencyInjection;
using ResizeImage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImage.Dependancy
{
    public static class AddDependancy
    {
        public static void AddImageResizer(this IServiceCollection services)
        {
            services.AddScoped<ResizeImageService>();
        }
    }
}
