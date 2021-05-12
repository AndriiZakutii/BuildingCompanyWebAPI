using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class ProjectType : BaseIdentifiable
    {
        [Required]
        public string Name { get; set; }
    }
}
