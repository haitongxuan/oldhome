using OldHome.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.BLL
{
    public class MedicationScheduleBLL
    {
        private readonly AppDataContext _context;

        public MedicationScheduleBLL(AppDataContext context)
        {
            _context = context;
        }


    }
}
