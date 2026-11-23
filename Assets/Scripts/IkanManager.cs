using UnityEngine;
using System.Collections;

public class IkanManager : MonoBehaviour
{
    public GameObject[] prefabIkan;
    public Transform[] posisiSpawn;
    private int ikanTersisa = 0;
    private int totalIkanDitangkap = 0;
    private int level = 1;

    void Start()
    {
        SpawnSemuaIkan();
    }

    void SpawnSemuaIkan()
    {
        ikanTersisa = posisiSpawn.Length;

        for (int i = 0; i < posisiSpawn.Length; i++)
        {
            int random = Random.Range(0, prefabIkan.Length);
            GameObject ikan = Instantiate(
                prefabIkan[random],
                posisiSpawn[i].position,
                Quaternion.identity
            );

            TangkapIkan t = ikan.GetComponent<TangkapIkan>();
            if (t == null) t = ikan.AddComponent<TangkapIkan>();
            t.ikanManager = this;

            SphereCollider sc = ikan.GetComponent<SphereCollider>();
            if (sc == null)
            {
                sc = ikan.AddComponent<SphereCollider>();
                sc.isTrigger = true;
                sc.radius = 1.5f;
            }
        }
    }

    public void IkanDitangkap()
    {
        ikanTersisa--;
        totalIkanDitangkap++;

        if (totalIkanDitangkap % 5 == 0)
        {
            NaikLevel();
        }

        if (ikanTersisa <= 0)
        {
            StartCoroutine(SpawnIkanBaru());
        }
    }

    void NaikLevel()
    {
        level++;

        GerakAR gerak = FindAnyObjectByType<GerakAR>();
        if (gerak != null)
            gerak.kecepatan += 0.5f;

        if (PopupManager.instance != null)
            PopupManager.instance.TampilkanPopupLevel(level);
    }

    IEnumerator SpawnIkanBaru()
    {
        yield return new WaitForSeconds(2f);
        SpawnSemuaIkan();
    }
}