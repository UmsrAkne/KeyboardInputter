namespace KeyboardInputter.Models;

using System;
using System.Runtime.InteropServices;

public class KeySender
{
    public void SendKey(short keyCode)
    {
        var inputs = new[]
        {
            new INPUT
            {
                type = NativeMethods.INPUT_KEYBOARD,
                ui = new INPUT_UNION
                {
                    keyboard = new KEYBDINPUT
                    {
                        wVk = keyCode,
                        wScan = (short)NativeMethods.MapVirtualKey(keyCode, 0),
                        dwFlags = NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYDOWN, // キーの押し下げ
                        dwExtraInfo = IntPtr.Zero,
                        time = 0,
                    },
                },
            },
            new INPUT
            {
                type = NativeMethods.INPUT_KEYBOARD,
                ui = new INPUT_UNION
                {
                    keyboard = new KEYBDINPUT
                    {
                        wVk = keyCode,
                        wScan = (short)NativeMethods.MapVirtualKey(keyCode, 0),
                        dwFlags = NativeMethods.KEYEVENTF_EXTENDEDKEY | NativeMethods.KEYEVENTF_KEYUP, // キーの押し上げ
                        dwExtraInfo = IntPtr.Zero,
                        time = 0,
                    },
                },
            },
        };

        NativeMethods.SendInput(2, ref inputs[0], Marshal.SizeOf(inputs[0]));
    }
}