using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Global_Mouse_Hooks
{
    public class ClickDetector
    {
        public static void ListenForMouseEvents()
        {
            Console.WriteLine("Listening to mouse clicks and key presses.");

            //When a key is pressed 
            Hook.GlobalEvents().KeyDown += async (sender, e) =>
            {
                Console.WriteLine($"Key {e.KeyCode} Down");
                HandleKeyPress(e.KeyCode);
            };
            //When a mouse button is pressed 
            Hook.GlobalEvents().MouseDown += async (sender, e) =>
            {
                Console.WriteLine($"Mouse {e.Button} Down");
            };
            //When a double click is made
            Hook.GlobalEvents().MouseDoubleClick += async (sender, e) =>
            {
                Console.WriteLine($"Mouse {e.Button} button double clicked.");
            };
        }

        private static void HandleKeyPress(Keys keyCode)
        {
            if (keyCode == Keys.N)
            {
                Console.WriteLine($"Next commit");
                CheckoutSpecificCommit(GetNextChecksum());
            }
            else if (keyCode == Keys.V)
            { 
                Console.WriteLine($"Previous commit");
                CheckoutSpecificCommit(GetPreviousChecksum());
            }

        }

        private static string GetNextChecksum()
        {
            // placeholder: replace logic to get from known checksum values
            return "3f73480fb6808ce57fee8e31edcfa44131e9cb1a";
        }

        private static string GetPreviousChecksum()
        {
            // placeholder: replace logic to get from known checksum values
            return "928e120dc67481376c0cdd0ef0bae932ba157d74";
        }

        private static void CheckoutSpecificCommit(string checksum)
        {
            string commandToExecute = @"C:\Program Files\Git\cmd\git";

            // placeholder: replace with your working folder path 
            string workingDirectory = @"C:\Users\user1\Source\Repos\myrepo";

            string checkoutParam = $"checkout {checksum}";
            ProcessStartInfo process1 = new ProcessStartInfo(commandToExecute, checkoutParam);
            process1.WindowStyle = ProcessWindowStyle.Minimized;
            process1.WorkingDirectory = workingDirectory;

            Process.Start(process1);

            string pullParam = "pull";
            ProcessStartInfo process2 = new ProcessStartInfo(commandToExecute, pullParam);
            process2.WindowStyle = ProcessWindowStyle.Minimized;
            process2.WorkingDirectory = workingDirectory;

            Process.Start(process2);
        }
    }
}
