using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestHandler : MonoBehaviour
{
    private List<Transform> quests = new();
    private List<int> finishedQuests = new();
    public int maxQuests;

    public bool isInShop;

    public Sprite checkmarkSprite;

    [Space]
    public Transform player;
    public AudioClip endMusic;
    public UnityEvent onCleanEnding;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            quests.Add(transform.GetChild(i));
        }

        if (isInShop)
        {
            for (int i = 0; i < quests.Count;  i++)
            {
                quests[i].GetChild(1).GetComponent<Image>().sprite = checkmarkSprite;
            }
        }
        else PlayerPrefs.DeleteAll();
    }

    public void StartMusic()
    {
        GetComponent<AudioSource>().Play();
    }

    public void QuestFinished(int index)
    {
        quests[index].GetChild(1).GetComponent<Image>().sprite = checkmarkSprite;
        finishedQuests.Add(index);
        PlayerPrefs.SetInt($"Task{index}", 1);
        if (finishedQuests.Count == maxQuests)
        {
            onCleanEnding?.Invoke();
        }
    }

    public void GameLose()
    {
        transform.parent.parent.position = new Vector3(-1f, 2f, 15.47f);
        transform.parent.parent.localScale = transform.parent.parent.localScale * 2f;
        player.position = new Vector3(-1f, 0f, 19f);
        GetComponent<AudioSource>().clip = endMusic;
        GetComponent<AudioSource>().Play();
    }

    public void GameWin()
    {
        player.position = new Vector3(-23.5f, 0f, 4f);
        GetComponent<AudioSource>().clip = endMusic;
        GetComponent<AudioSource>().Play();
    }
}
