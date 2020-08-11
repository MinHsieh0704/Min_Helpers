using System.ComponentModel.DataAnnotations;

namespace Min_Helpers.VerificationCodeHelper
{
    /// <summary>
    /// VerificationCode
    /// </summary>
    public class IVerificationCodeConfig
    {
        /// <summary>
        /// Height
        /// </summary>
        [Range(0, int.MaxValue)]
        public int Height { get; set; } = 40;

        /// <summary>
        /// Font Count
        /// </summary>
        [Range(0, int.MaxValue)]
        public int FontCount { get; set; } = 5;

        /// <summary>
        /// Font Spacing
        /// </summary>
        [Range(0, int.MaxValue)]
        public int FontSpacing { get; set; } = 20;

        /// <summary>
        /// Font Size
        /// </summary>
        [Range(0, int.MaxValue)]
        public int FontSize { get; set; } = 20;
    }
}
