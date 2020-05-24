using Core;
using UnityEngine;

namespace Collectables
{
    public class TimeModificator : MonoBehaviour, ICollectable
    {
        [SerializeField] private float speedUpMultiplier;
        [SerializeField] private float modificationDuration;

        private static int modificationsCount;
        
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