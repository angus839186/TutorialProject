using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;
    public float bulletSpeed = 20f;
    [SerializeField] Player player;
    [SerializeField] Weapon weapon;

    void Awake()
    {
        player = GetComponent<Player>();
    }

    void Start()
    {
    }

    void OnEnable()
    {
        player.OnFireInput += Shoot;
        player.OnReloadInput += Reload;
    }

    void OnDisable()
    {
        player.OnFireInput -= Shoot;
        player.OnReloadInput -= Reload;
    }
    public void Reload()
    {
        weapon.Reload();
    }

    void Shoot()
    {
        if (!weapon.TryFire()) return;
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