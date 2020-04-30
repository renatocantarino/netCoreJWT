using System.Text;

namespace shopWeb
{
    public static class Settings
    {
        private static string secret = "407c1d1c720dfec6deb43318a1de9d68";

        public static byte[] getKey()
        {
            return Encoding.ASCII.GetBytes(secret);
        }
    }
}