using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour
{
    private List<Transform> quests = new();
    private int finishedQuests;

    public Sprite checkmarkSprite;

    [Space]
    public Transform player;
    public AudioClip endMusic;

    private void Awake()
    { 
        for (int i = 0; i < transform.childCount; i++)
        {
            quests.Add(transform.GetChild(i));
        }
    }

    public void StartMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void QuestFinished(int index)
    {
        quests[index].GetChild(1).GetComponent<Image>().sprite = checkmarkSprite;
        finishedQuests++;
        if (finishedQuests == 4)
        {
            GameEnding();
        }
    }

    public void GameEnding()
    {
        transform.parent.parent.position = new Vector3(-1f, 2f, 15.47f);
        transform.parent.parent.localScale = transform.parent.parent.localScale * 2f;
        player.position = new Vector3(-1f, 0f, 19f);
        GetComponent<AudioSource>().clip = endMusic;
        GetComponent<AudioSource>().Play();
    }
}
