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

    public void EjectFromPool(AssetItem item, Vector3 position, Vector3 direction)
    {
        if (item.Prefab != null)
        {
            GameObject ejectedItem = Instantiate(item.Prefab, position, Quaternion.identity);
            var target = position + (direction.normalized * _range);
            target = _ground.bounds.ClosestPoint(target);

            ejectedItem.AddComponent<MovingAlongCurve>().StartMoving(
                position, 
                target, 
                Vector3.Lerp(position, target, 0.5f) + new Vector3(0, 2, 0), 
                1
            ).RemoveWhenFinished();
        }
        else
        {
            Debug.LogWarning($"Item {item.Name} does not have a prefab assigned.");
        }
    }
}
       

