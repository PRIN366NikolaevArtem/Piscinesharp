using StructRate;
namespace StructSum
{
	struct ExchangeSum
	{
		public string inCurrency1;
		public string inCurrency2;
		public double Sum1;
		public double Sum2;

		public void compute(ExchangeRate exchangeRate, double sum)
		{
			this.inCurrency1 = exchangeRate.inCurrency1;
			this.inCurrency2 = exchangeRate.inCurrency2;
			this.Sum1 = sum * exchangeRate.rate1;
			this.Sum2 = sum * exchangeRate.rate2;
		}
	}
}