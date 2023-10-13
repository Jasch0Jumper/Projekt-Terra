using System;
using System.Collections.Generic;
using UnityEngine;

namespace Terra
{
    public static class Physics
    {
        public static float Scale = 1f;

        private const float PERMEABILITY_OF_SPACE = Mathf.PI * 4f * 1e-7f;

        public static void Step(List<IParticle> particles, Number time)
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
        
        public static void UpdatePosition(IParticle particle, Number time)
        {
            particle.Position += particle.Velocity * time;
        }
        
        public static Vector ApplyForce(IParticle particle, Vector force)
        {
            var acceleration = force / particle.Data.Mass;
            return particle.Velocity += acceleration;
        }
        
        public static Vector MagneticAttractionForce(IParticle p1, IParticle p2)
        {
            var direction = p1.Position * Scale - p2.Position * Scale;
            var squaredDistance = direction.SquareMagnitude; 
            var forceMagnitude = (PERMEABILITY_OF_SPACE * p1.Data.ElectricCharge * p2.Data.ElectricCharge) / (4f * Mathf.PI * squaredDistance);
            return direction.Normalized * forceMagnitude;
        }
    }
}
