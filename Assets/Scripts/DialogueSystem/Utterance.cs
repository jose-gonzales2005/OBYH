using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class Utterance
{
    [SerializeField] private string speaker;
    [SerializeField] [TextArea] private string spoke;
    [SerializeField] private Sprite sprite;

    public string Speaker => speaker;

    public string Spoke => spoke;

}
