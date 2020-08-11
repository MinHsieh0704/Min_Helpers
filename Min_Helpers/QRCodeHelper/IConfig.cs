using System.ComponentModel.DataAnnotations;
using ZXing.QrCode.Internal;

namespace Min_Helpers.QRCodeHelper
{
    /// <summary>
    /// QRCode
    /// </summary>
    public class IQRCodeConfig
    {
        /// <summary>
        /// Size
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Size { get; set; } = 250;

        /// <summary>
        /// Margin
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Margin { get; set; } = 1;

        /// <summary>
        /// Level
        /// </summary>
        public ErrorCorrectionLevel Level { get; set; } = ErrorCorrectionLevel.M;
    }
}
