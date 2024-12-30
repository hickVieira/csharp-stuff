namespace VSect
{
    public struct float3;
    public struct float4;
    public struct float3x3;
    public struct float4x4;

    public struct boneweight4;

    public struct transform;
    public struct bone;
    public struct limb;

    public class Component;
    public class MonoBehaviour : Component;
    public class Renderer : Component;
    public class MeshRenderer : Renderer;
    public class SkinnedMeshRenderer : Renderer;

    public class Skeleton
    {
        limb[] limbs { get; set; }
    }

    public class Model
    {
        public Renderer renderer { get; set; }
        public Skeleton skeleton { get; set; }
    }

    public abstract class Form : MonoBehaviour
    {
        public Core.Entity entity { get; set; }
        public Model[] models { get; set; }
    }
}