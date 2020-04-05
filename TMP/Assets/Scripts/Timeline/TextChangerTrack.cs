using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TypoGrapher
{
    [TrackClipType(typeof(TextChanger))]
    [TrackBindingType(typeof(TextItem))]
    public class TextChangerTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var clips = GetClips();
            foreach (var clip in clips)
            {
                var textClip = clip.asset as TextChanger;
                clip.displayName = textClip.Behaviour.text;
            }

            return ScriptPlayable<TextClipMixerBehaviour>.Create(graph, inputCount);
        }
    }
}
