using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    public Transform player;

	void Update ()
    {
        if(player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
	}
}
