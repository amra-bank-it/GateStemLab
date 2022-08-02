using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterFaceEkassir.Basic.Provider.Models
{
    internal class RespPay
    {
        public bool Success { get; set; }

        public int idRecepient { get; set; }
        
        public int income { get; set; }

        public string note { get; set; }

        public bool isConfirmed { get; set; }

    }
}
