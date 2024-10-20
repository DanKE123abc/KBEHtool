using KBEHtool.Utils;

namespace KBEHtool.Base;

public class KeyboardEventCenter
{
    private const string KeyboardDownEventName = "KeyboardDownEvent";
    
    private const string KeyboardUpEventName = "KeyboardUpEvent";
    
    public static void AddKeyDownListener(Action<KeyCode> action)
    {
        EventCenter.instance.AddEventListener(KeyboardDownEventName, action);
    }
    
    public static void TriggerKeyDown(KeyCode keyCode)
    {
        EventCenter.instance.EventTrigger(KeyboardDownEventName, keyCode);
    }

    public static void RemoveKeyDownListener(Action<KeyCode> action)
    {
        EventCenter.instance.RemoveEventListener(KeyboardDownEventName, action);
    }
    
    
    public static void AddKeyUpListener(Action<KeyCode> action)
    {
        EventCenter.instance.AddEventListener(KeyboardUpEventName, action);
    }
    
    public static void TriggerKeyUp(KeyCode keyCode)
    {
        EventCenter.instance.EventTrigger(KeyboardUpEventName, keyCode);
    }

    public static void RemoveKeyUpListener(Action<KeyCode> action)
    {
        EventCenter.instance.RemoveEventListener(KeyboardUpEventName, action);
    }


    public static void RemoveAllListener()
    {
        EventCenter.instance.Clear();
    }
}
