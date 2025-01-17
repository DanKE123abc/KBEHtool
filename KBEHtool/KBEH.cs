using System.Windows.Interop;
using KBEHtool.Base;
using KBEHtool.Utils;

namespace KBEHtool;

public class KBEH
{
    private static bool isRunning = false;
    private static KeyboardHook keyboardHook= null;

    public static bool Start()
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
                return false;
            }
        }
        return true;
    }

    public static bool Stop()
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
                return false;
            }
        }
        return true;
    }
}