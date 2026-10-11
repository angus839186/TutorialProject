using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] Transform target;

    public float moveSpeed = 1f;

    public float stoppingDistance = 1f;
    public float rotationSpeed = 5f;


    void Update()
    {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0f;
        float distance = direction.magnitude;


        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (distance > stoppingDistance)
        {
            Vector3 moveDirection = direction.normalized;
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }
}
