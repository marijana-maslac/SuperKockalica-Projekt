using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SecondPlayerMovement : MonoBehaviour
{
    public float brzina = 10f;
    public float sirinaMape = 10f;
    int trenutniRezultat;
    int trenutniCoins = 0;
    public float brzinaKretanja = 10f;
    private Rigidbody RB;

    public TextMeshProUGUI Rezultat;
    public TextMeshProUGUI HighScore;
    public TextMeshProUGUI Coins;
    public AudioClip CoinSound;
    public AudioClip DeathSound;

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        Time.timeScale = 1f;

        trenutniCoins = PlayerPrefs.GetInt("DrugiCoins");
        Coins.text = "COINS: " + PlayerPrefs.GetInt("DrugiCoins", trenutniCoins);

        if (!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        HighScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        StartCoroutine(ScoreTime());
    }

    IEnumerator ScoreTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            trenutniRezultat += 1;
            Rezultat.text = "REZULTAT: " + trenutniRezultat;

            if (trenutniRezultat > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", trenutniRezultat);
            }
            HighScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            AudioSource.PlayClipAtPoint(DeathSound, transform.position, 100);
            RB.constraints = RigidbodyConstraints.FreezeAll;
            StartCoroutine(DelaySceneLoad());
        }
        if (collision.gameObject.tag == "Coins")
        {
            trenutniCoins++;
            trenutniRezultat += 5;
            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator DelaySceneLoad()
    {
        Time.timeScale = 1f / brzinaKretanja;
        Time.fixedDeltaTime = Time.fixedDeltaTime / brzinaKretanja;

        yield return new WaitForSeconds(3f / brzinaKretanja);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * brzinaKretanja;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boost")
        {
            brzina = 16f;
            StartCoroutine(BackSpeed());
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Slow")
        {
            brzina = 4f;
            StartCoroutine(BackSpeed());
            Destroy(other.gameObject);
        }
    }

    IEnumerator BackSpeed()
    {
        yield return new WaitForSeconds(3);
        brzina = 10f;
    }

    private void Update()
    {
        Coins.text = "COINS: " + trenutniCoins;
        PlayerPrefs.SetInt("DrugiCoins", trenutniCoins);
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        HighScore.text = "HIGH SCORE: " + 0;
        trenutniCoins = 0;
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Vertical") * Time.fixedDeltaTime * brzina;
        Vector3 granice = RB.position + Vector3.right * x;                   //granice:> kocka dolazi do 10 ili -10 position na x osi i to joj je granica, ne ide dalje
        granice.x = Mathf.Clamp(granice.x, -sirinaMape, sirinaMape);
        RB.MovePosition(granice);
    }
}
