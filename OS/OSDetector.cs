namespace Scripter.OS
{
    public class OSDetector
    {
        //game's always going to run under wine, so here's where i take from a friend,
        //and see if windows processes are running or not, which will basically act as a win/linux flag
        
        /// <summary>
        /// Tries to find out what OS we're running under
        /// </summary>
        /// <returns>True if Linux, False if Windows</returns>
        public static bool OS()
        {
            return System.Diagnostics.Process.GetProcessesByName("winlogon").Length == 0;
        }
        
    }
}