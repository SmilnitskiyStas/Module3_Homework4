using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndLinQ.Models
{
    internal class LinQProcessing
    {
        public List<User> users = new List<User>();

        public void LinqRun()
        {
            CreateUsers();
            LinQProcessingToUsers();
        }

        public void LinQProcessingToUsers()
        {
            User firstOrDefaultUser = users.FirstOrDefault();

            Console.WriteLine($"\nFirst user - {firstOrDefaultUser}");

            User lastOrDefaultUser = users.LastOrDefault();

            Console.WriteLine($"\nLast user - {lastOrDefaultUser}");

            Console.WriteLine("\nSelect all users name");

            var selectUsers = users.Select(u => u.Name);

            foreach (var user in selectUsers)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("\nSelect users where Name start 'R'");

            bool r = users.Any(u => u.Name.StartsWith("R"));

            if (r)
            {
                var whereUsers = users.Where(u => u.Name.StartsWith("R")).Select(u => u.Name).OrderBy(u => u);

                foreach (var user in whereUsers)
                {
                    Console.WriteLine(user);
                }
            }

            Console.WriteLine("\nDistinct users list");

            var distinctUsers = users.Distinct();

            foreach (var user in distinctUsers)
            {
                Console.WriteLine(user.Name);
            }

            Console.WriteLine("\nCount users");

            var countUsers = users.Count(u => u.Name.StartsWith("T"));

            Console.WriteLine(countUsers);

            Console.WriteLine("\nDone!\n");
        }

        private void CreateUsers()
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(20, 100); i++)
            {
                int randomValuesForName = random.Next(2, 8);
                int randomValuesForLastName = random.Next(4, 12);
                string randomValuesForPhoneNumber = random.Next(100000000, 999999999).ToString();

                User user = new User(RandomeName(randomValuesForName), RandomeName(randomValuesForLastName), randomValuesForPhoneNumber);

                users.Add(user);
            }
        }

        private string RandomeName(int len)
        {
            Random r = new Random();
            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "l", "n", "p", "q", "r", "s", "sh", "zh", "t", "v", "w", "x" };
            string[] vowels = { "a", "e", "i", "o", "u", "ae", "y" };

            string name = "";

            name += consonants[r.Next(consonants.Length)].ToUpper();
            name += vowels[r.Next(vowels.Length)];
            int b = 2;

            while (b < len)
            {
                name += consonants[r.Next(consonants.Length)];
                b++;
                name += vowels[r.Next(vowels.Length)];
                b++;
            }

            return name;
        }
    }
}
