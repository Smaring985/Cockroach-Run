using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            int nextLVL = SceneManager.GetActiveScene().buildIndex;
            nextLVL++;
            SceneManager.LoadScene(nextLVL);
            Debug.Log("k");
        }
    }
}
