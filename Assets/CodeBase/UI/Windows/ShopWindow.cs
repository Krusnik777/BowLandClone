namespace CodeBase.UI.Windows
{
    public class ShopWindow : WindowBase
    {
        protected override void OnClose()
        {
            Destroy(gameObject);
        }
    }
}
