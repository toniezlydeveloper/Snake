using Core;
using UnityEngine;
using Utility;

namespace Collectables
{
    public class TimeModificator : MonoBehaviour, ICollectable
    {
        [SerializeField] private int pointValue;
        [SerializeField] private float speedUpMultiplier;
        [SerializeField] private float modificationDuration;

        private static int modificationsCount;
        
        public int PointValue => pointValue;
        
        public void Collect()
        {
            TimeController.MultiplyTimeScale(speedUpMultiplier);
            Invoke(nameof(RemoveModifierAndDestroyObject), modificationDuration * speedUpMultiplier);
            gameObject.SetActive(false);
            modificationsCount++;
        }

        private void RemoveModifierAndDestroyObject()
        {
            Destroy(gameObject);
            if (--modificationsCount > 0)
            {
                return;
            }
            
            TimeController.ResetTimeScale();
        }
    }
}