using UnityEngine;

namespace Terra
{
    [CreateAssetMenu(fileName = "Particle", menuName = "ScriptableObjects/ParticleData", order = 1)]
    public class ParticleData: ScriptableObject
    {
        public Number Mass = new Number(0f);
        public float ElectricCharge;
    }
}
