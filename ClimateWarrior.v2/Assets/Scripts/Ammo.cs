using UnityEngine;

public sealed class Ammo
{
    public int BulletCount { get; set; }
    public int MaxBulletCount { get; set; }

    public Ammo()
    {
    }
    public Ammo(int bulletCount)
    {
        BulletCount = bulletCount;
    }
    
    public Ammo(int bulletCount,int maxBulletCount)
    {
        BulletCount = bulletCount;
        MaxBulletCount = maxBulletCount;
    }

    public void Validate() => BulletCount = Mathf.Clamp(BulletCount, 0, MaxBulletCount);

    public bool IsFull() => BulletCount >= MaxBulletCount;

    public static Ammo operator +(Ammo a1, Ammo a2) =>
        new Ammo(a1.BulletCount + a2.BulletCount, a1.MaxBulletCount + a2.MaxBulletCount);
    
    public static Ammo operator -(Ammo a1, Ammo a2) =>
        new Ammo(a1.BulletCount - a2.BulletCount, a1.MaxBulletCount - a2.MaxBulletCount);
}