using Microsoft.AspNetCore.Mvc.Rendering;

namespace BikeShop.Models.ViewModels
{
    public class BikeViewModel
    {
        public Model Model { get; set; }
        public IEnumerable<Make> Makes { get; set; }


    }
}
