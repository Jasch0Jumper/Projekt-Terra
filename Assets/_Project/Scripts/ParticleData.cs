using UnityEngine;

namespace Terra
{
    [CreateAssetMenu(fileName = "Particle", menuName = "ScriptableObjects/ParticleData", order = 1)]
    public class ParticleData: ScriptableObject
    {
        public Number Mass;
        public float ElectricCharge;
    }
}
