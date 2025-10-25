using UnityEngine;

public enum SpawnType
{
    FromFirePoint,
    AroundPlayer,
    RandomAboveEnemies,
    OnPlayer
}

[CreateAssetMenu(menuName = "Items/Active Item")]
public class ActiveItem : ItemData
{
    [Header("Active Settings")]
    public GameObject projectilePrefab;
    public SpawnType spawnType = SpawnType.FromFirePoint;

    public float baseCooldown = 2f;
    public float baseDamage = 10f;
    public float baseProjectileSpeed = 5f;
    public int baseProjectileCount = 1;
    public float spawnRadius = 5f;
    public float meteorHeight = 10f;

    private float cooldownTimer = 0f;

    public override void OnPickup(StatsManager stats) { cooldownTimer = 0f; }

    public override void OnUpgrade(StatsManager stats)
    {
        level++;
        baseDamage *= 1.2f;
        baseProjectileSpeed *= 1.1f;
        baseProjectileCount += 1;
    }

    public void UpdateItem(StatsManager stats, Transform player, Transform firePoint)
    {
        cooldownTimer -= Time.deltaTime;
        float actualCooldown = baseCooldown / stats.GetStat(Stat.COOLDOWN);

        if (cooldownTimer <= 0f)
        {
            Activate(stats, player, firePoint);
            cooldownTimer = actualCooldown;
        }
    }

    private void Activate(StatsManager stats, Transform player, Transform firePoint)
    {
        int totalProjectiles = baseProjectileCount + (int)(stats.GetStat(Stat.PROJECTILE_AMOUNT) - 1);

        for (int i = 0; i < totalProjectiles; i++)
        {
            Vector3 spawnPos = GetSpawnPosition(player, firePoint);
            Quaternion rotation = GetSpawnRotation(player, firePoint, spawnPos);

            // GameObject proj = Instantiate(projectilePrefab, spawnPos, rotation);
            // if (proj.TryGetComponent(out ProjectileBase projectile))
            // {
            //     projectile.Init(stats, baseDamage * stats.GetStat(Stat.ATTACK), baseProjectileSpeed * stats.GetStat(Stat.PROJECTILE_SPEED));
            // }
        }
    }

    private Vector3 GetSpawnPosition(Transform player, Transform firePoint)
    {
        switch (spawnType)
        {
            case SpawnType.FromFirePoint:
                return firePoint.position;
            case SpawnType.AroundPlayer:
                Vector2 circle = Random.insideUnitCircle.normalized * spawnRadius;
                return player.position + new Vector3(circle.x, 0, circle.y);
            case SpawnType.RandomAboveEnemies:
                // You could later replace this with actual enemy targeting
                Vector2 randomPos = Random.insideUnitCircle * spawnRadius * 2f;
                return new Vector3(player.position.x + randomPos.x, meteorHeight, player.position.z + randomPos.y);
            case SpawnType.OnPlayer:
                return player.position;
            default:
                return firePoint.position;
        }
    }

    private Quaternion GetSpawnRotation(Transform player, Transform firePoint, Vector3 spawnPos)
    {
        if (spawnType == SpawnType.FromFirePoint)
            return firePoint.rotation;
        else if (spawnType == SpawnType.RandomAboveEnemies)
            return Quaternion.LookRotation(Vector3.down); // meteors fall down
        else
            return Quaternion.identity;
    }
}
