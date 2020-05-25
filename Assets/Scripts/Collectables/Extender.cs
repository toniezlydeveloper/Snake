using Core;
using UnityEngine;

namespace Collectables
{
    public class Extender : MonoBehaviour, ICollectable
    {
        [SerializeField] private int pointValue;
        
        private SnakeController _snakeController;

        public int PointValue => pointValue;

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