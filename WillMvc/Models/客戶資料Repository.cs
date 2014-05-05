using System;
using System.Linq;
using System.Collections.Generic;

namespace WillMvc.Models
{
    public class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
    {
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(i => i.是否刪除 == false);
        }

        public IQueryable <客戶資料> CustomersFromTaipei()
        {
            return All().Where(i => i.電話.StartsWith("02"));
        }

        public 客戶資料 Find(int id)
        {
            return base.All().SingleOrDefault(i => i.Id == id);
        }

        public void Delete(客戶資料 entity)
        {
            entity.是否刪除 = true;
        }
    }

    public interface I客戶資料Repository : IRepository<客戶資料>
    {

    }
}