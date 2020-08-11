using Min_Helpers.AttributeHelper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Min_Helpers.EmailHelper
{
    /// <summary>
    /// IMessage
    /// </summary>
    public class IEmailMessage
    {
        /// <summary>
        /// title
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// content
        /// </summary>
        [Required]
        public string Content { get; set; }

        /// <summary>
        /// to list
        /// </summary>
        [CollectionRange(1, int.MaxValue)]
        [Required]
        public List<string> Tos { get; set; }

        /// <summary>
        /// cc list
        /// </summary>
        [CollectionRange(1, int.MaxValue)]
        public List<string> Ccs { get; set; }

        /// <summary>
        /// bcc list
        /// </summary>
        [CollectionRange(1, int.MaxValue)]
        public List<string> Bccs { get; set; }

        /// <summary>
        /// attachment list
        /// </summary>
        [CollectionRange(1, int.MaxValue)]
        public List<Attachment> Attachments { get; set; }
    }
}
