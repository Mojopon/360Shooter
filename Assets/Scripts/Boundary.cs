using UnityEngine;
using System.Collections;

public delegate void OnTriggerEnterEventHandler(Collider2D other);
[RequireComponent(typeof(BoxCollider2D))]
public class Boundary : MonoBehaviour {

    public event OnTriggerEnterEventHandler OnEnterBoundary;
    BoundariesController controller;
    void Start()
    {
        controller = GetComponentInParent<BoundariesController>();
        if(controller != null)
        {
            Debug.Log("got a script from the parent");
        }
        GetComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(OnEnterBoundary != null)
        {
            OnEnterBoundary(other);
        }
    }
}
