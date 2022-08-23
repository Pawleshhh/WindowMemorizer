namespace WindowMemorizer.Core
{
    public interface IWindowEngine
    {

        void MoveWindow(nint id, int x, int y);

        void ResizeWindow(nint id, double width, double height);

        nint GetSelectedWindow();

        IEnumerable<nint> GetOpenWindows();

        Point GetWindowPosition(nint id);

        Size GetWindowSize(nint id);

    }
}
