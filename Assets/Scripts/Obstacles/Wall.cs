using UnityEngine;

namespace Obstacles
{
    public class Wall : MonoBehaviour, IObstacle
    {
        public bool Interact()
        {
            return true;
        }
    }
}