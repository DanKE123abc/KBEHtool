using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace KBEHtool.Base;

public static class KeyCodeConverter
{

    private static readonly Dictionary<KeyCode, Key> keyCodeToKeyMap = new Dictionary<KeyCode, Key>
    {
        { KeyCode.A, Key.A }, { KeyCode.B, Key.B }, { KeyCode.C, Key.C }, { KeyCode.D, Key.D },
        { KeyCode.E, Key.E }, { KeyCode.F, Key.F }, { KeyCode.G, Key.G }, { KeyCode.H, Key.H },
        { KeyCode.I, Key.I }, { KeyCode.J, Key.J }, { KeyCode.K, Key.K }, { KeyCode.L, Key.L },
        { KeyCode.M, Key.M }, { KeyCode.N, Key.N }, { KeyCode.O, Key.O }, { KeyCode.P, Key.P },
        { KeyCode.Q, Key.Q }, { KeyCode.R, Key.R }, { KeyCode.S, Key.S }, { KeyCode.T, Key.T },
        { KeyCode.U, Key.U }, { KeyCode.V, Key.V }, { KeyCode.W, Key.W }, { KeyCode.X, Key.X },
        { KeyCode.Y, Key.Y }, { KeyCode.Z, Key.Z },
        //---
        { KeyCode.F1, Key.F1 }, { KeyCode.F2, Key.F2 }, { KeyCode.F3, Key.F3 }, { KeyCode.F4, Key.F4 },
        { KeyCode.F5, Key.F5 }, { KeyCode.F6, Key.F6 }, { KeyCode.F7, Key.F7 }, { KeyCode.F8, Key.F8 }, 
        { KeyCode.F9, Key.F9 }, { KeyCode.F10, Key.F10 }, { KeyCode.F11, Key.F11 }, { KeyCode.F12, Key.F12 },
        //---
        { KeyCode.Key1, Key.D1 }, { KeyCode.Key2, Key.D2 }, { KeyCode.Key3, Key.D3 },
        { KeyCode.Key4, Key.D4 }, { KeyCode.Key5, Key.D5 }, { KeyCode.Key6, Key.D6 },
        { KeyCode.Key7, Key.D7 }, { KeyCode.Key8, Key.D8 }, { KeyCode.Key9, Key.D9 }, { KeyCode.Key0, Key.D0 },
        //---
        { KeyCode.Num1, Key.NumPad1 }, { KeyCode.Num2, Key.NumPad2 }, { KeyCode.Num3, Key.NumPad3 },
        { KeyCode.Num4, Key.NumPad4 }, { KeyCode.Num5, Key.NumPad5 }, { KeyCode.Num6, Key.NumPad6 }, 
        { KeyCode.Num7, Key.NumPad7 }, { KeyCode.Num8, Key.NumPad8 }, { KeyCode.Num9, Key.NumPad9 }, { KeyCode.Num0, Key.NumPad0 }, 
        //---
        { KeyCode.UpArrow, Key.Up }, { KeyCode.DownArrow, Key.Down }, { KeyCode.LeftArrow, Key.Left }, { KeyCode.RightArrow, Key.Right },
        { KeyCode.LeftShift, Key.LeftShift }, { KeyCode.RightShift, Key.RightShift },
        { KeyCode.LeftControl, Key.LeftCtrl }, { KeyCode.RightControl, Key.RightCtrl },
        { KeyCode.LeftAlt, Key.LeftAlt }, { KeyCode.RightAlt, Key.RightAlt },
        { KeyCode.Escape, Key.Escape }, { KeyCode.Space, Key.Space }, { KeyCode.CapsLock, Key.CapsLock }, { KeyCode.Tab, Key.Tab },
        { KeyCode.Enter, Key.Enter }, { KeyCode.Delete, Key.Delete }, { KeyCode.Backspace, Key.Back }, { KeyCode.Tilde, Key.Oem8 },
    };

    private static readonly Dictionary<KeyCode, byte> keyCodeToBvkMap = new Dictionary<KeyCode, byte>
    {
        { KeyCode.A, ByteVirtualKey.vbKeyA }, { KeyCode.B, ByteVirtualKey.vbKeyB }, { KeyCode.C, ByteVirtualKey.vbKeyC }, 
        { KeyCode.D, ByteVirtualKey.vbKeyD }, { KeyCode.E, ByteVirtualKey.vbKeyE }, { KeyCode.F, ByteVirtualKey.vbKeyF }, 
        { KeyCode.G, ByteVirtualKey.vbKeyG }, { KeyCode.H, ByteVirtualKey.vbKeyH }, { KeyCode.I, ByteVirtualKey.vbKeyI }, 
        { KeyCode.J, ByteVirtualKey.vbKeyJ }, { KeyCode.K, ByteVirtualKey.vbKeyK }, { KeyCode.L, ByteVirtualKey.vbKeyL },
        { KeyCode.M, ByteVirtualKey.vbKeyM }, { KeyCode.N, ByteVirtualKey.vbKeyN }, { KeyCode.O, ByteVirtualKey.vbKeyO }, 
        { KeyCode.P, ByteVirtualKey.vbKeyP }, { KeyCode.Q, ByteVirtualKey.vbKeyQ }, { KeyCode.R, ByteVirtualKey.vbKeyR }, 
        { KeyCode.S, ByteVirtualKey.vbKeyS }, { KeyCode.T, ByteVirtualKey.vbKeyT }, { KeyCode.U, ByteVirtualKey.vbKeyU }, 
        { KeyCode.V, ByteVirtualKey.vbKeyV }, { KeyCode.W, ByteVirtualKey.vbKeyW }, { KeyCode.X, ByteVirtualKey.vbKeyX }, 
        { KeyCode.Y, ByteVirtualKey.vbKeyY }, { KeyCode.Z, ByteVirtualKey.vbKeyZ },
        //---
        { KeyCode.F1, ByteVirtualKey.vbKeyF1 }, { KeyCode.F2, ByteVirtualKey.vbKeyF2}, { KeyCode.F3, ByteVirtualKey.vbKeyF3},
        { KeyCode.F4, ByteVirtualKey.vbKeyF4 }, { KeyCode.F5, ByteVirtualKey.vbKeyF5}, { KeyCode.F6, ByteVirtualKey.vbKeyF6},
        { KeyCode.F7, ByteVirtualKey.vbKeyF7 }, { KeyCode.F8, ByteVirtualKey.vbKeyF8}, { KeyCode.F9, ByteVirtualKey.vbKeyF9},
        { KeyCode.F10, ByteVirtualKey.vbKeyF10 }, { KeyCode.F11, ByteVirtualKey.vbKeyF11}, { KeyCode.F12, ByteVirtualKey.vbKeyF12},
        //---
        { KeyCode.Key1, ByteVirtualKey.vbKey1 }, { KeyCode.Key2, ByteVirtualKey.vbKey2}, { KeyCode.Key3, ByteVirtualKey.vbKey3}, 
        { KeyCode.Key4, ByteVirtualKey.vbKey4 }, { KeyCode.Key5, ByteVirtualKey.vbKey5}, { KeyCode.Key6, ByteVirtualKey.vbKey6},
        { KeyCode.Key7, ByteVirtualKey.vbKey7 }, { KeyCode.Key8, ByteVirtualKey.vbKey8}, { KeyCode.Key9, ByteVirtualKey.vbKey9},
        { KeyCode.Key0, ByteVirtualKey.vbKey0 },
        //---
        { KeyCode.Num1, ByteVirtualKey.vbKeyNumpad1}, { KeyCode.Num2, ByteVirtualKey.vbKeyNumpad2}, 
        { KeyCode.Num3, ByteVirtualKey.vbKeyNumpad3}, { KeyCode.Num4, ByteVirtualKey.vbKeyNumpad4}, 
        { KeyCode.Num5, ByteVirtualKey.vbKeyNumpad5}, { KeyCode.Num6, ByteVirtualKey.vbKeyNumpad6}, 
        { KeyCode.Num7, ByteVirtualKey.vbKeyNumpad7}, { KeyCode.Num8, ByteVirtualKey.vbKeyNumpad8}, 
        { KeyCode.Num9, ByteVirtualKey.vbKeyNumpad9}, { KeyCode.Num0, ByteVirtualKey.vbKeyNumpad0}, 
        //---
        { KeyCode.UpArrow, ByteVirtualKey.vbKeyUp}, { KeyCode.DownArrow, ByteVirtualKey.vbKeyDown}, { KeyCode.LeftArrow, ByteVirtualKey.vbKeyLeft}, { KeyCode.RightArrow, ByteVirtualKey.vbKeyRight},
        { KeyCode.LeftShift, ByteVirtualKey.vbKeyShift}, { KeyCode.RightShift, ByteVirtualKey.vbKeyShift},
        { KeyCode.LeftControl, ByteVirtualKey.vbKeyControl}, { KeyCode.RightControl, ByteVirtualKey.vbKeyControl},
        { KeyCode.LeftAlt, ByteVirtualKey.vbKeyAlt}, { KeyCode.RightAlt, ByteVirtualKey.vbKeyAlt},
        { KeyCode.Escape, ByteVirtualKey.vbKeyEscape}, { KeyCode.Space, ByteVirtualKey.vbKeySpace}, 
        { KeyCode.CapsLock, ByteVirtualKey.vbKeyCapital}, { KeyCode.Tab, ByteVirtualKey.vbKeyTab},
        { KeyCode.Enter, ByteVirtualKey.vbKeyReturn}, { KeyCode.Delete, ByteVirtualKey.vbKeyDelete}, 
        { KeyCode.Backspace, ByteVirtualKey.vbKeyBack}, { KeyCode.Tilde, ByteVirtualKey.vbKeyOemtilde},
        
    };
    
    public static Key ToKey(KeyCode keyCode)
    {
        return keyCodeToKeyMap.TryGetValue(keyCode, out var key) ? key : Key.None;
    }

    public static KeyCode ToKeyCode(Key key)
    {
        foreach (var pair in keyCodeToKeyMap)
        {
            if (pair.Value == key)
            {
                return pair.Key;
            }
        }

        return KeyCode.None;
    }
    
    public static byte ToVirtualKey(KeyCode keyCode)
    {
        return keyCodeToBvkMap.TryGetValue(keyCode, out var key) ? key : (byte)0;
    }
    
    public static KeyCode ToKeyCode(byte bvk)
    {
        foreach (var pair in keyCodeToBvkMap)
        {
            if (pair.Value == bvk)
            {
                return pair.Key;
            }
        }

        return KeyCode.None;
    }
    
}