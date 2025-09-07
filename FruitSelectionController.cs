using UnityEngine;
using UnityEngine.SceneManagement;

public class FruitSelectionController : MonoBehaviour
{
    public string nextSceneName = "ServeScene"; // หรือ "Bar" ตาม flow ที่ต้องการ

    public void PickFruit(string fruitId)
    {
        if (GameManager.Instance != null) GameManager.Instance.selectedFruit = fruitId;
        SceneManager.LoadScene(nextSceneName);
    }
}
