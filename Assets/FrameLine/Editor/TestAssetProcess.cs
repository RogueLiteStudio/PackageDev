using FrameLine;
using System;
[CustomFrameLineProcess(typeof(TestAsset))]
public class TestAssetProcess : IFrameLineProcess
{
    public Type EditorWindowType => typeof(TestAssetEditorWindow);

    public bool CheckIsValidNodeType(Type type)
    {
        return typeof(IFrameAction).IsAssignableFrom(type);
    }

    public FrameLineAsset OnCreateAction()
    {
        return null;
    }

    public void OnSave(FrameLineAsset asset)
    {
    }
}