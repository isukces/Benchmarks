using System;
using System.Runtime.CompilerServices;

namespace WrappedValuesBenchmarks
{
    public struct XPipeIndex : IEquatable<XPipeIndex>, IComparable<XPipeIndex>, IIntegerBasedKey
    {
        public XPipeIndex(int value)
        {
            Value = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XPipeIndex operator +(XPipeIndex left, int right)
        {
            return left.IsEmpty ? left : new XPipeIndex(left.Value + right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XPipeIndex operator --(XPipeIndex src)
        {
            return src.IsEmpty ? src : new XPipeIndex(src.Value - 1);
        }

        public static bool operator ==(XPipeIndex left, XPipeIndex right)
        {
            return left.Value.Equals(right.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XPipeIndex operator ++(XPipeIndex src)
        {
            return src.IsEmpty ? src : new XPipeIndex(src.Value + 1);
        }

        public static bool operator !=(XPipeIndex left, XPipeIndex right)
        {
            return !left.Value.Equals(right.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static XPipeIndex operator -(XPipeIndex left, int right)
        {
            return left.IsEmpty ? left : new XPipeIndex(left.Value - right);
        }

        public int CompareTo(XPipeIndex other)
        {
            return Value.CompareTo(other.Value);
        }

        public bool Equals(XPipeIndex other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is XPipeIndex s && Value.Equals(s.Value);
        }

        public bool Equals(XPipeIndex? obj)
        {
            return !(obj is null) && Value.Equals(obj.Value.Value);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public bool IsZero()
        {
            return Value == 0;
        }

        public override string ToString()
        {
            return "pipe in facade index " + Value;
        }

        public string ValueAsText()
        {
            return IsEmpty ? "Empty" : Value.ToString();
        }

        public static XPipeIndex Empty => new XPipeIndex(int.MinValue);

        public static XPipeIndex Zero => new XPipeIndex(0);

        public bool IsEmpty => Value == int.MinValue;

        public int Value { get; }
    }
}