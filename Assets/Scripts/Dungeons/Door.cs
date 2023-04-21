using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] string targetName; 

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetButton("Jump"))
        {
            SceneManager.LoadScene(sceneName);
            DungeonMaster.instance.spawnLocationName = targetName;
        }
    }
}
