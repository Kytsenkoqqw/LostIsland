using System;
using Item;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ItemsEjector : MonoBehaviour
{
    
    [SerializeField] private ItemsObjectPool _pool;
    [SerializeField] private float _range;
    [SerializeField] private TerrainCollider _ground;
    [SerializeField] private AssetItem itemData;
    
    public void EjectFromPool(IItem item, Vector3 position, Vector3 direction)
    {
        var presenter = Instantiate(item.Prefab);
        presenter.transform.position = position;

        Vector3 target = position;

        if (_ground != null)
        {
            target = _ground.bounds.ClosestPoint(target);
        }

        // Устанавливаем начальную и конечную позицию для перемещения
        presenter.gameObject
            .AddComponent<MovingAlongCurve>()
            .StartMoving(position, target, Vector3.Lerp(position, target, 0.5f) + new Vector3(0, 2, 0), 1)
            .RemoveWhenFinished();
    }
}
       

