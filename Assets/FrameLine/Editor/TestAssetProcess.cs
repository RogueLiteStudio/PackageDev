using FrameLine;
using System;
[CustomFrameLineProcess(typeof(TestAsset))]
public class TestAssetProcess : IFrameLineProcess
{
    public Type EditorWindowType => typeof(TestAssetEditorWindow);

    public FrameLineAsset OnCreateAction()
    {
        return null;
    }

    public void OnSave(FrameLineAsset asset)
    {
    }
}