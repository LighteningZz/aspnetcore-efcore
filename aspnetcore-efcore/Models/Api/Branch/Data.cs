using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_efcore.Models.Database;

namespace aspnetcore_efcore.Models.Api.Branch
{
    public partial class Data
    {
        public object List(Field.Filter param, int skip = 0, int take = 0, string sortby = "BRANCH_CODE ASC")
        {
            using (var db = new Db())
            {
                var data = (from b in db.MBranchs.AsQueryable()
                            join c in db.MCorps.AsQueryable() on b.CorpId equals c.CorpId
                            select new
                            {
                                c.CorpId,
                                c.CorpCode,
                                b.BranchId,
                                b.BranchCode,
                                b.BranchName
                            });
                if (!string.IsNullOrEmpty(param.SEARCH))
                {
                    data = data
                        .Where(c => c.CorpCode.Contains(param.SEARCH) ||
                                    c.BranchCode.Contains(param.SEARCH) ||
                                    c.BranchName.Contains(param.SEARCH)
                        );
                }
                if (!string.IsNullOrEmpty(param.CORP_ID))
                {
                    data = data.Where(c => c.CorpId == param.CORP_ID);
                }
                if (!string.IsNullOrEmpty(sortby))
                {
                    string[] sortArray = sortby.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    if (sortArray[1] == "ASC")
                    {
                        switch (sortArray[0])
                        {
                            case "BRANCH_NAME":
                                data = data.OrderBy(c => c.BranchCode);
                                break;
                            default:
                                data = data.OrderBy(c => c.BranchName);
                                break;
                        }
                    }
                    else
                    {
                        switch (sortArray[0])
                        {
                            case "BRANCH_NAME":
                                data = data.OrderByDescending(c => c.BranchCode);
                                break;
                            default:
                                data = data.OrderByDescending(c => c.BranchName);
                                break;
                        }
                    }
                }
                if (take > 0)
                {
                    data = data.Skip(skip).Take(take);
                }
                var Res = data.ToList().Select((e, i) => new
                {
                    RECORD = skip + i + 1,
                    e.BranchId,
                    e.CorpId,
                    e.CorpCode,
                    e.BranchCode,
                    e.BranchName
                }).ToList();

                return Res;
            }
        }

    }
}
