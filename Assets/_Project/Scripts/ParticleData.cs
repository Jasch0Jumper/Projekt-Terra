using UnityEngine;

namespace Terra
{
    [CreateAssetMenu(fileName = "Particle", menuName = "ScriptableObjects/ParticleData", order = 1)]
    public class ParticleData: ScriptableObject
    {
        public float Mass;
        public float ElectricCharge;
    }
}
