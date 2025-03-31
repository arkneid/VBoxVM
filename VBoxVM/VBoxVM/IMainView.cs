namespace VBoxVM
{
    public interface IMainView
    {
        event EventHandler ChangeClickEvent;
        string FolderPath { get; }
    }
}