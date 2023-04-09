using System;
using System.IO;
using Newtonsoft.Json;

namespace TP_MOD8_1302210024
{
    public class CovidConfig
    {
        public string SatuanSuhu { get; set; }
        public int BatasHariDeman { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }

        public static CovidConfig LoadFromFile()
        {
            string filePath = "covid_config.json";
            CovidConfig config = new CovidConfig();

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                config = JsonConvert.DeserializeObject<CovidConfig>(json);
            }
            else
            {
                config.SatuanSuhu = "celcius";
                config.BatasHariDeman = 14;
                config.PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
                config.PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
            }

            return config;
        }

        public static void SaveToFile(CovidConfig config)
        {
            string filePath = "covid_config.json";
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            if (SatuanSuhu == "celcius")
            {
                SatuanSuhu = "fahrenheit";
            }
            else
            {
                SatuanSuhu = "celcius";
            }
        }
    }
}
