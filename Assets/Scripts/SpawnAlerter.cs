using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SpawnAlerter : MonoBehaviour, ISpawnAlerter
{
    public Text alertText;

    void Start()
    {
        alertText.text = "";
    }

    public void AlertNextWave()
    {
        StartCoroutine(AlertCoroutine());
    }

    public void SetText()
    {

    }

    IEnumerator AlertCoroutine()
    {
        alertText.text = "Incoming\nNext Wave!";

        float endTime = Time.time + 2f;

        while(endTime > Time.time)
        {
            yield return null;
        }

        alertText.text = "";
    }
}
