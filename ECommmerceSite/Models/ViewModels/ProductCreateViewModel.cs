using System.Collections.Generic;

namespace ECommmerceSite.Models.ViewModels
{
    public class ProductCreateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }

    }
}
