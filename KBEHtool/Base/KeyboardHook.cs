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
    List<string> keyList = new List<string>();
    private HOOKPROC hOOKPROC;
    
    [StructLayout(LayoutKind.Sequential)] //声明键盘钩子的封装结构类型
    public class KeyBoardHookStruct
    {
        public int vkCode; 
        public int scanCode;
        public int flags;
        public int time;
        public int dwExtraInfo;
    }
    
    private int hHook;
    [DllImport("user32.dll")]
    public static extern IntPtr SetWindowsHookEx(int idHook,HOOKPROC lpfn,IntPtr hmod,int dwThreadId);
    
    public delegate int HOOKPROC(int nCode, int wParam, IntPtr lParam);
    
    //卸下钩子的函数 
    [DllImport("user32.dll")]
    public static extern bool UnhookWindowsHookEx(int idHook);
    
    //下一个钩挂的函数 
    [DllImport("user32.dll")]
    public static extern int CallNextHookEx(int idHook, int nCode, int wParam, IntPtr lParam);
    
    public int CallBackFunc(int nCode, int wParam, IntPtr lParam)
    {
        KeyBoardHookStruct keyBoardHookStruct = (KeyBoardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyBoardHookStruct));
        Key key = KeyInterop.KeyFromVirtualKey(keyBoardHookStruct.vkCode);
        if(wParam==WM_KEYDOWN)
        {
            KeyDown(key);
        }
        if (wParam == WM_KEYUP)
        {
            KeyUp(key);
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

    public KeyboardHook(IntPtr handle)
    {
        hOOKPROC = new HOOKPROC(CallBackFunc);
        hHook = (int)SetWindowsHookEx(13, hOOKPROC, handle, 0);
    }
    
    public void Unhook()
    {
        UnhookWindowsHookEx(hHook);
    }
    
}