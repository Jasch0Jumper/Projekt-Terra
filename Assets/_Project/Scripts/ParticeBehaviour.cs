using UnityEngine;

namespace Sanomic
{
    public class ParticeBehaviour: MonoBehaviour
    {
        [SerializeField] private ParticleData _data;
        public Particle Particle { get; set; }
        
        public ParticleData Data => _data;
        public Vector StartPosition => new(transform.position);
    }
}