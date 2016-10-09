using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KuChat.Models;
using KuChat.Models.Transfer;

namespace KuChat.Extensions
{
    public static class ContentTransferExtensions
    {
        public static ContentTransfer ToTransfer(this Content content)
        {
            switch (content.Type)
            {
                case ContentType.Text:
                    return ToTransfer(content as TextContent);
            }
            return null;
        }
        public static TextContentTransfer ToTransfer(this TextContent content) => new TextContentTransfer(content);
    }
}