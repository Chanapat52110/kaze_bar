using UnityEngine;

public enum IceType { None, Cube, Sphere, Crushed }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // ค่าที่แชร์ข้าม Scene
    public bool drinkShaken = false;
    public IceType selectedIce = IceType.None;
    public string carvedShape = "";
    public string selectedFruit = "";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ResetOrder()
    {
        drinkShaken = false;
        selectedIce = IceType.None;
        carvedShape = "";
        selectedFruit = "";
    }
}
