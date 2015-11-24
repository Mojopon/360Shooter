using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPresenter : MonoBehaviour
{
    public Transform chargeBar;

    private Image chargeBarImage;
    private Player player;

    void Start()
    {
        chargeBarImage = chargeBar.GetComponent<Image>();
    }

    void Update()
    {
        if(player == null)
        {
            var playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject == null)
            {
                chargeBar.localScale = new Vector3(0, chargeBar.localScale.y, chargeBar.localScale.z);
            }

            player = playerObject.GetComponent<Player>();
        }

        var chargeRate = player.GetCurrentChargeRate();
        chargeBar.localScale = new Vector3(chargeRate, chargeBar.localScale.y, chargeBar.localScale.z);

        if(chargeRate >= 1)
        {
            chargeBarImage.color = Color.blue;
        }else
        {
            chargeBarImage.color = Color.green;
        }
    }
	
}
