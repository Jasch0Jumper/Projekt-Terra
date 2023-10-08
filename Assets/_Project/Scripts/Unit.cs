using UnityEngine;

namespace Terra
{
    [CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects/Unit", order = 1)]
    public class Unit : ScriptableObject
    {
        public string Name;
        public string Symbol;
        public string Description;
    }
}