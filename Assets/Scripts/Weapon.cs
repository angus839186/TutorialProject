using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Fire")]
    [Min(0.01f)]
    public float fireRate = 5f;

    [Header("Magazine")]
    [Min(1)]
    public int magazineSize = 10;

    public int currentAmmo;

    [Min(0f)]
    public float reloadTime = 1.5f;

    public bool isReloading;

    float nextFireTime;

    void Awake()
    {
        currentAmmo = magazineSize;
    }

    public bool TryFire()
    {
        if (isReloading)
        {
            return false;
        }

        if (currentAmmo <= 0)
        {
            Debug.Log("No Ammo - Press R to reload");
            return false;
        }

        if (Time.time < nextFireTime)
        {
            return false;
        }

        float fireInterval = 1f / fireRate;
        nextFireTime = Time.time + fireInterval;

        currentAmmo--;

        Debug.Log("Ammo: " + currentAmmo + "/" + magazineSize);

        return true;
    }

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }

        if (currentAmmo == magazineSize)
        {
            return;
        }

        StartCoroutine(ReloadRoutine());
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        isReloading = false;

        Debug.Log("Reload Complete");
    }
}