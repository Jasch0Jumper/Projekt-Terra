using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Terra
{
    public class ProtonBehaviour : MonoBehaviour
    {
        [SerializeField] [Range(0f, 10f)] private float _attractionForce = 1f;
        
        private static List<ProtonBehaviour> _protons;
        
        [HideInInspector] [NotNull] public List<ProtonBehaviour> connectedProtons = new();

        private void Awake() => _protons ??= new List<ProtonBehaviour>();
        private void OnEnable() => _protons.Add(this);
        private void OnDisable() => _protons.Remove(this);

        private void FixedUpdate()
        {
            var positionDelta = Vector3.zero;
            foreach (var proton in _protons)
            {
                if (proton == this) continue;
                if (connectedProtons.Contains(proton)) continue;

                var otherPosition = proton.transform.position;
                var thisPosition = transform.position;
                var direction = (otherPosition - thisPosition).normalized;

                var forceBase = (float)Math.Pow(0.9, 1.5 * (-Vector3.Distance(otherPosition, thisPosition) - 20));
                var forceMultiplier = _attractionForce * (proton.connectedProtons.Count == 0 ? 1f : proton.connectedProtons.Count) / 10;

                if (forceMultiplier == 0f) forceMultiplier = 1f;
                
                positionDelta += direction * (forceBase * forceMultiplier);
            }
            transform.position += positionDelta * Time.fixedDeltaTime;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out ProtonBehaviour proton))
            {
                connectedProtons.Add(proton);
            }
        }
    }
}
