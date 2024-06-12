using System;

namespace Backend.Models
{
    public class MovieStar
    {
		public DateTime DateOfBirth { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
		public string Sex { get; set; }

		public string Nationality { get; set; }


		//       {
		//	"dateOfBirth": "27-Oct-1995",
		//	"Name": "Adolf",
		//	"Surname": "Mayo",
		//	"Email": "amayo0@huffingtonpost.com",
		//	"Sex": "Male",
		//	"Nationality": "irish"
		//},
	}
}