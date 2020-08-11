using Min_Helpers.AttributeHelper;
using System.ComponentModel.DataAnnotations;

namespace Min_Helpers.EmailHelper
{
    /// <summary>
    /// IMessage
    /// </summary>
    public class IEmailConfig
    {
        /// <summary>
        /// Host
        /// </summary>
        [Required]
        public string ServerHost { get; set; }

        /// <summary>
        /// Port
        /// </summary>
        [Port]
        [Required]
        public int ServerPort { get; set; }

        /// <summary>
        /// Sender Name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Sender Id
        /// </summary>
        [EmailAddress]
        [Required]
        public string SenderEmail { get; set; }

        /// <summary>
        /// Sender Password
        /// </summary>
        [Required]
        public string SenderPassword { get; set; }
    }
}
