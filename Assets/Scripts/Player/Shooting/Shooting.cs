using UnityEngine;

public class Shooting : MonoBehaviour
{
    //timers
    public float timeToReload = 3;
    public float reloadTimer;
    public bool reloadTimerRunning;
    //
    public float timeBetweenShot = 0.5f;
    public float timeBetweenShotTimer;
    public bool timeBetweenShotTimerRunning;
    
    //bools
    public bool canShoot;
    public bool needsAmmo;
    public bool isShotgun;
    public bool burstRifle;
    public bool chanceToSaveBullet;

    //Game Objects
    public Transform firePoint;
    public GameObject bulletPrefab;
    [HideInInspector] public Camera cam;

    //gun settings
    public float bulletForce = 20f;
    public int totalPossibleBullets;
    public int totalBullets;
    public int magSize;
    public int bulletsInMag;
    public float rangeOfSpread;
    public int shotgunPelletCount;
    [HideInInspector] public int chanceToSaveBulletInt; 

    //Burst Shooting
    public int burstShotCount = 3;
    public int totalBurstShotsFired = 0;
    public float timeBetweenBurstShot;
    public float timeBetweenBurstShotTimer;
    public bool timeBetweenBurstShotTimerRunning;
    public bool isBursting;

    public void Start()
    {
        reloadTimer = timeToReload;
        timeBetweenShotTimer = timeBetweenShot;
        timeBetweenBurstShotTimer = timeBetweenBurstShot;

        SetBullets();
    }
    void Update()
    {
        //Enabling shooting
        #region
        if (reloadTimerRunning)
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
                canShoot = true;
                reloadTimerRunning = false;
                reloadTimer = timeToReload;
            }
        }

        if (bulletsInMag > 0)
        {
            canShoot = true;
        }

        if (timeBetweenShotTimerRunning)
        {
            canShoot = false;
            timeBetweenShotTimer -= Time.deltaTime;

            if (timeBetweenShotTimer <= 0)
            {
                canShoot = true;
                timeBetweenShotTimerRunning = false;
                timeBetweenShotTimer = timeBetweenShot;
            }
        }
        #endregion

        //Disabling shooting
        #region
        if (bulletsInMag <= 0)
        {
            canShoot = false;
        }
        #endregion

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
                TimeBetweenShots();
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

        if (isBursting == true)
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

        //reloading
        if (totalBullets > 0 && bulletsInMag != magSize && Input.GetKeyDown(KeyCode.R))
        {
            Reload();
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
        //if is a shotgun
        if(isShotgun == true)
        {
            for (int i = 1; i < shotgunPelletCount + 1; i++)
            {
                //points the gun
                Vector3 mousePos = Input.mousePosition;
                Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                //shoots the gun
                Vector2 error = Random.insideUnitCircle * rangeOfSpread;
                GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
                bullet.transform.LookAt(worldPos + (transform.right * error.x) + (transform.up * error.y));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = Vector3.zero;
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * bulletForce, ForceMode2D.Impulse);
            }
        }
        //if is a normal gun
        else
        {
            //points the gun
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            //shoots the gun
            Vector2 error = Random.insideUnitCircle * rangeOfSpread;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
            bullet.transform.LookAt(worldPos + (transform.right * error.x) + (transform.up * error.y));
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * bulletForce, ForceMode2D.Impulse);
        }
    }

    public void Reload()
    {
        reloadTimerRunning = true;
    }

    public void TimeBetweenShots()
    {
        timeBetweenShotTimerRunning = true;
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
