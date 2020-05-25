using UnityEngine;

namespace Utility
{
    [RequireComponent(typeof(Camera))]
    public class CameraSizeAdjuster : MonoBehaviour
    {
        [SerializeField] private float referenceWidth;
        [SerializeField] private float referenceSize;

        private void Start()
        {
            GetComponent<Camera>().orthographicSize = (referenceWidth / Screen.width) * referenceSize;
        }
    }
}