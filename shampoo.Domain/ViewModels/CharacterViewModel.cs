using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shampoo.Domain.ViewModels
{
    public class CharacterViewModel
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? surname { get; set; }
        public DateTime? birthday { get; set; }
        public string? gender { get; set; }
        public double? height { get; set; }
        public double? weigh { get; set; }
        public string? personality { get; set; }
        public string? ability { get; set; }
        public string? appearance { get; set; }
        public string? goals { get; set; }
        public string? motivation { get; set; }
        public string? worldview { get; set; }
        public DateTime? deathday { get; set; }

    }
}
