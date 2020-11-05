using System;
using System.Text;
using OtpNet;
namespace TOTP
{
    class Program
    {
        static void Main(string[] args)
        {
            var secretKey = Base32Encoding.ToBytes("NBSWY3DP");
            Console.Write(Encoding.ASCII.GetString(secretKey));
            var totpStep = 30;
            var totpSize = 8;
            var totp = new Totp(secretKey, mode: OtpHashMode.Sha256, step:totpStep, totpSize: totpSize);

            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 5000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            Console.ReadKey();
            void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                var now = DateTime.Now.ToUniversalTime();
                Console.WriteLine(now + " " + totp.ComputeTotp(now));
            }

        }
    }
}
