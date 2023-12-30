using System.Text;

namespace Project_Crypto
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Encrypt");
            Console.WriteLine("2. Decrypt");

            int choice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the message:");
            string message = Console.ReadLine();

            Console.WriteLine("Enter the key:");
            string key = Console.ReadLine();

            string result = "";

            switch (choice)
            {
                case 1:
                    result = Encrypt(message, key);
                    Console.WriteLine("Encrypted message: " + result);
                    break;
                case 2:
                    result = Decrypt(message, key);
                    Console.WriteLine("Decrypted message: " + result);
                    break;
            }
        }

        static string Encrypt(string message, string key)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            for (int i = 0; i < messageBytes.Length; i++)
            {
                messageBytes[i] ^= keyBytes[i % keyBytes.Length];
            }

            return Convert.ToBase64String(messageBytes);
        }

        static string Decrypt(string encryptedMessage, string key)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);

            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                encryptedBytes[i] ^= keyBytes[i % keyBytes.Length];
            }

            return Encoding.UTF8.GetString(encryptedBytes);
        }
    }
}