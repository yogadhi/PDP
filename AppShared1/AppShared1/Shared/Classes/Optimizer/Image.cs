using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Shared.Classes.Optimizer
{
    public class Image
    {
        static Dictionary<string, ImageSource> cache = new Dictionary<string, ImageSource>();

        static public ImageSource FromFile(String filename)
        {
            try
            {
                ImageSource retVal = null;
                bool hit = cache.TryGetValue(filename, out retVal);

                if (!hit)
                {
                    retVal = ImageSource.FromFile(filename);
                    cache[filename] = retVal;
                }
                return retVal;

            }
            catch (Exception ex)
            {
                Shared.Services.Logs.Insights.Send("ImageFromFile", ex);
                return "";
            }

        }

        static public ImageSource FromUri(String filename)
        {
            try
            {
                if (filename != "")
                {
                    ImageSource retVal = null;
                    bool hit = cache.TryGetValue(filename, out retVal);

                    if (!hit)
                    {
                        retVal = new UriImageSource
                        {
                            CachingEnabled = true,
                            CacheValidity = new TimeSpan(30, 0, 0, 0),
                            Uri = new Uri(filename)
                        };
                        cache[filename] = retVal;
                    }
                    return retVal;
                }
                else
                {
                    return "";
                }

            }
            catch (Exception ex)
            {
                Shared.Services.Logs.Insights.Send("ImageFromUri", ex);
                return "";
            }
        }
    }
}
