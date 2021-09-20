using UnityEngine;

public class PrefabPool : ObjectPoolBase<GameObject>
{
    private readonly GameObject _prefab;
    
    public PrefabPool(int capacity,GameObject prefab) : base(capacity)
    {
        _prefab = prefab;
    }

    protected override GameObject Instantiate()
    {
        return Object.Instantiate(_prefab);
    }

    protected override void Destroy(GameObject item)
    {
        Object.Destroy(item);
    }

    protected override void OnCollect(GameObject item)
    {
        item.SetActive(false);
    }

    public override GameObject Get()
    {
        GameObject obj = base.Get();
        obj.SetActive(true);
        return obj;
    }
}