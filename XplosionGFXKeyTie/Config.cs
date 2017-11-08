using LibAtem.Common;

namespace XplosionGFXKeyTie
{
    public class Config
    {
        public string AtemAddress { get; set; }

        public string GraphicsAddress { get; set; }

        public MixEffectBlockId MeId { get; set; }
        public UpstreamKeyId KeyerId { get; set; }
    }
}