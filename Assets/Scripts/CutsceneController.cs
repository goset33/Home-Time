using System.Collections;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

// Ётот класс контролирует стартовую катсцену с мамой, открытие двери после уборки комнаты, канвас "UI" и таймер
public class CutsceneController : MonoBehaviour
{
    private int timer = 900; // 15 минут в секундах
    private AudioSource audioSource;

    public GameObject momPrefab;
    public Animator momAnimator;
    public Transform door, locomotion;
    public TextMeshProUGUI counter, subtitle;
    public AudioClip[] sounds;
    public LocalizedString[] localizedStrings;

    public UnityEvent onGameStart, onTimeOut;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(StarterCutscene());
    }

    IEnumerator StarterCutscene()
    {
        audioSource.PlayOneShot(sounds[0], 0.6f);
        momAnimator.SetBool("Talking", true);
        subtitle.text = localizedStrings[0].GetLocalizedString();
        yield return new WaitForSeconds(9f);
        momAnimator.SetBool("Talking", false);
        DOTween.Sequence()
            .Append(momAnimator.transform.DORotate(new Vector3(0f, -100f, 0f), 1f))
            .Append(momAnimator.transform.DOMove(new Vector3(-2.1f, 0f, -7.7f), 1f))
            .Join(momAnimator.transform.DORotate(new Vector3(0f, -30f, 0f), 1f))
            .Append(momAnimator.transform.DOMove(new Vector3(-3.3f, 0f, -6.75f), 2f))
            .Append(door.DORotate(new Vector3(0f, 180f, 0f), 1f))
            .Join(door.DOMove(new Vector3(-2.1f, 0f, -7.7f), 1f));
        yield return new WaitForSeconds(4.7f);
        audioSource.PlayOneShot(sounds[1], 0.6f);
        Destroy(momAnimator.gameObject, 0.1f);
        momAnimator = null;
        yield return new WaitForSeconds(0.3f);

        audioSource.PlayOneShot(sounds[2]);
        subtitle.text = localizedStrings[1].GetLocalizedString();
        yield return new WaitForSeconds(3f);

        subtitle.text = localizedStrings[2].GetLocalizedString();
        onGameStart?.Invoke();
        for (int i = 0; i < locomotion.childCount; i++)
        {
            locomotion.GetChild(i).gameObject.SetActive(true);
        }
        StartCoroutine(UpdateTime(1));
    }

    //  орутина таймера, котора€ каждую секунду отсчитывает врем€ пока оно не истечет
    IEnumerator UpdateTime(int timeInSec) 
    {
        yield return new WaitForSeconds(timeInSec);

        timer -= timeInSec;
        string minutes = timer / 60 < 10 ? "0" + timer / 60 : (timer / 60).ToString();
        string seconds = timer % 60 < 10 ? "0" + timer % 60 : (timer % 60).ToString();
        counter.text = $"{minutes}:{seconds}";

        if (timer > 0)
        {
            StartCoroutine(UpdateTime(timeInSec));
        }
        else
        {
            timer = 0;
            onTimeOut?.Invoke();
        }
    }

    public void WhenBasketFilled()
    {
        subtitle.text = "";
        audioSource.PlayOneShot(sounds[3], 0.3f);
        DOTween.Sequence()
            .Append(door.DORotate(new Vector3(0f, 135f, 0f), 1f))
            .Join(door.DOMove(new Vector3(-2.6f, 0f, -7.9f), 1f));
    }

    public void CleanEnd()
    {
        StartCoroutine(CleanEnding());
    }

    IEnumerator CleanEnding()
    {
        Instantiate(momPrefab, new Vector3(2.5f, 0f, 2.2f), Quaternion.Euler(0f, -90f, 0f));
        locomotion.parent.position = new Vector3(-1f, 0f, 1.5f);
        for (int i = 0; i < locomotion.childCount; i++)
        {
            locomotion.GetChild(i).gameObject.SetActive(false);
        }

        subtitle.text = localizedStrings[3].GetLocalizedString();
        audioSource.PlayOneShot(sounds[4], 0.7f);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Shop");
    }
}
