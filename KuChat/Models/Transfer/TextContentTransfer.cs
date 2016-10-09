using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KuChat.Models.Transfer
{
    public class TextContentTransfer : ContentTransfer
    {
        public string Text { get; }

        public TextContentTransfer(TextContent content) : base(content)
        {
            this.Text = content.Text;
        }
    }
}