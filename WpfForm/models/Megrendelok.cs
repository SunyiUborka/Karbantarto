using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfForm.models
{
    class Megrendelok
    {
        public int megrendelo_id { get; set; }
        public string nev { get; set; }
        public string cim { get; set; }
        public int kedvezmeny { get; set; }
        public string telefon { get; set; }
    }
}
