using System;

namespace TheLastFacepuncher
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TLFPGame game = new TLFPGame())
            {
                game.Run();
            }
        }
    }
#endif
}

