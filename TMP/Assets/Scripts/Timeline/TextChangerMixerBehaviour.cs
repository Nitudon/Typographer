using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

namespace TypoGrapher
{
    /// <summary>
    /// TextClipのミキサー
    /// </summary>
    public class TextClipMixerBehaviour : PlayableBehaviour
    {
        private TextItem _bindingTextItem;
        
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            if (_bindingTextItem == null)
            {
                var textItem = playerData as TextItem;
                if (textItem == null)
                {
                    return;
                }
                
                _bindingTextItem = textItem;
            }
            
            int inputCount = playable.GetInputCount();
            for (int i = 0; i < inputCount; i++)
            {
                if (playable.GetInputWeight(i) <= 0)
                {
                    continue;
                }
                var input = (ScriptPlayable<TextChangerBehaviour>) playable.GetInput(i);
                var text = input.GetBehaviour()?.text ?? string.Empty;
                _bindingTextItem.SetText(text);
                break;
            }
        }
    }
}