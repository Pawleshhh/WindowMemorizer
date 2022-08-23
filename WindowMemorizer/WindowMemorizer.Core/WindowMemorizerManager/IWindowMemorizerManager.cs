namespace WindowMemorizer.Core
{
    public interface IWindowMemorizerManager
    {

        void MemorizeWindowLayout(IEnumerable<WindowInfo> windowInfos);

        void SetupWindowLayout(IEnumerable<WindowInfo> windowInfos);

        void RemoveMemorizedWindowLayout();

        IEnumerable<WindowInfo> GetMemorizedWindowLayout();

    }
}
