﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Movement
{
    public class Agent : MonoBehaviour
    {
        // Parameters
        public float maximumLinearVelocity = 1;
        public float maximumAngularVelocity = 90; // degrees per second

        public float maximumLinearAcceleration = 1;
        public float maximumLinearDeceleration = 1;
        public float maximumAngularAcceleration = 90;

        [Space]
        public GameObject pippottino;

        // State
        private Vector2 linearVelocity;
        private float angularVelocity;

        private float currentLinearVelocity;

        private float linearAcceleration;
        private float angularAcceleration;

        private SeekBehaviour seek;
        private SteeringBehaviour[] steeringBehaviours;

        void Start()
        {
            steeringBehaviours = GetComponents<SteeringBehaviour>();
            seek = GetComponent<SeekBehaviour>();
            pippottinoRenderer = pippottino.GetComponent<SpriteRenderer>();
            ChangeDirection();

        }

        void Update()
        {

            pippottinoRenderer.sortingOrder = (int)((pippottino.transform.position.y* - 1 * 100 ) + 1000);

            // Get the steering output
            Vector2 totalSteering = Vector2.zero;
            float totalWeight = 0;

            foreach (SteeringBehaviour steeringBehaviour in steeringBehaviours)
            {
                totalSteering += steeringBehaviour.GetSteering().targetLinearVelocityPercent * steeringBehaviour.weight;
                totalWeight += steeringBehaviour.weight;
            }
            totalSteering = totalSteering / totalWeight;

            // Set accelerations based on steering target
            Vector2 targetVelocityPercent = totalSteering;
            Vector2 targetVelocity = targetVelocityPercent * maximumLinearVelocity;

            if (targetVelocity.sqrMagnitude > currentLinearVelocity * currentLinearVelocity)
            {
                linearAcceleration = maximumLinearAcceleration;
            }
            else if (targetVelocity.sqrMagnitude < currentLinearVelocity * currentLinearVelocity)
            {
                linearAcceleration = -maximumLinearDeceleration;
            }
            else
            {
                linearAcceleration = 0;
            }

            Vector3 crossVector = Vector3.Cross(targetVelocity, transform.right);
            float angle = Mathf.Abs(Vector3.Angle(targetVelocityPercent, transform.right));
            int rotationDirection = -(int)Mathf.Sign(crossVector.z);

            float accelerationRatio = Mathf.Clamp(angle, 0, 5) / 5f;
            angularAcceleration = rotationDirection * maximumAngularAcceleration * accelerationRatio;

            // Velocity Update
            currentLinearVelocity += linearAcceleration * Time.deltaTime;
            currentLinearVelocity = Mathf.Clamp(currentLinearVelocity, 0, maximumLinearVelocity);
            linearVelocity += (Vector2)transform.right * currentLinearVelocity;
            if (linearVelocity.sqrMagnitude > maximumLinearVelocity * maximumLinearVelocity)
            {
                linearVelocity = linearVelocity.normalized * maximumLinearVelocity;
            }

            angularVelocity += angularAcceleration * Time.deltaTime;
            angularVelocity = Mathf.Clamp(angularVelocity, -maximumAngularVelocity, maximumAngularVelocity);
            angularVelocity *= accelerationRatio;

            // Position/Rotation Update
            transform.position += (Vector3)(linearVelocity * Time.deltaTime);
            transform.localEulerAngles += Vector3.forward * angularVelocity * Time.deltaTime;

            Debug.DrawLine(transform.position, transform.position + (Vector3)linearVelocity, Color.red);
            Debug.DrawLine(transform.position, transform.position + (Vector3)totalSteering, Color.green);
        }

        private void LateUpdate()
        {
            if (pippottino)
                pippottino.transform.rotation = Quaternion.identity;
        }

        SpriteRenderer pippottinoRenderer;

        public void ChangeDirection()
        {


            if (seek.targetTransform.position.x > transform.position.x)
            {
                pippottinoRenderer.flipX = true;
                transform.rotation = Quaternion.identity;
            }
            else
            {
                pippottinoRenderer.flipX = false;
                transform.rotation = new Quaternion(0, 0, 0.5f, 0);
            }
        }
    }
}