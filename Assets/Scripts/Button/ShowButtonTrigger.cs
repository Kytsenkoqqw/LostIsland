using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _treeButton;
    [SerializeField] private Image _imageButton;
    //private GameObject _spawnedButton;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _treeButton.SetActive(true);
            Debug.Log("Enter");
        }
    }
    
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _treeButton.SetActive(false);
            Debug.Log("Exit");
        }
        
    }
}
