using HtmlAgilityPack;

namespace MyApp
{
    internal class Export
    {

        public static void ExportFromSites()
        {
            TrustedLines();
            TrustLinesKnownAirdrops();
            PossibleAirdrops();
        }

        private static void PossibleAirdrops()
        {
            //pobieranie z xumm.community/tokens
            var file = @"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\xummcommunitytokens.htm";
            var html_ = file;
            var web = new HtmlWeb();
            var xd = web.Load(html_);
            var names = xd.DocumentNode.SelectNodes("//*[contains(@class,'mat-cell cdk-cell cdk-column-currencyCodeUTF8 mat-column-currencyCodeUTF8 ng-tns-c182-1 ng-star-inserted')]").Select(x => x.FirstChild);
            foreach (var name in names)
            {
                File.AppendAllText(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\xummtokens.txt", name.InnerText.Trim() + "\n");
            }

        }

        private static void TrustedLines()
        {
            //pobieranie z xrpscan.com
            var file = @"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\matikwallet.htm";

            var html_ = file;
            var web = new HtmlWeb();
            var xd = web.Load(html_);
            var names = xd.DocumentNode.SelectNodes("//*[contains(@class,'text-monospace')]").Select(x => x.FirstChild);
            //zapisywanie do pliku nazw połączonych trustlinów
            foreach (var name in names.Skip(1))
            {

                File.AppendAllText(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\xrpscan.txt", name.InnerText + "\n");
            }

        }

        private static void TrustLinesKnownAirdrops()
        {
            //pobieranie z xrpltools.com/#/airdrops
            var file = @"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\airdrop1.htm";
            var html_ = file;
            var web = new HtmlWeb();
            var xd = web.Load(html_);
            var names = xd.DocumentNode.SelectNodes("//*[contains(@class,'el-table_1_column_2 is-left')]").Select(x => x.FirstChild);
            foreach (var name in names)
            {
                File.AppendAllText(@"C:\Users\sam_sepi0l\Desktop\CheckAirdrops\CheckAirdrops\xrpltoolslist.txt", name.InnerText.Trim() + "\n");
            }

        }
    }
}