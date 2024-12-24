using Silk.NET.OpenGLES;

namespace VirtualPathCore.Graphics.OpenGL;

/// <summary>
/// 表示一个OpenGL纹理资源
/// </summary>
public unsafe class Texture : GraphicsResource
{
    /// <summary>
    /// 创建一个新的纹理实例，并根据提供的图形主机进行初始化
    /// </summary>
    /// <param name="graphicsHost">用于创建纹理的图形主机</param>
    public Texture(IGraphicsHost<GL> graphicsHost) : base(graphicsHost)
    {
        Handle = GL.GenTexture();

        GL.BindTexture(TextureTarget.Texture2D, Handle);

        GL.TexParameter(GLEnum.Texture2D, GLEnum.TextureMinFilter, (int)GLEnum.Nearest);
        GL.TexParameter(GLEnum.Texture2D, GLEnum.TextureMagFilter, (int)GLEnum.Nearest);
        GL.TexParameter(GLEnum.Texture2D, GLEnum.TextureWrapS, (int)GLEnum.ClampToEdge);
        GL.TexParameter(GLEnum.Texture2D, GLEnum.TextureWrapT, (int)GLEnum.ClampToEdge);

        GL.BindTexture(GLEnum.Texture2D, 0);
    }

    /// <summary>
    /// 清理并释放纹理资源
    /// </summary>
    /// <param name="disposing">指示是否由用户调用此方法</param>
    protected override void Destroy(bool disposing = false)
    {
        GL.DeleteTexture(Handle);
    }

    /// <summary>
    /// 将数据写入纹理
    /// </summary>
    /// <param name="width">纹理的宽度</param>
    /// <param name="height">纹理的高度</param>
    /// <param name="data">指向数据的指针</param>
    /// <param name="isAlpha">指示纹理是否包含alpha通道</param>
    public void Write(uint width, uint height, byte* data, bool isAlpha = false)
    {
        GL.BindTexture(GLEnum.Texture2D, Handle);

        if (isAlpha)
        {
            GL.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgba, width, height, 0, GLEnum.Rgba, GLEnum.UnsignedByte, data);
        }
        else
        {
            GL.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgb, width, height, 0, GLEnum.Rgb, GLEnum.UnsignedByte, data);
        }

        GL.BindTexture(GLEnum.Texture2D, 0);
    }

    /// <summary>
    /// 清空纹理内容
    /// </summary>
    /// <param name="width">纹理的宽度</param>
    /// <param name="height">纹理的高度</param>
    /// <param name="isAlpha">指示纹理是否包含alpha通道</param>
    public void Clear(uint width, uint height, bool isAlpha = false)
    {
        GL.BindTexture(GLEnum.Texture2D, Handle);

        if (isAlpha)
        {
            GL.TexImage2D(TextureTarget.Texture2D, 0, (int)InternalFormat.Rgba8, width, height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, null);
        }
        else
        {
            GL.TexImage2D(GLEnum.Texture2D, 0, (int)GLEnum.Rgb8, width, height, 0, GLEnum.Rgb, GLEnum.UnsignedByte, null);
        }

        GL.BindTexture(GLEnum.Texture2D, 0);
    }
}
