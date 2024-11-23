using System;
using Silk.NET.OpenGLES;

namespace VirtualPathCore.Graphics.OpenGL
{
    /// <summary>
    /// 表示一个 OpenGL 缓冲区对象
    /// </summary>
    public class Buffer : GraphicsResource
    {
        /// <summary>
        /// 初始化一个新的 <see cref="Buffer"/> 实例
        /// </summary>
        /// <param name="graphicsHost">图形主机</param>
        /// <param name="bufferTarget">缓冲区目标类型</param>
        /// <param name="bufferUsage">缓冲区使用类型</param>
        /// <param name="length">缓冲区的长度</param>
        public Buffer(IGraphicsHost<GL> graphicsHost, BufferTargetARB bufferTarget, BufferUsageARB bufferUsage, uint length = 1) : base(graphicsHost)
        {
            Length = length;
            BufferTarget = bufferTarget;
            BufferUsage = bufferUsage;
        }

        /// <summary>
        /// 获取缓冲区的长度
        /// </summary>
        public uint Length { get; }

        /// <summary>
        /// 获取缓冲区目标类型
        /// </summary>
        public BufferTargetARB BufferTarget { get; }

        /// <summary>
        /// 获取缓冲区的使用类型
        /// </summary>
        public BufferUsageARB BufferUsage { get; }

        /// <summary>
        /// 释放使用的资源
        /// </summary>
        /// <param name="disposing">是否释放托管资源</param>
        protected override void Destroy(bool disposing = false)
        {
            GL.DeleteBuffer(Handle);
        }
    }

    /// <summary>
    /// 表示一个指定数据类型的 OpenGL 缓冲区对象
    /// </summary>
    /// <typeparam name="TDataType">缓冲区中数据的类型，必须是未管理类型</typeparam>
    public unsafe class Buffer<TDataType> : Buffer where TDataType : unmanaged
    {
        /// <summary>
        /// 初始化一个新的 <see cref="Buffer{TDataType}"/> 实例
        /// </summary>
        /// <param name="graphicsHost">图形主机</param>
        /// <param name="bufferTarget">缓冲区目标类型</param>
        /// <param name="bufferUsage">缓冲区使用类型</param>
        /// <param name="length">缓冲区的长度</param>
        public Buffer(IGraphicsHost<GL> graphicsHost, BufferTargetARB bufferTarget, BufferUsageARB bufferUsage, uint length = 1)
            : base(graphicsHost, bufferTarget, bufferUsage, length)
        {
            Handle = GL.GenBuffer();

            GL.BindBuffer(BufferTarget, Handle);
            GL.BufferData(BufferTarget, (uint)(Length * sizeof(TDataType)), null, BufferUsage);
            GL.BindBuffer(BufferTarget, 0);
        }

        /// <summary>
        /// 设置缓冲区的数据
        /// </summary>
        /// <param name="data">要设置的数据数组</param>
        /// <param name="offset">数据的偏移</param>
        /// <exception cref="Exception">如果数据长度不等于缓冲区长度</exception>
        public void SetData(TDataType[] data, uint offset = 0)
        {
            if (data.Length != Length)
            {
                throw new Exception("数据长度必须等于缓冲区长度");
            }

            fixed (TDataType* dataPtr = data)
            {
                SetData(dataPtr, offset);
            }
        }

        /// <summary>
        /// 设置缓冲区的数据
        /// </summary>
        /// <param name="data">要设置的数据指针</param>
        /// <param name="offset">数据的偏移</param>
        public void SetData(TDataType* data, uint offset = 0)
        {
            GL.BindBuffer(BufferTarget, Handle);
            GL.BufferSubData(BufferTarget, (int)(offset * sizeof(TDataType)), (uint)(Length * sizeof(TDataType)), data);
            GL.BindBuffer(BufferTarget, 0);
        }

        /// <summary>
        /// 设置缓冲区的数据
        /// </summary>
        /// <param name="data">要设置的单个数据</param>
        /// <param name="offset">数据的偏移</param>
        public void SetData(TDataType data, uint offset = 0)
        {
            GL.BindBuffer(BufferTarget, Handle);
            GL.BufferSubData(BufferTarget, (int)(offset * sizeof(TDataType)), (uint)sizeof(TDataType), &data);
            GL.BindBuffer(BufferTarget, 0);
        }

        /// <summary>
        /// 获取缓冲区的数据
        /// </summary>
        /// <returns>缓冲区的数据数组</returns>
        public TDataType[] GetData()
        {
            TDataType[] result = new TDataType[Length];

            GL.BindBuffer(BufferTarget, Handle);
            void* mapBuffer = GL.MapBufferRange(BufferTarget, 0, (uint)(Length * sizeof(TDataType)), (uint)GLEnum.MapReadBit);

            Span<TDataType> resultSpan = new(mapBuffer, (int)Length);
            resultSpan.CopyTo(result);

            GL.UnmapBuffer(BufferTarget);
            GL.BindBuffer(BufferTarget, 0);

            return result;
        }
    }
}
