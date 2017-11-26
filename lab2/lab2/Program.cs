using System;

// variant 2-16
namespace lab2
{
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
		public override string ToString()
		{
			return string.Format("[Trupa: nameProperty={0}]", nameProperty);
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
		public override string ToString()
		{
			return string.Format("[Building: nameProperty={0}, orkestrPriceProperty={1}]", nameProperty,
			                     orkestrPriceProperty);
		}
		public static bool operator < (Building building1, Building building2)
		{
			return building1.placeAmount < building2.placeAmount;
		}
		public static bool operator > (Building building1, Building building2)
		{
			return building1.placeAmount > building2.placeAmount;
		}
		public override bool Equals(Object obj)
		{
			return base.Equals(obj);
		}
		public static bool operator == (Building building1, Building building2)
		{
			if (building1.name.Equals(building2.name) && building1.adress.Equals(building2.adress)
			    && building1.orendFee == building2.orendFee && building1.placeAmount == building2.placeAmount)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool operator !=(Building building1, Building building2)
		{
			if (!building1.name.Equals(building2.name) && building1.adress.Equals(building2.adress)
			   && building1.orendFee == building2.orendFee && building1.placeAmount == building2.placeAmount)
			{
				return true;
			}
			else {
				return false;
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
		public override string ToString()
		{
			return string.Format("[Performance: nameProperty={0}, isOrkesterNeededProperty={1}]", nameProperty, isOrkesterNeededProperty);
		}
	}
	class Repertuar:ICloneable
	{
		private String month;
		private int performancesAmount;
		private Performance[] performances;
		public Performance this[int index]
		{
			get
			{
				return this.performances[index];
			}
			set
			{
				this.performances[index] = value;
			}
		}
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
			for (int i = 0; i < this.performances.Length; i++)
			{
				Console.WriteLine(this.performances[i].nameProperty);
			}
		}
		public Repertuar(Repertuar repertuar)
		{
			Console.WriteLine("Copy constr");
			this.monthProperty = repertuar.monthProperty;
			this.performances = repertuar.performances;
			this.performancesAmount = repertuar.performancesAmount;
		}
		public object Clone()
		{
			Console.WriteLine("Clone repertuar");
			Repertuar repertuar = new Repertuar(this.month, this.performancesAmount, this.performances);
			return repertuar;
		}
		~Repertuar()
		{
			Console.WriteLine(this.monthProperty + " has been deleted");
		}
		public override string ToString()
		{
			return string.Format("[Repertuar: monthProperty={0}]", monthProperty);
		}
	}


	//demonstrating virtual and non-virtual functions
	 /*Compilation error
	  method from DerrivedNonVirtual hides method from BaseNonVirtual*/
	 
	  class BaseNonVirtual
	{
		public void method()
		{
			Console.WriteLine("BaseNonVirtual");
		}
	}
	class DerrivedNonVirtual:BaseNonVirtual
	{
		public new void method()
		{
			Console.WriteLine("DerrivedNonVirtual");
		}
	}

	class BaseVirtual
	{
		public virtual void method()
		{
			Console.WriteLine("BaseVirtual");
		}
	}
	class DerrivedVirtual:BaseVirtual
	{
		public override void method()
		{
			Console.WriteLine("DerrivedVirtual");
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
			Performance performance3 = new Performance("Performance3", Category.OPERA, building1, trupa1, System.DateTime.Now, false);
			Performance[] performances1 = { performance1, performance2 };
			Performance[] performances2 = { performance1, performance3 };
			Repertuar repertuar1 = new Repertuar("may", 2, performances1);
			Repertuar repertuar2 = new Repertuar("june", 2, performances2);
			repertuar1.info();
			repertuar2.info();
			Repertuar repertuar3 = (Repertuar)repertuar2.Clone();
			Console.WriteLine(repertuar1);
			Console.WriteLine(repertuar1[0]);



			BaseNonVirtual baseNonVirtual = new BaseNonVirtual();
			DerrivedNonVirtual derrivedNonVirtual = new DerrivedNonVirtual();
			BaseNonVirtual baseNonVirtualHref = null;
			baseNonVirtualHref = baseNonVirtual;
			baseNonVirtualHref.method();              // output: BaseNonVirtual
			baseNonVirtualHref = derrivedNonVirtual;
			baseNonVirtualHref.method();              // output: BaseNonVirtual

			BaseVirtual baseVirtual = new BaseVirtual();
			DerrivedVirtual derrivedVirtual = new DerrivedVirtual();
			BaseVirtual baseVirtualHref = null;
			baseVirtualHref = baseVirtual;
			baseVirtualHref.method();				  // output: BaseVirtual
			baseVirtualHref = derrivedVirtual;
			baseVirtualHref.method();				  // output: DerrivedVirtual
		}
	}
}
