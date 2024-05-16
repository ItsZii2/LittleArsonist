using UnityEngine;

namespace UnityStandardAssets.Effects
{
    public class ParticleSystemMultiplier : MonoBehaviour
    {
        public float multiplier = 1;
        private bool shouldPlayOnStart = true; // Flag to control initial playback

        private void Start()
        {
            // Set the shouldPlayOnStart flag based on whether the parent FireController wants to delay emission
            FireController fireController = GetComponentInParent<FireController>();
            if (fireController != null)
            {
                shouldPlayOnStart = !fireController.IsFireSpreading; // Invert the flag
            }

            var systems = GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem system in systems)
            {
                ParticleSystem.MainModule mainModule = system.main;
                mainModule.startSizeMultiplier *= multiplier;
                mainModule.startSpeedMultiplier *= multiplier;
                mainModule.startLifetimeMultiplier *= Mathf.Lerp(multiplier, 1, 0.5f);

                // Clear and play particles only if the flag is set
                if (shouldPlayOnStart)
                {
                    
                    system.Play();
                }
            }
        }

        // Additional method to manually play particles after a delay
        public void PlayParticles()
        {
            var systems = GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem system in systems)
            {
                
                system.Play();
            }
        }
        public void PauseParticles()
        {
            var systems = GetComponentsInChildren<ParticleSystem>();
            foreach (ParticleSystem system in systems)
            {
                system.Stop(); // Or use system.Pause() to retain particle state
            }
        }
    }
}