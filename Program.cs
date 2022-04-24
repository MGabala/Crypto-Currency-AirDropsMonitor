using HtmlAgilityPack;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program : Export
    {
        static void Main(string[] args)
        {
             ExportFromSites();
              ShowData();
          
        }

     

        private static void ShowData()
        {
            
            //wallet
            var wallet_z_trustami = File.ReadAllLines(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\xrpscan.txt");
            //lista trustów
           var trusty_do_polaczenia =  File.ReadAllLines(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\xummtokens.txt");
            var list_of_new_coins = new List<string>();
            var list_of_old_coins = new List<string>();
            foreach(var newcoin in trusty_do_polaczenia)
            {
                list_of_new_coins.Add(newcoin);
            }
            foreach(var oldcoin in wallet_z_trustami)
            {
                list_of_old_coins.Add(oldcoin);
            }
            var new_list = new List<string>();
            new_list = list_of_new_coins.Except(list_of_old_coins).ToList();
            foreach(var item in new_list)
            {
                File.AppendAllText(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\newcoins.txt", item+"\n");
            }
            
            //for (int i = 0; i < trusty_do_polaczenia.Count(); i++)
            //{
            //    for (int y = 0; y < wallet_z_trustami.Count(); y++)
            //    {
            //        Console.WriteLine(trusty_do_polaczenia[i]+":"+wallet_z_trustami[y]);
            //        if (wallet_z_trustami[y] != trusty_do_polaczenia[i])
            //        {
            //            File.AppendAllText(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\newcoins.txt", trusty_do_polaczenia[i] + "\n");
            //        }
            //        else Console.WriteLine($"else + {trusty_do_polaczenia[i]}");
                   
            //    }
            //}
  
        }
    }
}