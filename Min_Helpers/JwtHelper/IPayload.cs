namespace Min_Helpers.JwtHelper
{
    public interface IPayload
    {
        /// <summary>
        /// Issuer
        /// </summary>
        string iss { get; set; }

        /// <summary>
        /// Subject
        /// </summary>
        string sub { get; set; }

        /// <summary>
        /// Audience
        /// </summary>
        string aud { get; set; }

        /// <summary>
        /// Issued At
        /// </summary>
        long iat { get; set; }

        /// <summary>
        /// Expiration Time
        /// </summary>
        long exp { get; set; }
    }
}
