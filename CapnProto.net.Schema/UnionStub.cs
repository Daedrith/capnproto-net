﻿
namespace CapnProto
{
    public struct UnionStub
    {
        public UnionStub(uint? offset, ushort? value) : this(offset.Value, value.Value) { }
        public UnionStub(uint offset, ushort value)
        {
            this.offset = offset;
            this.value = value;
        }
        private readonly uint offset;
        private readonly ushort value;
        public ulong Expected
        {
            get { return ((ulong)value) << ByteIndex; }
        }
        public int FieldIndex
        {
            get { return checked((int)((offset * 16) / 64)); }
        }
        private int ByteIndex
        {
            get { return checked((int)((offset * 16) % 64)); }
        }
        public ulong Mask
        {
            get { return ((ulong)0xFFFF) << ByteIndex; }
        }
        public ushort Value { get { return value; } }
        public int Offset { get { return (int)offset; } }
    }
}
