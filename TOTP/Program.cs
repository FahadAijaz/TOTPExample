using System;
using System.Text;
using OtpNet;
namespace TOTP
{
    class Program
    {
        static void Main(string[] args)
        {
            var secretKey = Encoding.ASCII.GetBytes("abc");
            var totpStep = 30;
            var totpSize = 8;
            var totp = new Totp(secretKey, mode: OtpHashMode.Sha256, step:totpStep, totpSize: totpSize);
            Console.WriteLine(totp.ComputeTotp(DateTime.Now));
        }
    }
}
