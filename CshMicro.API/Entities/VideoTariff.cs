using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CshMicro.API.Entities
{
    public class VideoTariff
    {
        public VideoTariff()
        {
            TempQt = 1;
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
        public string Image { get; set; }
        [Display(Name = "Resolution")]
        public int ResolutionId { get; set; }
        [ForeignKey("ResolutionId")]
        public virtual Resolution Resolution { get; set; }
        [Display(Name = "Period")]
        public int PeriodId { get; set; }
        [ForeignKey("PeriodId")]
        public virtual Period Period { get; set; }
        [NotMapped]
        [Range(1, 10000)]
        public int TempQt { get; set; }
    }
}
