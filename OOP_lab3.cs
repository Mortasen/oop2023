using System;
using System.Collections.Generic;


public interface INumber
{
    int GetValue ();
    int Add (INumber num);
    int Subtract (INumber num);
}

public class Number : INumber
{
  protected int value;

  public int GetValue () {
    return this.value;
  }

  public int Add (INumber num) {
    return this.value + num.GetValue();
  }

  public int Subtract (INumber num) {
    return this.value - num.GetValue();
  }
  
  public void Output () {
  	Console.Write(this.value);
  }
}

public class ArabicNumber : Number
{
	public ArabicNumber (string val)
	{
		this.value = Int32.Parse(val);
	}
}

public class UkrainianNumber : Number
{
  private static readonly Dictionary<string, int> NumberMap = new Dictionary<string, int>
      {
          { "нуль", 0 },
          { "один", 1 },
          { "одна", 1 },
          { "два", 2 },
          { "дві", 2 },
          { "три", 3 },
          { "чотири", 4 },
          { "п'ять", 5 },
          { "шість", 6 },
          { "сім", 7 },
          { "вісім", 8 },
          { "дев'ять", 9 },
          { "десять", 10 },
          { "одинадцять", 11 },
          { "дванадцять", 12 },
          { "тринадцять", 13 },
          { "чотирнадцять", 14 },
          { "п'ятнадцять", 15 },
          { "шістнадцять", 16 },
          { "сімнадцять", 17 },
          { "вісімнадцять", 18 },
          { "дев'ятнадцять", 19 },
          { "двадцять", 20 },
          { "тридцять", 30 },
          { "сорок", 40 },
          { "п'ятдесят", 50 },
          { "шістдесят", 60 },
          { "сімдесят", 70 },
          { "вісімдесят", 80 },
          { "дев'яносто", 90 },
          { "сто", 100 },
          { "двісті", 200 },
          { "триста", 300 },
          { "чотириста", 400 },
          { "п'ятсот", 500 },
          { "шістсот", 600 },
          { "сімсот", 700 },
          { "вісімсот", 800 },
          { "дев'ятсот", 900 },
      };
	  
	public UkrainianNumber (string val)
	{
        var words = val.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var result = 0;

        foreach (var word in words)
        {
            if (!NumberMap.ContainsKey(word))
                throw new ArgumentException($"Неправильне слово: '{word}'");

            var intval = NumberMap[word];
            result += intval;
        }

        this.value = result;
	}
}

public class RomanNumber : Number
{
	private static readonly Dictionary<char, int> RomanMap = new Dictionary<char, int>
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };
	
	public RomanNumber (string val)
	{
        int result = 0;

        for (int i = val.Length - 1; i >= 0; i--)
        {
            char currentSymbol = val[i];

            if (!RomanMap.ContainsKey(currentSymbol))
                throw new ArgumentException($"Неправильний символ: '{currentSymbol}'");

            int currentValue = RomanMap[currentSymbol];

            result += currentValue;
		}
		this.value = result;
	}
}







public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторна робота №3, Дронь Олександр.");

        while (true)
        {
            Number num1 = CreateNumber();
			if (num1 is null) break;
            Number num2 = CreateNumber();
			if (num2 is null) break;
			
			
            Console.Write("\nПерше число: ");
			num1.Output();
            Console.Write("\nДруге число: ");
			num2.Output();
            
            Console.Write("\nСума чисел: ");
            Console.WriteLine(num1.Add(num2));
            Console.Write("\nРізниця чисел: ");
            Console.WriteLine(num1.Subtract(num2));
        }
    }
	
	public static Number CreateNumber ()
	{
		Console.WriteLine("\nВиберіть тип числа:");
		Console.WriteLine("1. Арабське");
		Console.WriteLine("2. Римське");
		Console.WriteLine("3. Українське (прописом)");
		Console.WriteLine("4. Вийти");
		Console.Write("> ");
		int choice = Convert.ToInt32(Console.ReadLine());
		
		Console.Write("Введіть число: ");
		string num = Console.ReadLine();
		Number number = new Number();
		
		switch (choice)
        {
			case 1:
				number = new ArabicNumber(num);
				break;
			case 2:
				number = new RomanNumber(num);
				break;
			case 3:
				number = new UkrainianNumber(num);
				break;
			case 4:
				number = null;
				break;
		}
		return number;
	}
}

