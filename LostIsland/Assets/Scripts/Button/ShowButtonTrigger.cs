using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonTrigger : MonoBehaviour, IShowButtonTrigger
{
    public List<Collider> _collidersObject;
    [SerializeField] private Button _treeButton;
    [SerializeField] private Transform _spawnButtonPoint;

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PlayerController>())
        {
            foreach (Collider Tree in _collidersObject)
            {
                if (collider.gameObject == Tree)
                {
                    Debug.Log("Bamm");
                    SpawnButton(); 
                }
                
            }
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        throw new System.NotImplementedException();
    }

    private void SpawnButton()
    {
       // Instantiate(_treeButton, _spawnButtonPoint, Quaternion.identity);
       Debug.Log("NANANA");
    }
}
