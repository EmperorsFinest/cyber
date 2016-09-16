using UnityEngine;
using System.Collections;
public class Shoot : MonoBehaviour
{
    public int rifleDamage = 15;
    public int shotgunDamage = 30;
    public int submachineDamage = 10;
    public int rifleInitialBullets = 30;
    public int shotgunInitialBullets = 8;
    public int submachineInitialBullets = 50;


    public float range = 100f;
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public GameObject shootOrigin;
    public GameObject shootEffectObject;
    public GameObject Laser;
    public GameObject muzzleFlash;
    public float reloadTime = 2.7f;
    public int bullets = 10;
    public int magazine;

    public GameObject[] weapons;
   
    public GameObject[] muzzleFlashes;
    public GameObject[] fireEffects;
    public GameObject rifleWeapon;
    public GameObject shotgunWeapon;
    public GameObject submachineWeapon;

    float timer;
    int shootableMask;
    Vector3 mousePos;
    Ray shootRay;
    RaycastHit shootHit;
    Animator anim;
    Animator rifleAnim;
    ParticleSystem gunParticles;                    // Reference to the particle system.
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    float effectsDisplayTime = 0.15f;                // The proportion of the timeBetweenBullets that the effects will display for.
    public int initialBullets;
    bool reloadOnce = false;
    bool reloading;

    shotgunWeapon shotgunWeaponScript;
    rifleWeapon rifleWeaponScript;
    submachineWeapon submachineWeaponScript;



    public bool shotgun;
    public bool rifle;
    public bool submachine;
    // Use this for initialization
    void Awake()
    {
        Weapons rifle = new Weapons(weapons[0], muzzleFlashes[0], fireEffects[0], 5, rifleInitialBullets, rifleDamage, 0.25f, 50f);
        Weapons shotgun = new Weapons(weapons[1], muzzleFlashes[1], fireEffects[1], magazine, shotgunInitialBullets, shotgunDamage, 0.7f, 15f);
        Weapons submachine = new Weapons(weapons[2], muzzleFlashes[2], fireEffects[2], magazine, submachineInitialBullets, submachineDamage, 0.1f, 30f);
        /*shotgunWeaponScript = shotgunWeapon.GetComponent<shotgunWeapon>();
        rifleWeaponScript = rifleWeapon.GetComponent<rifleWeapon>();
        submachineWeaponScript = submachineWeapon.GetComponent<submachineWeapon>();*/
        //Set Weapons

        rifle.activateRifle();
        shotgun.deactivateRifle();
        submachine.deactivateRifle();


        /*
        rifleWeaponScript.activateRifle();
        shotgunWeaponScript.deactivateRifle();
        submachineWeaponScript.deactivateRifle();
        rifle = true;*/


        shootableMask = LayerMask.GetMask("Shootable");

        bullets = initialBullets;
        // Set up the references.



        gunLine = shootEffectObject.GetComponent<LineRenderer>();
        gunAudio = shootEffectObject.GetComponent<AudioSource>();
        gunLight = shootEffectObject.GetComponent<Light>();

        muzzleFlash.SetActive(false);

        shootRay.origin = shootOrigin.transform.position;
        shootRay.direction = shootOrigin.transform.forward;


        timer = 10f;
        anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1) && rifle && rifleWeaponScript.rifleActivated == false && reloading == false)
        {
            rifleWeaponScript.activateRifle();
            shotgunWeaponScript.deactivateRifle();
            submachineWeaponScript.deactivateRifle();
            gunLine = shootEffectObject.GetComponent<LineRenderer>();
            gunAudio = shootEffectObject.GetComponent<AudioSource>();
            gunLight = shootEffectObject.GetComponent<Light>();


        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && shotgun && shotgunWeaponScript.shotgunActivated == false && reloading == false)
        {
            shotgunWeaponScript.activateRifle();
            rifleWeaponScript.deactivateRifle();
            submachineWeaponScript.deactivateRifle();
            gunLine = shootEffectObject.GetComponent<LineRenderer>();
            gunAudio = shootEffectObject.GetComponent<AudioSource>();
            gunLight = shootEffectObject.GetComponent<Light>();


        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) && submachine && submachineWeaponScript.submachineActivated == false && reloading == false)
        {
            submachineWeaponScript.activateRifle();
            shotgunWeaponScript.deactivateRifle();
            rifleWeaponScript.deactivateRifle();
            gunLine = shootEffectObject.GetComponent<LineRenderer>();
            gunAudio = shootEffectObject.GetComponent<AudioSource>();
            gunLight = shootEffectObject.GetComponent<Light>();
        }





        //Debug.Log("Bullets:" + bullets);
        //Debug.Log(initialBullets);
        timer += Time.deltaTime;
        if (timer >= effectsDisplayTime * 5)
        {
            Laser.SetActive(true);
        }
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && bullets > 0 && reloading == false)
        {
            ShootWeapon();



        }
        else if (bullets == 0 && reloadOnce == true && magazine > 0 || (Input.GetKeyDown(KeyCode.R) && bullets < initialBullets && reloadOnce == true && magazine > 0))
        {
            reloading = true;
            anim.SetBool("shooting", false);
            anim.SetTrigger("Reload");
            magazine--;
            reloadOnce = false;
            Invoke("WaitNewBullets", reloadTime);
            //shootEffectObject.SetActive(false);
        }
        else if (bullets == initialBullets)
        {
            reloading = false;


        }
        else
        {
            anim.SetBool("shooting", false);
            

        }


        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            // ... disable the effects.

            DisableEffects();
        }




    }


    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        gunLight.enabled = false;
        muzzleFlash.SetActive(false);

    }


    void WaitNewBullets()
    {

        bullets = initialBullets;
    }





    void ShootWeapon()
    {
        muzzleFlash.SetActive(true);
        Laser.SetActive(false);
        // Play the gun shot audioclip.
        gunAudio.Play();

        // Enable the light.
        gunLight.enabled = true;

        bullets -= 1;

        if (bullets < initialBullets)
        {
            reloadOnce = true;
        }


        anim.SetBool("shooting", true);
        timer = 0f;
        shootRay.origin = shootOrigin.transform.position;
        shootRay.direction = shootOrigin.transform.forward;


        // Enable the line renderer and set it's first position to be the end of the gun.
        gunLine.enabled = true;
        gunLine.SetPosition(0, shootRay.origin);


        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // Try and find an EnemyHealth script on the gameobject hit.
            enemyHealth enemyHealth = shootHit.collider.GetComponent<enemyHealth>();

            // If the EnemyHealth component exist...
            if (enemyHealth != null)
            {
                // ... the enemy should take damage.
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }

            gunLine.SetPosition(1, shootHit.point);

        }
        else
        {
            // ... set the second position of the line renderer to the fullest extent of the gun's range.
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }


    public void addRifleMagazine(int size)
    {
        rifleWeaponScript.addMagazineFromItem(size);
    }

    public void addShotgunMagazine(int size)
    {
        shotgunWeaponScript.addMagazineFromItem(size);
    }

    public void addSubmachineMagazine(int size)
    {
        submachineWeaponScript.addMagazineFromItem(size);
    }

}
