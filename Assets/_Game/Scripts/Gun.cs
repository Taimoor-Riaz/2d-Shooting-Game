using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IObserver
{
    public GunSC gunData;
    public float detectionRadius;
    public LayerMask targetLayer;
    public Transform firePoint;

    public Transform target;

    protected float lastFireTime = 0;
    private bool isFlipped = false;
    private Quaternion originalRotation;
    private GuiSubject guiSubject;
    private void Awake()
    {
        guiSubject = GuiSubject.Instance;
    }
    void Start()
    {
        originalRotation = transform.rotation;
    }

    private void OnEnable()
    {
        PlayerController.OnPlayerFlip += FlipGun;
        guiSubject.AddObserver(this);
    }
    private void OnDisable()
    {
        PlayerController.OnPlayerFlip -= FlipGun;
        guiSubject.RemoveObserver(this);
    }

    private void Update()
    {
        DetectTarget();
        AimAtTarget();
        if (target == null)
        {
            ResetRotation();
        }
    }

    void DetectTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, targetLayer);
        float closestDistance = Mathf.Infinity;
        target = null;
        foreach (Collider2D hit in hits)
        {
            float distanceToTarget = Vector2.Distance(transform.position, hit.transform.position);
            if (distanceToTarget < closestDistance)
            {
                closestDistance = distanceToTarget;
                target = hit.transform;
            }
        }
    }

    void AimAtTarget()
    {
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (direction.x < 0 && !isFlipped)
            {
                FlipGun(true);
            }
            else if (direction.x > 0 && isFlipped)
            {
                FlipGun(false);
            }
            if (isFlipped)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle + 180);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }

    void FlipGun(bool flip)
    {
        isFlipped = flip;
        Vector3 scale = transform.localScale;
        scale.x = flip ? -Mathf.Abs(scale.x) : Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    void ResetRotation()
    {
        transform.rotation = originalRotation;
    }
    public virtual void Shoot()
    {
        Debug.Log("Shoot Called");
        if (Time.time >= lastFireTime + gunData.nextFireTime)
        {
            FireBullets(firePoint);
            lastFireTime = Time.time;
        }
    }

    protected virtual void FireBullets(Transform firePoint)
    {
        for (int i = 0; i < gunData.bulletsPerShot; i++)
        {
            GameObject bullet = Instantiate(gunData.bulletSC.bulletPrefab, firePoint.position, firePoint.rotation);


            bullet.GetComponent<Bullet>().Initialize(gunData.bulletSC.bulletSpeed, gunData.bulletSC.bulletDestroyTime, target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    public void OnNotify(ButtonType buttonType)
    {
        if (buttonType == ButtonType.Shoot)
        {
            if ( target != null)
            {
                Shoot();
            }
        }
    }
}
