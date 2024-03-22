namespace RecNetSharp.Models.RecNet
{
    // thanks to jegarde on discord for having this!
    public enum PlatformMask
    {
        None = 0,
        Steam = 1,
        Oculus = 2,
        PlayStation = 4,
        Xbox = 8,
        HeadlessBot = 16,
        iOS = 32,
        Android = 64,
        Standalone = 128,
        Pico = 256,
        All = -1
    }
}
