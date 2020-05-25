using Core;
using UnityEngine;

namespace Collectables
{
    public class Extender : Collectable
    {
        private SnakeController _snakeController;

        public void Construct(SnakeController snakeController)
        {
            _snakeController = snakeController;
        }
        
        public override void Collect()
        {
            _snakeController.Expand();
            Destroy(gameObject);
        }
    }
}