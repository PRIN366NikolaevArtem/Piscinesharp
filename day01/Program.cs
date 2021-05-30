using System;
using StructRate;
using StructSum;
using ExchangerSpace;

Main(args);





int Main(string[] args)
{
	if (args.Length != 2)
	{
		Exchanger.mistakeOut();
		return 1;
	}
	if (Exchanger.checker(args.Length, args[0], args[1]))
		return 1;
	string FileName = Exchanger.FileName(args[0]);
	string outCurrency = FileName;
	if (args[1][args.Length - 1] == '/')
		FileName = args[1] + FileName + ".txt";
	else
		FileName = args[1] + "/" + FileName + ".txt";
	ExchangeRate structRate = new ExchangeRate();
	structRate.parser(FileName, outCurrency);
	ExchangeSum structSum = new ExchangeSum();
	double.TryParse(args[0].Split(' ')[0], out double sum);
	structSum.compute(structRate, sum);
	Console.WriteLine($"Сумма в исходной валюте: {args[0]}\nСумма в {structSum.inCurrency1}: {structSum.Sum1.ToString("C2")} {structSum.inCurrency1}\nСумма в {structSum.inCurrency2}: {structSum.Sum2.ToString("C2")} {structSum.inCurrency2}");


	
	return 0;

}
