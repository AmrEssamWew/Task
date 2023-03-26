using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class Product
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Title { get; set; }
		[Required]
		public string Category { get; set; }
		[Required]
		public decimal Price { get; set; }
		[Required, DisplayName("Price for 50 to 99")]
		public decimal Price50 { get; set; }
		[Required, DisplayName("Price for 100 and above")]
		public decimal Price100 { get; set; }

		
	}
}
