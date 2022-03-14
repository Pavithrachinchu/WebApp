using PhoneShop.DAL;
using PhoneShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneShop.Models.Home
{
    public class HomeAboutViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public IEnumerable<Tbl_Product> ListOfProducts { get; set; }
        public HomeAboutViewModel CreateModel()
        {
            return new HomeAboutViewModel()
            {
                ListOfProducts = _unitOfWork.GetRepositoryInstance<Tbl_Product>().GetAllRecord()
            };
        }
    }
}