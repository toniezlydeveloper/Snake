using UnityEngine;

namespace Collectables
{
    public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] private int pointValue;

        public int PointValue => pointValue;
        
        public abstract void Collect();
    }
}