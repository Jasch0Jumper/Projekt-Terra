using System.Collections.Generic;
using UnityEngine;

namespace Terra
{
    public static class Physics
    {
        public static float Scale = 1f;

        private const float PERMEABILITY_OF_SPACE = Mathf.PI * 4f; //* 1e-7f;

        public static void Step(List<IParticle> particles, float time)
        {
            foreach (var particle in particles)
            {
                foreach (var otherParticle in particles)
                {
                    if (otherParticle == particle) continue;
                        
                    var force = MagneticAttractionForce(particle, otherParticle);
                    ApplyForce(particle, force);
                }
                UpdatePosition(particle, time);
            }
        }
        
        public static void UpdatePosition(IParticle particle, float time)
        {
            particle.Position += particle.Velocity * time;
        }
        
        public static Vector3 ApplyForce(IParticle particle, Vector3 force)
        {
            var acceleration = force / particle.Data.Mass;
            return particle.Velocity += acceleration;
        }
        
        public static Vector3 MagneticAttractionForce(IParticle p1, IParticle p2)
        {
            var direction = p1.Position * Scale - p2.Position * Scale;
            var squaredDistance = direction.sqrMagnitude; 
            var forceMagnitude = (PERMEABILITY_OF_SPACE * p1.Data.ElectricCharge * p2.Data.ElectricCharge) / (4f * Mathf.PI * squaredDistance);
            return direction.normalized * forceMagnitude;
        }
    }
}
