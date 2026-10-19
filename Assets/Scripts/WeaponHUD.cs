using UnityEngine;
using TMPro;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField] Weapon weapon;

    [SerializeField] TMP_Text AmmoText;

    [SerializeField] TMP_Text ReserveAmmoText;

    [SerializeField] GameObject reloadingHint;

    void OnEnable()
    {
        weapon.OnAmmoChanged += RefreshAmmo;
        weapon.Reloading += ToggleReloadingHint;
    }
    void OnDisable()
    {
        weapon.OnAmmoChanged += RefreshAmmo;
        weapon.Reloading -= ToggleReloadingHint;
    }
    void Start()
    {
        RefreshAmmo();
    }

    void RefreshAmmo()
    {
        AmmoText.text = weapon.currentAmmo + "/" + weapon.magazineSize;
        ReserveAmmoText.text = weapon.reserveAmmo.ToString();
    }
    void ToggleReloadingHint(bool toggle)
    {
        reloadingHint.SetActive(toggle);
    }
}