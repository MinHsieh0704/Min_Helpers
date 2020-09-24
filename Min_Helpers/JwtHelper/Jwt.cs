using Jose;
using System;
using System.Net;
using System.Text;

namespace Min_Helpers.JwtHelper
{
    public class Jwt
    {
        public static string Key { get; private set; } = "Pv0bRHSydU8nxVQNnlQf@2fT$wgpk%LBVX36RsSf5F6gHPc1%9";

        public static TimeSpan Expiration { get; private set; } = new TimeSpan(0, 30, 0);

        private JwsAlgorithm alg { get; } = JwsAlgorithm.HS256;

        public void Initialize(TimeSpan expiration)
        {
            try
            {
                Expiration = expiration;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Initialize(string key)
        {
            try
            {
                Key = key;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Initialize(string key, TimeSpan expiration)
        {
            try
            {
                Key = key;
                Expiration = expiration;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Encode<T>(T payload) where T : IPayload
        {
            try
            {
                byte[] keys = Encoding.UTF8.GetBytes(Key);

                payload.iat = DateTime.Now.Ticks;
                payload.exp = payload.iat + Expiration.Ticks;

                return JWT.Encode(payload, keys, this.alg);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private T Decode<T>(string token) where T : IPayload
        {
            try
            {
                byte[] keys = Encoding.UTF8.GetBytes(Key);

                T payload = JWT.Decode<T>(token, keys, this.alg);

                return payload;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Check<T>(string token) where T : IPayload
        {
            try
            {
                if (string.IsNullOrEmpty(token))
                {
                    Exception ex = new Exception(Convert.ToInt32(HttpStatusCode.BadRequest).ToString());
                    throw ex;
                }

                T payload = Decode<T>(token);

                if (DateTime.Now.Ticks > payload.exp)
                {
                    Exception ex = new Exception(Convert.ToInt32(HttpStatusCode.RequestTimeout).ToString());
                    throw ex;
                }

                return payload;
            }
            catch (IntegrityException)
            {
                Exception ex = new Exception(Convert.ToInt32(HttpStatusCode.Unauthorized).ToString());
                throw ex;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
