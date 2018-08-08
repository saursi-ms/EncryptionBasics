using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MSKsp
{
    public class TestMSKsp
    {
        private static string quote =
         "Things may come to those who wait, but only the " +
         "things left by those who hustle. -- Abraham Lincoln";

        public static void Main()
        {
            Console.WriteLine("Generate Keys(1)/ Delete Key(2) :");
            int ch = Convert.ToInt32(Console.ReadLine());
            if(ch == 1)
            {
                Console.WriteLine("Generating 2 Keys:");
                string key1 = MSKsp.GenerateAESKey();
                Console.WriteLine("Key 1 :-> " + key1);
                string key2 = MSKsp.GenerateAESKey();
                Console.WriteLine("Key 2 :-> " + key2);
            }
            else
            {
                Console.WriteLine("Enter Key :");
                string delKey = Console.ReadLine();
                MSKsp.DeleteAESKey(delKey);
            }

/*
            //Encrypt & Decrypt:
            using (AesCng aesCSP = new AesCng(key))
                {

                    Console.WriteLine("Using Existing Key -" + key);
                    byte[] encQuote = EncryptString(aesCSP, quote);

                    Console.WriteLine("Encrypted Quote:\n");
                    Console.WriteLine(Convert.ToBase64String(encQuote));

                    Console.WriteLine("\nDecrypted Quote:\n");
                    Console.WriteLine(DecryptBytes(aesCSP, encQuote));

                }
            Thread.Sleep(10000);
                MSKsp.DeleteAESKey(key);       
*/
        }

        public static byte[] EncryptString(SymmetricAlgorithm symAlg, string inString)
        {
            byte[] inBlock = UnicodeEncoding.Unicode.GetBytes(inString);
            ICryptoTransform xfrm = symAlg.CreateEncryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBlock, 0, inBlock.Length);

            return outBlock;
        }

        public static string DecryptBytes(SymmetricAlgorithm symAlg, byte[] inBytes)
        {
            ICryptoTransform xfrm = symAlg.CreateDecryptor();
            byte[] outBlock = xfrm.TransformFinalBlock(inBytes, 0, inBytes.Length);

            return UnicodeEncoding.Unicode.GetString(outBlock);
        }

    }
}
