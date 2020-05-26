using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(AudioSource))]
    public class ButtonAudioService : MonoBehaviour
    {
        [SerializeField] private AudioClip clickSfx;
        
        
        private AudioSource _audioSource;
        
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            GetComponent<Button>().onClick.AddListener(PlayAudio);
        }

        private void PlayAudio()
        {
            _audioSource.PlayOneShot(clickSfx);
        }
    }
}
