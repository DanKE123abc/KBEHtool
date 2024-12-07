using System.Windows.Interop;
using KBEHtool.Base;
using KBEHtool.Utils;

namespace KBEHtool;

public class KBEH
{
    private static bool isRunning = false;
    private static KeyboardHook keyboardHook= null;

    public static bool StartKBEH()
    {
        if (!isRunning)
        {
            try
            {
                keyboardHook = new KeyboardHook();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        Console.WriteLine("KBEH service already running");
        return true;
    }

    public static bool StopKBEH()
    {
        if (isRunning)
        {
            try
            {
                keyboardHook.Unhook();
                EventCenter.instance.Clear();
                KeyboardState.instance.ClearAllKeys();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        Console.WriteLine("KBEH service has stopped running");
        return true;
    }
}