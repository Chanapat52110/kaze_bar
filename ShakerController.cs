using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShakerController : MonoBehaviour
{
    public Slider shakeMeter;
    public float fillPerSecond = 0.35f;
    public float decayPerSecond = 0.15f;
    public float required = 1.0f;
    public Animator shakerAnimator; // optional
    public string nextSceneName = "IceSelectScene";

    private bool holding = false;

    void Update()
    {
        if (holding)
            shakeMeter.value = Mathf.Clamp01(shakeMeter.value + fillPerSecond * Time.deltaTime);
        else
            shakeMeter.value = Mathf.Clamp01(shakeMeter.value - decayPerSecond * Time.deltaTime);

        if (shakerAnimator) shakerAnimator.SetBool("Shaking", holding);

        if (shakeMeter.value >= required)
        {
            if (GameManager.Instance != null) GameManager.Instance.drinkShaken = true;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    // เรียกจาก HoldArea หรือ EventTrigger
    public void OnHoldDown() { holding = true; }
    public void OnHoldUp()   { holding = false; }
}
