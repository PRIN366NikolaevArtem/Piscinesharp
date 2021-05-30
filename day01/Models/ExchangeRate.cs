namespace StructRate
{
	struct ExchangeRate
	{
		public string inCurrency1;
		public double rate1;
		public string outCurrency;
		public string inCurrency2;
		public double rate2;

		public void parser(string File, string outCurrency)
		{
			this.outCurrency = outCurrency;
			string [] text = System.IO.File.ReadAllLines(File);
			string [] firstLine = text[0].Split(':');
			string [] secondLine = text[1].Split(':');
			inCurrency1 = firstLine[0];
			inCurrency2 = secondLine[0];
			System.Globalization.NumberStyles style = System.Globalization.NumberStyles.Float;
			System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CreateSpecificCulture("ru");
			double.TryParse(firstLine[1], style, culture, out rate1);
			double.TryParse(secondLine[1], style, culture, out rate2);
		}
	
		
		


	}
}