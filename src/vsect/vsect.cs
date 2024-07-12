using Matematica;
using static Matematica.math;
using lib;

namespace vsect;

public struct vertex
{
    public vec3 position;
    public vec3 normal;
    public vec4 tangent;
    public vec4 uv01;
    public bw4 boneweight;
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
    public vec4x4[] bindposes;

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

