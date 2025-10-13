using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class TargetHit : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    private float messageDuration = 2f;

    private float grabTime;
    private bool isGrabbed = false;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.onSelectEntered.AddListener(OnGrabbed);
        }
    }

    private void OnGrabbed(XRBaseInteractor interactor)
    {
        isGrabbed = true;
        grabTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isGrabbed) return;
        if (collision.gameObject.name != "WallTarget") return;
        if (Camera.main == null) return;

        float distance = Vector3.Distance(Camera.main.transform.position, transform.position);
        float timeTaken = Time.time - grabTime;
        float score = distance * timeTaken;

        ShowMessage($"Nice! Score: {score:F1}");

        isGrabbed = false;
    }

    private void ShowMessage(string text)
    {
        if (messageText == null) return;

        messageText.gameObject.SetActive(true);
        messageText.text = text;

        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), messageDuration);
    }

    private void HideMessage()
    {
        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }
}
