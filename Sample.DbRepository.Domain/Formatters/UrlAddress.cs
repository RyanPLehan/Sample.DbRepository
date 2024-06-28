using System;
using System.Collections.Specialized;
using System.Web;


namespace Sample.DbRepository.Domain.Formatters
{
    public static class UrlAddress
    {
        public static string CreateEndpoint(string baseUri, string relativeUri)
        {
            const char FORWARD_SLASH = '/';

            // Strip trailing / from base uri
            if (!String.IsNullOrWhiteSpace(baseUri) &&
                baseUri.EndsWith(FORWARD_SLASH))
                baseUri = baseUri.Substring(0, baseUri.Length - 1);

            // Strip leading / from relative uri
            if (!String.IsNullOrWhiteSpace(relativeUri) &&
                relativeUri.StartsWith(FORWARD_SLASH))
                relativeUri = relativeUri.Substring(1, relativeUri.Length - 1);

            // Create uri
            return String.Format("{0}{1}{2}", baseUri, FORWARD_SLASH, relativeUri);
        }

        public static string BuildQueryString(NameValueCollection nvc)
        {
            IList<string> paramList = new List<string>();

            foreach (var key in nvc.AllKeys)
            {
                IEnumerable<string> values = nvc.GetValues(key) ?? Enumerable.Empty<string>();
                foreach (var value in values)
                {
                    if (!String.IsNullOrWhiteSpace(value))
                        paramList.Add(String.Format("{0}={1}",
                                                    HttpUtility.UrlEncode(key),
                                                    HttpUtility.UrlEncode(value)));
                }
            }

            return paramList.Any() ? ("?" + String.Join("&", paramList.ToArray())) : String.Empty;
        }
    }
}
