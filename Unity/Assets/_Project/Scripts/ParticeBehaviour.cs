using UnityEngine;

namespace Sanomic
{
    public class ParticeBehaviour: MonoBehaviour, IParticle
    {
        [SerializeField] private ParticleData _data;
        
        public ParticleData Data => _data;

        public Vector Position {
            get => new(transform.position);
            set => transform.position = new Vector3(value.X.Mantissa, value.Y.Mantissa, value.Z.Mantissa);
        }

        public Vector Velocity { get; set; }
    }
}