using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Chat
{
    
    public static class Data_From_User2ToUser1
    {
        public delegate void MyEvent(byte[] data, RSAParameters key);
        public static MyEvent EventHandler;
    }
    
    public static class Data_From_User1ToUser2
    {
        public delegate void MyEvent(byte[] data, RSAParameters key);
        public static MyEvent EventHandler;
    }
}
