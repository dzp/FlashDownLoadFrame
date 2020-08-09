using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PowerPcDownLoad
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Diagnostics.Process p_gdb;
            //Process p_gdbSev = Process.Start(@"pegdbserver_power_console.exe", "-startserver -device=MPC5748G -gdbmiport=6224  -speed = 5000 -verbose");
            ProcessStartInfo pi = new ProcessStartInfo(@"pegdbserver_power_console.exe", "-startserver -device=MPC5748G -gdbmiport=6224  -speed = 5000 -verbose");
            pi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p_gdbSev = Process.Start(pi);
            /*
                        p_gdbSev = new Process();
                        p_gdbSev.StartInfo.FileName = "pegdbserver_power_console.exe -startserver -device=MPC5748G -gdbmiport=6224  -speed = 5000 -verbose";
                        p_gdbSev.StartInfo.UseShellExecute = false;
                        //p_gdbSev.StartInfo.RedirectStandardOutput = true;
                        //p_gdbSev.StartInfo.RedirectStandardInput = true;
                        p_gdbSev.StartInfo.CreateNoWindow = true;
                        p_gdbSev.Start();
            #endif  */
           // p_gdbSev.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process p_gdb = new Process();
            p_gdb.StartInfo.FileName = "powerpc-eabivle-gdb.exe";
            p_gdb.StartInfo.UseShellExecute = false;
            p_gdb.StartInfo.RedirectStandardInput = true;

            p_gdb.Start();
            p_gdb.StandardInput.WriteLine("target remote localhost:7224");
            p_gdb.StandardInput.WriteLine("load PowerPcFrame_Z4_0.elf");
           
            
            
            p_gdb.StandardInput.WriteLine("q");
            
            Console.ReadLine();
            p_gdb.WaitForExit();
            p_gdbSev.Kill();
            //p_gdbSev.StandardInput.WriteLine("dir");
        }
    }
}
