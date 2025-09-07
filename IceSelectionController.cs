using UnityEngine;
using UnityEngine.SceneManagement;

public class IceSelectionController : MonoBehaviour
{
    public string nextSceneName = "IceCarveScene";

    public void PickCube()    { SetIce(IceType.Cube); }
    public void PickSphere()  { SetIce(IceType.Sphere); }
    public void PickCrushed() { SetIce(IceType.Crushed); }

    void SetIce(IceType type)
    {
        if (GameManager.Instance != null) GameManager.Instance.selectedIce = type;
        SceneManager.LoadScene(nextSceneName);
    }
}
