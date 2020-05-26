using Core;
using UnityEngine;

namespace Collectables
{
    public class Extender : Collectable
    {
        [SerializeField] private float destroyDelay;
        
        private SnakeController _snakeController;

        public void Construct(SnakeController snakeController)
        {
            _snakeController = snakeController;
        }
        
        public override void Collect()
        {
            base.Collect();
            
            Invoke(nameof(Destroy), destroyDelay);
            _snakeController.Expand();
        }

        private void Destroy()
        {
            Destroy(gameObject);
        }
    }
}