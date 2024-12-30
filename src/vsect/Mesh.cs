using static Matematica.math;

namespace vsect;

public struct vertex
{
    public float3 position;
    public float3 normal;
    public float4 tangent;
    public float4 uv01;
    public boneweight4 boneweight;
}

public struct char_vertex
{
    public u32 sourceIndex;
    public f32 blood;
    public f32 flesh;
    public f32 alpha;
}

public struct source_triangle
{
    public u32 index0;
    public u32 index1;
    public u32 index2;
    public u32 material;
}

public struct source_skeleton
{
    public transform[] bones;
    public float4x4[] bindposes;

    public limb[] limbs;

    public u32[] limbToBone;
    public u32[] boneToLimb;

    public u32[][] limbHierarchy;
}

public struct source_mesh
{
    public vertex[] vertices;
    public source_triangle[] triangles;
}
