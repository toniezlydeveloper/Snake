using Core;
using UnityEngine;

namespace Collectables
{
    public class TimeModificator : MonoBehaviour, ICollectable
    {
        [SerializeField] private float speedUpMultiplier;
        [SerializeField] private float modificationDuration;
        
        public void Collect()
        {
            TimeController.MultiplyTimeScale(speedUpMultiplier);
            Invoke(nameof(RemoveModifierAndDestroyObject), modificationDuration * speedUpMultiplier);
            gameObject.SetActive(false);
        }

        private void RemoveModifierAndDestroyObject()
        {
            TimeController.ResetTimeScale();
            Destroy(gameObject);
        }
    }
}