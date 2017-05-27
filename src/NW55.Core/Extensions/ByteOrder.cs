using System;

namespace NW55.Extensions
{
    public static class ByteOrder
    {
        public static ushort ReverseByteOrder(this ushort value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return (ushort)(
                    (value & 0x00ff) << 8 |
                    (value & 0xff00) >> 8);
            }
            return value;
        }
        public static uint ReverseByteOrder(this uint value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return (uint)(
                    (value & 0x000000ff) << 24 |
                    (value & 0x0000ff00) << 8 |
                    (value & 0x00ff0000) >> 8 |
                    (value & 0xff000000) >> 24);
            }
            return value;
        }
        public static ulong ReverseByteOrder(this ulong value)
        {
            if (BitConverter.IsLittleEndian)
            {
                return (ulong)(
                    (value & 0x00000000000000ff) << 56 |
                    (value & 0x000000000000ff00) << 40 |
                    (value & 0x0000000000ff0000) << 24 |
                    (value & 0x00000000ff000000) << 8 |
                    (value & 0x000000ff00000000) >> 8 |
                    (value & 0x0000ff0000000000) >> 24 |
                    (value & 0x00ff000000000000) >> 40 |
                    (value & 0xff00000000000000) >> 56);
            }
            return value;
        }

        public static short ReverseByteOrder(this short value)
            => (short)ReverseByteOrder((ushort)value);
        public static int ReverseByteOrder(this int value)
            => (int)ReverseByteOrder((uint)value);

        public static long ReverseByteOrder(this long value)
            => (long)ReverseByteOrder((ulong)value);

        public static byte[] ToNetworkBytes(this ushort value)
        {
            return new byte[]
            {
                (byte)((value & 0xff00) >> 8),
                (byte)(value & 0x00ff)
            };
        }
        public static byte[] ToNetworkBytes(this uint value)
        {
            return new byte[]
            {
                (byte)((value & 0xff000000) >> 24),
                (byte)((value & 0x00ff0000) >> 16),
                (byte)((value & 0x0000ff00) >> 8),
                (byte)(value & 0x000000ff)
            };
        }
        public static byte[] ToNetworkBytes(this ulong value)
        {
            return new byte[]
            {
                (byte)((value & 0xff00000000000000) >> 56),
                (byte)((value & 0x00ff000000000000) >> 48),
                (byte)((value & 0x0000ff0000000000) >> 40),
                (byte)((value & 0x000000ff00000000) >> 32),
                (byte)((value & 0x00000000ff000000) >> 24),
                (byte)((value & 0x0000000000ff0000) >> 16),
                (byte)((value & 0x000000000000ff00) >> 8),
                (byte)(value & 0x00000000000000ff)
            };
        }

        public static byte[] ToNetworkBytes(this short value)
            => ToNetworkBytes((ushort)value);
        public static byte[] ToNetworkBytes(this int value)
            => ToNetworkBytes((uint)value);
        public static byte[] ToNetworkBytes(this long value)
            => ToNetworkBytes((ulong)value);

        public static void ToNetworkBytes(this ushort value, byte[] target, int startIndex = 0)
        {
            target[startIndex] = (byte)((value & 0xff00) >> 8);
            target[startIndex + 1] = (byte)(value & 0x00ff);
        }
        public static void ToNetworkBytes(this uint value, byte[] target, int startIndex = 0)
        {
            target[startIndex] = (byte)((value & 0xff000000) >> 24);
            target[startIndex + 1] = (byte)((value & 0x00ff0000) >> 16);
            target[startIndex + 2] = (byte)((value & 0x0000ff00) >> 8);
            target[startIndex + 3] = (byte)(value & 0x000000ff);
        }
        public static void ToNetworkBytes(this ulong value, byte[] target, int startIndex = 0)
        {
            target[startIndex] = (byte)((value & 0xff00000000000000) >> 56);
            target[startIndex + 1] = (byte)((value & 0x00ff000000000000) >> 48);
            target[startIndex + 2] = (byte)((value & 0x0000ff0000000000) >> 40);
            target[startIndex + 3] = (byte)((value & 0x000000ff00000000) >> 32);
            target[startIndex + 4] = (byte)((value & 0x00000000ff000000) >> 24);
            target[startIndex + 5] = (byte)((value & 0x0000000000ff0000) >> 16);
            target[startIndex + 6] = (byte)((value & 0x000000000000ff00) >> 8);
            target[startIndex + 7] = (byte)(value & 0x00000000000000ff);
        }

        public static void ToNetworkBytes(this short value, byte[] target, int startIndex = 0)
            => ToNetworkBytes((ushort)value, target, startIndex);
        public static void ToNetworkBytes(this int value, byte[] target, int startIndex = 0)
            => ToNetworkBytes((uint)value, target, startIndex);
        public static void ToNetworkBytes(this long value, byte[] target, int startIndex = 0)
            => ToNetworkBytes((ulong)value, target, startIndex);

        public static ushort ToHostUInt16(this byte[] networkBytes, int startIndex = 0)
        {
            return (ushort)(
                networkBytes[startIndex] << 8 |
                networkBytes[startIndex + 1]);
        }
        public static uint ToHostUInt32(this byte[] networkBytes, int startIndex = 0)
        {
            return (uint)networkBytes[startIndex] << 24 |
                (uint)networkBytes[startIndex + 1] << 16 |
                (uint)networkBytes[startIndex + 2] << 8 |
                (uint)networkBytes[startIndex + 3];
        }
        public static ulong ToHostUInt64(this byte[] networkBytes, int startIndex = 0)
        {
            return (ulong)networkBytes[startIndex] << 56 |
                (ulong)networkBytes[startIndex + 1] << 48 |
                (ulong)networkBytes[startIndex + 2] << 40 |
                (ulong)networkBytes[startIndex + 3] << 32 |
                (ulong)networkBytes[startIndex + 4] << 24 |
                (ulong)networkBytes[startIndex + 5] << 16 |
                (ulong)networkBytes[startIndex + 6] << 8 |
                (ulong)networkBytes[startIndex + 7];
        }

        public static short ToHostInt16(this byte[] networkBytes, int startIndex = 0)
            => (short)ToHostUInt16(networkBytes, startIndex);
        public static int ToHostInt32(this byte[] networkBytes, int startIndex = 0)
            => (int)ToHostUInt32(networkBytes, startIndex);
        public static long ToHostInt64(this byte[] networkBytes, int startIndex = 0)
            => (long)ToHostUInt64(networkBytes, startIndex);
    }
}
