using System;
using UnityEngine;

[Serializable]
public class Message
{
    public string name;
    public Sprite image;
    [TextArea(3, 10)]
    public string sentence;
}
