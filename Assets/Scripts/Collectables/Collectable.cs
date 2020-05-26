using UnityEngine;

namespace Collectables
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(SpriteRenderer))]
    public abstract class Collectable : MonoBehaviour
    {
        [SerializeField] private int pointValue;
        [SerializeField] private AudioClip collectSfx;

        private AudioSource _audioSource;

        public int PointValue => pointValue;
        
        private void Start()
        {
            _audioSource = GetComponentInParent<AudioSource>();
        }

        public virtual void Collect()
        {
            _audioSource.PlayOneShot(collectSfx);
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        
    }
}