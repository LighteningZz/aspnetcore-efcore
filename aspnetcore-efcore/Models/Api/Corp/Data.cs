using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_efcore.Models.Database;

namespace aspnetcore_efcore.Models.Api.Corp
{
    public partial class Data
    {
        public object Get(string CORP_ID)
        {
            using (var db = new Db())
            {
                var data = (from c in db.MCorps
                            where c.CorpId == CORP_ID
                            select new
                            {
                                ID = c.CorpId,
                                CODE = c.CorpCode,
                                NAME = c.CorpName
                            }).FirstOrDefault();

                return data;
            }
        }

        //  string param.SEARCH
        public object List(Field.Filter param, int skip = 0, int take = 0, string sortby = "CORP_CODE ASC")
        {
            using (var db = new Db())
            {
                var data = (from c in db.MCorps.AsQueryable()
                            select c);
                if (!string.IsNullOrEmpty(sortby))
                {
                    string[] sortArray = sortby.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
                    if (sortArray[1] == "ASC")
                    {
                        switch (sortArray[0])
                        {
                            case "CORP_NAME":
                                data = data.OrderBy(c => c.CorpName);
                                break;
                            default:
                                data = data.OrderBy(c => c.CorpCode);
                                break;
                        }
                    }
                    else
                    {
                        switch (sortArray[0])
                        {
                            case "CORP_NAME":
                                data = data.OrderByDescending(c => c.CorpName);
                                break;
                            default:
                                data = data.OrderByDescending(c => c.CorpCode);
                                break;
                        }
                    }
                }
                if (take > 0)
                {
                    data = data.Skip(skip).Take(take);
                }
                var Res = data.Select((e, i) => new
                {
                    RECORD = skip + i + 1,
                    e.CorpId,
                    e.CorpCode,
                    e.CorpName,
                }).ToList();

                return Res;
            }
        }

        public object Add(Field.Corp param)
        {
            using (var db = new Db())
            {
                MCorps corp = new MCorps()
                {
                    CorpId = Guid.NewGuid().ToString(),
                    CorpCode = param.CORP_CODE,
                    CorpName = param.CORP_NAME,
                    DeleteStatus = 0,
                    CreateBy = "Dev",
                    CreateDate = DateTime.Now,
                    UpdateBy = "Dev",
                    UpdateDate = DateTime.Now,
                    Revision = 0
                };
                db.MCorps.Add(corp);
                db.SaveChanges();
                return new { corp };
            }
        }

        public object Update(Field.Corp param)
        {
            using (var db = new Db())
            {
                var corp = db.MCorps.Find(param.CORP_ID);
                corp.CorpCode = param.CORP_CODE;
                corp.CorpName = param.CORP_NAME;
                corp.UpdateBy = "Dev";
                corp.UpdateDate = DateTime.Now;
                db.SaveChanges();
                return new { corp };
            }
        }
    }
}
