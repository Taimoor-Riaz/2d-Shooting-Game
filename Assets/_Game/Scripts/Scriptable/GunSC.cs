
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun",menuName = "ScriptableObjects/Gun Data")]
public class GunSC : ScriptableObject
{
    public GunType gunType;
    public int bulletsPerShot;      
    public float nextFireTime;        
    public float bulletDamage;        
    public float bulletDestroyTime;   
    public GameObject bulletPrefab;
}

public enum GunType
{
    pistol,
    shotgun
}