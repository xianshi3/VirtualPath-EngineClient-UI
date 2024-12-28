using System;
using VirtualPathCore.Helpers;
using Silk.NET.Maths;

namespace VirtualPathCore.Graphics;

/// <summary>
/// 表示一个相机，用于处理视图和投影矩阵
/// </summary>
public class Camera
{
    private Vector3D<float> front = -Vector3D<float>.UnitZ;
    private Vector3D<float> up = Vector3D<float>.UnitY;
    private Vector3D<float> right = Vector3D<float>.UnitX;
    private float pitch;
    private float yaw = -MathHelper.PiOver2;
    private float fov = MathHelper.PiOver2;

    /// <summary>
    /// 相机的宽度
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// 相机的高度
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// 相机的位置
    /// </summary>
    public Vector3D<float> Position { get; set; } = new(0.0f, 0.0f, 0.0f);

    /// <summary>
    /// 前方方向向量
    /// </summary>
    public Vector3D<float> Front => front;

    /// <summary>
    /// 上方方向向量
    /// </summary>
    public Vector3D<float> Up => up;

    /// <summary>
    /// 右方方向向量
    /// </summary>
    public Vector3D<float> Right => right;

    /// <summary>
    /// 相机的俯仰角（Pitch），单位为度
    /// </summary>
    public float Pitch
    {
        get => MathHelper.RadiansToDegrees(pitch);
        set
        {
            pitch = MathHelper.DegreesToRadians(MathHelper.Clamp(value, -89f, 89f));
            UpdateVectors();
        }
    }

    /// <summary>
    /// 相机的偏航角（Yaw），单位为度
    /// </summary>
    public float Yaw
    {
        get => MathHelper.RadiansToDegrees(yaw);
        set
        {
            yaw = MathHelper.DegreesToRadians(value);
            UpdateVectors();
        }
    }

    /// <summary>
    /// 相机的视场（FOV），单位为度
    /// </summary>
    public float Fov
    {
        get => MathHelper.RadiansToDegrees(fov);
        set
        {
            fov = MathHelper.DegreesToRadians(MathHelper.Clamp(value, 1f, 90f));
        }
    }

    /// <summary>
    /// 获取视图矩阵
    /// </summary>
    public Matrix4X4<float> View => Matrix4X4.CreateLookAt(Position, Position + Front, Up);

    /// <summary>
    /// 获取投影矩阵
    /// </summary>
    public Matrix4X4<float> Projection => Matrix4X4.CreatePerspectiveFieldOfView(fov, (float)Width / Height, 0.1f, 1000.0f);

    /// <summary>
    /// 更新方向向量
    /// </summary>
    private void UpdateVectors()
    {
        front.X = MathF.Cos(pitch) * MathF.Cos(yaw);
        front.Y = MathF.Sin(pitch);
        front.Z = MathF.Cos(pitch) * MathF.Sin(yaw);

        front = Vector3D.Normalize(front);

        right = Vector3D.Normalize(Vector3D.Cross(front, Vector3D<float>.UnitY));
        up = Vector3D.Normalize(Vector3D.Cross(right, front));
    }
}
