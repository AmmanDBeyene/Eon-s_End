using Unity.VisualScripting; using Assets.Event_Scripts;
public class EditorOutputTest : EventController { 
    void Start() { Load(); }
    public void Load() {
        SerializationData data = new SerializationData(@"");
        rootPipe = (IEventPipe)data.Deserialize();
    }
}
