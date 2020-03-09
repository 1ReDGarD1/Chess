namespace MyChess.Scripts.Display.Foundation.View
{
    public interface IViewElement 
    {
        #region IViewElement
        
        bool IsVisible { get; }
        
        void Show();
        void Hide();

        #endregion
    }
}