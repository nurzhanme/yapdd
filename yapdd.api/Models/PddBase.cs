using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace yapdd.api.Models
{
    public class PddBase
    {
        public string PddToken { get; set; }
        public string OAuthToken { get; set; }
        public string Domain { get; set; }
    }
}
