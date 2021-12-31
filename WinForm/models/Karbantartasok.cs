using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForm.models
{
    class Karbantartasok
    {
        public int karbantartas_id { get; set; }
        public int szerelo_id { get; set; }
        public int megrendelo_id { get; set; }
        public DateTime datum { get; set; }
        public int javido { get; set; }
    }
}
