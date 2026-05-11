using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// ============================================================
// ScenarioManager.cs
// Fade animasyonu + mevcut tum mantik korundu.
// CanvasGroup'u otomatik ekler, Inspector'dan eklemeye gerek yok.
// ============================================================
public class ScenarioManager : MonoBehaviour
{
    [Header("Karaciger Objesi")]
    public GameObject liverObject;

    [Header("UI Referanslari")]
    public Text bildirimText;
    public GameObject bildirimPanel;
    public GameObject kararPanel;
    public Button butonA;
    public Button butonB;

    [Header("Zamanlama")]
    public float ilacHatirlatmaSuresi = 5f;
    public float bildirimGostermeSuresi = 3f;
    public float fadeSuresi = 0.3f; // yeni: fade hizi

    [Header("Renkler")]
    public Color saglikliRenk = new Color(0.11f, 0.62f, 0.46f);
    public Color riskliRenk = new Color(0.89f, 0.29f, 0.29f);
    public Color varsayilanRenk = new Color(0.55f, 0.13f, 0.13f);
    public Color bildirimRenk = new Color(0.18f, 0.18f, 0.18f, 0.95f);

    private ScoreManager scoreManager;
    private bool kararBekleniyor = false;
    private Coroutine aktifFade; // cakisan fade'i onle

    void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        RenkSifirla();
        HerSeyleriGizle();
        StartCoroutine(IlacHatirlatmaDongusu());
    }

    void HerSeyleriGizle()
    {
        if (kararPanel != null) kararPanel.SetActive(false);
        if (bildirimPanel != null) bildirimPanel.SetActive(false);
        if (bildirimText != null) bildirimText.gameObject.SetActive(false);
        ButonlariAktiflestir(false);
    }

    IEnumerator IlacHatirlatmaDongusu()
    {
        while (true)
        {
            yield return new WaitForSeconds(ilacHatirlatmaSuresi);
            IlacVaktiBildirimi();
            kararBekleniyor = true;
            yield return new WaitUntil(() => !kararBekleniyor);
            yield return new WaitForSeconds(bildirimGostermeSuresi);
            SifirlaVeDevam();
        }
    }

    void IlacVaktiBildirimi()
    {
        BildirimGoster("Ilac alma zamani!\nNe yapmak istersiniz?", bildirimRenk);
        if (kararPanel != null) kararPanel.SetActive(true);
        ButonlariAktiflestir(true);
    }

    public void IlacAl()
    {
        if (!kararBekleniyor) return;
        kararBekleniyor = false;
        LiverRengi(saglikliRenk);
        scoreManager?.PuanEkle(5);
        ButonlariAktiflestir(false);
        if (kararPanel != null) kararPanel.SetActive(false);
        BildirimGoster("Ilacinizi aldiniz!\nKaracigeriniz saglikli.",
            new Color(0.11f, 0.62f, 0.46f, 0.95f));
    }

    public void IlacAtla()
    {
        if (!kararBekleniyor) return;
        kararBekleniyor = false;
        LiverRengi(riskliRenk);
        scoreManager?.PuanCikar(5);
        ButonlariAktiflestir(false);
        if (kararPanel != null) kararPanel.SetActive(false);
        BildirimGoster("Ilaci atladiniz!\nKaracigeriniz risk altinda.",
            new Color(0.89f, 0.29f, 0.29f, 0.95f));
    }

    void SifirlaVeDevam()
    {
        RenkSifirla();
        HerSeyleriGizle();
    }

    // ----- FADE ANIMASYONU (YENI) -----
    void BildirimGoster(string mesaj, Color renk)
    {
        if (bildirimPanel == null) return;

        if (bildirimText != null)
        {
            bildirimText.gameObject.SetActive(true);
            bildirimText.text = mesaj;
        }

        Image img = bildirimPanel.GetComponent<Image>();
        if (img != null) img.color = renk;

        // onceki fade varsa durdur, yenisini baslat
        if (aktifFade != null) StopCoroutine(aktifFade);
        aktifFade = StartCoroutine(FadeGoster());
    }

    IEnumerator FadeGoster()
    {
        CanvasGroup cg = bildirimPanel.GetComponent<CanvasGroup>();
        if (cg == null) cg = bildirimPanel.AddComponent<CanvasGroup>();

        bildirimPanel.SetActive(true);
        cg.alpha = 0f;

        // fade IN
        float t = 0f;
        while (t < fadeSuresi)
        {
            t += Time.deltaTime;
            cg.alpha = Mathf.Clamp01(t / fadeSuresi);
            yield return null;
        }
        cg.alpha = 1f;
    }

    void ButonlariAktiflestir(bool aktif)
    {
        if (butonA != null) butonA.interactable = aktif;
        if (butonB != null) butonB.interactable = aktif;
    }

    void LiverRengi(Color renk)
    {
        if (liverObject == null) return;
        foreach (Renderer r in
            liverObject.GetComponentsInChildren<Renderer>())
            r.material.color = renk;
    }

    void RenkSifirla()
    {
        if (liverObject == null) return;
        foreach (Renderer r in
            liverObject.GetComponentsInChildren<Renderer>())
            r.material.color = varsayilanRenk;
    }
}