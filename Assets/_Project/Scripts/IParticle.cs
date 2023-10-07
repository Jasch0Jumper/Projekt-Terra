using UnityEngine;

namespace Terra
{
    public interface IParticle
    {
        public ParticleData Data { get; }
        
        public Vector3 Position { get; set; }
        public Vector3 Velocity { get; set; }
        
    }
}