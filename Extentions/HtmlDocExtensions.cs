using Core.Interfaces;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Infrastructure.Extentions
{
    public static class HtmlDocExtensions
    {
        // Parse images that use Base64 string for src attribute, upload to remote storage and replace src with hosted image url
        public static async Task<IEnumerable<string>> ProcessBase64Images(this HtmlDocument doc, IRemoteFileStorageHandler remoteFileStorageHandler)
        {
            List<string> uploadedImgUrls = new();
            var imgTags = doc.DocumentNode.SelectNodes("//img");
            if (imgTags != null)
            {
                foreach (var img in imgTags)
                {
                    var src = img.Attributes["src"].Value;
                    // Upload image and set src to the image url
                    if (src.StartsWith("data:image"))
                    {
                        var stream = new MemoryStream(Convert.FromBase64String(src.Split(";base64,")[1]));
                        src = await remoteFileStorageHandler.UploadAsync(stream, "jpg");
                        img.Attributes["src"].Value = src;
                    }
                    uploadedImgUrls.Add(src);
                }
            }
            return uploadedImgUrls;
        }
    }
}
