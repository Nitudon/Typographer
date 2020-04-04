using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace TypoGrapher
{
    /// <summary>
    /// ClipやBehaviourを特定したカスタムClip的なもののベース
    /// </summary>
    public abstract class CustomClipBase<T> : PlayableAsset, ITimelineClipAsset
        where T : PlayableBehaviour, new()
    {
        private T _behaviour;
        public T Behaviour 
        {
            get
            {
                if (_behaviour == null)
                {
                    _behaviour = new T();
                }

                return _behaviour;
            }
        }
        
        public abstract ClipCaps clipCaps { get; }
   
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            // BehaviourのPlayableを作って返すだけ
            return ScriptPlayable<T>.Create(graph);
        }
    }
}