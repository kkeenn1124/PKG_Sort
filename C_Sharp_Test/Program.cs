using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Timers;
using System.IO;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading;
using System.Linq;
using System.Management;
using System.Globalization;

namespace C_Sharp_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ////System.Management.EnumerationOptions options = new System.Management.EnumerationOptions();
            ////options.Rewindable = false;
            ////options.ReturnImmediately = true;

            ////string query = "SELECT * FROM Win32_USBHub";

            ////ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\cimv2", query);

            ////ManagementObjectCollection processes = searcher.Get();

            ////foreach (ManagementObject process in processes)
            ////{
            ////    Console.WriteLine(process["Name"]);
            ////}
            ///////////////////////
            ////ManagementObjectSearcher search = new ManagementObjectSearcher("SELECT * FROM Win32_USBControllerDevice");
            ////ManagementObjectCollection collection = search.Get();
            ////var usbList = from u in collection.Cast<ManagementBaseObject>()
            ////              select new
            ////              {
            ////                  id = u.GetPropertyValue("DeviceID"),
            ////                  name = u.GetPropertyValue("Name"),
            ////                  status = u.GetPropertyValue("Status"),
            ////                  system = u.GetPropertyValue("SystemName"),
            ////                  caption = u.GetPropertyValue("Caption"),
            ////                  pnp = u.GetPropertyValue("PNPDeviceID"),
            ////                  description = u.GetPropertyValue("Description")
            ////              };
            ////foreach (var u in usbList)
            ////    Console.WriteLine(String.Format($"{u.id}\n{u.name}"));
            //////////////////////////////////
            //ManagementObjectCollection moc = new ManagementObjectSearcher("select * from CIM_USBHub").Get();
            //if(moc != null)
            //{
            //    foreach (ManagementObject mm in moc)
            //    {
            //        if (mm["Name"].ToString() == "USB Mass Storage Device")
            //        {
            //            Console.WriteLine(mm["Name"]);
            //            Console.WriteLine(mm["DeviceID"]);
            //            //Console.WriteLine(mm["SystemName"]);
            //            //Console.WriteLine(mm["Caption"]);
            //            //Console.WriteLine(mm["PNPDeviceID"]);
            //            //Console.WriteLine(Convert.ToUInt32( mm["GetDescriptor"]));
            //        }
            //    }
            //}
            //////////////////////////////////
            //DriveInfo[] allDrives = DriveInfo.GetDrives();

            //foreach (DriveInfo d in allDrives)
            //{
            //    if(d.DriveType.ToString()== "Removable") { 
            //    Console.WriteLine("Drive {0}", d.Name);
            //    Console.WriteLine("  Drive type: {0}", d.DriveType);
            //    if (d.IsReady == true)
            //    {
            //        Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
            //        Console.WriteLine("  File system: {0}", d.DriveFormat);
            //        //Console.WriteLine(
            //        //    "  Available space to current user:{0, 15} bytes",
            //        //    d.AvailableFreeSpace);

            //        //Console.WriteLine(
            //        //    "  Total available space:          {0, 15} bytes",
            //        //    d.TotalFreeSpace);

            //        //Console.WriteLine(
            //        //    "  Total size of drive:            {0, 15} bytes ",
            //        //    d.TotalSize);
            //    }
            //}
            ///////////////////////////////////////
            //}

            List<double> list = new List<double>();

            string con = "";

            while (con != "aa")
            {
                Console.Write("輸入數值：");
                con = Console.ReadLine();
                if (double.TryParse(con, out double cons))
                {
                    list.Add(cons);
                }

            }

            double[] num = list.ToArray();
            string[] name = new string[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                name[i] = (i + 1).ToString();
            }
            Line();

            int target1 = 200, target2 = 120;
            int num_count = 0;


            for (int i = 0; i < num.Length; i++)
            {
                num[i] = Math.Ceiling(num[i] / target1);
                while (num[i] >= target2)
                {
                    num[i] -= target2;
                    num_count++;
                    Console.WriteLine($"編號：{name[i]} 一個棧板 剩下{num[i]}");
                    if (num[i] == 0)
                    {
                        name[i] = "0";
                    }
                }
            }

            num = Array.FindAll(num, x => x != 0);
            name = Array.FindAll(name, x => x != "0");

            Line();


            for (int i = 0; i < num.Length; i++)
            {
                for (int j = i + 1; j < num.Length; j++)    //Bouble Sort
                {
                    if (num[j] > num[i])
                    {
                        (num[j], num[i]) = (num[i], num[j]);
                        (name[j], name[i]) = (name[i], name[j]);
                    }
                }
            }

            for (int i = 0; i < num.Length; i++)
            {
                Console.WriteLine($"編號：{name[i]} \t還有{num[i]}");
            }
            Line();
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            double sum = 0;
            List<string> tmp = new List<string>();
            List<double> num_tmp = new List<double>();
            string aa;
            for (int i = 0; i < num.Length; i++)
            {
                sum += num[i];
                tmp.Add(name[i] + " ");
                num_tmp.Add(num[i]);
                if (sum >= target2)
                {
                    sum -= target2;
                    num_count++;
                    Console.Write("編號：");

                    for (int q = 0; q < tmp.Count; q++)
                    {
                        for (int r = q + 1; r < tmp.Count; r++)
                        {
                            if (num_tmp[r] > num_tmp[q])
                            {
                                (tmp[r], tmp[q]) = (tmp[q], tmp[r]);
                                (num_tmp[r], num_tmp[q]) = (num_tmp[q], num_tmp[r]);
                            }

                        }
                    }

                    foreach (var item in tmp)
                    {
                        Console.Write(item + " ");
                    }

                    aa = tmp[tmp.Count - 1];
                    Console.WriteLine($"編號：{aa} 剩下{sum}");
                    tmp.Clear();
                    num_tmp.Clear();
                    tmp.Add(aa);
                    num_tmp.Add(sum);
                    Console.WriteLine();

                }

            }

            Console.Write("編號：");
            for (int q = 0; q < tmp.Count; q++)
            {
                for (int r = q + 1; r < tmp.Count; r++)
                {
                    if (num_tmp[r] > num_tmp[q])
                    {
                        (tmp[r], tmp[q]) = (tmp[q], tmp[r]);
                        (num_tmp[r], num_tmp[q]) = (num_tmp[q], num_tmp[r]);
                    }

                }
            }
            foreach (var item in tmp)
            {
                Console.Write(item + " ");
            }
            num_count++;
            Console.WriteLine($"剩下{sum}");

            Line();

            Console.WriteLine($"共{num_count}個棧板");
        }

        public static void Line()
        {
            for (int i = 0; i < 50; i++)    //分隔線
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }
    }
}
