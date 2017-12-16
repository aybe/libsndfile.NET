using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    internal struct Marshaller<T> : IDisposable where T : struct
    {
        public T Data { get; }
        public int Size { get; }
        public IntPtr Address { get; }

        public Marshaller(T data, MarshallerBehavior behavior = MarshallerBehavior.Push)
        {
            Data = data;
            Size = Marshal.SizeOf(data);
            Address = Marshal.AllocHGlobal(Size);

            switch (behavior)
            {
                case MarshallerBehavior.None:
                    break;
                case MarshallerBehavior.Push:
                    Push();
                    break;
                case MarshallerBehavior.PushDeleteOld:
                    Push(true);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(behavior), behavior, null);
            }
        }

        public void Push(bool deleteOld = false)
        {
            Marshal.StructureToPtr(Data, Address, deleteOld);
        }

        public T Pop()
        {
            return Marshal.PtrToStructure<T>(Address);
        }

        public void Dispose()
        {
            Marshal.FreeHGlobal(Address);
        }
    }
}