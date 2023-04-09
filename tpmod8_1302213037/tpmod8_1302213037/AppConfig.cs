using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace tpmod8_1302213037
{
    internal class AppConfig
    {
        public CovidConfig covidConfig;
        public void readConfig()
        {
            string hasilbaca = File.ReadAllText(@"./covid_config.json");
            covidConfig = JsonSerializer.Deserialize<CovidConfig>(hasilbaca);
        }
        public void writeConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(covidConfig, options);

            File.WriteAllText(@"./covid_config.json", jsonString);
        }
        public void defaultConfig()
        {
            covidConfig = new CovidConfig("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan untuk masuk gedung ini");
        }
        public void UbahSatuan()
        {
            if (covidConfig.satuan_suhu == "celcius") 
            {
                covidConfig.satuan_suhu = "fahreinheit";
                writeConfig();
            } else {
                covidConfig.satuan_suhu = "celcius";
                writeConfig();
            }
        }
    }
}
