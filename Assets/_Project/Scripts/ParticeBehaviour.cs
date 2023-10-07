using System.Collections.Generic;
using UnityEngine;

namespace Terra
{
    public class ParticeBehaviour: MonoBehaviour, IParticle
    {
        [SerializeField] private ParticleData _data;
        
        public ParticleData Data => _data;

        public Vector3 Position {
            get => transform.position;
            set => transform.position = value;
        }

        public Vector3 Velocity { get; set; }
    }
}