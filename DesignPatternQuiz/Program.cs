using System;
using System.IO;

namespace DesignPatternQuiz
{

  class Program
  {
    public abstract class Ticket
    {
      DiscoutType discountType;
      public int Month { get; set; }
      public int Discount { get; set; }
      public Ticket()
      {

      }
      public void setDiscountType(int month)
      {
        this.Month = month;
        if (month == 12)
        {
          this.Discount = 0;
          this.discountType = new Double();
        }
        else if (month == 6 || month == 7)
        {
          this.Discount = 25;
          this.discountType = new OneFourthDiscount();
        }
        else
        {
          this.Discount = 0;
          this.discountType = new NoDiscount();
        }
      }
      public string getDetail()
      {
        return ("50" + " " + this.Month + " " + this.Discount + " " + discountType.GetPrice());
      }
    }

    public class WinToTor : Ticket
    {
      public string GetRoute()
      {
        return "From Winnipeg to Torrento";
      }
    }
    public interface DiscoutType
    {
      double GetPrice();
    }
    public class Double : DiscoutType
    {
      public double GetPrice()
      {
        return 50 * 2;
      }
    }

    public class OneFourthDiscount : DiscoutType
    {
      public double GetPrice()
      {
        return 50 - ((50 * 25) / 100);
      }
    }

    public class NoDiscount : DiscoutType
    {
      public double GetPrice()
      {
        return 50;
      }
    }

    #region Game Code
    public class Hero
    {
      public Weapon weapon { get; set; }
      public Hero(Weapon weapon)
      {
        this.weapon = weapon;
      }

    }
    public abstract class Enemy
    {
      public virtual string name { get; set; }
      public string getType()
      {
        return name;
      }
    }
    public class Gient : Enemy
    {
      public Gient()
      {
        name = "Gient";
      }
    }
    public class WeakEnemy : Enemy
    {
      public WeakEnemy()
      {
        name = "WeakEnemy";
      }
    }
    public abstract class Weapon
    {
      public virtual string Detail { get; set; }
      public virtual string GetDetail()
      {
        return Detail;
      }
    }
    public class Sniper : Weapon
    {
      public Sniper()
      {
        Detail = "Sniper";
      }
    }
    public class ShortGun : Weapon
    {
      public ShortGun()
      {
        Detail = "ShortGun";
      }
    }
    public abstract class WeaponUpgrades : Weapon
    {
      public abstract override string GetDetail();
    }
    public class Scope : WeaponUpgrades
    {
      Weapon weapon;
      public Scope(Weapon weapon)
      {
        this.weapon = weapon;
      }
      public override string GetDetail()
      {
        return weapon.GetDetail() + " Scope Added";
      }
    }

    public class Stabilizer : WeaponUpgrades
    {
      Weapon weapon;
      public Stabilizer(Weapon weapon)
      {
        this.weapon = weapon;
      }
      public override string GetDetail()
      {
        return weapon.GetDetail() + " Stabilizer Added";
      }
    }
    #endregion
    static void Main(string[] args)
    {
      #region Game Code
      //Weapon weapon = new Sniper();
      //Hero hero = new Hero(weapon);
      //Console.WriteLine("The Game is begin");
      //Random random = new Random();
      //var enemyType = random.Next(0, 3);
      //if (enemyType == 1)
      //{
      //  Enemy enemy = new Gient();
      //  Console.WriteLine(enemy.name);
      //  Console.WriteLine("Your enemy is strong prees key to upgrade weapon and kill enemy.");
      //  Console.ReadLine();
      //  hero.weapon = new Scope(hero.weapon);
      //  hero.weapon = new Stabilizer(hero.weapon);
      //}
      //else
      //{
      //  Enemy enemy = new WeakEnemy();
      //  Console.WriteLine(enemy.name);
      //  Console.WriteLine("Your enemy is weak you don't need any upgrades.");
      //}
      //Console.WriteLine("You attacked on enemy with:- " + hero.weapon.GetDetail());
      //Console.WriteLine("You win the game");
      //Console.ReadLine();
      #endregion

      Ticket ticket = new WinToTor();
      Console.WriteLine("Booked Tickets");
      GetTickets();
      Console.WriteLine("Enter month in number to get price");
      int month = Convert.ToInt32(Console.ReadLine());
      ticket.setDiscountType(month);
      addTicket(ticket.getDetail());
      Console.WriteLine(ticket.getDetail());
      Console.ReadLine();
    }
    public static void addTicket(string ticketDetails)
    {
      String path = @"D:\TicketDetails.txt";

      using (StreamWriter sw = File.AppendText(path))
      {
        sw.WriteLine(ticketDetails);
        sw.Close();
      }
      Console.WriteLine("Ticket saved in File");
    }
    public static void GetTickets()
    {
      String path = @"D:\TicketDetails.txt";

      using (StreamReader sr = File.OpenText(path))
      {
        string s = "";
        while ((s = sr.ReadLine()) != null)
        {
          Console.WriteLine(s);
        }
      }
      Console.WriteLine("All Tickets are as above");
    }
  }
}
