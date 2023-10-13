using System.Collections.Generic;
using UnityEngine;

namespace Terra
{
    public class ParticeBehaviour: MonoBehaviour, IParticle
    {
        [SerializeField] private ParticleData _data;
        
        public ParticleData Data => _data;

        public Vector Position {
            get => new Vector(transform.position);
            set => transform.position = value.ToVector3();
        }

        public Vector Velocity { get; set; }
    }
}