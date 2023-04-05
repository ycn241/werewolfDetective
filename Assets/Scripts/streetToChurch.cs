using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerTransport : MonoBehaviour
{
   public void streetToChurch(GameObject charObject)
   {
        SceneManager.LoadScene("insideChurch");
   }
}
