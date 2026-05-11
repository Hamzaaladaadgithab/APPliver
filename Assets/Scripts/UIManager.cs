using UnityEngine;
using UnityEngine.UI;

// ============================================================
// UIManager.cs
// GameManager objesine bagla.
// Buton etiketlerini Turkce ayarlar.
// ============================================================
public class UIManager : MonoBehaviour
{
    [Header("Butonlar")]
    public Button butonA;
    public Button butonB;

    void Start()
    {
        AyarlaButon(butonA, "Hemen ilac al  +5");
        AyarlaButon(butonB, "Sonra alirim  -5");
    }

    void AyarlaButon(Button btn, string etiket)
    {
        if (btn == null) return;
        Text t = btn.GetComponentInChildren<Text>();
        if (t != null) t.text = etiket;
    }
}
