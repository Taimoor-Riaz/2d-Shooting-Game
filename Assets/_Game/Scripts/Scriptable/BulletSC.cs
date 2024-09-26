
using UnityEngine;
[CreateAssetMenu(fileName ="New Bullet",menuName = "ScriptableObjects/Bullet")]
public class BulletSC : ScriptableObject
{
    public float bulletSpeed;
    public float bulletDamage;
    public float bulletDestroyTime;
    public GameObject bulletPrefab;
}
