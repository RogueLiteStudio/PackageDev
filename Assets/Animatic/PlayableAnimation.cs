using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class BlendPlayable : PlayableBehaviour
{
    public PlayableAnimation Animation;
    public override void PrepareFrame(Playable playable, FrameData info)
    {
        Animation.FrameDataSpeed = info.effectiveSpeed;
        Animation.FrameFrame = info.frameId;
        Animation.State = info.effectivePlayState;
    }
}

public class PlayableAnimation : MonoBehaviour
{
    [System.Serializable]
    public struct BlendInfo
    {
        public int PrePort;
        public int Port;
        public float Time;
        public float Duration;
    }

    public AnimationClip[] clips;
    private PlayableGraph playableGraph;

    public float Speed = 1;

    [Range(0, 1)]
    public float BlendNormalizedTime = 0.2f;

    private AnimationClipPlayable[] animationClipPlayables;
    private AnimationMixerPlayable mixerPlayable;
    [SerializeField]
    private int length;
    [SerializeField]
    private int index;
    [SerializeField]
    private int[] ports = new int[2] { -1, -1};
    [SerializeField]
    private BlendInfo blend;

    [Header("Debug")]
    public float FrameDataSpeed;
    public ulong FrameFrame;
    public PlayState State;

    private void Start()
    {
        playableGraph = PlayableGraph.Create();
        if (clips != null)
        {
            length = clips.Length;
            var animator = GetComponent<Animator>();
            animationClipPlayables = new AnimationClipPlayable[clips.Length];
            for (int i = 0; i < clips.Length; i++)
            {
                animationClipPlayables[i] = AnimationClipPlayable.Create(playableGraph, clips[i]);
            }
            var playableOutput = AnimationPlayableOutput.Create(playableGraph, "Animation", animator);
            int count = clips.Length;
            if (count > 2)
                count = 2;
            mixerPlayable = AnimationMixerPlayable.Create(playableGraph, count);
            for (int i=0; i<count; ++i)
            {
                mixerPlayable.SetInputWeight(i, i > 0 ? 0 : 1);
                playableGraph.Connect(animationClipPlayables[i], 0, mixerPlayable, i);
                ports[i] = i;
            }
            var playable = ScriptPlayable<BlendPlayable>.Create(playableGraph);
            playable.SetInputCount(1);
            playable.ConnectInput(0, mixerPlayable, 0);
            playable.SetInputWeight(0, 1);
            var behaviour = playable.GetBehaviour();
            behaviour.Animation = this;
            playableOutput.SetSourcePlayable(playable);
            playableGraph.Play();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int preIndex = index;
            index++;
            if (index >= length)
                index = 0;
            int prePort = System.Array.IndexOf(ports, preIndex);
            animationClipPlayables[index].SetTime(0);
            mixerPlayable.SetInputWeight(prePort, 0);
            mixerPlayable.SetInputWeight(1- prePort, 1);
            if (ports[0] == index || ports[1] == index)
                return;
            if (ports[0] == preIndex)
            {
                mixerPlayable.DisconnectInput(1);
                mixerPlayable.ConnectInput(1, animationClipPlayables[index], 0);
                mixerPlayable.SetInputWeight(0, 0);
                mixerPlayable.SetInputWeight(1, 1);
                ports[1] = index;
                blend = new BlendInfo 
                { 
                    Time = 0, 
                    Duration = BlendNormalizedTime * clips[index].length, 
                    Port = 1, 
                    PrePort = 0 
                };
            }
            else if (ports[1] == preIndex)
            {
                mixerPlayable.DisconnectInput(0);
                mixerPlayable.ConnectInput(0, animationClipPlayables[index], 0);
                mixerPlayable.SetInputWeight(0, 1);
                mixerPlayable.SetInputWeight(1, 0);
                ports[0] = index;
                blend = new BlendInfo
                {
                    Time = 0,
                    Duration = BlendNormalizedTime * clips[index].length,
                    Port = 0,
                    PrePort = 1
                };
            }
        }
        if (blend.Duration > 0)
        {
            blend.Time += Time.deltaTime;
            float weight = Mathf.Clamp01(blend.Time / blend.Duration);
            mixerPlayable.SetInputWeight(blend.PrePort, 1 - weight);
            mixerPlayable.SetInputWeight(blend.Port, weight);
            if (blend.Time >= blend.Duration)
            {
                blend.Duration = 0;
            }
        }
        mixerPlayable.SetSpeed(Speed);
    }

    private void OnDestroy()
    {
        playableGraph.Destroy();
    }
}
