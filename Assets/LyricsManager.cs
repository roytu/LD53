using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LyricsManager : MonoBehaviour
{
    private int lyric = 0;
    public TMPro.TextMeshProUGUI textTMP;
    private string[] lyrics =
    {
        "",
        "yo",
        "I am very sick",
        "But i made this rap for ludum dare",
        "I",
        "I am a fetus",
        "I like money, I got wicked shades",
        "They gave me a pistol",
        "I'll shoot your mom!",
        "I like pressing W to move up",
        "and A and D to move around",
        "and Space to stand up",
        "and R to reset if I get stuck in a wallllll....",
        ""
    };
    public void StartLyric()
    {
        lyric = 0;
        textTMP.text = lyrics[lyric];
    }
    public void UpdateLyric()
    {
        lyric++;
        textTMP.text = lyrics[lyric];
    }
}
