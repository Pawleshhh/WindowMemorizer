using System.Runtime.InteropServices;
using System.Text;
using HWND = System.IntPtr;

namespace WindowMemorizer.Core
{
    public class WindowEngineImplementation : IWindowEngine
    {

        #region IWindowEngine

        public IEnumerable<nint> GetOpenWindows()
        {
            HWND shellWindow = GetShellWindow();
            List<nint> windows = new List<nint>();

            EnumWindows((hWnd, lParam) =>
            {
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                windows.Add(hWnd);

                return true;
            }, 0);

            return windows;
        }

        public nint GetSelectedWindow()
        {
            if (GetCursorPos(out var point))
            {
                return WindowFromPoint(point);
            }

            return IntPtr.Zero;
        }

        public Point GetWindowPosition(nint id)
        {
            Rect rect = new Rect();
            GetWindowRect(id, ref rect);

            return new Point(rect.Left, rect.Top);
        }

        public Size GetWindowSize(nint id)
        {
            Rect rect = new Rect();
            GetWindowRect(id, ref rect);
            var (width, height) = RectToWindowSize(rect);

            return new Size((int)width, (int)height);
        }

        public void MoveWindow(nint id, int x, int y, int width, int height)
        {
            MoveWindow(id, x, y, width, height, true);
        }

        #endregion

        #region Helpers

        private (double Width, double Height) RectToWindowSize(Rect rect)
        {
            var width = rect.Right - rect.Left;
            var height = rect.Bottom - rect.Top;

            return (width, height);
        }

        #endregion

        #region Externals

        private delegate bool EnumWindowsProc(HWND hWnd, int lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(HWND hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(HWND hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(HWND hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(System.Drawing.Point p);

        [DllImport("USER32.DLL")]
        private static extern bool GetCursorPos(out POINT point);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = x;
            }

            public static implicit operator System.Drawing.Point(POINT p)
            {
                return new System.Drawing.Point(p.X, p.Y);
            }

            public static implicit operator POINT(System.Drawing.Point p)
            {
                return new POINT(p.X, p.Y);
            }
        }

        private struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }

            public override string ToString()
            {
                return $"L:{Left}, T{Top}, R:{Right}, B:{Bottom}";
            }
        }

        #endregion

    }
}
