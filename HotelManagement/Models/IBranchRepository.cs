using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagement.Models
{
    public interface IBranchRepository
    {
        Branch Add(Branch branch);
        Branch Update(Branch branchChanges);
        Branch Delete(int id);
        Branch GetBranch(int id);
        IEnumerable<Branch> GetAllBranches();
    }
}
