using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float bulletSpeed = 20f;

    [SerializeField] Player player;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void OnEnable()
    {
        player.OnFireInput += Shoot;
    }

    void OnDisable()
    {
        player.OnFireInput -= Shoot;
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            muzzlePoint.position,
            muzzlePoint.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = muzzlePoint.forward * bulletSpeed;

        Debug.DrawRay(
            muzzlePoint.position,
            muzzlePoint.forward * 5f,
            Color.red,
            1f
        );
    }
}