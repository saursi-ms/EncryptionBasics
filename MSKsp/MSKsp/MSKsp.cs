using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

//  Needs .Net version 4.7.1
namespace MSKsp
{
    public static class MSKsp
    {
        public static string GenerateAESKey()
        {
            string keyName = RandomKeyName();
            CngKeyCreationParameters keyCreationParams = new CngKeyCreationParameters();
            keyCreationParams.Provider = CngProvider.MicrosoftSoftwareKeyStorageProvider;
            CngKey key = CngKey.Create(new CngAlgorithm("AES"), keyName, keyCreationParams);
            return keyName;
        }

        public static void DeleteAESKey(string keyName)
        {
            if (CngKey.Exists(keyName, CngProvider.MicrosoftSoftwareKeyStorageProvider))
            {
                Console.WriteLine("Deleting Existing Key -:" + keyName);
                CngKey deleteKey = CngKey.Open(keyName, CngProvider.MicrosoftSoftwareKeyStorageProvider);
                deleteKey.Delete();
            }
        }

        private static string RandomKeyName()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            return GuidString;
        }
    }
}
