using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiVoto.EmojiSvc.Api.Queries
{
    public class EmojiDto
    {
        public string Unicode { get; set; } = null!;
        public string Shortcode { get; set; } = null!;
    }
}
