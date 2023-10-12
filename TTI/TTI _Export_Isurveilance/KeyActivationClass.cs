using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace TTI
{
    class KeyActivationClass
    {
        public KeyActivationClass()
        {
             GenerateClientKey();
        }

        public void GenerateClientKey()
        {
            String strKeyFilePath = "ClientKey.ditk";
            String strDone = SSTCryptographer.Encrypt(GetMACAddress(), "founder");
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(strKeyFilePath))
            {
                file.Write(strDone);
            }
        }

        public bool TryActivate()
        {
            if (DecryptSerialKeyFromClient(ReadClientKey()) ==
                DecryptSerialKeyFromSupport(ReadSerialKey()))
                return true;
            else
                return false;
        }

        private String ReadClientKey()
        {
            String strKey = "", file = "";
            try
            {
                string text = File.ReadAllText("ClientKey.ditk");
                strKey = text;
            }
            catch (IOException)
            {
            }
            return strKey;
        }

        private String ReadSerialKey()
        {
            String strKey = "", file ="";
            try
            {
                string text = File.ReadAllText("SerialKey.ditk");
                strKey = text;
            }
            catch (IOException)
            {
            }
            return strKey;
        }

        private String DecryptSerialKeyFromClient(String strKey)
        {
            if (strKey.Length == 0)
                return "";
            String strDone = SSTCryptographer.Decrypt(strKey, "founder");
            return strDone;
        }

        private String DecryptSerialKeyFromSupport(String strKey)
        {
            if (strKey.Length == 0)
                return "";
            String strDone = SSTCryptographer.Decrypt(strKey, "founder");
            strDone = SSTCryptographer.Decrypt(strDone, "founder");
            return strDone;
        }

        public static string GetMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }
    }
}
