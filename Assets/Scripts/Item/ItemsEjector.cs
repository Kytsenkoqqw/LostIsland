using System;
using Item;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class ItemsEjector : MonoBehaviour
{
    [SerializeField] private TerrainCollider _ground;
    
    public void EjectFromPool(IItem item, Vector3 position, Vector3 direction)
    {
        var presenter = Instantiate(item.Prefab);
        
        // Используем Raycast для определения высоты поверхности террейна
        if (Physics.Raycast(position + Vector3.up * 10, Vector3.down, out RaycastHit hit, 20, LayerMask.GetMask("Terrain")))
        {
            // Устанавливаем позицию предмета на поверхности террейна
            position.y = hit.point.y;
        }

        presenter.transform.position = position;

        Vector3 target = position;

        if (_ground != null)
        {
            target = _ground.bounds.ClosestPoint(target);
        }

        presenter.gameObject
            .AddComponent<MovingAlongCurve>()
            .StartMoving(position, target, Vector3.Lerp(position, target, 0.5f) + new Vector3(0, 2, 0), 1)
            .RemoveWhenFinished();
    }
}
       

