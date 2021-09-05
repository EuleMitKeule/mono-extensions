using UnityEngine;

namespace UnityExtensions.Runtime
{
    public static class Rigidbody2DExtensions
    {
        public static Vector2 SetDirection(this Rigidbody2D rigidbody, Vector2 direction) =>
            rigidbody.velocity = direction * rigidbody.velocity.magnitude;

        public static Vector2 SetSpeed(this Rigidbody2D rigidbody, float speed) =>
            rigidbody.velocity = rigidbody.velocity.normalized * speed;

        public static void Stop(this Rigidbody2D rigidbody)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0f;
        }
    }
}