using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] PlayerHealth target;

    public int damage = 10;

    public float attackDistance = 1.75f;

    public float attackRate = 1f;

    float nextAttackTime;

    void Update()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.transform.position);

        if (distance > attackDistance) return;

        if (Time.time < nextAttackTime) return;

        float attackInterval = 1f / attackRate;
        nextAttackTime = Time.time + attackInterval;

        target.TakeDamage(damage);
    }
}