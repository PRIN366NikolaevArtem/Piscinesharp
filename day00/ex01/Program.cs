using System;
using System.IO;
Main(args);

        int Main(string[] args)
        {
			string path = "./us.txt";
			if (!File.Exists(path))
			{
				Console.WriteLine("Ошибка, файла us.txt не существует");
				return (1);
			}
			Console.WriteLine("Enter name:");
			string Name = Console.ReadLine();
			if (Name == "")
			{
				Console.WriteLine("Имя не введено");
				return (2);
			}
			int check = 0;
			while (check < Name.Length)
			{
				if (Name[check] == ' ' || Name[check] == '-' )
				{
					Console.WriteLine("Wrong name");
					return (1);
				}
				check++;
			}
			int lenName;
			int lenEdit;
			string[] ListOfNames = File.ReadAllLines(path);
			foreach (string edit in  ListOfNames)
			{
				lenName = Name.Length;
				lenEdit = edit.Length;
			
				int [,] array = new int[lenName + 1, lenEdit + 1];
				int i, j;
				i = 0;
				j = 0;
				while (i < lenName + 1)
				{
					j = 0;
					while(j < lenEdit + 1)
					{
						array[i,j] = 0;
						j++;
					}
					i++;
				}
				i = 1;
				while (i < lenEdit + 1)
				{
					array[0, i] = i;
					i++;
				}
				i = 1;
				while (i < lenName + 1)
				{
					array[i, 0] = i;
					i++;
				}
				i = 1;
				
				int minimal;
				while (i < lenName + 1)
				{
					j = 1;
					while (j < lenEdit + 1)
					{
						if (Name[i - 1] == edit[j - 1])
							array[i,j] = array[i - 1, j - 1];
						else
						{
							minimal = array[i - 1, j - 1];
							if (array[i - 1, j] < minimal)
							minimal = array[i - 1, j];
							if (array[i, j - 1] < minimal)
							minimal = array[i, j - 1];
							array[i,j] = minimal + 1;
						}
						j++;
					}
					i++;
				}
				int result = array[i - 1, j - 1];
				if (result < 3)
				{
					Console.WriteLine("Did you mean " + edit + "? Y/N");
					string answer = Console.ReadLine();
					if ( answer == "Y" || answer == "y")
					{
						Console.WriteLine("Hello, "+ edit +"!");
						return 0;
					}
					else if (answer == "N" || answer == "n")
					{
					}
					else 
					{
						Console.WriteLine ("Имя не введено");
						return (1);
					}
				}




			}
			Console.WriteLine("Your name was not found.");
			return (0);
			
        }
