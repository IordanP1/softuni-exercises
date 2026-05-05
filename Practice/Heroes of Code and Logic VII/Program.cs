namespace Heroes_of_Code_and_Logic_VII
{
    class Hero
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            Heal(hp);
            Recharge(mp);
        }
        public int Heal(int hp)
        {
            int recoveredHp = Math.Min(hp, 100 - HP);
            HP += recoveredHp;

            return recoveredHp;
        }
        public int Recharge(int mp)
        {
            int recoveredMp = Math.Min(mp, 200 - MP);
            MP += recoveredMp;
            return recoveredMp;
        }

        override public string ToString()
        {
            return $"{Name}\n HP: {HP}\n MP: {MP}";
        }

    }   
    internal class Program
    {
        public static List<Hero> party = new List<Hero>();
        
       

        static void Main(string[] args)
        {
            int herosCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < herosCount; i++)
            {
                string[] heroData = Console.ReadLine().Split(" ");
                Hero newHero = new Hero(heroData[0], int.Parse(heroData[1]), int.Parse(heroData[2]));

                party.Add(newHero);
            }

            string command = "";
            while ((command=Console.ReadLine())!="End")
            {
                string[] arguments = command.Split(" - ");
                switch (arguments[0])
                {
                    case "CastSpell":
                        CastSpell(arguments[1], int.Parse(arguments[2]), arguments[3]);

                        break;

                    case "TakeDamage":
                        TakeDemage(arguments[1], int.Parse(arguments[2]), arguments[3]);
                        break;

                    case "Recharge":
                        Recharge(arguments[1], int.Parse(arguments[2]));
                        break;

                    case "Heal":
                        Heal(arguments[1], int.Parse(arguments[2]));
                        break;


                }
            }
            foreach (Hero hero in party)
            {
                Console.WriteLine(hero.ToString());
            }
        }

        private static void Heal(string hero, int amount)
        {
            Hero foundHero = FindHero(hero);
            if (foundHero != null)
            {
                int recoverHealth = foundHero.Heal(amount);
                Console.WriteLine($"{foundHero.Name} healed for {recoverHealth} HP!");
            }
        }

        private static void Recharge(string hero, int amount)
        {
            Hero foundHero = FindHero(hero);
            if (foundHero != null)
            {
                int recoverManna = foundHero.Recharge(amount);
                Console.WriteLine($"{foundHero.Name} recharged for {recoverManna} MP!");
            }
        }

        public static void TakeDemage(string hero, int demage, string attacker)
        {
            Hero foundHero = FindHero(hero);
            if (foundHero!=null)
            {
                foundHero.HP -= demage;
            }
            if (foundHero.HP>0)
            {
                Console.WriteLine($"{foundHero.Name} was hit for {demage} HP by {attacker} and now has {foundHero.HP} HP left!");
            }
            else
            {
                Console.WriteLine($"{foundHero.Name} has been killed by {attacker}!");
                party.Remove(foundHero);
            }

        }

        public static void CastSpell(string hero, int mannaNeed, string spelName)
        {
            Hero foundHero= FindHero(hero);
            if (foundHero != null && foundHero.MP >= mannaNeed) 
            {
                foundHero.MP -= mannaNeed;
                Console.WriteLine($"{foundHero.Name} has successfully cast {spelName} and now has {foundHero.MP} MP!");
            }
            else
            {
                Console.WriteLine($"{foundHero.Name} does not have enough MP to cast {spelName}!");
            }
        }

        public static  Hero FindHero(string hero)
        {
            return party.FirstOrDefault(h => h.Name == hero);
            
            
        }
    }
}
/* 
2
Solmyr 85 120
Kyrre 99 50
Heal - Solmyr - 10
Recharge - Solmyr - 50
TakeDamage - Kyrre - 66 - Orc
CastSpell - Kyrre - 15 - ViewEarth
End
 */
