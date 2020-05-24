using System;
using UnityEngine;

public class CollisionsChecker : MonoBehaviour
{
    public event Action OnObstacleHit;
    public event Action<GameObject> OnPointHit;
    
    [SerializeField] private Transform interactionCheckPoint;
    [SerializeField] private LayerMask pointLayerMask;
    [SerializeField] private LayerMask obstacleLayerMask;
    

    private const float InteractionCheckRadius = 0.05f;

    private void Start()
    {
        GetComponent<SnakeController>().OnDestinationSet += CheckCollisions;
    }

    private void CheckCollisions()
    {
        Vector3 interactionPoint = interactionCheckPoint.position;
        Collider2D point =
            Physics2D.OverlapCircle(interactionPoint, InteractionCheckRadius, pointLayerMask);

        bool isObstacleInFront =
            Physics2D.OverlapCircle(interactionPoint, InteractionCheckRadius, obstacleLayerMask);

        if (isObstacleInFront)
        {
            OnObstacleHit?.Invoke();
        }
        
        if (point != null)
        {
            OnPointHit?.Invoke(point.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(interactionCheckPoint.position, InteractionCheckRadius);
    }
}