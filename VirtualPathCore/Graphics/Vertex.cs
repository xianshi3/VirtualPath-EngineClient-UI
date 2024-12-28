using Silk.NET.Maths;

namespace VirtualPathCore.Graphics;

/// <summary>
/// 表示一个顶点结构，包含顶点的位置、法线、切线、副切线、颜色和纹理坐标信息
/// </summary>
public struct Vertex(Vector3D<float> position = default, Vector3D<float> normal = default, Vector3D<float> tangent = default, Vector3D<float> bitangent = default, Vector4D<float> color = default, Vector2D<float> texCoord = default)
{
    /// <summary>
    /// 顶点的位置坐标
    /// </summary>
    public Vector3D<float> Position = position;

    /// <summary>
    /// 顶点的法线向量
    /// </summary>
    public Vector3D<float> Normal = normal;

    /// <summary>
    /// 顶点的切线向量
    /// </summary>
    public Vector3D<float> Tangent = tangent;

    /// <summary>
    /// 顶点的副切线向量
    /// </summary>
    public Vector3D<float> Bitangent = bitangent;

    /// <summary>
    /// 顶点的颜色值
    /// </summary>
    public Vector4D<float> Color = color;

    /// <summary>
    /// 顶点的纹理坐标
    /// </summary>
    public Vector2D<float> TexCoord = texCoord;
}
