namespace ValidatePassword
{
    class Program
    {
        static int ValidatePassword(string pwd)
        {
            if (pwd.Length < 8)
                return -1;

            if (!char.IsLetter(pwd[0]))
                return -1;

            if (!char.IsLetterOrDigit(pwd[pwd.Length - 1]))
                return -1;

            bool hasLetter = false, hasDigit = false, hasSpecial = false;

            foreach (char c in pwd)
            {
                if (char.IsLetter(c)) hasLetter = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (c == '@' || c == '#' || c == '_') hasSpecial = true;
            }

            return (hasLetter && hasDigit && hasSpecial) ? 1 : -1;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int res1=ValidatePassword("ashok_23");
            int res2=ValidatePassword("1991_23");

            Console.WriteLine(res1);
            Console.WriteLine(res2);
        }
    }
}
