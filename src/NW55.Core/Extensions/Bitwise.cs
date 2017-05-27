namespace NW55.Extensions
{
    public static class Bitwise
    {
        public static unsafe float BitwiseToSingle(this int val)
            => *((float*)&val);
        public static unsafe int BitwiseToInt32(this float val)
            => *((int*)&val);
        public static unsafe double BitwiseToDouble(this long val)
            => *((double*)&val);
        public static unsafe long BitwiseToInt64(this double val)
            => *((long*)&val);
    }
}
