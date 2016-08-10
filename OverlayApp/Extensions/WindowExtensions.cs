using System;
using System.Runtime.InteropServices;

namespace OverlayApp
{
    public static class WindowExtensions
    {

        enum nIndex
        {
            GCL_CBCLSEXTRA = -20,
            GCL_CBWNDEXTRA = -18,
            GCL_HBRBACKGROUND =-10,
            GCL_HCURSOR = -12,
            GCL_HICON = -14,
            GCL_HIOCNSM = -34,
            GCL_HMODULE = -16,
            GCL_MENUNAME = -8,
            GCL_STYLE = -26,
            GCL_WNDPROC = -24,
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        public static IntPtr SetClassLong(HandleRef hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size > 4)
                return SetClassLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetClassLongPtr32(hWnd, nIndex, unchecked((uint)dwNewLong.ToInt32())));
        }

        [DllImport("user32.dll", EntryPoint = "SetClassLong")]
        public static extern uint SetClassLongPtr32(HandleRef hWnd, int nIndex, uint dwNewLong);

        [DllImport("user32.dll", EntryPoint = "SetClassLongPtr")]
        public static extern IntPtr SetClassLongPtr64(HandleRef hWnd, int nIndex, IntPtr dwNewLong);
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static void setParent(IntPtr child, IntPtr parent)
        {

            SetClassLong(new HandleRef(child,parent), (int)nIndex.GCL_STYLE, new IntPtr(0x0080));
            SetParent(child, parent);
        }
        public static void setParentToGw2(IntPtr child)
        {
            IntPtr gw2 = FindWindow("ArenaNet_Dx_Window_Class", "Guild Wars 2");
            setParent(child, gw2);
        }
    }
}
