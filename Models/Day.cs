using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adutova_TKR2.Models
{
    public class Day
    {
        public long Id { get; set; }
        public List<TodoItem> tasks { get; set; }
    }
}
