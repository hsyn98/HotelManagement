using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public class SQLBranchRepository : IBranchRepository
    {
        private readonly AppDbContext context;

        public SQLBranchRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Branch Add(Branch loc)
        {
            context.Branches.Add(loc);
            context.SaveChanges();
            return loc;
        }

        public Branch Delete(int id)
        {
            Branch branch = context.Branches.Find(id);
            if (branch != null)
            {
                context.Branches.Remove(branch);
                context.SaveChanges();
            }
            return branch;
        }

        public IEnumerable<Branch> GetAllBranches()
        {
            return context.Branches;
        }

        public Branch GetBranch(int id)
        {
            return context.Branches.Find(id);
        }

        public Branch Update(Branch locChanges)
        {
            var branch = context.Branches.Attach(locChanges);
            branch.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return locChanges;
        }
    }
}
