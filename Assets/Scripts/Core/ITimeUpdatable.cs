namespace com.ARTillery.Core
{
    public interface ITimeUpdatable
    {
        public void UpdateObject(float deltaTime);
        public void AddToUpdatables(ITimeUpdatable updatable);
    }
}
