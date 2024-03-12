using System.ComponentModel.DataAnnotations;

namespace QuarterlySales.Models
{
	public class PastEarliestHireDateAttribute : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			if (value is DateTime date)
			{
				return date >= new DateTime(1995, 1, 1);
			}
			return false;
		}
	}
}
