using Core;
using UnityEngine;

namespace Collectables
{
    public class Extender : MonoBehaviour, ICollectable
    {
        private SnakeController _snakeController;
        
        public void Construct(SnakeController snakeController)
        {
            _snakeController = snakeController;
        }
        
        public void Collect()
        {
            _snakeController.Expand();
            Destroy(gameObject);
        }
    }
}