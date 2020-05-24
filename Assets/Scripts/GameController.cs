using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SnakeController snakeController;
    [SerializeField] private CollisionsChecker collisionsChecker;
    [SerializeField] private PointPlacer pointPlacer;

    private void Awake()
    {
        collisionsChecker.OnObstacleHit += () => Destroy(snakeController);
        collisionsChecker.OnPointHit += HandlePointHit;
    }

    private void HandlePointHit(GameObject point)
    {
        pointPlacer.PlaceNextPoint();
        snakeController.Expand();
        Destroy(point);
    }
}