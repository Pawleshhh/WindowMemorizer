namespace WindowMemorizer.Core
{
    public interface IDatabaseEngine
    {

        void AddWindow(WindowInfo windowInfo);

        bool RemoveWindow(string title);

        bool RemoveWindow(nint id);

        bool RemoveWindow(WindowInfo windowInfo);

        void SaveWindowLayout(IEnumerable<WindowInfo> windowInfos);

        IEnumerable<WindowInfo> RetrieveWindowLayout();

    }
}
