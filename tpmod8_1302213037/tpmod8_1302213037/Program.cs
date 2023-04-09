using tpmod8_1302213037;

internal class Program
{
    private static void Main(string[] args)
    {
        AppConfig config1 = new AppConfig();
        try
        {
            config1.readConfig();
        }
        catch
        {
            config1.defaultConfig();
            config1.writeConfig();
            config1.readConfig();
        }
        config1.UbahSatuan();

        Console.WriteLine("Berapa suhu badan anda pada saat ini? Dalam nilai "+ config1.covidConfig.satuan_suhu);
        double inputSuhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu(perkiraan) anda terakhir memiliki gejala demam ?");
        int inputHari = Convert.ToInt32(Console.ReadLine());

        if((config1.covidConfig.satuan_suhu == "celcius" &&(inputSuhu >= 36.5 && inputSuhu < 37.5)) || (config1.covidConfig.satuan_suhu == "fahreinheit" && (inputSuhu >= 97.7 && inputSuhu < 99.5))) 
        {
            Console.WriteLine(config1.covidConfig.pesan_diterima);
        } 
        else if (inputHari > config1.covidConfig.batas_hari_demam)
        {
            Console.WriteLine(config1.covidConfig.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config1.covidConfig.pesan_ditolak);
        }
    }
}