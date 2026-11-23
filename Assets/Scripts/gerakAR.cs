using UnityEngine;
using UnityEngine.EventSystems;

public class GerakAR : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [Header("Gerakan")]
    public float kecepatan = 3f;
    public RectTransform joystickBG;
    public RectTransform joystickHandle;
    public Transform kucing;

    [Header("Batas Kamera")]
    public float radiusDariKamera = 2f;      // Maksimal jarak kucing dari kamera
    public float kecepatanFollow = 5f;       // Kecepatan kembali

    private Vector2 inputGerak;
    private CharacterController cc;
    private float radius;
    private float posisiY;
    private Animator anim;
    private bool sedangJalan = false;

    void Start()
    {
        if (kucing != null)
        {
            cc = kucing.GetComponent<CharacterController>();
            anim = kucing.GetComponentInChildren<Animator>();
            posisiY = kucing.position.y;
        }

        radius = joystickBG.sizeDelta.x * 0.5f;
    }

    void Update()
    {
        if (cc == null) return;

        Camera cam = Camera.main;
        if (cam == null) return;

        // Arah mengikuti kamera
        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 gerak = forward * inputGerak.y + right * inputGerak.x;

        cc.Move(gerak * kecepatan * Time.deltaTime);

        // Kunci posisi Y
        Vector3 pos = kucing.position;
        pos.y = posisiY;
        kucing.position = pos;

        // Rotasi
        if (gerak != Vector3.zero)
        {
            kucing.rotation = Quaternion.Slerp(
                kucing.rotation,
                Quaternion.LookRotation(gerak),
                8f * Time.deltaTime
            );
        }

        // Animasi
        if (anim != null)
        {
            if (inputGerak.magnitude > 0.1f)
            {
                if (!sedangJalan)
                {
                    sedangJalan = true;
                    anim.Play("walk");
                }
            }
            else
            {
                if (sedangJalan)
                {
                    sedangJalan = false;
                    anim.Play("idle");
                }
            }
        }

        // Pastikan kucing tetap berada dekat kamera
        BatasiJarakKucing();
    }

    void BatasiJarakKucing()
    {
        Camera cam = Camera.main;

        Vector3 posisiKamera = cam.transform.position;

        posisiKamera.y = posisiY;

        Vector3 arah = kucing.position - posisiKamera;

        arah.y = 0;

        if (arah.magnitude > radiusDariKamera)
        {
            Vector3 target =
                posisiKamera +
                arah.normalized * radiusDariKamera;

            target.y = posisiY;

            kucing.position = Vector3.Lerp(
                kucing.position,
                target,
                kecepatanFollow * Time.deltaTime
            );
        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public void OnDrag(PointerEventData ped)
    {
        Vector2 direction;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickBG,
            ped.position,
            ped.pressEventCamera,
            out direction
        );

        direction = Vector2.ClampMagnitude(direction, radius);

        joystickHandle.localPosition = direction;

        inputGerak = direction / radius;
    }

    public void OnPointerUp(PointerEventData ped)
    {
        inputGerak = Vector2.zero;

        joystickHandle.localPosition = Vector2.zero;

        if (anim != null)
        {
            sedangJalan = false;
            anim.Play("idle");
        }
    }
}