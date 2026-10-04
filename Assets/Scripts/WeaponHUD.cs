using UnityEngine;
using TMPro;

public class WeaponHUD : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;

    [SerializeField]
    TMP_Text AmmoText;

    [SerializeField]
    GameObject reloadingHint;

    void Awake()
    {
    }

    void Start()
    {
        RefreshAmmo();
        ToggleReloadingHint(false);
    }

    void OnEnable()
    {
        weapon.OnAmmoChanged += RefreshAmmo;
        weapon.Reloading += ToggleReloadingHint;
    }
    void OnDisable()
    {
        weapon.OnAmmoChanged -= RefreshAmmo;
        weapon.Reloading -= ToggleReloadingHint;
    }

    void RefreshAmmo()
    {
        AmmoText.text = weapon.currentAmmo + " / " + weapon.reserveAmmo;
    }
    void ToggleReloadingHint(bool toggle)
    {
        reloadingHint.SetActive(toggle);
    }
}