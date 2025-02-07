using Terraria.ModLoader;
using Terraria.Audio;

namespace TerraScape{
    public class Sounds : ModSystem{
        public static SoundStyle DragonClawProcSound = new SoundStyle("TerraScape/Assets/Sounds/Melee/DragonClawProc.wav"){
            Volume = 0.8f,
            PitchVariance = 0.2f
        };
        /* public static SoundStyle BandosGodswordProcSound = new SoundStyle("TerraScape/Assets/Sounds/Melee/BandosGodswordProc"){
            Volume = 0.8f,
            PitchVariance = 0.2f
        }; */
    }
}