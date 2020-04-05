using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TypoGrapher
{
    /// <summary>
    /// テキストの設定を行うClip
    /// </summary>
    [Serializable]
    public class TextChanger : CustomClipBase<TextChangerBehaviour>
    {
        public override ClipCaps clipCaps => ClipCaps.None;
    }
    
    [Serializable]
    public class TextChangerBehaviour : PlayableBehaviour
    {
        [SerializeField]
        public string text;
    }
}
