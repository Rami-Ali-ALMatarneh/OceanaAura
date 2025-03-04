using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanaAura.Domain.Entities
{
    public class Resources
    {
        [Key] 
        public string Key { get; set; }

        public string ValueAr { get; set; }

        public string ValueEn { get; set; }
    }
}
