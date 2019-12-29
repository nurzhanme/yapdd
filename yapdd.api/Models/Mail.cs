using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kasthack.yandex.pdd.Entities;

namespace yapdd.api.Models
{
    public class Mail : PddBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
