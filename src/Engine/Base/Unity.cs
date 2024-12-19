using vsect;

namespace Game.Base;

public class Component;
public class MonoBehaviour;
public class Renderer;
public class MeshRenderer : Renderer;
public class SkinnedMeshRenderer : Renderer;

public class Skeleton
{
    limb[] limbs { get; }
}

public class Model
{
    public Renderer renderer { get; }
    public Skeleton skeleton { get; }
}

public abstract class Form : MonoBehaviour
{
    public Entity entity { get; }
    public Model[] models { get; }
}
