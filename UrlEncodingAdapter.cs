using System.Net;
namespace Adapter
{
    class UrlEncodingAdapter : IEncodingAdapter
    {
        ApiUrlEndpointSimulator endpoint;
        public UrlEncodingAdapter()
        {
            endpoint = new();
        }

        public string EncodeAndUse(string input)
        {
            string encoded = WebUtility
                .UrlEncode(input)
                .Replace("%3A", ":")
                .Replace("%2F", "/")
                .Replace("%3F", "?")
                .Replace("%3D", "=");
            MakeApiCall(encoded);
            return encoded;
        }

        public void MakeApiCall(string input)
        {
            endpoint.MakeCall(input);
        }
    }
}