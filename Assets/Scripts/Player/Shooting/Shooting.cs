using UnityEngine;
using CodeMonkey.Utils;

public class Shooting : MonoBehaviour
{
    //timers
    public float timeToReload = 3;
    [HideInInspector] public float reloadTimer;
    [HideInInspector] public bool reloadTimerRunning;

    public float timeBetweenShot = 0.5f;
    [HideInInspector] public float timeBetweenShotTimer;
    [HideInInspector] public bool timeBetweenShotTimerRunning;
    
    //bools
    [HideInInspector] public bool canShoot;
    [HideInInspector] public bool needsAmmo;
    public bool isShotgun;
    public bool burstRifle;
    [HideInInspector] public bool chanceToSaveBullet;

    //Game Objects
    public Transform firePoint;
    public GameObject bulletPrefab;
    [HideInInspector] public Camera cam;
    private Animator animator;

    //gun settings
    public int costToReload;
    public int totalPossibleBullets;
    [HideInInspector] public int totalBullets;
    public int magSize;
    [HideInInspector] public int bulletsInMag;
    public float rangeOfSpread;
    public int shotgunPelletCount;
    [HideInInspector] public int chanceToSaveBulletInt;

    //Burst Shooting
    public int burstShotCount = 3;
    public int totalBurstShotsFired = 0;
    public float timeBetweenBurstShot;
    [HideInInspector] public float timeBetweenBurstShotTimer;
    [HideInInspector] public bool timeBetweenBurstShotTimerRunning;
    [HideInInspector] public bool isBursting;

    public void Start()
    {
        animator = GetComponentInChildren<Animator>();

        reloadTimer = timeToReload;
        timeBetweenShotTimer = timeBetweenShot;
        timeBetweenBurstShotTimer = timeBetweenBurstShot;

        SetBullets();
    }

    void FixedUpdate()
    {
        if (reloadTimerRunning)
        {
            Reload();
        }

        if (bulletsInMag  == 0)
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }

        if (timeBetweenShotTimerRunning)
        {
            TimeBetweenShots();
        }

        //shooting
        if (canShoot == true && !reloadTimerRunning && Input.GetButton("Fire1"))
        {
            if (burstRifle == true)
            {
                isBursting = true;
            }
            else
            {
                Shoot();
                timeBetweenShotTimerRunning = true;
                if (chanceToSaveBullet == true)
                {
                    SaveBulletChance();
                }
                if (chanceToSaveBullet == false)
                {
                    bulletsInMag--;
                }
            }
        }

        if (timeBetweenBurstShotTimerRunning)
        {
            TimeBetweenBurstShots();
        }

        //burst shooting
            if (isBursting == true)
            {
                TimeBetweenBurstShots();
            }

        //reloading
        if (totalBullets > 0 && bulletsInMag != magSize && Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("Reload", true);
            reloadTimerRunning = true;
        }

        //for ammo machine
        if (totalBullets != totalPossibleBullets)
        {
            needsAmmo = true;
        }
        else
        {
            needsAmmo = false;
        }
    }
    public void Shoot()
    {
        float randomNumber = Random.Range(0, rangeOfSpread);
        float shootError = Random.Range(randomNumber - 90f, -randomNumber - 90f);

        //if is a shotgun
        if (isShotgun == true)
        {
            for (int i = 1; i < shotgunPelletCount + 1; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
                Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
                Vector3 aimDirection = (mousePos - transform.position).normalized;
                float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + shootError;
                bullet.transform.localRotation = Quaternion.Euler(0, 0, angle);
            }
        }
        //if is a normal gun
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            Vector3 mousePos = UtilsClass.GetMouseWorldPosition();
            Vector3 aimDirection = (mousePos - transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg + shootError;
            bullet.transform.localRotation = Quaternion.Euler(0, 0, angle);
        }
    }

    public void Reload()
    {
        canShoot = false;
        reloadTimer -= Time.deltaTime;

        if (reloadTimer <= 0)
        {
            if (totalBullets >= magSize)
            {
                if (bulletsInMag == 0)
                {
                    bulletsInMag = magSize;
                    totalBullets = totalBullets - magSize;
                }
                else
                {
                    int bulletsToTake = magSize - bulletsInMag;
                    bulletsInMag = magSize;
                    totalBullets = totalBullets - bulletsToTake;
                }
            }
            else
            {
                bulletsInMag = bulletsInMag + totalBullets;
                totalBullets = 0;
            }
            animator.SetBool("Reload", false);
            canShoot = true;
            reloadTimerRunning = false;
            reloadTimer = timeToReload;
        }
    }

    public void TimeBetweenShots()
    {
        timeBetweenShotTimerRunning = true;

        animator.SetBool("Recoil", true);
        canShoot = false;
        timeBetweenShotTimer -= Time.deltaTime;
        
        if (timeBetweenShotTimer <= 0)
        {
            animator.SetBool("Recoil", false);
            canShoot = true;
            timeBetweenShotTimerRunning = false;
            timeBetweenShotTimer = timeBetweenShot;
        }
    }

    public void TimeBetweenBurstShots()
    {
        timeBetweenBurstShotTimer -= Time.deltaTime;
        timeBetweenBurstShotTimerRunning = true;

        if (timeBetweenBurstShotTimerRunning == true)
        {
            if (timeBetweenBurstShotTimer <= 0)
            {
                if (totalBurstShotsFired < burstShotCount)
                {
                    Shoot();
                    totalBurstShotsFired++;
                    if (chanceToSaveBullet == true)
                    {
                        SaveBulletChance();
                    }
                    else
                    {
                        bulletsInMag--;
                    }

                    timeBetweenBurstShotTimer = timeBetweenBurstShot;
                }
                else
                {
                    isBursting = false;
                    totalBurstShotsFired = 0;
                    timeBetweenBurstShotTimerRunning = false;
                    TimeBetweenShots();
                }
            }
        }
    }

    public void SetBullets()
    {
        totalBullets = totalPossibleBullets;
        bulletsInMag = magSize;
    }

    public void SaveBulletChance()
    {
        int chanceToSave = Random.Range(0, chanceToSaveBulletInt + 1);

        if(chanceToSave != 0)
        {
            bulletsInMag--;
        }
    }
}
