using Min_Helpers.AttributeHelper;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;

namespace Min_Helpers.QRCodeHelper
{
    /// <summary>
    /// QRCode
    /// </summary>
    public class QRCode
    {
        /// <summary>
        /// Config
        /// </summary>
        public IQRCodeConfig Config { get; private set; }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="config"></param>
        public void Initialization(IQRCodeConfig config)
        {
            try
            {
                Validate.TryValidateObject(config);

                this.Config = config;
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"qrcode helper: {ex.Message}", ex);

                throw exception;
            }
        }

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string Encode(string content)
        {
            try
            {
                if (string.IsNullOrEmpty(content))
                {
                    Exception ex = new Exception("content can not null or empty");
                    throw ex;
                }

                BarcodeWriterPixelData barcodeWriterPixelData = new BarcodeWriterPixelData
                {
                    Format = BarcodeFormat.QR_CODE,
                    Options = new QrCodeEncodingOptions
                    {
                        Width = this.Config.Size,
                        Height = this.Config.Size,
                        Margin = this.Config.Margin,
                        ErrorCorrection = this.Config.Level,
                        CharacterSet = "UTF-8",
                    }
                };

                PixelData pixelData = barcodeWriterPixelData.Write(content);

                using (Bitmap bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb))
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, pixelData.Width, pixelData.Height), ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

                        try
                        {
                            Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                        }
                        finally
                        {
                            bitmap.UnlockBits(bitmapData);
                        }

                        bitmap.Save(memoryStream, ImageFormat.Png);

                        byte[] byteImage = memoryStream.ToArray();

                        return Convert.ToBase64String(byteImage);
                    }
                }
            }
            catch (Exception ex)
            {
                Exception exception = new Exception($"qrcode helper: {ex.Message}", ex);

                throw exception;
            }
        }
    }
}
