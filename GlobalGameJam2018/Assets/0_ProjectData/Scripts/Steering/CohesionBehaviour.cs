using UnityEngine;

namespace AI.Movement
{
    public class CohesionBehaviour : SteeringBehaviour
    {
        public float radius = 1;
        private Agent agentone;

        public override SteeringOutput GetSteering()
        {
            SteeringOutput steering = new SteeringOutput();

            // Get all agents inside the circle
            Vector2 baricenter = Vector2.zero;
            int totalAgents = 0;
            foreach (Agent agent in agentone.agentispawnati)
            {
                if (agent.gameObject == this.gameObject) continue; // Skips itself

                if ((agent.transform.position - transform.position).sqrMagnitude <= radius * radius)
                {
                    baricenter += (Vector2)agent.transform.position;
                    totalAgents++;
                }
            }

            // Nobody inside the circle :(
            if (totalAgents == 0)
            {
                return steering; // Init Default
            }

            baricenter /= totalAgents;

            steering.targetLinearVelocityPercent = (baricenter - (Vector2)transform.position).normalized;
            return steering;
        }
    }
}