using UnityEngine;
using System.Collections;

public delegate void OnTriggerEnterEventHandler(Collider2D other);
[RequireComponent(typeof(BoxCollider2D))]
public class Boundary : MonoBehaviour {

    public event OnTriggerEnterEventHandler OnEnterBoundary;
    void Start()
    {
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
