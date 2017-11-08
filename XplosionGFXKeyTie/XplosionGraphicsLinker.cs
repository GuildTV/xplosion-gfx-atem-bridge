using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using log4net;
using LibAtem.Commands;
using LibAtem.Commands.MixEffects;
using LibAtem.Commands.MixEffects.Key;
using LibAtem.Net;

namespace XplosionGFXKeyTie
{
    internal class XplosionGraphicsLinker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(XplosionGraphicsLinker));

        public Config Config { get; }
        public AtemClient Client { get; }

        public XplosionGraphicsLinker(Config config, AtemClient client)
        {
            Config = config;
            Client = client;
        }

        public void Start()
        {
            Client.OnReceive += OnCommand;
        }

        private void OnCommand(object sender, IReadOnlyList<ICommand> commands)
        {
            foreach (ICommand cmd in commands)
            {
                try
                {
                    if (cmd is MixEffectKeyOnAirGetCommand)
                        Handle(cmd as MixEffectKeyOnAirGetCommand);

                }
                catch (Exception e)
                {
                    Console.WriteLine("T: {0}", e);
                }
            }
        }
        
        private void Handle(MixEffectKeyOnAirGetCommand cmd)
        {
            if (cmd.MixEffectIndex != Config.MeId || cmd.KeyerIndex != Config.KeyerId)
                return;

            Log.InfoFormat("Turning graphic to: {0}", cmd.OnAir);

            var uri = new Uri(string.Format("{0}/api/main", Config.GraphicsAddress));
            var jsonInString = string.Format("{{\"Updates\":[{{\"key\":\"in\",\"value\":{0}}}]}}", cmd.OnAir.ToString().ToLower());

            var client = new HttpClient();
            client.PostAsync(uri, new StringContent(jsonInString, Encoding.UTF8, "application/json"));
        }
        
    }
}