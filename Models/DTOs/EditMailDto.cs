using kasthack.yandex.pdd.Entities;

namespace yapdd.Models.DTOs
{
    public class EditMailDto
    {
        public PddBase pddBase { get; set; }

        public EmailAccountBase emailAccountBase { get; set; }
    }
}
