using System;

namespace Adapter
{
    class Client
    {
        static void Main(string[] args)
        {
            IEncodingAdapter adapter = new UrlEncodingAdapter();
            adapter.EncodeAndUse("http://example.com/search?q=وصفة شوربة العدس");
        }
    }
}
