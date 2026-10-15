using UnityEngine;

namespace Tanks.Complete
{
    public class EnemyPatrol : MonoBehaviour
    {
        public Transform pointA;
        public Transform pointB;

        public float speed = 4f;

        private Transform target;

        private void Start()
        {
            target = pointB;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime);

            transform.LookAt(target);

            if (Vector3.Distance(transform.position, target.position) < 0.2f)
            {
                target = target == pointA ? pointB : pointA;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            TankHealth tank = collision.gameObject.GetComponent<TankHealth>();

            if (tank != null)
            {
                tank.TakeDamage(20f);
            }
        }
    }
}