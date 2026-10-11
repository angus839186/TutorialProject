using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour
{
    [Header("射擊間隔")]
    public float fireRate = 5f;

    [Header("彈匣最大上限")]
    public int magazineSize = 10;

    [Header("目前子彈數量")]
    public int currentAmmo;

    [Header("裝彈時間")]
    public float reloadTime = 1.5f;


    public bool isReloading = false;
    float nextFireTime;

    public event Action OnAmmoChanged;
    public event Action<bool> Reloading;

    void Awake()
    {
        currentAmmo = magazineSize;
        OnAmmoChanged?.Invoke();
    }

    public bool TryFire()
    {
        if (isReloading) return false;
        if (currentAmmo <= 0)
        {
            Debug.Log("No Ammo");
            return false;
        }
        if (Time.time < nextFireTime)
        {
            return false;
        }
        float fireInterval = 1f / fireRate;
        nextFireTime = Time.time + fireInterval;

        currentAmmo--;
        OnAmmoChanged?.Invoke();

        Debug.Log("Ammo:" + currentAmmo + "/" + magazineSize);

        return true;
    }
    public void Reload()
    {
        if (isReloading) return;
        if (currentAmmo == magazineSize) return;

        StartCoroutine(ReloadRoutine());
    }

    IEnumerator ReloadRoutine()
    {
        isReloading = true;

        Debug.Log("Reloading...");
        Reloading?.Invoke(true);
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        OnAmmoChanged?.Invoke();
        Reloading?.Invoke(false);
        isReloading = false;

        Debug.Log("Reloaded");

    }
}