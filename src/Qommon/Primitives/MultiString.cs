using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Qommon
{
    /// <summary>
    ///     Represents one or more strings in an efficient way.
    /// </summary>
    public readonly struct MultiString : IList<ReadOnlyMemory<char>>, IReadOnlyList<ReadOnlyMemory<char>>
    {
        /// <summary>
        ///     Gets a value representing a single <see langword="null"/> string.
        /// </summary>
        public static MultiString Null => new((string) null);

        /// <summary>
        ///     Gets a value representing a single empty string.
        /// </summary>
        public static MultiString Empty => new(ReadOnlyMemory<char>.Empty);

        /// <summary>
        ///     Gets the amount of strings contained within this instance.
        /// </summary>
        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveOptimization)]
            get => _value switch
            {
                ReadOnlyMemory<char> => 1,
                IList<ReadOnlyMemory<char>> list => list.Count,
                _ => 0
            };
        }

        /// <summary>
        ///     Gets a string at the specified index.
        /// </summary>
        /// <param name="index"> The index to get the string at. </param>
        public ReadOnlyMemory<char> this[int index]
        {
            get
            {
                return _value switch
                {
                    ReadOnlyMemory<char> memoryValue => index == 0 ? memoryValue : Throw.ArgumentOutOfRangeException<ReadOnlyMemory<char>>(nameof(index)),
                    IList<ReadOnlyMemory<char>> list => list[index],
                    _ => Throw.ArgumentOutOfRangeException<ReadOnlyMemory<char>>(nameof(index))
                };
            }
        }

        private readonly object _value;

        /// <summary>
        ///     Instantiates a new <see cref="MultiString"/> from a single string value.
        /// </summary>
        /// <param name="value"> The value to wrap. </param>
        public MultiString(ReadOnlyMemory<char> value)
        {
            _value = value;
        }

        /// <summary>
        ///     Instantiates a new <see cref="MultiString"/> from a single string value.
        /// </summary>
        /// <param name="value"> The value to wrap. </param>
        public MultiString(string value)
        {
            _value = value?.AsMemory();
        }

        /// <summary>
        ///     Instantiates a new <see cref="MultiString"/> from multiple string values.
        /// </summary>
        /// <param name="values"> The values to wrap. </param>
        public MultiString(IList<ReadOnlyMemory<char>> values)
        {
            _value = values;
        }

        /// <summary>
        ///     Instantiates a new <see cref="MultiString"/> from multiple string values.
        /// </summary>
        /// <param name="values"> The values to wrap. </param>
        public MultiString(params ReadOnlyMemory<char>[] values)
        {
            _value = values;
        }

        private void ThrowIfReadOnly(out IList<ReadOnlyMemory<char>> list)
        {
            if ((list = _value as IList<ReadOnlyMemory<char>>) == null || list.IsReadOnly)
                Throw.InvalidOperationException("This multi-string is read-only.");
        }

        public static MultiString CreateList(out IList<ReadOnlyMemory<char>> list)
        {
            list = new List<ReadOnlyMemory<char>>();
            return new(list);
        }

        public static implicit operator MultiString(ReadOnlyMemory<char> value)
            => new(value);

        public static implicit operator MultiString(string value)
            => new(value);

        public static implicit operator MultiString(ReadOnlyMemory<char>[] values)
            => new(values);

        public bool Contains(ReadOnlyMemory<char> value)
            => IndexOf(value, StringComparison.Ordinal) != -1;

        public bool Contains(ReadOnlyMemory<char> value, StringComparison comparison)
            => IndexOf(value, comparison) != -1;

        public int IndexOf(ReadOnlyMemory<char> value)
            => IndexOf(value, StringComparison.Ordinal);

        public int IndexOf(ReadOnlyMemory<char> value, StringComparison comparison)
        {
            switch (_value)
            {
                case ReadOnlyMemory<char> memory:
                {
                    return memory.Span.Equals(value.Span, comparison) ? 0 : -1;
                }
                case IList<ReadOnlyMemory<char>> list:
                {
                    var count = list.Count;
                    for (var i = 0; i < count; i++)
                    {
                        if (list[i].Span.Equals(value.Span, comparison))
                            return i;
                    }

                    return -1;
                }
                default:
                {
                    return -1;
                }
            }
        }

        /// <summary>
        ///     Copies the wrapped strings into the specified array.
        /// </summary>
        /// <param name="array"> The array to copy the strings to. </param>
        /// <param name="arrayIndex"> The index to copy the strings onto. </param>
        public void CopyTo(ReadOnlyMemory<char>[] array, int arrayIndex = 0)
        {
            switch (_value)
            {
                case ReadOnlyMemory<char> memory:
                {
                    array[arrayIndex] = memory;
                    break;
                }
                case IList<ReadOnlyMemory<char>> list:
                {
                    list.CopyTo(array, arrayIndex);
                    break;
                }
            }
        }

        bool ICollection<ReadOnlyMemory<char>>.IsReadOnly => _value is not IList<ReadOnlyMemory<char>> list || list.IsReadOnly;

        ReadOnlyMemory<char> IList<ReadOnlyMemory<char>>.this[int index]
        {
            get => this[index];
            set
            {
                ThrowIfReadOnly(out var list);

                list[index] = value;
            }
        }

        void ICollection<ReadOnlyMemory<char>>.Add(ReadOnlyMemory<char> value)
        {
            ThrowIfReadOnly(out var list);

            list.Add(value);
        }

        void ICollection<ReadOnlyMemory<char>>.Clear()
        {
            ThrowIfReadOnly(out var list);

            list.Clear();
        }

        bool ICollection<ReadOnlyMemory<char>>.Remove(ReadOnlyMemory<char> value)
        {
            ThrowIfReadOnly(out var list);

            return list.Remove(value);
        }

        void IList<ReadOnlyMemory<char>>.Insert(int index, ReadOnlyMemory<char> value)
        {
            ThrowIfReadOnly(out var list);

            list.Insert(index, value);
        }

        void IList<ReadOnlyMemory<char>>.RemoveAt(int value)
        {
            ThrowIfReadOnly(out var list);

            list.RemoveAt(value);
        }

        /// <summary>
        ///     Returns an enumerator that iterates through this <see cref="MultiString"/>.
        /// </summary>
        /// <returns></returns>
        public Enumerator GetEnumerator()
            => new(this);

        /// <summary>
        ///     Represents the enumerator for <see cref="MultiString"/>.
        /// </summary>
        public struct Enumerator : IEnumerator<ReadOnlyMemory<char>>
        {
            /// <inheritdoc/>
            public ReadOnlyMemory<char> Current => _current;

            object IEnumerator.Current => _current;

            private int _state;
            private ReadOnlyMemory<char> _current;

            private readonly MultiString _multiString;

            internal Enumerator(MultiString multiString)
            {
                _multiString = multiString;
                _current = default;
                _state = _multiString._value switch
                {
                    ReadOnlyMemory<char> => -2,
                    IList<ReadOnlyMemory<char>> => 0,
                    _ => -1
                };
            }

            /// <inheritdoc/>
            public bool MoveNext()
            {
                var state = _state;
                if (state == -1)
                {
                    _current = default;
                    return false;
                }

                var value = _multiString._value;
                if (state == -2)
                {
                    _current = (ReadOnlyMemory<char>) value;
                    _state = -1;
                    return true;
                }

                var list = value as IList<ReadOnlyMemory<char>>;
                if (state < list.Count)
                {
                    _current = list[state++];
                    _state = state;
                    return true;
                }

                _state = -1;
                return false;
            }

            /// <inheritdoc/>
            public void Reset()
            {
                this = new(_multiString);
            }

            /// <inheritdoc/>
            public void Dispose()
            { }
        }

        IEnumerator<ReadOnlyMemory<char>> IEnumerable<ReadOnlyMemory<char>>.GetEnumerator()
            => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
