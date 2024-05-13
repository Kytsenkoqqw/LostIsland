using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestroy : MonoBehaviour
{
    public void OnButtonClick()
    {
        StartCoroutine(DestroyTree());
    }

    public IEnumerator DestroyTree()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
