using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GlobalFinance.Shared.Models
{
	public class SavedConfigurationModel
	{
		[Required, Key]
		public int SavedConfigurationId { get; set; }
		[Required]
		public int ConfigurationPrice { get; set; }
		[Required, ForeignKey("Customisation")]
		public int CustomisationId { get; set; }

		public CustomisationModel? Customisation { get; set; }


	}
}

