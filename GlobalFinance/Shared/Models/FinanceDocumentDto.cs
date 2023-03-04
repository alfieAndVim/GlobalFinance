using System;
namespace GlobalFinance.Shared.Models
{
	public class FinanceDocumentDto
	{
		public string FileName { get; set; } = string.Empty;
		public string Base64FileContent { get; set; } = string.Empty;
		public string ContentType { get; set; } = string.Empty;
		public int FinanceId { get; set; }
	}
}

