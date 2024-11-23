using System;
using Silk.NET.Maths;

namespace VirtualPathCore.Helpers
{
    /// <summary>
    /// 数学扩展方法的集合，提供额外的矩阵和向量操作
    /// </summary>
    public static class MathExtensions
    {
        /// <summary>
        /// 计算给定 4x4 矩阵的逆矩阵
        /// </summary>
        /// <typeparam name="T">矩阵元素的类型，必须满足特定的约束条件</typeparam>
        /// <param name="value">要计算逆矩阵的矩阵</param>
        /// <returns>计算得到的逆矩阵</returns>
        public static Matrix4X4<T> Invert<T>(this Matrix4X4<T> value) where T : unmanaged, IFormattable, IEquatable<T>, IComparable<T>
        {
            Matrix4X4.Invert(value, out Matrix4X4<T> result);
            return result;
        }

        /// <summary>
        /// 将一个浮点向量转换为字节向量，值范围被缩放到 0 到 255
        /// </summary>
        /// <param name="value">要转换的浮点向量</param>
        /// <returns>转换后的字节向量</returns>
        public static Vector4D<byte> ToByte(this Vector4D<float> value)
        {
            return new Vector4D<byte>((byte)(value.X * 255), (byte)(value.Y * 255), (byte)(value.Z * 255), (byte)(value.W * 255));
        }

        /// <summary>
        /// 将字节向量转换为浮点向量，值范围从 0 到 255 映射到 0.0 到 1.0
        /// </summary>
        /// <param name="value">要转换的字节向量</param>
        /// <returns>转换后的浮点向量</returns>
        public static Vector4D<float> ToSingle(this Vector4D<byte> value)
        {
            return new Vector4D<float>(value.X / 255.0f, value.Y / 255.0f, value.Z / 255.0f, value.W / 255.0f);
        }

        /// <summary>
        /// 将弧度转换为度数
        /// </summary>
        /// <param name="value">要转换的弧度向量</param>
        /// <returns>转换后的度数向量</returns>
        public static Vector3D<float> RadianToDegree(this Vector3D<float> value)
        {
            return value * 180.0f / MathF.PI;
        }

        /// <summary>
        /// 将度数转换为弧度
        /// </summary>
        /// <param name="value">要转换的度数向量</param>
        /// <returns>转换后的弧度向量</returns>
        public static Vector3D<float> DegreeToRadian(this Vector3D<float> value)
        {
            return value * MathF.PI / 180.0f;
        }

        /// <summary>
        /// 将四元数转换为欧拉角
        /// </summary>
        /// <param name="rotation">要转换的四元数</param>
        /// <returns>转换后的欧拉角向量，其中 x 是俯仰，y 是偏航，z 是滚转</returns>
        public static Vector3D<float> ToEulerAngles(this Quaternion<float> rotation)
        {
            float yaw = MathF.Atan2(2.0f * (rotation.Y * rotation.W + rotation.X * rotation.Z), 1.0f - 2.0f * (rotation.X * rotation.X + rotation.Y * rotation.Y));
            float pitch = MathF.Asin(2.0f * (rotation.X * rotation.W - rotation.Y * rotation.Z));
            float roll = MathF.Atan2(2.0f * (rotation.X * rotation.Y + rotation.Z * rotation.W), 1.0f - 2.0f * (rotation.X * rotation.X + rotation.Z * rotation.Z));

            // 如果结果为 NaN 或无穷，则将该值设置为 0
            if (float.IsNaN(yaw) || float.IsInfinity(yaw))
            {
                yaw = 0;
            }

            if (float.IsNaN(pitch) || float.IsInfinity(pitch))
            {
                pitch = 0;
            }

            if (float.IsNaN(roll) || float.IsInfinity(roll))
            {
                roll = 0;
            }

            return new Vector3D<float>(pitch, yaw, roll);
        }

        /// <summary>
        /// 将欧拉角转换为四元数
        /// </summary>
        /// <param name="eulerAngles">要转换的欧拉角向量，其中 x 是俯仰，y 是偏航，z 是滚转</param>
        /// <returns>转换后的四元数</returns>
        public static Quaternion<float> ToQuaternion(this Vector3D<float> eulerAngles)
        {
            return Quaternion<float>.CreateFromYawPitchRoll(eulerAngles.Y, eulerAngles.X, eulerAngles.Z);
        }
    }
}
