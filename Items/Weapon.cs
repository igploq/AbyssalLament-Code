using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public GameObject shotgunBulletPrefab; 

    public Transform bulletSpawn;
    public float bulletVelocity = 30f;
    public float bulletPrefabLifeTime = 3f;
    public float fireRate = 0.2f;

    public int shotgunPellets = 5; 
    public float shotgunBulletVelocity = 25f; 
    public float shotgunBulletLifeTime = 2f; 
    public float spreadAngle = 10f; 

    private float nextFireTime = 0f;

    void Update()
    {
        
        if (Input.GetKey(KeyCode.Mouse0) && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            FireWeapon();
        }

        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            FireShotgun();
        }
    }

    private void FireWeapon()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);
        StartCoroutine(DestroyBulletTime(bullet, bulletPrefabLifeTime));
    }

    private void FireShotgun()
    {
        for (int i = 0; i < shotgunPellets; i++)
        {
            
            Quaternion spread = Quaternion.Euler(
                bulletSpawn.rotation.eulerAngles.x + Random.Range(-spreadAngle, spreadAngle),
                bulletSpawn.rotation.eulerAngles.y + Random.Range(-spreadAngle, spreadAngle),
                bulletSpawn.rotation.eulerAngles.z
            );

            GameObject bullet = Instantiate(shotgunBulletPrefab, bulletSpawn.position, spread);
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward.normalized * shotgunBulletVelocity, ForceMode.Impulse);
            StartCoroutine(DestroyBulletTime(bullet, shotgunBulletLifeTime));
        }
    }

    private IEnumerator DestroyBulletTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
