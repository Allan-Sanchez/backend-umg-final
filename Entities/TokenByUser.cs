using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class TokenByUser
    {
        public int TokenByUserId { get; set; }
        public int UserId { get; set; }
        [StringLength(-1)]
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }

        public User User { get; set; }
    }
}
