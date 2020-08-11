namespace Min_Helpers
{
    /// <summary>
    /// Status Helper
    /// </summary>
    public class StatusHelper
    {
        /// <summary>
        /// HttpStatus
        /// </summary>
        public enum EHttpStatus : int
        {
            /// <summary>
            /// BadRequest
            /// </summary>
            BadRequest = 400,

            /// <summary>
            /// Unauthorized
            /// </summary>
            Unauthorized = 401,

            /// <summary>
            /// Timeout
            /// </summary>
            Timeout = 408
        }
    }
}
