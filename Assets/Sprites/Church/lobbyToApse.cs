using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//original position
// x = 3.25, y = -5, z = -10
//new position
//x = 3.25, y = 4.5, z = -10
public class lobbyToApse : MonoBehaviour
{
    public GameObject player;
    public Transform playerUpperPoint;
    public Transform playerLowerPoint;
    public Transform CameraPointUpper;
    public Transform CameraPointLower;
 
    int trigger = 0;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player" && trigger == 0) {
            Vector3 newPosition = CameraPointUpper.position;
            Camera.main.transform.position = newPosition;
            player.transform.position = playerUpperPoint.transform.position;
            trigger = 1;
        }
        else if (collision.tag == "Player" && trigger == 1) {
            Vector3 newPosition = CameraPointLower.position;
            Camera.main.transform.position = newPosition;
            player.transform.position = playerLowerPoint.transform.position;
            trigger = 0;
        }
    }
}
