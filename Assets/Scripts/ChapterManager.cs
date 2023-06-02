using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    private bool[] chapterUnlocked;

    private void Awake()
    {
        // set to number of chapters
        chapterUnlocked = new bool[6];
    }

    // Method to unlock a specific chapter
    public void UnlockChapter(int chapterIndex)
    {
        // check the chapter index is valid
        if (chapterIndex >= 0 && chapterIndex < chapterUnlocked.Length)
        {
            chapterUnlocked[chapterIndex] = true;
        }
        else
        {
            Debug.LogWarning("Invalid chapter index: " + chapterIndex);
        }
    }

    // Method to check if a specific chapter is unlocked
    public bool IsChapterUnlocked(int chapterIndex)
    {
        // check the chapter index is valid
        if (chapterIndex >= 0 && chapterIndex < chapterUnlocked.Length)
        {
            return chapterUnlocked[chapterIndex];
        }

        Debug.LogWarning("Invalid chapter index: " + chapterIndex);
        return false;
    }
}
