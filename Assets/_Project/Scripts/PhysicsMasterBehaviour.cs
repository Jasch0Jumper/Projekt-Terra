using System;
using System.Collections.Generic;
using UnityEngine;

namespace Terra
{
    public class PhysicsMasterBehaviour: MonoBehaviour
    {
        [SerializeField] private List<ParticeBehaviour> particles;
        [Space]
        [SerializeField] [Range(0f, 1f)] private float simulationScale = 1;
        [Space]
        [SerializeField] private bool useFixedUpdate = false;
        [SerializeField] private bool useCustomDeltaTime = true;
        [SerializeField] [Range(0f, 0.1f)] private float customDeltaTime;
        [SerializeField] [Range(0, 200)] private int fixedUpdateCallsPerSecond = 50;
        [SerializeField] [Range(1, 10)] private int simulationStepsPerFrame = 1;
        
        private List<IParticle> _particlesInterfaces = new();
        
        private void Awake()
        {
            foreach (var particle in particles)
            {
                _particlesInterfaces.Add(particle);
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
                Physics.Step(_particlesInterfaces, time);
            }
        }

        private void FixedUpdate()
        {
            if (!useFixedUpdate) return;
            for (var i = 0; i < simulationStepsPerFrame; i++)
            {
                var time = useCustomDeltaTime ? customDeltaTime : Time.fixedDeltaTime;
                Physics.Step(_particlesInterfaces, time);
            }
        }
    }
}