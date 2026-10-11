using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifeTime = 3f;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Bullet Hit:" + collision.gameObject.name);
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if(enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}