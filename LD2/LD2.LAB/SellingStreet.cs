using System;

public class SellingStreet
{
	public SellingStreet()
	{
		public string Street { get; set; }
		public int StCount { get; set; }

		public SellingStreet(string street, int stCount)
		{
			Street = street;
			StCount = stCount;
		}
	}
}
