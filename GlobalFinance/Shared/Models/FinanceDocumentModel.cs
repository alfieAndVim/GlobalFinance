using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalFinance.Shared.Models
{
	public class FinanceDocumentModel
	{
		[Key]
		public int FileId { get; set; }
		public string FileName { get; set; } = string.Empty;
		public string? StoredFileName { get; set; } = string.Empty;
		public byte[]? FileContent { get; set; }
		public string ContentType { get; set; } = string.Empty;
		public int FinanceId { get; set; }

		public FinanceModel? Finance { get; set; }

	}
}

