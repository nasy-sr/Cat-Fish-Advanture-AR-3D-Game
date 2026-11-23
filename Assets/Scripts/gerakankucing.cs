using UnityEngine;

public class gerakankucing : MonoBehaviour
{
    public float kecepatan = 5f;
    private CharacterController cc;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        if (cc == null) return;
    }

    void Update()
    {
        if (cc == null) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 gerak = new Vector3(h, 0f, v).normalized;

        if (gerak.magnitude > 0.1f)
        {
            cc.Move(gerak * kecepatan * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(gerak),
                0.2f
            );
        }

        cc.Move(Vector3.down * 9.8f * Time.deltaTime);
    }
}

