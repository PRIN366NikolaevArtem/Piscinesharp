namespace ExchangerSpace
{
	class Exchanger
	{
		static public bool checker(int argsLength, string firstArg, string path)
		{
			if (argsCheck(argsLength) || directoryCheck(path) || firstArgCheck(firstArg))
				return (true);
			return (false);
		}
		static private bool argsCheck (int amount)
		{
			if (amount != 2)
			{
				mistakeOut();
				return (true);
			}
			return (false);
		}
		static private bool directoryCheck(string path)
		{
			if (System.IO.Directory.Exists(path) == false)
			{
				mistakeOut();
				return (true);
			}
			return (false);
		}
		static private bool firstArgCheck (string firstArg)
		{
			if (firstArg.Length < 5)
			{
				mistakeOut();
				return(true);
			}
			return (false);
		}



		static public string FileName(string FileName)
		{
			string identifier = null;
			if (FileName[FileName.Length - 3] == 'R' && FileName[FileName.Length - 2] == 'U' && FileName[FileName.Length - 1] == 'B')
				identifier = "RUB";
			else if (FileName[FileName.Length - 3] == 'E' && FileName[FileName.Length - 2] == 'U' && FileName[FileName.Length - 1] == 'R')
				identifier = "EUR";
			else if (FileName[FileName.Length - 3] == 'U' && FileName[FileName.Length - 2] == 'S' && FileName[FileName.Length - 1] == 'D')
				identifier = "USD";
			else
			{
				mistakeOut();
				return null;
			}
			return identifier;
		}

		static public void mistakeOut ()
		{
			System.Console.WriteLine("Ошибка ввода. Проверьте входные данные и повторите запрос.");
		}

	}
}