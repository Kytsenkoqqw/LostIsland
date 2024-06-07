using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowButtonTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _treeButton;
    [SerializeField] private Image _imageButton;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _treeButton.SetActive(true);
        }
    }
    
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            _treeButton.SetActive(false);
        }
        
    }
}
