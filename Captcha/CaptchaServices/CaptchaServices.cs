using Captcha.CaptchaDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Captcha.CaptchaServices
{
    public class CaptchaServices
    {
        private readonly CaptchaOptionsParams _params;

        public CaptchaServices(CaptchaOptionsParams captchaOptionsParams)
        {
            _params = captchaOptionsParams;
        }

        private AffineTransformBuilder getRotation()
        {
            Random random = new Random();
            var builder = new AffineTransformBuilder();
            var width = random.Next(10, _params.Width);
            var height = random.Next(10, _params.Height);
            var pointF = new PointF(width, height);
            var rotationDegrees = random.Next(0, _params.MaxRotationDegrees);
            var result = builder.PrependRotationDegrees(rotationDegrees, pointF);
            return result;
        }

    }
}
