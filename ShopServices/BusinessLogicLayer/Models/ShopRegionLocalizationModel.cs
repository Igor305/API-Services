using System;

namespace BusinessLogicLayer.Models
{
    public class ShopRegionLocalizationModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Name { get; set; }
        public int ShopRegionId { get; set; }
        public string CreatedByUserId { get; set; }
        public int LanguageId { get; set; }
        public string LastUpdateByUserId { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
