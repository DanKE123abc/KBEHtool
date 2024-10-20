using System.Windows.Input;
using KBEHtool.Base;

namespace KBEHtool
{
    public enum KeyCode
    {
        None,
        A, B, C, D, E, F, G, H, I, J, K, L, M,
        N, O, P, Q, R, S, T, U, V, W, X, Y, Z,
        F1,F2,F3,F4,F5,F6,F7,F8,F9,F10,F11,F12,
        Key1,Key2,Key3,Key4,Key5,Key6,Key7,Key8,Key9,Key0,
        Num1,Num2,Num3,Num4,Num5,Num6,Num7,Num8,Num9,Num0,
        UpArrow,DownArrow,LeftArrow,RightArrow,
        LeftShift,RightShift,LeftControl,RightControl,LeftAlt,RightAlt,
        Escape,Space,CapsLock,Tab,Enter,Delete,Backspace,Tilde,
        
    }

    public static class KeyCodeExtensions
    {
        public static Key ToKey(this KeyCode keyCode)
        {
            return KeyCodeConverter.ToKey(keyCode);
        }

        public static KeyCode ToKeyCode(this Key key)
        {
            return KeyCodeConverter.ToKeyCode(key);
        }

        public static bool isPressed(this KeyCode keyCode)
        {
            return KeyboardState.instance.GetKeyState(keyCode);
        }
    }
}

