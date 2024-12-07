using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace KBEHtool.Base;

public class KeyboardHook
{
    public int WM_KEYDOWN = 0x0100;
    public int WM_KEYUP = 0x0101;
    public int WM_SYSKEYDOWN = 0x0104;
    public int WM_SYSKEYUP = 0x0105;
    public int WH_KEYBOARD_LL = 13;
    
    List<string> keyList = new List<string>();
    private HOOKPROC hOOKPROC;
    
    [StructLayout(LayoutKind.Sequential)] //声明键盘钩子的封装结构类型
    public class KeyBoardHookStruct
    {
        public int vkCode; 
        public int scanCode;
        public int flags;
        public int time;
        public IntPtr dwExtraInfo;
    }
    
    private IntPtr hHook;
    
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowsHookEx(int idHook,HOOKPROC lpfn,IntPtr hmod,uint dwThreadId);
    
    public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);
    
    //卸下钩子的函数 
    [DllImport("user32.dll")]
    public static extern bool UnhookWindowsHookEx(IntPtr idHook);
    
    //下一个钩挂的函数 
    [DllImport("user32.dll")]
    public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);
    
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string lpModuleName);
    
    public IntPtr CallBackFunc(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            KeyBoardHookStruct keyBoardHookStruct =
                (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
            Key key = KeyInterop.KeyFromVirtualKey(keyBoardHookStruct.vkCode);
            if (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN)
            {
                KeyDown(key);
            }

            if (wParam == (IntPtr)WM_KEYUP || wParam == (IntPtr)WM_SYSKEYUP)
            {
                KeyUp(key);
            }
        }

        return CallNextHookEx(hHook,nCode, wParam,lParam);
    }
    
    private void KeyDown(Key key)
    {
        KeyboardEventCenter.TriggerKeyDown(KeyCodeConverter.ToKeyCode(key));
        KeyboardState.instance.SetKeyState(KeyCodeConverter.ToKeyCode(key),true);
    }

    public void KeyUp(Key key)
    {
        KeyboardEventCenter.TriggerKeyUp(KeyCodeConverter.ToKeyCode(key));
        KeyboardState.instance.SetKeyState(KeyCodeConverter.ToKeyCode(key),false);
    }

    public KeyboardHook()
    {
        hOOKPROC = new HOOKPROC(CallBackFunc);
        IntPtr hModule = GetModuleHandle(null);
        hHook = SetWindowsHookEx(WH_KEYBOARD_LL, hOOKPROC, hModule, 0);
    }

    public void Unhook()
    {
        UnhookWindowsHookEx(hHook);
    }
    
}