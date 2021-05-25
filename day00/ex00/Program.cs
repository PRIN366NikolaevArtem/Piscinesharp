using System;
Main(args);

        int Main(string[] args)
        {
			if (args.Length != 5)
			{
    			System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return (1);

			}
			double sum;
			double rate;
			int term;
			int selectedMonth;
			double payment;
			bool test;

			test = double.TryParse(args [0], out sum);
			if (test == false)
			{
				System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return (1);
			}

			test = double.TryParse(args [1], out rate);
			if (test == false)
			{
				System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return (1);
			}

			test = int.TryParse(args [2], out term);
			if (test == false)
			{
				System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return (1);
			}

			test = int.TryParse(args [3], out selectedMonth);
			if (test == false)
			{
				System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return (1);
			}

			test = double.TryParse(args [4], out payment);
			if (test == false)
			{
				System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
				return (1);
			}

			double mounthrate = rate / 12 / 100;
			int daysInYear = (new System.DateTime(2022, 1, 1) - new System.DateTime(2021, 1 ,1 )).Days;
			int Mounth = 4;
			int StartMounth = 5;
			int countMounth;
			int year = 2021;
			int yearlow = 2021;
			double pay;
			double newsum = sum;
			System.TimeSpan subtractdates;
			double procent;
			double res = 0;
			countMounth = 0;

		
			while (newsum >= 0)
			{
				if (Mounth + 1 - StartMounth == selectedMonth)
					newsum = newsum - payment;
				if (Mounth + 1 - StartMounth >= selectedMonth)
					pay = (newsum * mounthrate * System.Math.Pow((1 + mounthrate), term - countMounth)) / (System.Math.Pow(1 + mounthrate, term - countMounth) - 1);
				else
					pay = (newsum * mounthrate * System.Math.Pow((1 + mounthrate), term - countMounth)) / (System.Math.Pow(1 + mounthrate, term - countMounth) - 1);
				countMounth++;
				if (Mounth % 11 == 0)
					year += 1;
				subtractdates = new System.DateTime(year, (((Mounth + 1) % 12) + 1), 1) - new System.DateTime(yearlow, (Mounth % 12) + 1, 1);
				Mounth += 1;
				if (Mounth > 12)
				Mounth = 1;
				if (year != yearlow)
					yearlow += 1; 
				procent = newsum * rate * subtractdates.Days / (daysInYear * 100);
				res = res + procent;
				newsum = newsum - pay + procent;
			}
			double res1 = res;

			//  РАСЧЕТ 2!

			Mounth = 4;
			StartMounth = 5;
			year = 2021;
			yearlow = 2021;
			res = 0;
			newsum = sum;
			pay = (sum * mounthrate * System.Math.Pow((1 + mounthrate), term )) / (System.Math.Pow(1 + mounthrate, term ) - 1);
			while (newsum >= 0)
			{
				if (Mounth + 1 - StartMounth == selectedMonth)
					newsum = newsum - payment;
				if (Mounth % 11 == 0)
				year += 1;
	
				subtractdates = new System.DateTime(year, (((Mounth + 1) % 12) + 1), 1) - new System.DateTime(yearlow, (Mounth % 12) + 1, 1);
				Mounth += 1;
				if (Mounth > 12)
				Mounth = 1;
				if (year != yearlow)
					yearlow += 1; 
				procent = newsum * rate * subtractdates.Days / (daysInYear * 100);
				res = res + procent;
				newsum = newsum - pay + procent;
			}

			// ВЫВОД РЕЗУЛЬТАТА
			double res2 = res;
			res = res2 - res1;
			if (res == 0)
				Console.WriteLine("Переплата при уменьшении платежа: " + res1 + "р.\nПереплата при уменьшении срока: " + res2 + "р.\nПереплата одинакова в обоих вариантах.");
			if (res > 0)
				Console.WriteLine("Переплата при уменьшении платежа: " + res1 + "р.\nПереплата при уменьшении срока: " + res2 + "р.\nУменьшение платежа выгоднее уменьшения срока на "+res+"р.");
			if (res < 0)
				Console.WriteLine("Переплата при уменьшении платежа: " + res1 + "р.\nПереплата при уменьшении срока: " + res2 + "р.\nУменьшение срока выгоднее уменьшения платежа на "+ (-res)+ "р.");
			return (0);
        }
