using System.Collections.Generic;
using NearHspt.Models;

namespace NearHspt.Data
{
    public static class Single02Data
    {
        public static IList<DB_01_Items> Single02_Equipment { get; private set; }

        static Single02Data()
        {
            Single02_Equipment = new List<DB_01_Items>();

            Single02_Equipment.Add(new DB_01_Items
            {
                Name = "African Bush Elephant",
                Location = "Africa",
                Details = "The African bush elephant, also known as the African savanna elephant, is the larger of the two species of African elephants, and the largest living terrestrial animal. These elephants were previously regarded as the same species, but the African forest elephant has been reclassified as L. cyclotis.",
                ImageUrl = "elephant.png"
            });

        }
    }
}


