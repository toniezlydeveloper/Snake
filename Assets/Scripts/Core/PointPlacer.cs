using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PointPlacer : MonoBehaviour
    {
        [SerializeField] private float tileSize;
        [SerializeField] private Transform rightUpperPoint;
        [SerializeField] private Transform leftBottomPoint;
        [SerializeField] private GameObject pointPrefab;

        private readonly List<Vector3> _validPoints = new List<Vector3>();

        private const float PointCheckRadius = 0.05f;
    
        private void Start()
        {
            SortPoints();
        }

        public void PlaceNextPoint()
        {
            SortPoints();
            Instantiate(pointPrefab, DesignatePointPosition(), Quaternion.identity);
        }

        private void SortPoints()
        {
            _validPoints.Clear();
        
            float yPosition = leftBottomPoint.position.y;
            float xPosition = leftBottomPoint.position.x;

            while (yPosition < rightUpperPoint.position.y)
            {
                while (xPosition < rightUpperPoint.position.x)
                {
                    Vector2 point = new Vector2(xPosition, yPosition);
                
                    if (!Physics2D.OverlapCircle(point, PointCheckRadius))
                    {
                        _validPoints.Add(point);
                    }

                    xPosition += tileSize;
                }

                yPosition += tileSize;
            }
        }

        private Vector2 DesignatePointPosition()
        {
            int randomIndex = Random.Range(0, _validPoints.Count - 1);
            return _validPoints[randomIndex];
        }
    }
}