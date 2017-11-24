using System;

namespace lab2
{
	// 25.11.2017 0:51
	//Variant 2-16
	//First part (pages 23-24)
	enum Category
	{
		DRAMA,
		OPERETA,
		OPERA,
		BALET
	}
	class Trupa
	{
		private String name;
		private int actorsAmount;
		private double moneyToPayout;
		public Trupa(String name, int actorsAmount, double moneyToPayout)
		{
			this.name = name;
			this.actorsAmount = actorsAmount;
			this.moneyToPayout = moneyToPayout;
		}
		public String nameProperty
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

	}
	class Building
	{
		private String name;
		private String adress;
		private double orendFee;
		private int placeAmount;
		static int orkestrPrice;
		public Building(String name, String adress, double orendFee, int placeAmount)
		{
			this.name = name;
			this.adress = adress;
			this.orendFee = orendFee;
			this.placeAmount = placeAmount;
		}
		public String nameProperty
		{ 
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}
		public int orkestrPriceProperty
		{
			get
			{
				return orkestrPrice;
			}
			set
			{
				orkestrPrice = value;
			}
		}
			
	}
	class Performance
	{
		private String name;
		private Category category;
		private Building building;
		private Trupa trupa;
		private System.DateTime date;
		private bool isOrkesterNeeded;
		public Performance(String name, Category category, Building building, Trupa trupa, System.DateTime date, bool isOrkestrNeeded)
		{
			this.name = name;
			this.category = category;
			this.building = building;
			this.trupa = trupa;
			this.date = date;
			this.isOrkesterNeeded = isOrkestrNeeded;
		}
		public String nameProperty
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public bool isOrkesterNeededProperty
		{
			get
			{
				return isOrkesterNeeded;
			}
			set
			{
				isOrkesterNeeded = value;
			}
		}
	}
	class Repertuar
	{
		private String month;
		private int performancesAmount;
		private Performance[] performances;
		public String monthProperty
		{
			get
			{
				return month;
			}
			set
			{
				month = value;
			}
		}
		public Repertuar(String month, int performancesAmount, Performance[] performances)
		{
			this.month = month;
			this.performancesAmount = performancesAmount;
			this.performances = performances;
		}
		public void addPerformance(Performance performance)
		{
			Performance[] temp = performances;
			this.performances = new Performance[++performancesAmount];
			for (int i = 0; i < this.performances.Length - 1; i++)
			{
				this.performances[i] = temp[i];
			}
			this.performances[this.performances.Length - 1] = performance;
		}
		public void removePerformance()
		{
			Performance[] temp = this.performances;
			this.performances = new Performance[--this.performancesAmount];
			for (int i = 0; i < this.performances.Length; i++)
			{
				this.performances[i] = temp[i];
			}
		}
		public void info()
		{
			Console.WriteLine("Repertuars " + month + " " + this.performancesAmount);
		}

	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			Trupa trupa1 = new Trupa("FirstTrupa", 5, 500.0);
			Building building1 = new Building("Building1", "Adress1", 400.0, 50);
			Performance performance1 = new Performance("Performance1", Category.OPERA, building1, trupa1, System.DateTime.Now, false);
			Performance performance2 = new Performance("Performance2", Category.DRAMA, building1, trupa1, System.DateTime.Now, true);
			Performance[] performances = { performance1, performance2 };
			Repertuar repertuar = new Repertuar("may", 2, performances);
			repertuar.info();
		}
	}
}
