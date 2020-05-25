namespace Collectables
{
    public interface ICollectable
    {
        int PointValue { get; }
        
        void Collect();
    }
}