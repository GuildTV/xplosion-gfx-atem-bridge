using System;
using System.IO;
using System.Reflection;
using log4net;
using log4net.Config;
using Newtonsoft.Json;
using LibAtem.Net;

namespace XplosionGFXKeyTie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            var log = LogManager.GetLogger(typeof(Program));
            log.Info("Starting");

            Config config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("config.json"));
            using (var client = new AtemClient(config.AtemAddress))
            {
                new XplosionGraphicsLinker(config, client).Start();

                Console.WriteLine("Press any key to terminate...");
                Console.ReadKey(); // Pause until keypress
            }
        }
    }
}
