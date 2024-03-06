using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IShowButtonTrigger
{
    public void OnTriggerEnter(Collider collider);
    public void OnTriggerExit(Collider collider);

    public void ShowButton();
}
