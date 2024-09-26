
using UnityEngine;

public class ShotGun : Gun
{
    public float spreadAmount = 10f;
    protected override void FireBullets(Transform firePoint)
    {
        for (int i = 0; i < gunData.bulletsPerShot; i++)
        {
            // Randomize the bullet spread by adjusting the angle
            float spreadAngle = Random.Range(-spreadAmount, spreadAmount);

            // Get the fire direction (use firePoint.right if the gun's facing direction is right in 2D)
            Vector3 fireDirection = firePoint.right; // Assuming the gun's facing direction is along the X-axis (right in 2D)

            // Apply the spread to the fire direction by rotating it
            Vector3 spreadDirection = Quaternion.Euler(0, 0, spreadAngle) * fireDirection;

            // Instantiate the bullet
            GameObject bullet = Instantiate(gunData.bulletSC.bulletPrefab, firePoint.position, firePoint.rotation);

            // Initialize the bullet with the spread direction
            bullet.GetComponent<Bullet>().Initialize(gunData.bulletSC.bulletSpeed, gunData.bulletSC.bulletDestroyTime, spreadDirection);
        }
    }
}
