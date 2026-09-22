namespace FirstApi.Services
{
    public abstract class AbstractionService
    {
        public bool DoAction(Action action)
        {
            try
            {
                action.Invoke();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
