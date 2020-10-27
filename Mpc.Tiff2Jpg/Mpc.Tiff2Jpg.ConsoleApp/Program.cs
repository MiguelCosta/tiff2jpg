using System;
using ImageMagick;

namespace Mpc.Tiff2Jpg.ConsoleApp
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello tiff2jpg with Migick.NET");

            using (var image = new MagickImage(@"TiffFiles\File1.tif"))
            {
                // jpg
                // https://github.com/dlemstra/Magick.NET/blob/master/docs/ConvertImage.md
                image.Format = MagickFormat.Jpeg;
                image.Write(@"Output-File1.jpg");

                // jpg, 72dpi
                // https://github.com/dlemstra/Magick.NET/issues/462
                image.Density = new Density(72, DensityUnit.PixelsPerInch);
                image.Write(@"Output-File2.jpg");

                // jpg, 72dpi, 1000px
                // https://github.com/dlemstra/Magick.NET/blob/master/docs/ResizeImage.md
                image.Resize(1000, 0);
                image.Write(@"Output-File3.jpg");
            }

            Console.WriteLine("END");

            Console.ReadLine();
        }
    }
}
