using UnityEngine;
using System.Collections;

public class TangkapIkan : MonoBehaviour
{
    [Header("Pengaturan Tangkap")]
    public float jarakTangkap = 1f;

    [HideInInspector]
    public IkanManager ikanManager;

    private bool sudahDitangkap = false;
    private bool bisaDitangkap = false;

    void Start()
    {
        // Tampilkan ikan
        SetVisibility(true);

        // Delay 1 detik agar ikan tidak langsung tertangkap saat spawn
        StartCoroutine(AktifkanSetelahDelay());
    }

    IEnumerator AktifkanSetelahDelay()
    {
        yield return new WaitForSeconds(1f);
        bisaDitangkap = true;
    }

    void Update()
    {
        // Jika sudah ditangkap atau belum aktif
        if (sudahDitangkap || !bisaDitangkap)
            return;

        // Cari kucing
        GameObject kucing = GameObject.FindWithTag("Player");

        if (kucing == null)
            return;

        // Hitung jarak
        float jarak = Vector3.Distance(transform.position, kucing.transform.position);

        // Jika jarak cukup dekat
        if (jarak <= jarakTangkap)
        {
            Debug.Log("IKAN TERTANGKAP : " + gameObject.name);

            sudahDitangkap = true;

            // Popup "Nyam"
            if (PopupManager.instance != null)
                PopupManager.instance.TampilkanPopup();

            // Tambah skor
            if (SkorManager.instance != null)
                SkorManager.instance.TambahSkor(10);

            // Beritahu IkanManager
            if (ikanManager != null)
                ikanManager.IkanDitangkap();

            // Hapus ikan dari scene
            Destroy(gameObject);
        }
    }

    void SetVisibility(bool visible)
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        foreach (Renderer r in renderers)
        {
            r.enabled = visible;
        }
    }
}