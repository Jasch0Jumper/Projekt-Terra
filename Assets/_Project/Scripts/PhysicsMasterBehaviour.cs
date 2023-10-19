using System.Collections.Generic;
using UnityEngine;

namespace Sanomic
{
    public class PhysicsMasterBehaviour: MonoBehaviour
    {
        [SerializeField] private List<ParticeBehaviour> visualizers;
        [Space]
        [SerializeField] [Range(0f, 1f)] private float simulationScale = 1;
        [Space]
        [SerializeField] private bool useFixedUpdate = false;
        [SerializeField] private bool useCustomDeltaTime = true;
        [SerializeField] [Range(0f, 0.1f)] private float customDeltaTime;
        [SerializeField] [Range(0, 200)] private int fixedUpdateCallsPerSecond = 50;
        [SerializeField] [Range(1, 10)] private int simulationStepsPerFrame = 1;
        
        private List<Particle> _particles = new();
        
        private void Awake()
        {
            foreach (var particle in visualizers)
            {
                _particles.Add(particle);
            }
            
            Physics.Scale = simulationScale;
        }
        
        private void Update()
        {
            Time.fixedDeltaTime = 1f / fixedUpdateCallsPerSecond;
            
            if (useFixedUpdate) return;
            for (var i = 0; i < simulationStepsPerFrame; i++)
            {
                var time = useCustomDeltaTime ? customDeltaTime : Time.deltaTime;
                Physics.Step(_particles, time);
            }
        }

        private void FixedUpdate()
        {
            if (!useFixedUpdate) return;
            for (var i = 0; i < simulationStepsPerFrame; i++)
            {
                var time = useCustomDeltaTime ? customDeltaTime : Time.fixedDeltaTime;
                Physics.Step(_particles, time);
            }
        }
    }
}