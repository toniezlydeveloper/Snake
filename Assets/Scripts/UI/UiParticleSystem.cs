using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI
{
    public class UiParticleSystem : MonoBehaviour
    {
        [SerializeField] private int particleMaxCount;
        [SerializeField] private int emissionPerSecond;
        [SerializeField] private float rotationAmount;
        [SerializeField] private GameObject particlePrefab;

        private readonly List<GameObject> _particleGameObjects = new List<GameObject>();
        private readonly List<Transform> _simulatedParticleTransforms = new List<Transform>();

        private void Start()
        {
            for (int i = 0; i < particleMaxCount; i++)
            {
                GameObject particle = Instantiate(particlePrefab, transform);
                _particleGameObjects.Add(particle);
                particle.SetActive(false);
            }
            
            InvokeRepeating(nameof(EnableParticles), 1f, 1f);
            gameObject.SetActive(false);
        }

        private void Update()
        {
            foreach (Transform particleTransform in _simulatedParticleTransforms)
            {
                particleTransform.Rotate(0f, 0f, rotationAmount * Time.deltaTime);
            }
        }

        private void EnableParticles()
        {
            int emittedParticles = 0;
            
            for (int i = 0; i < emissionPerSecond; i++)
            {
                if (!_particleGameObjects[i].activeSelf)
                {
                    _simulatedParticleTransforms.Add(_particleGameObjects[i].transform);
                    _simulatedParticleTransforms[i].position = DesignateSpawnPosition();
                    _particleGameObjects[i].SetActive(true);
                    emittedParticles++;
                }

                if (emittedParticles >= emissionPerSecond)
                {
                    return;
                }
            }
        }

        private Vector2 DesignateSpawnPosition()
        {
            return new Vector2(Random.Range(0, Screen.width), 0);
        }
    }
}