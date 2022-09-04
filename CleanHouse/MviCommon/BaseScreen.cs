namespace CleanHouse.MviCommon
{
    public abstract class BaseScreen : BaseFragment { }
    
    public abstract class BaseScreen<TPresenter> : BaseFragment<TPresenter> where TPresenter : BasePresenter { }
}