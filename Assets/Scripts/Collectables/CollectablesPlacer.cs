using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Collectables
{
    public class CollectablesPlacer : MonoBehaviour
    {
        [SerializeField] private float tileSize;
        [SerializeField] private Transform rightUpperPoint;
        [SerializeField] private Transform leftBottomPoint;
        [SerializeField] private SnakeController snakeController;
        [SerializeField] private List<GameObject> collectablePrefabs;

        private readonly List<Vector3> _validPlacingPoints = new List<Vector3>();

        private const float PointCheckValidationRadius = 0.05f;
    
        private void Start()
        {
            GetValidPlacingPoints();
            PlaceCollectable();
        }

        public void PlaceCollectable()
        {
            GetValidPlacingPoints();
            Instantiate(DesignatePrefab(), DesignatePointPosition(), Quaternion.identity).GetComponent<Extender>()
                ?.Construct(snakeController);
        }

        private void GetValidPlacingPoints()
        {
            _validPlacingPoints.Clear();
        
            float yPosition = leftBottomPoint.position.y;
            float xPosition = leftBottomPoint.position.x;

            while (yPosition < rightUpperPoint.position.y)
            {
                while (xPosition < rightUpperPoint.position.x)
                {
                    Vector2 point = new Vector2(xPosition, yPosition);
                
                    if (!Physics2D.OverlapCircle(point, PointCheckValidationRadius))
                    {
                        _validPlacingPoints.Add(point);
                    }

                    xPosition += tileSize;
                }

                yPosition += tileSize;
            }
        }

        private Vector2 DesignatePointPosition()
        {
            int randomIndex = Random.Range(0, _validPlacingPoints.Count);
            return _validPlacingPoints[randomIndex];
        }

        private GameObject DesignatePrefab()
        {
            int randomIndex = Random.Range(0, collectablePrefabs.Count);
            return collectablePrefabs[randomIndex];
        }
    }
}