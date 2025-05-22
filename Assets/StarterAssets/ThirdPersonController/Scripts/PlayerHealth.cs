using UnityEngine;

namespace StarterAssets
{
    public class PlayerHealth : MonoBehaviour
    {
        public float Health { get; private set; } = 1f;

        private bool isFalling = false;
        private float fallStartTime = 0f;

        private void Update()
        {
            if (!IsGrounded())
            {
                if (!isFalling)
                {
                    isFalling = true;
                    fallStartTime = Time.time;
                }
            }
            else
            {
                if (isFalling)
                {
                    isFalling = false;
                    float fallDuration = Time.time - fallStartTime;

                    if (fallDuration > 0.2f)
                    {
                        TakeDamage(0.1f);
                    }
                }
            }
        }

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, 1.1f);
        }

        public void TakeDamage(float amount)
        {
            Health = Mathf.Clamp01(Health - amount);
        }
    }
}
