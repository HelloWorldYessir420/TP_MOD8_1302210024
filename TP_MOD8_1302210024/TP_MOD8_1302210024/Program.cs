using System;

namespace TP_MOD8_1302210024
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = CovidConfig.LoadFromFile();

            Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
            double suhuBadan = Convert.ToDouble(Console.ReadLine());

            if (config.SatuanSuhu == "celcius")
            {
                if (suhuBadan >= 36.5 && suhuBadan <= 37.5)
                {
                    Console.WriteLine(config.PesanDiterima);
                }
                else
                {
                    Console.WriteLine(config.PesanDitolak);
                }
            }
            else if (config.SatuanSuhu == "fahrenheit")
            {
                if (suhuBadan >= 97.7 && suhuBadan <= 99.5)
                {
                    Console.WriteLine(config.PesanDiterima);
                }
                else
                {
                    Console.WriteLine(config.PesanDitolak);
                }
            }

            Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
            int hariDeman = Convert.ToInt32(Console.ReadLine());

            if (hariDeman < config.BatasHariDeman)
            {
                Console.WriteLine(config.PesanDiterima);
            }
            else
            {
                Console.WriteLine(config.PesanDitolak);
            }

            Console.WriteLine("Tekan enter untuk mengubah satuan suhu.");
            Console.ReadLine();

            config.UbahSatuan();
            CovidConfig.SaveToFile(config);

            Console.WriteLine($"Satuan suhu saat ini: {config.SatuanSuhu}");
        }
    }
}
