using UnityEngine;
using System.Collections;

public delegate void OnBoundaryEnter(Transform boundary, Collider2D other);

public class BoundariesController : MonoBehaviour {

    public Transform target;
    public Transform boundary;
    public float battleFieldSizeX = 50f;
    public float battleFieldSizeY = 50f;

    private Transform leftBoundary;
    private Transform rightBoundary;
    private Transform topBoundary;
    private Transform bottomBoundary;

	void Start ()
    {
        leftBoundary = Instantiate(boundary, Vector3.zero, Quaternion.identity) as Transform;
        leftBoundary.SetParent(transform);
        leftBoundary.position -= new Vector3(battleFieldSizeX / 2f, 0, 0);
        leftBoundary.localScale = new Vector3(1, battleFieldSizeY, 1);

        rightBoundary = Instantiate(boundary, Vector3.zero, Quaternion.identity) as Transform;
        rightBoundary.SetParent(transform);
        rightBoundary.position += new Vector3(battleFieldSizeX / 2f, 0, 0);
        rightBoundary.localScale = new Vector3(1, battleFieldSizeY, 1);

        topBoundary = Instantiate(boundary, Vector3.zero, Quaternion.identity) as Transform;
        topBoundary.SetParent(transform);
        topBoundary.position += new Vector3(0, battleFieldSizeY / 2f, 0);
        topBoundary.localScale = new Vector3(battleFieldSizeX, 1, 1);

        bottomBoundary = Instantiate(boundary, Vector3.zero, Quaternion.identity) as Transform;
        bottomBoundary.SetParent(transform);
        bottomBoundary.position -= new Vector3(0, battleFieldSizeY / 2f, 0);
        bottomBoundary.localScale = new Vector3(battleFieldSizeX, 1, 1);

        leftBoundary.GetComponent<Boundary>().OnEnterBoundary += new OnTriggerEnterEventHandler(TeleportObjectToRightBoundary);
        rightBoundary.GetComponent<Boundary>().OnEnterBoundary += new OnTriggerEnterEventHandler(TeleportObjectToLeftBoundary);
        topBoundary.GetComponent<Boundary>().OnEnterBoundary += new OnTriggerEnterEventHandler(TeleportObjectToBottomBoundary);
        bottomBoundary.GetComponent<Boundary>().OnEnterBoundary += new OnTriggerEnterEventHandler(TeleportObjectToTopBoundary);
    }

    void TeleportObjectToRightBoundary(Collider2D other)
    {
        var obj = other.transform;

        var margin = obj.position - leftBoundary.position;
        obj.position = new Vector3(obj.position.x + battleFieldSizeX - (margin.x * 2), obj.position.y, obj.position.z);
    }

    void TeleportObjectToLeftBoundary(Collider2D other)
    {
        var obj = other.transform;
  
        var margin = obj.position - rightBoundary.position;
        obj.position = new Vector3(obj.position.x - battleFieldSizeX - (margin.x * 2), obj.position.y, obj.position.z);
    }

    void TeleportObjectToTopBoundary(Collider2D other)
    {
        var obj = other.transform;

        var margin = obj.position - bottomBoundary.position;
        obj.position = new Vector3(obj.position.x , obj.position.y + battleFieldSizeY - (margin.y * 2), obj.position.z);
    }

    void TeleportObjectToBottomBoundary(Collider2D other)
    {
        var obj = other.transform;

        var margin = obj.position - topBoundary.position;
        obj.position = new Vector3(obj.position.x, obj.position.y - battleFieldSizeY - (margin.y * 2), obj.position.z);
    }

    void Update()
    {
        transform.position = target.position;
    }
}
