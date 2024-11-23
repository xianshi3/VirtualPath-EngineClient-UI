using System;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Numerics;

namespace VirtualPathCore.Helpers
{
    /// <summary>
    /// 提供数学相关的帮助函数和常量
    /// </summary>
    public static class MathHelper
    {
        /// <summary>
        /// 定义 Pi 的值，类型为 <see cref="float"/>
        /// </summary>
        public const float Pi = 3.1415927f;

        /// <summary>
        /// 定义 Pi 除以二的值，类型为 <see cref="float"/>
        /// </summary>
        public const float PiOver2 = Pi / 2;

        /// <summary>
        /// 定义 Pi 除以三的值，类型为 <see cref="float"/>
        /// </summary>
        public const float PiOver3 = Pi / 3;

        /// <summary>
        /// 定义 Pi 除以四的值，类型为 <see cref="float"/>
        /// </summary>
        public const float PiOver4 = Pi / 4;

        /// <summary>
        /// 定义 Pi 除以六的值，类型为 <see cref="float"/>
        /// </summary>
        public const float PiOver6 = Pi / 6;

        /// <summary>
        /// 定义 Pi 乘以二的值，类型为 <see cref="float"/>
        /// </summary>
        public const float TwoPi = 2 * Pi;

        /// <summary>
        /// 定义 Pi 乘以三再除以二的值，类型为 <see cref="float"/>
        /// </summary>
        public const float ThreePiOver2 = 3 * Pi / 2;

        /// <summary>
        /// 定义 E 的值，类型为 <see cref="float"/>
        /// </summary>
        public const float E = 2.7182817f;

        /// <summary>
        /// 定义 E 的以 10 为底的对数
        /// </summary>
        public const float Log10E = 0.4342945f;

        /// <summary>
        /// 定义 E 的以 2 为底的对数
        /// </summary>
        public const float Log2E = 1.442695f;

        /// <summary>
        /// 返回指定十进制数的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个十进制数字，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static decimal Abs(decimal n) => Math.Abs(n);

        /// <summary>
        /// 返回指定双精度数的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个双精度数字，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static double Abs(double n) => Math.Abs(n);

        /// <summary>
        /// 返回指定短整型数的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个短整型数，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static short Abs(short n) => Math.Abs(n);

        /// <summary>
        /// 返回指定整型数的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个整型数，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static int Abs(int n) => Math.Abs(n);

        /// <summary>
        /// 返回指定长整型数的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个长整型数，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static long Abs(long n) => Math.Abs(n);

        /// <summary>
        /// 返回指定带符号字节的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个带符号字节数，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static sbyte Abs(sbyte n) => Math.Abs(n);

        /// <summary>
        /// 返回指定浮点数的绝对值
        /// </summary>
        /// <param name="n">一个大于等于 MinValue 且小于等于 MaxValue 的数字</param>
        /// <returns>一个浮点数，满足 0 ≤ x ≤ MaxValue</returns>
        [Pure]
        public static float Abs(float n) => Math.Abs(n);

        /// <summary>
        /// 返回指定角度的正弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>角度的正弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Sin(double radians) => Math.Sin(radians);

        /// <summary>
        /// 返回指定角度的双曲正弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的双曲正弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Sinh(double radians) => Math.Sinh(radians);

        /// <summary>
        /// 返回指定角度的反正弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的反正弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Asin(double radians) => Math.Asin(radians);

        /// <summary>
        /// 返回指定角度的余弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>角度的余弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Cos(double radians) => Math.Cos(radians);

        /// <summary>
        /// 返回指定角度的双曲余弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的双曲余弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Cosh(double radians) => Math.Cosh(radians);

        /// <summary>
        /// 返回指定角度的反余弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的反余弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Acos(double radians) => Math.Acos(radians);

        /// <summary>
        /// 返回指定角度的反余弦值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的反余弦值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static float Acos(float radians) => MathF.Acos(radians);

        /// <summary>
        /// 返回指定角度的正切值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的正切值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Tan(double radians) => Math.Tan(radians);

        /// <summary>
        /// 返回指定角度的双曲正切值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的双曲正切值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Tanh(double radians) => Math.Tanh(radians);

        /// <summary>
        /// 返回指定角度的反正切值
        /// </summary>
        /// <param name="radians">指定的角度</param>
        /// <returns>指定角度的反正切值如果 radians 等于 NaN、NegativeInfinity 或 PositiveInfinity，返回 NaN</returns>
        [Pure]
        public static double Atan(double radians) => Math.Atan(radians);

        /// <summary>
        /// 返回指定点的坐标比
        /// </summary>
        /// <param name="y">点的 y 坐标</param>
        /// <param name="x">点的 x 坐标</param>
        /// <returns>以弧度表示的角度 θ，满足 -π ≤ θ ≤ π，且 tan(θ) = y / x，其中 (x, y) 是平面直角坐标系中的点</returns>
        [Pure]
        public static double Atan2(double y, double x) => Math.Atan2(y, x);

        /// <summary>
        /// 生成两个 32 位数字的完整乘积
        /// </summary>
        /// <param name="a">要相乘的第一个数字</param>
        /// <param name="b">要相乘的第二个数字</param>
        /// <returns>包含指定数字乘积的数字</returns>
        [Pure]
        public static long BigMul(int a, int b) => Math.BigMul(a, b);

        /// <summary>
        /// 返回指定数字的平方根
        /// </summary>
        /// <param name="n">要查找平方根的数字</param>
        /// <returns>数字 n 的正平方根</returns>
        [Pure]
        public static double Sqrt(double n) => Math.Sqrt(n);

        /// <summary>
        /// 返回指定数字的指定幂的值
        /// </summary>
        /// <param name="x">要计算的双精度浮点数</param>
        /// <param name="y">指定的幂</param>
        /// <returns>x 的 y 次方</returns>
        [Pure]
        public static double Pow(double x, double y) => Math.Pow(x, y);

        /// <summary>
        /// 返回大于或等于指定数字的最小整数值
        /// </summary>
        /// <param name="n">十进制数字</param>
        /// <returns>大于或等于 n 的最小整数值注意，此方法返回十进制而不是整型</returns>
        [Pure]
        public static decimal Ceiling(decimal n) => Math.Ceiling(n);

        /// <summary>
        /// 返回大于或等于指定数字的最小整数值
        /// </summary>
        /// <param name="n">双精度浮点数</param>
        /// <returns>大于或等于 n 的最小整数值如果 n 等于 NaN、NegativeInfinity 或 PositiveInfinity，则返回该值
        /// 注意，此方法返回双精度而不是整型</returns>
        [Pure]
        public static double Ceiling(double n) => Math.Ceiling(n);

        /// <summary>
        /// 返回小于或等于指定数字的最大整数值
        /// </summary>
        /// <param name="n">十进制数字</param>
        /// <returns>返回小于或等于指定十进制数字的最大整数值</returns>
        [Pure]
        public static decimal Floor(decimal n) => Math.Floor(n);

        /// <summary>
        /// 返回小于或等于指定数字的最大整数值
        /// </summary>
        /// <param name="n">双精度浮点数</param>
        /// <returns>返回小于或等于指定双精度浮点数的最大整数值</returns>
        [Pure]
        public static double Floor(double n) => Math.Floor(n);

        /// <summary>
        /// 计算两个整数的商，并在输出参数中返回余数
        /// </summary>
        /// <param name="a">被除数</param>
        /// <param name="b">除数</param>
        /// <param name="result">余数</param>
        /// <returns>指定数字的商</returns>
        /// <exception cref="DivideByZeroException">如果 b 为零</exception>
        [Pure]
        public static int DivRem(int a, int b, out int result) => Math.DivRem(a, b, out result);

        /// <summary>
        /// 计算两个长整型数的商，并在输出参数中返回余数
        /// </summary>
        /// <param name="a">被除数</param>
        /// <param name="b">除数</param>
        /// <param name="result">余数</param>
        /// <returns>指定数字的商</returns>
        /// <exception cref="DivideByZeroException">如果 b 为零</exception>
        [Pure]
        public static long DivRem(long a, long b, out long result) => Math.DivRem(a, b, out result);

        /// <summary>
        /// 返回指定数字的自然对数（以 e 为底的对数）
        /// </summary>
        /// <param name="n">要查找对数的数字</param>
        /// <returns>数字 n 的自然对数</returns>
        [Pure]
        public static double Log(double n) => Math.Log(n);

        /// <summary>
        /// 返回指定数字在指定底数下的对数
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <param name="newBase">指定的底数</param>
        /// <returns>数字 n 在底数 newBase 下的对数</returns>
        [Pure]
        public static double Log(double n, double newBase) => Math.Log(n, newBase);

        /// <summary>
        /// 返回指定数字的以 10 为底的对数
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <returns>数字 n 的以 10 为底的对数</returns>
        [Pure]
        public static double Log10(double n) => Math.Log10(n);

        /// <summary>
        /// 返回指定数字的以 2 为底的对数
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <returns>数字 n 的以 2 为底的对数</returns>
        /// <remarks>此方法将在 .netcore 3.0 及以后的版本中由 System.Math 实现</remarks>
        [Pure]
        public static double Log2(double n) => Math.Log(n, 2);

        /// <summary>
        /// 返回 e 的指定幂的值
        /// </summary>
        /// <param name="n">指定的幂</param>
        /// <returns>数 e 的 n 次幂如果 n 等于 NaN 或 PositiveInfinity，则返回该值如果 n 等于 NegativeInfinity，则返回 0</returns>
        [Pure]
        public static double Exp(double n) => Math.Exp(n);

        /// <summary>
        /// 返回指定数字除以另一个指定数字的余数
        /// </summary>
        /// <param name="a">被除数</param>
        /// <param name="b">除数</param>
        /// <returns>一个数字等于 a - (b Q)，其中 Q 是 a / b 除以四舍五入到最近的整数（如果 a / b 恰好在两个整数之间，则返回偶数整数）
        /// 如果 a - (b Q) 为零，则如果 a 为正，则返回 +0，如果 a 为负，则返回 -0
        /// 如果 b 为 0，则返回 NaN</returns>
        [Pure]
        public static double IEEERemainder(double a, double b) => Math.IEEERemainder(a, b);

        /// <summary>
        /// 返回两个字节中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个字节</param>
        /// <param name="b">要比较的第二个字节</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static byte Max(byte a, byte b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个带符号字节中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个带符号字节</param>
        /// <param name="b">要比较的第二个带符号字节</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static sbyte Max(sbyte a, sbyte b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个短整型数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个短整型数</param>
        /// <param name="b">要比较的第二个短整型数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static short Max(short a, short b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个无符号短整型数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个无符号短整型数</param>
        /// <param name="b">要比较的第二个无符号短整型数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static ushort Max(ushort a, ushort b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个十进制数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个十进制数</param>
        /// <param name="b">要比较的第二个十进制数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static decimal Max(decimal a, decimal b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个整型数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个整型数</param>
        /// <param name="b">要比较的第二个整型数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static int Max(int a, int b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个无符号整型数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个无符号整型数</param>
        /// <param name="b">要比较的第二个无符号整型数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static uint Max(uint a, uint b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个浮点数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个浮点数</param>
        /// <param name="b">要比较的第二个浮点数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static float Max(float a, float b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个长整型数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个长整型数</param>
        /// <param name="b">要比较的第二个长整型数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static long Max(long a, long b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个无符号长整型数中的较大者
        /// </summary>
        /// <param name="a">要比较的第一个无符号长整型数</param>
        /// <param name="b">要比较的第二个无符号长整型数</param>
        /// <returns>参数 a 或 b，中较大的一个</returns>
        [Pure]
        public static ulong Max(ulong a, ulong b) => Math.Max(a, b);

        /// <summary>
        /// 返回两个字节中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个字节</param>
        /// <param name="b">要比较的第二个字节</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static byte Min(byte a, byte b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个带符号字节中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个带符号字节</param>
        /// <param name="b">要比较的第二个带符号字节</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static sbyte Min(sbyte a, sbyte b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个短整型数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个短整型数</param>
        /// <param name="b">要比较的第二个短整型数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static short Min(short a, short b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个无符号短整型数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个无符号短整型数</param>
        /// <param name="b">要比较的第二个无符号短整型数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static ushort Min(ushort a, ushort b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个十进制数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个十进制数</param>
        /// <param name="b">要比较的第二个十进制数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static decimal Min(decimal a, decimal b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个整型数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个整型数</param>
        /// <param name="b">要比较的第二个整型数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static int Min(int a, int b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个无符号整型数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个无符号整型数</param>
        /// <param name="b">要比较的第二个无符号整型数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static uint Min(uint a, uint b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个浮点数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个浮点数</param>
        /// <param name="b">要比较的第二个浮点数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static float Min(float a, float b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个浮点数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个浮点数</param>
        /// <param name="b">要比较的第二个浮点数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static double Min(double a, double b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个长整型数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个长整型数</param>
        /// <param name="b">要比较的第二个长整型数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static long Min(long a, long b) => Math.Min(a, b);

        /// <summary>
        /// 返回两个无符号长整型数中的较小者
        /// </summary>
        /// <param name="a">要比较的第一个无符号长整型数</param>
        /// <param name="b">要比较的第二个无符号长整型数</param>
        /// <returns>参数 a 或 b，中较小的一个</returns>
        [Pure]
        public static ulong Min(ulong a, ulong b) => Math.Min(a, b);

        /// <summary>
        /// 将十进制值四舍五入到指定的小数位数，并使用指定的舍入方式处理中点值
        /// </summary>
        /// <param name="d">要四舍五入的十进制数字</param>
        /// <param name="digits">返回值的小数位数</param>
        /// <param name="mode">舍入方式的规定</param>
        /// <returns>最接近 d 的数字，其小数位数与 digits 相等如果 d 的小数位数少于 digits，则 d 保持不变</returns>
        /// <exception cref="ArgumentOutOfRangeException">如果 digits 小于 0 或大于 28</exception>
        /// <exception cref="ArgumentException">如果 mode 不是有效的 MidpointRounding 值</exception>
        /// <exception cref="OverflowException">结果超出十进制范围</exception>
        [Pure]
        public static decimal Round(decimal d, int digits, MidpointRounding mode) => Math.Round(d, digits, mode);

        /// <summary>
        /// 将双精度浮点值四舍五入到指定的小数位数，并使用指定的舍入方式处理中点值
        /// </summary>
        /// <param name="d">要四舍五入的双精度浮点数</param>
        /// <param name="digits">返回值的小数位数</param>
        /// <param name="mode">舍入方式的规定</param>
        /// <returns>最接近 d 的数字，其小数位数与 digits 相等如果 d 的小数位数少于 digits，则 d 保持不变</returns>
        /// <exception cref="ArgumentOutOfRangeException">如果 digits 小于 0 或大于 15</exception>
        /// <exception cref="ArgumentException">如果 mode 不是有效的 MidpointRounding 值</exception>
        [Pure]
        public static double Round(double d, int digits, MidpointRounding mode) => Math.Round(d, digits, mode);

        /// <summary>
        /// 将十进制值四舍五入到最接近的整数，并使用指定的舍入方式处理中点值
        /// </summary>
        /// <param name="d">要四舍五入的十进制数字</param>
        /// <param name="mode">舍入方式的规定</param>
        /// <returns>最接近 d 的整数如果 d 恰好介于两个数字之间，则 mode 决定返回两个数字中的哪个
        /// 注意，此方法返回十进制而不是整型</returns>
        /// <exception cref="ArgumentException">如果 mode 不是有效的 MidpointRounding 值</exception>
        /// <exception cref="OverflowException">结果超出十进制范围</exception>
        [Pure]
        public static decimal Round(decimal d, MidpointRounding mode) => Math.Round(d, mode);

        /// <summary>
        /// 将双精度浮点数四舍五入到最接近的整数，并使用指定的舍入方式处理中点值
        /// </summary>
        /// <param name="d">要四舍五入的双精度浮点数</param>
        /// <param name="mode">舍入方式的规定</param>
        /// <returns>最接近 d 的整数如果 d 恰好介于两个整数之间，则 mode 决定返回两个数字中的哪个
        /// 注意，此方法返回双精度而不是整型</returns>
        /// <exception cref="ArgumentException">如果 mode 不是有效的 MidpointRounding 值</exception>
        [Pure]
        public static double Round(double d, MidpointRounding mode) => Math.Round(d, mode);

        /// <summary>
        /// 将十进制值四舍五入到指定的小数位数，并将中点值四舍五入到最接近的偶数
        /// </summary>
        /// <param name="d">要四舍五入的十进制数字</param>
        /// <param name="digits">返回值的小数位数</param>
        /// <returns>最接近 d 的数字，其小数位数等于 digits</returns>
        /// <exception cref="ArgumentOutOfRangeException">如果 digits 小于 0 或大于 15</exception>
        /// <exception cref="OverflowException">结果超出十进制范围</exception>
        [Pure]
        public static decimal Round(decimal d, int digits) => Math.Round(d, digits);

        /// <summary>
        /// 将双精度浮点值四舍五入到指定的小数位数，并将中点值四舍五入到最接近的偶数
        /// </summary>
        /// <param name="d">要四舍五入的双精度浮点数</param>
        /// <param name="digits">返回值的小数位数</param>
        /// <returns>最接近值的数字，其小数位数等于 digits</returns>
        /// <exception cref="ArgumentOutOfRangeException">如果 digits 小于 0 或大于 15</exception>
        [Pure]
        public static double Round(double d, int digits) => Math.Round(d, digits);

        /// <summary>
        /// 将十进制值四舍五入到最接近的整数，并将中点值四舍五入到最接近的偶数
        /// </summary>
        /// <param name="d">要四舍五入的十进制数字</param>
        /// <returns>最接近 d 的整数如果 d 的小数部分恰好介于两个整数之间，则返回偶数中的一个
        /// 注意，此方法返回十进制而不是整型</returns>
        /// <exception cref="OverflowException">结果超出十进制范围</exception>
        [Pure]
        public static decimal Round(decimal d) => Math.Round(d);

        /// <summary>
        /// 将双精度浮点值四舍五入到最接近的整数，并将中点值四舍五入到最接近的偶数
        /// </summary>
        /// <param name="d">要四舍五入的双精度浮点数</param>
        /// <returns>最接近 d 的整数如果 d 的小数部分恰好介于两个整数之间，则返回偶数中的一个
        /// 注意，此方法返回双精度而不是整型</returns>
        [Pure]
        public static double Round(double d) => Math.Round(d);

        /// <summary>
        /// 计算指定十进制数字的整数部分
        /// </summary>
        /// <param name="d">要截断的数字</param>
        /// <returns>数字 d 的整数部分；即，去掉任何小数位后所剩的数字</returns>
        [Pure]
        public static decimal Truncate(decimal d) => Math.Truncate(d);

        /// <summary>
        /// 计算指定双精度浮点数字的整数部分
        /// </summary>
        /// <param name="d">要截断的数字</param>
        /// <returns>数字 d 的整数部分；即，去掉任何小数位后所剩的数字，或者返回以下表中列出的任一值</returns>
        [Pure]
        public static double Truncate(double d) => Math.Truncate(d);

        /// <summary>
        /// 返回表示带符号字节的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(sbyte d) => Math.Sign(d);

        /// <summary>
        /// 返回表示带符号短整型的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(short d) => Math.Sign(d);

        /// <summary>
        /// 返回表示带符号整型的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(int d) => Math.Sign(d);

        /// <summary>
        /// 返回表示带符号浮点数的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(float d) => Math.Sign(d);

        /// <summary>
        /// 返回表示带符号十进制数的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(decimal d) => Math.Sign(d);

        /// <summary>
        /// 返回表示带符号双精度浮点数的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(double d) => Math.Sign(d);

        /// <summary>
        /// 返回表示带符号长整型的符号的整数值
        /// </summary>
        /// <param name="d">一个带符号的数字</param>
        /// <returns>如果 d ≤ -1，返回 -1；如果 1 ≤ d，返回 1；如果 d = 0，返回 0</returns>
        [Pure]
        public static int Sign(long d) => Math.Sign(d);

        /// <summary>
        /// 返回大于或等于指定数字的下一个二的幂
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <returns>下一个二的幂</returns>
        [Pure]
        public static long NextPowerOfTwo(long n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "必须为正");
            }

            return (long)Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// 返回大于或等于指定数字的下一个二的幂
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <returns>下一个二的幂</returns>
        [Pure]
        public static int NextPowerOfTwo(int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "必须为正");
            }

            return (int)Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// 返回大于或等于指定浮点数的下一个二的幂
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <returns>下一个二的幂</returns>
        [Pure]
        public static float NextPowerOfTwo(float n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "必须为正");
            }

            return MathF.Pow(2, MathF.Ceiling(MathF.Log(n, 2)));
        }

        /// <summary>
        /// 返回大于或等于指定双精度浮点数的下一个二的幂
        /// </summary>
        /// <param name="n">指定的数字</param>
        /// <returns>下一个二的幂</returns>
        [Pure]
        public static double NextPowerOfTwo(double n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n), "必须为正");
            }

            return Math.Pow(2, Math.Ceiling(Math.Log(n, 2)));
        }

        /// <summary>
        /// 计算给定自然数的阶乘
        /// </summary>
        /// <param name="n">数字</param>
        /// <returns><paramref name="n"/> 的阶乘</returns>
        [Pure]
        public static long Factorial(int n)
        {
            long result = 1;

            for (; n > 1; n--)
            {
                result *= n;
            }

            return result;
        }

        /// <summary>
        /// 计算 <paramref name="n"/> 关于 <paramref name="k"/> 的二项式系数
        /// </summary>
        /// <param name="n">n</param>
        /// <param name="k">k</param>
        /// <returns>n! / (k! * (n - k)!)</returns>
        [Pure]
        public static long BinomialCoefficient(int n, int k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        /// <summary>
        /// 返回指定数字的平方根的倒数的近似值
        /// </summary>
        /// <param name="x">一个数字</param>
        /// <returns>指定数字的平方根的倒数的近似值，误差上限为 0.001</returns>
        /// <remarks>
        /// 这是改进后的实现，称为 Carmack 的平方根倒数，
        /// 在 Quake III 源代码中找到此实现来自
        /// http://www.codemaestro.com/reviews/review00000105.html有关此方法的历史，请参见
        /// http://www.beyond3d.com/content/articles/8/
        /// </remarks>
        [Pure]
        public static float InverseSqrtFast(float x)
        {
            unsafe
            {
                var xhalf = 0.5f * x;
                var i = *(int*)&x; // 读取为整数的位
                i = 0x5f375a86 - (i >> 1); // 为牛顿-拉夫森近似值做初始猜测
                x = *(float*)&i; // 将位转换回浮点数
                x *= 1.5f - xhalf * x * x; // 进行单次牛顿-拉夫森步骤
                return x;
            }
        }

        /// <summary>
        /// 返回指定数字的平方根的倒数的近似值
        /// </summary>
        /// <param name="x">一个数字</param>
        /// <returns>指定数字的平方根的倒数的近似值，误差上限为 0.001</returns>
        /// <remarks>
        /// 这是改进后的实现，称为 Carmack 的平方根倒数，
        /// 在 Quake III 源代码中找到此实现来自
        /// http://www.codemaestro.com/reviews/review00000105.html有关此方法的历史，请参见
        /// http://www.beyond3d.com/content/articles/8/
        /// 双精度魔法数字来自：https://cs.uwaterloo.ca/~m32rober/rsqrt.pdf
        /// 第 4.8 章
        /// </remarks>
        [Pure]
        public static double InverseSqrtFast(double x)
        {
            unsafe
            {
                double xhalf = 0.5 * x;
                long i = *(long*)&x; // 读取为长整型的位
                i = 0x5fe6eb50c7b537a9 - (i >> 1); // 为牛顿-拉夫森近似值做初始猜测
                x = *(double*)&i; // 将位转换回双精度浮点数
                x *= 1.5 - xhalf * x * x; // 进行单次牛顿-拉夫森步骤
                return x;
            }
        }

        /// <summary>
        /// 将度转换为弧度
        /// </summary>
        /// <param name="degrees">角度（度）</param>
        /// <returns>以弧度表示的角度</returns>
        [Pure]
        public static float DegreesToRadians(float degrees)
        {
            const float degToRad = MathF.PI / 180.0f;
            return degrees * degToRad;
        }

        /// <summary>
        /// 将弧度转换为度
        /// </summary>
        /// <param name="radians">角度（弧度）</param>
        /// <returns>以度表示的角度</returns>
        [Pure]
        public static float RadiansToDegrees(float radians)
        {
            const float radToDeg = 180.0f / MathF.PI;
            return radians * radToDeg;
        }

        /// <summary>
        /// 将度转换为弧度
        /// </summary>
        /// <param name="degrees">角度（度）</param>
        /// <returns>以弧度表示的角度</returns>
        [Pure]
        public static double DegreesToRadians(double degrees)
        {
            const double degToRad = Math.PI / 180.0;
            return degrees * degToRad;
        }

        /// <summary>
        /// 将弧度转换为度
        /// </summary>
        /// <param name="radians">角度（弧度）</param>
        /// <returns>以度表示的角度</returns>
        [Pure]
        public static double RadiansToDegrees(double radians)
        {
            const double radToDeg = 180.0 / Math.PI;
            return radians * radToDeg;
        }

        /// <summary>
        /// 交换两个值
        /// </summary>
        /// <typeparam name="T">要交换的值的类型</typeparam>
        /// <param name="a">第一个值</param>
        /// <param name="b">第二个值</param>
        public static void Swap<T>(ref T a, ref T b) => (a, b) = (b, a);

        /// <summary>
        /// 将数字限制在最小值和最大值之间
        /// </summary>
        /// <param name="n">要限制的数字</param>
        /// <param name="min">允许的最小值</param>
        /// <param name="max">允许的最大值</param>
        /// <returns>如果 n 小于 min 则返回 min；如果 n 大于 max 则返回 max；否则返回 n</returns>
        [Pure]
        public static int Clamp(int n, int min, int max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        /// <summary>
        /// 将数字限制在最小值和最大值之间
        /// </summary>
        /// <param name="n">要限制的数字</param>
        /// <param name="min">允许的最小值</param>
        /// <param name="max">允许的最大值</param>
        /// <returns>如果 n 小于 min 则返回 min；如果 n 大于 max 则返回 max；否则返回 n</returns>
        [Pure]
        public static float Clamp(float n, float min, float max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        /// <summary>
        /// 将数字限制在最小值和最大值之间
        /// </summary>
        /// <param name="n">要限制的数字</param>
        /// <param name="min">允许的最小值</param>
        /// <param name="max">允许的最大值</param>
        /// <returns>如果 n 小于 min 则返回 min；如果 n 大于 max 则返回 max；否则返回 n</returns>
        [Pure]
        public static double Clamp(double n, double min, double max)
        {
            return Math.Max(Math.Min(n, max), min);
        }

        /// <summary>
        /// 按比例缩放指定的数字，范围介于最小值和最大值之间
        /// </summary>
        /// <remarks>如果值范围为零，此函数将引发零除异常</remarks>
        /// <param name="value">要缩放的数字</param>
        /// <param name="valueMin">最小期望数字（包含）</param>
        /// <param name="valueMax">最大期望数字（包含）</param>
        /// <param name="resultMin">最小输出数字（包含）</param>
        /// <param name="resultMax">最大输出数字（包含）</param>
        /// <returns>按比例缩放的数字，介于最小值和最大值之间</returns>
        [Pure]
        public static int MapRange(int value, int valueMin, int valueMax, int resultMin, int resultMax)
        {
            int inRange = valueMax - valueMin;
            int resultRange = resultMax - resultMin;
            return resultMin + resultRange * ((value - valueMin) / inRange);
        }

        /// <summary>
        /// 按比例缩放指定的数字，范围介于最小值和最大值之间
        /// </summary>
        /// <remarks>如果值范围为零，此函数将引发零除异常</remarks>
        /// <param name="value">要缩放的数字</param>
        /// <param name="valueMin">最小期望数字（包含）</param>
        /// <param name="valueMax">最大期望数字（包含）</param>
        /// <param name="resultMin">最小输出数字（包含）</param>
        /// <param name="resultMax">最大输出数字（包含）</param>
        /// <returns>按比例缩放的数字，介于最小值和最大值之间</returns>
        [Pure]
        public static float MapRange(float value, float valueMin, float valueMax, float resultMin, float resultMax)
        {
            float inRange = valueMax - valueMin;
            float resultRange = resultMax - resultMin;
            return resultMin + resultRange * ((value - valueMin) / inRange);
        }

        /// <summary>
        /// 按比例缩放指定的数字，范围介于最小值和最大值之间
        /// </summary>
        /// <remarks>如果值范围为零，此函数将引发零除异常</remarks>
        /// <param name="value">要缩放的数字</param>
        /// <param name="valueMin">最小期望数字（包含）</param>
        /// <param name="valueMax">最大期望数字（包含）</param>
        /// <param name="resultMin">最小输出数字（包含）</param>
        /// <param name="resultMax">最大输出数字（包含）</param>
        /// <returns>按比例缩放的数字，介于最小值和最大值之间</returns>
        [Pure]
        public static double MapRange(double value, double valueMin, double valueMax, double resultMin, double resultMax)
        {
            double inRange = valueMax - valueMin;
            double resultRange = resultMax - resultMin;
            return resultMin + resultRange * ((value - valueMin) / inRange);
        }

        /// <summary>
        /// 近似浮点数相等，使用最大不同位数
        /// /// <summary>
        /// 这通常用于替代 epsilon 比较
        /// </summary>
        /// <param name="a">要比较的第一个值</param>
        /// <param name="b">要比较的第二个值</param>
        /// <param name="maxDeltaBits">检查的浮点位数</param>
        /// <returns>如果两个值大致相等，则为真；否则为假</returns>
        [Pure]
        public static bool ApproximatelyEqual(float a, float b, int maxDeltaBits)
        {
            // 我们在这里使用长整型，否则会遇到二补数问题，导致在 -2 和 2.0 时失败
            long k = BitConverter.SingleToInt32Bits(a);
            if (k < 0)
            {
                k = int.MinValue - k;
            }

            long l = BitConverter.SingleToInt32Bits(b);
            if (l < 0)
            {
                l = int.MinValue - l;
            }

            var intDiff = Math.Abs(k - l);
            return intDiff <= 1 << maxDeltaBits;
        }

        /// <summary>
        /// 近似双精度浮点数相等，使用 epsilon（最大误差）值
        /// 该方法设计为“适用于所有”解决方案，尝试处理尽可能多的情况
        /// </summary>
        /// <param name="a">第一个浮点数</param>
        /// <param name="b">第二个浮点数</param>
        /// <param name="epsilon">两个数之间的最大误差</param>
        /// <returns>如果两个值在误差范围内大致相等，则为 <value>true</value>；否则为 <value>false</value></returns>
        [Pure]
        public static bool ApproximatelyEqualEpsilon(double a, double b, double epsilon)
        {
            const double doubleNormal = (1L << 52) * double.Epsilon;
            var absA = Math.Abs(a);
            var absB = Math.Abs(b);
            var diff = Math.Abs(a - b);

            if (a == b)
            {
                // 快捷处理，处理无穷大
                return true;
            }

            if (a == 0.0f || b == 0.0f || diff < doubleNormal)
            {
                // a 或 b 为零，或者都非常接近零
                // 相对误差在这里没有意义
                return diff < epsilon * doubleNormal;
            }

            // 使用相对误差
            return diff / Math.Min(absA + absB, double.MaxValue) < epsilon;
        }

        /// <summary>
        /// 近似单精度浮点数相等，使用 epsilon（最大误差）值
        /// 该方法设计为“适用于所有”解决方案，尝试处理尽可能多的情况
        /// </summary>
        /// <param name="a">第一个浮点数</param>
        /// <param name="b">第二个浮点数</param>
        /// <param name="epsilon">两个数之间的最大误差</param>
        /// <returns>如果两个值在误差范围内大致相等，则为 <value>true</value>；否则为 <value>false</value></returns>
        [Pure]
        public static bool ApproximatelyEqualEpsilon(float a, float b, float epsilon)
        {
            const float floatNormal = (1 << 23) * float.Epsilon;
            var absA = Math.Abs(a);
            var absB = Math.Abs(b);
            var diff = Math.Abs(a - b);

            if (a == b)
            {
                // 快捷处理，处理无穷大
                return true;
            }

            if (a == 0.0f || b == 0.0f || diff < floatNormal)
            {
                // a 或 b 为零，或者都非常接近零
                // 相对误差在这里没有意义
                return diff < epsilon * floatNormal;
            }

            // 使用相对误差
            var relativeError = diff / Math.Min(absA + absB, float.MaxValue);
            return relativeError < epsilon;
        }

        /// <summary>
        /// 近似两个单精度浮点数之间的等价关系，使用直接的人类尺度
        /// 重要的是要注意，这不近似相等 - 它仅检查两个数字是否可以在某个容差范围内被认为是等价的容差为包含性质
        /// </summary>
        /// <param name="a">要比较的第一个值</param>
        /// <param name="b">要比较的第二个值</param>
        /// <param name="tolerance">两者被视为等价的容差</param>
        /// <returns>这两个值是否可以在容差范围内被视为等价</returns>
        [Pure]
        public static bool ApproximatelyEquivalent(float a, float b, float tolerance)
        {
            if (a == b)
            {
                // 提前退出，处理无穷大
                return true;
            }

            var diff = Math.Abs(a - b);
            return diff <= tolerance;
        }

        /// <summary>
        /// 近似两个双精度浮点数之间的等价关系，使用直接的人类尺度
        /// 重要的是要注意，这不近似相等 - 它仅检查两个数字是否可以在某个容差范围内被认为是等价的容差为包含性质
        /// </summary>
        /// <param name="a">要比较的第一个值</param>
        /// <param name="b">要比较的第二个值</param>
        /// <param name="tolerance">两者被视为等价的容差</param>
        /// <returns>这两个值是否可以在容差范围内被视为等价</returns>
        [Pure]
        public static bool ApproximatelyEquivalent(double a, double b, double tolerance)
        {
            if (a == b)
            {
                // 提前退出，处理无穷大
                return true;
            }

            var diff = Math.Abs(a - b);
            return diff <= tolerance;
        }

        /// <summary>
        /// 线性插值，返回 a 和 b 之间的插值结果
        /// </summary>
        /// <param name="start">起始值</param>
        /// <param name="end">结束值</param>
        /// <param name="t">a 和 b 之间的插值值，限制在 [0, 1] 范围内</param>
        /// <returns>a 和 b 之间的插值结果</returns>
        [Pure]
        public static float Lerp(float start, float end, float t)
        {
            t = Math.Clamp(t, 0, 1);
            return start + t * (end - start);
        }

        /// <summary>
        /// 线性插值，返回 a 和 b 之间的插值结果
        /// </summary>
        /// <param name="start">起始值</param>
        /// <param name="end">结束值</param>
        /// <param name="t">a 和 b 之间的插值值，限制在 [0, 1] 范围内</param>
        /// <returns>a 和 b 之间的插值结果</returns>
        [Pure]
        public static double Lerp(double start, double end, double t)
        {
            t = Math.Clamp(t, 0, 1);
            return start + t * (end - start);
        }

        /// <summary>
        /// 线性插值，返回向量 a 和 b 之间的插值结果
        /// </summary>
        /// <param name="a">起始向量</param>
        /// <param name="b">结束向量</param>
        /// <param name="c">插值因子向量在每个分量上都应用 Lerp</param>
        /// <returns>插值的向量结果</returns>
        public static Vector3 Lerp(Vector3 a, Vector3 b, Vector3 c)
        {
            float x = Lerp(a.X, b.X, c.X);
            float y = Lerp(a.Y, b.Y, c.Y);
            float z = Lerp(a.Z, b.Z, c.Z);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// 将角度规范化到范围 (-180, 180]
        /// </summary>
        /// <param name="angle">要规范化的角度（度）</param>
        /// <returns>规范化后的角度，范围为 (-180, 180]</returns>
        public static float NormalizeAngle(float angle)
        {
            // 返回 [0, 360) 范围内的角度
            angle = ClampAngle(angle);

            if (angle > 180f)
            {
                // 将角度移至范围 (-180, 180]
                angle -= 360f;
            }

            return angle;
        }

        /// <summary>
        /// 将角度规范化到范围 (-180, 180]
        /// </summary>
        /// <param name="angle">要规范化的角度（度）</param>
        /// <returns>规范化后的角度，范围为 (-180, 180]</returns>
        public static double NormalizeAngle(double angle)
        {
            // 返回 [0, 360) 范围内的角度
            angle = ClampAngle(angle);

            if (angle > 180f)
            {
                // 将角度移至范围 (-180, 180]
                angle -= 360f;
            }

            return angle;
        }

        /// <summary>
        /// 将角度规范化到范围 (-π, π]
        /// </summary>
        /// <param name="angle">要规范化的角度（弧度）</param>
        /// <returns>规范化后的角度，范围为 (-π, π]</returns>
        public static float NormalizeRadians(float angle)
        {
            // 返回 [0, 2π) 范围内的角度
            angle = ClampRadians(angle);

            if (angle > Pi)
            {
                // 将角度移至范围 (-π, π]
                angle -= 2 * Pi;
            }

            return angle;
        }

        /// <summary>
        /// 将角度规范化到范围 (-π, π]
        /// </summary>
        /// <param name="angle">要规范化的角度（弧度）</param>
        /// <returns>规范化后的角度，范围为 (-π, π]</returns>
        public static double NormalizeRadians(double angle)
        {
            // 返回 [0, 2π) 范围内的角度
            angle = ClampRadians(angle);

            if (angle > Pi)
            {
                // 将角度移至范围 (-π, π]
                angle -= 2 * Pi;
            }

            return angle;
        }

        /// <summary>
        /// 将角度限制在范围 [0, 360)
        /// </summary>
        /// <param name="angle">要限制的角度（度）</param>
        /// <returns>限制在范围 [0, 360) 内的角度</returns>
        public static float ClampAngle(float angle)
        {
            // 将角度模以 (-360, 360) 的范围
            angle %= 360f;

            if (angle < 0.0f)
            {
                // 将角度移至范围 [0, 360)
                angle += 360f;
            }

            return angle;
        }

        /// <summary>
        /// 将角度限制在范围 [0, 360)
        /// </summary>
        /// <param name="angle">要限制的角度（度）</param>
        /// <returns>限制在范围 [0, 360) 内的角度</returns>
        public static double ClampAngle(double angle)
        {
            // 将角度模以 (-360, 360) 的范围
            angle %= 360d;

            if (angle < 0.0d)
            {
                // 将角度移至范围 [0, 360)
                angle += 360d;
            }

            return angle;
        }

        /// <summary>
        /// 将角度限制在范围 [0, 2π)
        /// </summary>
        /// <param name="angle">要限制的角度（弧度）</param>
        /// <returns>限制在范围 [0, 2π) 内的角度</returns>
        public static float ClampRadians(float angle)
        {
            // 将角度模以 (-2π, 2π) 的范围
            angle %= TwoPi;

            if (angle < 0.0f)
            {
                // 将角度移至范围 [0, 2π)
                angle += TwoPi;
            }

            return angle;
        }

        /// <summary>
        /// 将角度限制在范围 [0, 2π)
        /// </summary>
        /// <param name="angle">要限制的角度（弧度）</param>
        /// <returns>限制在范围 [0, 2π) 内的角度</returns>
        public static double ClampRadians(double angle)
        {
            // 将角度模以 (-2π, 2π) 的范围
            angle %= 2d * Math.PI;

            if (angle < 0.0d)
            {
                // 将角度移至范围 [0, 2π)
                angle += 2d * Math.PI;
            }

            return angle;
        }

        internal static string GetListSeparator(IFormatProvider formatProvider)
        {
            if (formatProvider is CultureInfo cultureInfo)
            {
                return cultureInfo.TextInfo.ListSeparator;
            }

            if (formatProvider?.GetFormat(typeof(TextInfo)) is TextInfo textInfo)
            {
                return textInfo.ListSeparator;
            }

            return CultureInfo.CurrentCulture.TextInfo.ListSeparator;
        }
    }
}
