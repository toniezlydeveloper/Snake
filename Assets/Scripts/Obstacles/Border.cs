using UnityEngine;

namespace Obstacles
{
    public class Border : MonoBehaviour, IObstacle
    {
        public bool Collide()
        {
            return true;
        }
    }
}