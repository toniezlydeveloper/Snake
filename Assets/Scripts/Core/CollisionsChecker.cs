using System;
using Collectables;
using Obstacles;
using UnityEngine;

namespace Core
{
    public class CollisionsChecker : MonoBehaviour
    {
        public event Action<IObstacle> OnObstacleHit;
        public event Action<ICollectable> OnCollectableHit;
    
        [SerializeField] private Transform interactionCheckPoint;
        [SerializeField] private LayerMask collectableLayerMask;
        [SerializeField] private LayerMask obstacleLayerMask;
    

        private const float InteractionCheckRadius = 0.05f;

        private void Start()
        {
            GetComponent<SnakeController>().OnDestinationSet += CheckCollisions;
        }

        private void CheckCollisions()
        {
            Vector3 checkPoint = interactionCheckPoint.position;
            ICollectable collectable =
                Physics2D.OverlapCircle(checkPoint, InteractionCheckRadius, collectableLayerMask)?.GetComponent<ICollectable>();

            IObstacle obstacle =
                Physics2D.OverlapCircle(checkPoint, InteractionCheckRadius, obstacleLayerMask)?.GetComponent<IObstacle>();

            if (obstacle != null)
            {
                OnObstacleHit?.Invoke(obstacle);
            }
        
            if (collectable != null)
            {
                OnCollectableHit?.Invoke(collectable);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(interactionCheckPoint.position, InteractionCheckRadius);
        }
    }
}