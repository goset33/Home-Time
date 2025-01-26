using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class SecretOfDog : MonoBehaviour
{
    public QuestHandler questHandler;
    public GameObject room;
    private Transform player;

    private void Awake()
    {
        player = questHandler.player;
    }

    public void OnActivate()
    {
        player.position = new Vector3(-3.8f, 0f, 38.4f);
        questHandler.GetComponent<AudioSource>().Stop();
        foreach (VideoPlayer wall in room.GetComponentsInChildren<VideoPlayer>())
        {
            wall.Play();
        }
        StartCoroutine(Returner());
    }

    IEnumerator Returner()
    {
        yield return new WaitUntil(() => !room.GetComponentInChildren<VideoPlayer>().isPlaying);

        player.position = new Vector3(-1f, 0f, 19f);
        questHandler.GetComponent<AudioSource>().Play();
    }
}
