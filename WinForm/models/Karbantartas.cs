using System;

namespace WinForm.models
{
    public class Karbantartas
    {
        public int karbantartas_id { get; set; } 
        public int szerelo_id { get; set; }
        public int megrendelo_id { get; set; } 
        public DateTime datum { get; set; }
        public int javido { get; set; }
    }
}