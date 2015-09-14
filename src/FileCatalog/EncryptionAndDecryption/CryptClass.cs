using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionAndDecryption
{
    class CryptClass
    {
        public static string Encrypt(string baseWord)
        {
            List<int> baseChars = new List<int>();
            List<char> encryptChars = new List<char>();
            string encryptWord;
                foreach (char c in baseWord)
                    {
                        baseChars.Add((int)c+1);
                    }
                for (int i = 0; i < baseChars.Count; i++)
                    {
                        encryptChars.Add((char)baseChars[i]);
                    }
            encryptWord = new string(encryptChars.ToArray());
            return encryptWord;
        }
        public static string Decrypt(string encryptWord)
        {
            List<int> encryptChars = new List<int>();
            List<char> decryptChars = new List<char>();
            string decriptWord;
            foreach (char c in encryptWord)
            {
                encryptChars.Add((int)c - 1);
            }
            for (int i = 0; i < encryptChars.Count; i++)
            {
                decryptChars.Add((char)encryptChars[i]);
            }
            decriptWord = new string(decryptChars.ToArray());
            return decriptWord;
        }

    }
}
