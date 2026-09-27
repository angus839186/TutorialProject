using UnityEngine;
using System.Collections;

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

    public bool TryFire()
    {
        if(isReloading) return false;
        if(currentAmmo <=0)
        {
            Debug.Log("No Ammo");
            return false;
        }
        if(Time.time < nextFireTime)
        {
            return false;
        }
        float fireInterval = 1f / fireRate;
        nextFireTime = Time.time + fireInterval;

        currentAmmo--;
        
        Debug.Log("Ammo:" + currentAmmo+ "/" + magazineSize);

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
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        isReloading = false;

        Debug.Log("Reloaded");

    }
}