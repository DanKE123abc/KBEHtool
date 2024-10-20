using KBEHtool.Base;

namespace KBEHtool;

public class KeyAction
{
    
    public static bool IsKeyPressed(KeyCode keyCode)
    {
        return KeyboardState.instance.GetKeyState(keyCode);
    }
    
    public static bool IsKeyReleased(KeyCode keyCode)
    {
        return !KeyboardState.instance.GetKeyState(keyCode);
    }

    public static bool IsAnykeyPressed
    {
        get
        {
            return KeyboardState.instance.IsStateTrue();
        }
    }
    
    public static void AddKeyDownListener(Action<KeyCode> action)
    {
        KeyboardEventCenter.AddKeyDownListener(action);   
    }

    public static void RemoveKeyDownListener(Action<KeyCode> action)
    {
        KeyboardEventCenter.RemoveKeyDownListener(action);
    }
    
    public static void AddKeyUpListener(Action<KeyCode> action)
    {
        KeyboardEventCenter.AddKeyUpListener(action);
    }

    public static void RemoveKeyUpListener(Action<KeyCode> action)
    {
        KeyboardEventCenter.RemoveKeyUpListener(action);
    }

    public static void RemoveAllKeyListener()
    {
        KeyboardEventCenter.RemoveAllListener();
    }
    
    public static void PressKey(KeyCode keyCode ,int delayTime = 0)
    {
        var bvk = KeyCodeConverter.ToVirtualKey(keyCode);
        ByteVirtualKey.keybd_event(bvk, 0, 0, 0);
        if (delayTime >= 0)
        {
            Thread.Sleep(delayTime);
            ByteVirtualKey.keybd_event(bvk, 0, 2, 0);
        }
    }

    public static void ReleaseKey(KeyCode keyCode)
    {
        var bvk = KeyCodeConverter.ToVirtualKey(keyCode);
        ByteVirtualKey.keybd_event(bvk, 0, 2, 0);
    }
    
}