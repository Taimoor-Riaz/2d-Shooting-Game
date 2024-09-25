
using UnityEngine;
[CreateAssetMenu(fileName ="PlayerData",menuName ="ScriptableObjects/PlayerData")]
public class PlayerSC : ScriptableObject
{
    public float playerSpeed;
    public RuntimeAnimatorController playerAnimator;
    public Sprite playerSprite;
}
