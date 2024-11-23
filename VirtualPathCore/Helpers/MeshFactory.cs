using System.Linq;
using VirtualPathCore.Graphics;

namespace VirtualPathCore.Helpers
{
    /// <summary>
    /// 提供用于生成不同类型网格（Mesh）的静态工厂方法
    /// </summary>
    public static unsafe class MeshFactory
    {
        /// <summary>
        /// 获取一个立方体的顶点和索引数据
        /// </summary>
        /// <param name="vertices">输出的顶点数组</param>
        /// <param name="indices">输出的索引数组</param>
        /// <param name="size">立方体的大小，默认为 0.5f</param>
        public static void GetCube(out Vertex[] vertices, out uint[] indices, float size = 0.5f)
        {
            vertices =
            [
                // 前面
                new(new(-size, -size, size), new(0.0f, 0.0f, 1.0f), texCoord: new(0.0f, 0.0f)),
                new(new(size, -size, size), new(0.0f, 0.0f, 1.0f), texCoord: new(1.0f, 0.0f)),
                new(new(size, size, size), new(0.0f, 0.0f, 1.0f), texCoord: new(1.0f, 1.0f)),
                new(new(size, size, size), new(0.0f, 0.0f, 1.0f), texCoord: new(1.0f, 1.0f)),
                new(new(-size, size, size), new(0.0f, 0.0f, 1.0f), texCoord: new(0.0f, 1.0f)),
                new(new(-size, -size, size), new(0.0f, 0.0f, 1.0f), texCoord: new(0.0f, 0.0f)),

                // 后面
                new(new(-size, -size, -size), new(0.0f, 0.0f, -1.0f), texCoord: new(1.0f, 0.0f)),
                new(new(-size, size, -size), new(0.0f, 0.0f, -1.0f), texCoord: new(1.0f, 1.0f)),
                new(new(size, size, -size), new(0.0f, 0.0f, -1.0f), texCoord: new(0.0f, 1.0f)),
                new(new(size, size, -size), new(0.0f, 0.0f, -1.0f), texCoord: new(0.0f, 1.0f)),
                new(new(size, -size, -size), new(0.0f, 0.0f, -1.0f), texCoord: new(0.0f, 0.0f)),
                new(new(-size, -size, -size), new(0.0f, 0.0f, -1.0f), texCoord: new(1.0f, 0.0f)),

                // 上面
                new(new(-size, size, -size), new(0.0f, 1.0f, 0.0f), texCoord: new(0.0f, 1.0f)),
                new(new(-size, size, size), new(0.0f, 1.0f, 0.0f), texCoord: new(0.0f, 0.0f)),
                new(new(size, size, size), new(0.0f, 1.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(size, size, size), new(0.0f, 1.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(size, size, -size), new(0.0f, 1.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(-size, size, -size), new(0.0f, 1.0f, 0.0f), texCoord: new(0.0f, 1.0f)),

                // 下面
                new(new(-size, -size, -size), new(0.0f, -1.0f, 0.0f), texCoord: new(0.0f, 0.0f)),
                new(new(size, -size, -size), new(0.0f, -1.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(size, -size, size), new(0.0f, -1.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(size, -size, size), new(0.0f, -1.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(-size, -size, size), new(0.0f, -1.0f, 0.0f), texCoord: new(0.0f, 1.0f)),
                new(new(-size, -size, -size), new(0.0f, -1.0f, 0.0f), texCoord: new(0.0f, 0.0f)),

                // 右面
                new(new(size, -size, -size), new(1.0f, 0.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(size, size, -size), new(1.0f, 0.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(size, size, size), new(1.0f, 0.0f, 0.0f), texCoord: new(0.0f, 1.0f)),
                new(new(size, size, size), new(1.0f, 0.0f, 0.0f), texCoord: new(0.0f, 1.0f)),
                new(new(size, -size, size), new(1.0f, 0.0f, 0.0f), texCoord: new(0.0f, 0.0f)),
                new(new(size, -size, -size), new(1.0f, 0.0f, 0.0f), texCoord: new(1.0f, 0.0f)),

                // 左面
                new(new(-size, -size, -size), new(-1.0f, 0.0f, 0.0f), texCoord: new(0.0f, 0.0f)),
                new(new(-size, -size, size), new(-1.0f, 0.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(-size, size, size), new(-1.0f, 0.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(-size, size, size), new(-1.0f, 0.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(-size, size, -size), new(-1.0f, 0.0f, 0.0f), texCoord: new(0.0f, 1.0f)),
                new(new(-size, -size, -size), new(-1.0f, 0.0f, 0.0f), texCoord: new(0.0f, 0.0f))
            ];

            indices = vertices.Select((a, b) => (uint)b).ToArray();
        }

        /// <summary>
        /// 获取一个平面的顶点和索引数据
        /// </summary>
        /// <param name="vertices">输出的顶点数组</param>
        /// <param name="indices">输出的索引数组</param>
        public static void GetCanvas(out Vertex[] vertices, out uint[] indices)
        {
            vertices =
            [
                new(new(-1.0f, 1.0f, 0.0f), new(0.0f, 0.0f, 0.0f), texCoord: new(0.0f, 1.0f)),
                new(new(-1.0f, -1.0f, 0.0f), new(0.0f, 0.0f, 0.0f), texCoord: new(0.0f, 0.0f)),
                new(new(1.0f, -1.0f, 0.0f), new(0.0f, 0.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(1.0f, -1.0f, 0.0f), new(0.0f, 0.0f, 0.0f), texCoord: new(1.0f, 0.0f)),
                new(new(1.0f, 1.0f, 0.0f), new(0.0f, 0.0f, 0.0f), texCoord: new(1.0f, 1.0f)),
                new(new(-1.0f, 1.0f, 0.0f), new(0.0f, 0.0f, 0.0f), texCoord: new(0.0f, 1.0f))
            ];

            indices = vertices.Select((a, b) => (uint)b).ToArray();
        }
    }
}
