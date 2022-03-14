using PhoneShop.DAL;
using PhoneShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneShop.Models.Home
{
    public class HomeContactViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IEnumerable<Tbl_Category> ListOfCategories { get; set; }
        public HomeContactViewModel CreateModel()
        {
            return new HomeContactViewModel()
            {
                ListOfCategories = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecord()
            };
        }
    }
}