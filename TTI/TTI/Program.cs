using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TTI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();

        [DllImport("kernel32", SetLastError = true)]
        static extern bool AttachConsole(int dwProcessId);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frm_Main());
            }
            else
            {
                //*********************************************
                // Edit Stephen 2017-08-03
                //*********************************************
                List<String> lst_Report_View = new List<String>();
                //*********************************************
                // Edit Stephen 2017-08-03
                //*********************************************
                if (args[0] == "silent")
                {
                    //IntPtr ptr = GetForegroundWindow();

                    //int u;

                    //GetWindowThreadProcessId(ptr, out u);

                    //Process process = Process.GetProcessById(u);
                    //if(process.ProcessName == "cmd")
                    //    AttachConsole(process.Id);
                    //else
                    AllocConsole();
                    bool bNeedConfirm = false;

                    //*********************************************
                    // Edit Stephen 2017-08-03
                    //*********************************************
                    //                    if (args.Length > 1 && args[1] == "-c")
                    //                        bNeedConfirm = true;
                    bool bWebService = false;
                    for (int i = 1; i < args.Length; i++)
                    {
                        if (args[i] == "-c")
                            bNeedConfirm = true;
                        else if (args[i] == "-ws")
                            bWebService = true;
                        else
                        {
                            string[] strTok = args[i].Split(',');
                            for (int j = 0; j < strTok.Length; j++)
                            {
                                string strReportView = strTok[j].Replace("\"", "");
                                strReportView = strReportView.Replace("\'", "");
                                strReportView = strReportView.ToLower();
                                lst_Report_View.Add(strReportView);
                            }
                        }
                    }
                    //*********************************************
                    // Edit Stephen 2017-08-03
                    //*********************************************
                    
                    SilentModeClass silent = new SilentModeClass();
                    if (silent.VerifyingSerialKey() == false)
                    {
                        Console.WriteLine("Activation Failed");
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                        FreeConsole();
                        Application.Exit();
                        return;
                    }
                    Console.WriteLine("In process...");
//                    silent.Run("silent", false);//Pat 20160810 in_resume

                    //*********************************************
                    // Edit Stephen 2017-08-03
                    //*********************************************
                    silent.Run("silent", bWebService, lst_Report_View);//Pat 20160810 in_resume
                    //*********************************************
                    // Edit Stephen 2017-08-03
                    //*********************************************
                    Console.WriteLine("Success to export:");
                    //Pat 20160810 in_resume-------------------------------
                    List<String[]> lst_File = silent.GetFileList();
                    for (int i = 0; i < lst_File.Count; i++)
                    {
                        String[] strArr = new String[2];
                        strArr = lst_File[i];
                        Console.WriteLine(strArr[0]);
                        if (!strArr[1].Equals(""))
                            Console.WriteLine(strArr[1]);
                    }
                    //-----------------------------------------------------
                    if (bNeedConfirm == true)
                    {
                        Console.WriteLine("Press any key to exit");
                        Console.ReadKey();
                    }
                    FreeConsole();
                    Application.Exit();
                }//Pat 20160810 in_resume----------------------------------------------------------
                else if (args[0] == "silent_in_on_time" 
                    || args[0] == "silent_in_late" 
                    || args[0] == "silent_resume_on_time" 
                    || args[0] == "silent_resume_late" 
                    || args[0] == "silent_in" 
                    || args[0] == "silent_resume"
                    || args[0] == "silent_in_resume")
                {
                    AllocConsole();
                    //check doing web service-----------------
                    bool bNeedConfirm = false;
                    bool bWebService = false;
                    for (int i = 0; i < args.Length; i++)
                    {
                        if(args[i] == "-c")
                            bNeedConfirm = true;
                        else if (args[i] == "-ws")
                            bWebService = true;
                    }
                    //----------------------------------------                    

                    //write log-------------------------------
                    List<String> strLogList = new List<String>();
                    //----------------------------------------

                    SilentModeClass silent = new SilentModeClass();
                    if (silent.VerifyingSerialKey() == false)
                    {
                        Console.WriteLine("Activation Failed");
                        strLogList.Add("Activation Failed");//for write log
                        Console.WriteLine("Press any key to exit");
                        strLogList.Add("Press any key to exit");//for write log
                        Console.ReadKey();
                        FreeConsole();
                        Application.Exit();
                        return;
                    }
                    Console.WriteLine("In process...");
                    strLogList.Add("In process...");//for write log
                    //*********************************************
                    // Edit Stephen 2017-08-03
                    //*********************************************
                    silent.Run(args[0], bWebService, lst_Report_View);//Pat 20160810 in_resume
                    //*********************************************
                    // Edit Stephen 2017-08-03
                    //*********************************************
                    Console.WriteLine("Success to export:");
                    strLogList.Add("Success to export:");//for write log
                    //Pat 20160810 in_resume-------------------------------
                    List<String[]> lst_File = silent.GetFileList();
                    for(int i = 0;i<lst_File.Count;i++)
                    {
                        String[] strArr = new String[2];
                        strArr = lst_File[i];
                        Console.WriteLine(strArr[0]);
                        strLogList.Add(strArr[0]);//for write log
                        if (!strArr[1].Equals(""))
                        {
                            Console.WriteLine(strArr[1]);
                            strLogList.Add(strArr[1]);//for write log
                        }
                    }
                    //-----------------------------------------------------
                    if (bNeedConfirm == true)
                    {
                        Console.WriteLine("Press any key to exit");
                        strLogList.Add("Press any key to exit");//for write log
                        Console.ReadKey();
                    }

                    //write log-------------------------------
                    try
                    {
                        if (!Directory.Exists("log"))
                            Directory.CreateDirectory("log");

                        FileStream filestream = new FileStream("log\\" + args[0] + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt", FileMode.Create, FileAccess.Write);
                        StreamWriter sw = new System.IO.StreamWriter(filestream);
                        foreach (String str in strLogList)
                        {
                            sw.WriteLine(str);
                        }

                        sw.Close();
                        filestream.Close();
                    }
                    catch
                    {

                    }
                    //----------------------------------------

                    FreeConsole();
                    Application.Exit();
                }
                //----------------------------------------------------------------------------------
            }
        }
    }
}
