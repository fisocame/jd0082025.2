using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMudador : MonoBehaviour
{
    public void MudarCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);        
    }
}
