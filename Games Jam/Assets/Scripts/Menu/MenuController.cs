using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene("Master");
    }
}
