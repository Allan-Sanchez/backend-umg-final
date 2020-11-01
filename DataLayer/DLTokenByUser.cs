using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLTokenByUser
    {
        private UMGDBContext _context;

        public DLTokenByUser(UMGDBContext Context)
        {
            _context = Context;
        }

        public TokenByUser AddTokenByUser(TokenByUser newToken)
        {
            _context.tokenByUser.Add(newToken);
            _context.SaveChanges();
            return newToken; 
        }

    }
}
