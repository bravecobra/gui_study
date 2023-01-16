using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmojiVotoWPF.Dashboard.Model
{
    internal class Result
    {
        public string Shortcode { get; init; } = null!;
        public string Unicode { get; init; } = null!;
        public int Votes { get; init; }
    }
}
