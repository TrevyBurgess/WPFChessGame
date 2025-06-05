//
//
namespace TrevyBurgess.Games.TrevyChess.ChessGameUI
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public static class HelperMethods
    {
        /// <summary>
        /// Convert a Bitmat into an ImageSource
        /// </summary>
        public static ImageSource GetImageSource(Bitmap theImage)
        {
           // //Contract.Requires<ArgumentNullException>(theImage != null);

            MemoryStream ms = new MemoryStream();

            theImage.Save(ms, ImageFormat.Jpeg);

            BitmapImage bImg = new BitmapImage();

            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();

            return bImg;
        }

        /// <summary>
        /// Convert a Bitmat into an ImageSource
        /// </summary>
        public static ImageSource GetImageSource(Icon theImage)
        {
            //Contract.Requires<ArgumentNullException>(theImage != null);

            MemoryStream ms = new MemoryStream();

            theImage.Save(ms);

            BitmapImage bImg = new BitmapImage();

            bImg.BeginInit();
            bImg.StreamSource = new MemoryStream(ms.ToArray());
            bImg.EndInit();

            return bImg;
        }

        /// <summary>
        /// Convert a Bitmat into an ImageSource
        /// </summary>
        public static System.Windows.Controls.Image GetImage(Bitmap theImage, double size)
        {
           // //Contract.Requires<ArgumentNullException>(theImage != null);
          //  //Contract.Requires<ArgumentException>(size > 0);

            return new System.Windows.Controls.Image { Source = GetImageSource(theImage), Width = size, Height = size };
        }

        /// <summary>
        /// Convert a Bitmat into an ImageSource
        /// </summary>
        public static System.Windows.Controls.Image GetImage(Icon theImage, double size)
        {
           // //Contract.Requires<ArgumentNullException>(theImage != null);
           // //Contract.Requires<ArgumentException>(size > 0);

            return new System.Windows.Controls.Image { Source = GetImageSource(theImage), Width = size, Height = size };
        }
    }
}
