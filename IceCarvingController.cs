using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class IceCarvingController : MonoBehaviour, IPointerClickHandler
{
    public Image iceImage;
    public Sprite iceStartSprite;
    public Sprite iceCarvedCubeSprite;
    public Sprite iceCarvedSphereSprite;
    public Sprite iceCarvedCrushedSprite;

    public Slider carveProgress;
    public float progressPerClick = 0.15f;
    public string nextSceneName = "FruitScene";

    void OnEnable()
    {
        carveProgress.value = 0f;
        if (iceImage != null) iceImage.sprite = iceStartSprite;
    }

    // ต้องแนบสคริปต์นี้ไว้กับ GameObject ที่รับคลิก (เช่น Image_IceBlock)
    public void OnPointerClick(PointerEventData eventData)
    {
        carveProgress.value = Mathf.Clamp01(carveProgress.value + progressPerClick);

        if (carveProgress.value >= 1f)
        {
            var gm = GameManager.Instance;
            if (gm != null)
            {
                switch (gm.selectedIce)
                {
                    case IceType.Cube:
                        iceImage.sprite = iceCarvedCubeSprite; gm.carvedShape = "cube"; break;
                    case IceType.Sphere:
                        iceImage.sprite = iceCarvedSphereSprite; gm.carvedShape = "sphere"; break;
                    case IceType.Crushed:
                        iceImage.sprite = iceCarvedCrushedSprite; gm.carvedShape = "crushed"; break;
                    default:
                        iceImage.sprite = iceCarvedCubeSprite; gm.carvedShape = "cube"; break;
                }
            }

            Invoke(nameof(GoNext), 0.6f);
        }
    }

    void GoNext()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
