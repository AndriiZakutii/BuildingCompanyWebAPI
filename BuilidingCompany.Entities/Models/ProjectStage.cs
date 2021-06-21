using System.ComponentModel.DataAnnotations;

namespace BuildingCompanyModel
{
    public class ProjectStage : BaseIdentifiable
    {
        [Required]
        public string Name { get; set; }
    }
}
