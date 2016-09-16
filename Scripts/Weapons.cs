using UnityEngine;
using System.Collections;

public class Weapons : MonoBehaviour {

    public bool rifleActivated;
    int magazine;
    int initialBullets;
    int bullets;
    int damage;
    float timeBetweenBullets;
    float range;
    GameObject shootOrigin;
    GameObject muzzleFlash;
    GameObject fireEffect;
    GameObject weaponObject;
    GameObject player;
    Shoot shootScript;
    GameObject weapon;

    public Weapons(GameObject weapon, GameObject muzzleFlash, GameObject fireEffect, int magazine, int initialBullets, int damage, float timeBetweenBullets, float range)
    {
        this.weapon = weapon;

        this.muzzleFlash = muzzleFlash;
        this.fireEffect = fireEffect;
        this.magazine = magazine;
        this.initialBullets = initialBullets;
        this.damage = damage;
        this.timeBetweenBullets = timeBetweenBullets;
        this.range = range;
    }

    void Awake()
    {
        bullets = initialBullets;
        player = GameObject.FindGameObjectWithTag("Player");
        shootScript = player.GetComponent<Shoot>();

    }

    public void activateRifle()
    {
        gameObject.SetActive(true);

        shootScript.range = range;
        shootScript.timeBetweenBullets = timeBetweenBullets;

        shootScript.muzzleFlash = fireEffect;
        shootScript.shootEffectObject = muzzleFlash;

        shootScript.Laser = shootOrigin;
        shootScript.initialBullets = initialBullets;
        shootScript.damagePerShot = damage;
        shootScript.magazine = magazine;
        shootScript.bullets = bullets;
        rifleActivated = true;
    }

    void Update()
    {

        if (rifleActivated)
        {
            bullets = shootScript.bullets;
            magazine = shootScript.magazine;

        }
    }


    public void deactivateRifle()
    {
        gameObject.SetActive(false);
        rifleActivated = false;
    }

    public void addMagazineFromItem(int size)
    {
        magazine = magazine + size;
        if (rifleActivated)
        {
            shootScript.magazine = magazine;
        }
    }
}
