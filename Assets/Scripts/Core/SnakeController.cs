using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class SnakeController : MonoBehaviour
    {
        public event Action OnDestinationSet;
    
        [Header("Settings")]
        [SerializeField] private int stepLength;
        [SerializeField] private float tickInterval;
        [SerializeField] private float moveSpeedMultiplier;
        [Header("References")]
        [SerializeField] private GameObject tailFragmentPrefab;
        [SerializeField] private List<Transform> tail;

        private Direction _currentDirection;
        private Direction _previousDirection;
        private readonly List<Vector3> _destinationPoints = new List<Vector3>();

        private void Start()
        {
            InvokeRepeating(nameof(FinishMoveAndSetNextDestination), tickInterval, tickInterval);
        }

        private void Update()
        {
            Move();
            TryChangingDirection();
        }

        public void Expand()
        {
            Vector3 lastTilesPositionDifference = tail[tail.Count - 2].position - tail[tail.Count - 1].position;
            Vector3 newTailFragmentPosition = tail[tail.Count - 1].position + lastTilesPositionDifference;
            tail.Add(Instantiate(tailFragmentPrefab, newTailFragmentPosition, Quaternion.identity).transform);
        }

        private void Move()
        {
            for (int i = 0; i < _destinationPoints.Count; i++)
            {
                tail[i].position =
                    Vector3.Lerp(tail[i].position, _destinationPoints[i],
                        moveSpeedMultiplier / tickInterval * Time.deltaTime);
            }
        }

        private void TryChangingDirection()
        {
            if (Input.GetKeyDown(KeyCode.W) && _previousDirection != Direction.Down)
            {
                _currentDirection = Direction.Up;
            }
            if (Input.GetKeyDown(KeyCode.S) && _previousDirection != Direction.Up)
            {
                _currentDirection = Direction.Down;
            }
            if (Input.GetKeyDown(KeyCode.A) && _previousDirection != Direction.Right)
            {
                _currentDirection = Direction.Left;
            }
            if (Input.GetKeyDown(KeyCode.D) && _previousDirection != Direction.Left)
            {
                _currentDirection = Direction.Right;
            }
        }

        private void FinishMoveAndSetNextDestination()
        {
            FinishMove();
            SetDestinationPoints();
        }

        private void FinishMove()
        {
            _previousDirection = _currentDirection;
        
            for (int i = 0; i < _destinationPoints.Count; i++)
            {
                tail[i].position = _destinationPoints[i];
            }
        
            _destinationPoints.Clear();
        }

        private void SetDestinationPoints()
        {
            switch(_currentDirection)
            {
                case Direction.Up:
                    _destinationPoints.Add(tail[0].position + (Vector3.up * stepLength));
                    tail[0].rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case Direction.Left:
                    _destinationPoints.Add(tail[0].position + (Vector3.left * stepLength));
                    tail[0].rotation = Quaternion.Euler(0, 0, 90);
                    break;
                case Direction.Right:
                    _destinationPoints.Add(tail[0].position + (Vector3.right * stepLength));
                    tail[0].rotation = Quaternion.Euler(0, 0, -90);
                    break;
                case Direction.Down:
                    _destinationPoints.Add(tail[0].position + (Vector3.down * stepLength));
                    tail[0].rotation = Quaternion.Euler(0, 0, 180);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
            for (int i = 0; i < tail.Count - 1; i++)
            {
                _destinationPoints.Add(tail[i].position);
            }
        
            OnDestinationSet?.Invoke();
        }
    }
}
