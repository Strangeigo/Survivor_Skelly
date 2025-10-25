using UnityEngine;

[CreateAssetMenu(fileName = "BasicBulletEffect", menuName = "Scriptable Objects/ItemEffect/BasicBulletEffect")]
public class BasicBulletEffect : ItemEffect
{
    public GameObject projectilePrefab;
    public float damage = 10f;
    public float projectileSpeed = 10f;
    public int picochetAmmount = 1;

    private Transform ownerTransform;

    public override void OnEquip(GameObject owner)
    {
        ownerTransform = owner.transform;
    }

    public override void Trigger(GameObject owner)
    {
        Vector3 spawnPos = ownerTransform.position + ownerTransform.forward;
        GameObject proj = Instantiate(projectilePrefab, ownerTransform);
        //  ObjectPoolManager.Instance.Spawn(projectilePrefab, spawnPos, ownerTransform.rotation);
        // proj.GetComponent<Projectile>().damage = damage + (stackCount - 1) * 5f; // example scaling
        // proj.GetComponent<Projectile>().speed = projectileSpeed;
    }

    public override void OnUnequip(GameObject owner)
    {
        // Clean-up if needed
    }

    public override void Stack(GameObject owner)
    {
        base.Stack(owner);
        // You can adjust damage, visuals, etc. here
    }
}