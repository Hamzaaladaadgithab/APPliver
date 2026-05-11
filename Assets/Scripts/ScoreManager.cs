using UnityEngine;
using UnityEngine.UI;
using Firebase.Firestore;
using System.Collections.Generic;

// ============================================================
// ScoreManager.cs
// GameManager objesine bagla (ScenarioManager ile ayni obje).
// Firebase kurulduktan sonra bu dosyayi kullan.
// ============================================================
public class ScoreManager : MonoBehaviour
{
    [Header("Skor UI")]
    public Text skorText;
    public Text dogruText;
    public Text yanlisText;

    private int skor = 0;
    private int dogru = 0;
    private int yanlis = 0;

    // Firebase
    private FirebaseFirestore db;
    private string userId;

    void Start()
    {
        db = FirebaseFirestore.DefaultInstance;
        userId = SystemInfo.deviceUniqueIdentifier;
        UIGuncelle();
    }

    public void PuanEkle(int miktar)
    {
        skor += miktar;
        dogru += 1;
        UIGuncelle();
        FirestoreYaz();
    }

    public void PuanCikar(int miktar)
    {
        skor -= miktar;
        yanlis += 1;
        UIGuncelle();
        FirestoreYaz();
    }

    void UIGuncelle()
    {
        if (skorText != null) skorText.text = "Skor: " + skor;
        if (dogruText != null) dogruText.text = "Dogru: " + dogru;
        if (yanlisText != null) yanlisText.text = "Yanlis: " + yanlis;
    }

    void FirestoreYaz()
    {
        if (db == null) return;

        DocumentReference docRef =
            db.Collection("scores").Document(userId);

        Dictionary<string, object> data =
            new Dictionary<string, object>
        {
            { "skor",   skor   },
            { "dogru",  dogru  },
            { "yanlis", yanlis },
            { "zaman",  FieldValue.ServerTimestamp }
        };

        // Async — hata olursa sessiz devam eder
        docRef.SetAsync(data).ContinueWith(task =>
        {
            if (task.IsFaulted)
                Debug.LogWarning("Firestore yazma hatasi: " + task.Exception);
        });
    }

    public void Sifirla()
    {
        skor = dogru = yanlis = 0;
        UIGuncelle();
        FirestoreYaz(); // sýfýrlamayý da kaydet
    }
}