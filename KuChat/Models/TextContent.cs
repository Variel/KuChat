using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KuChat.Models
{
    public class TextContent : Content
    {
        public string Text { get; set; }
        public override ContentType Type => ContentType.Text;
        public override string GetPreview() => Text;

        public TextContent() { }
        public TextContent(string text)
        {
            this.Text = text;
        }
    }
}