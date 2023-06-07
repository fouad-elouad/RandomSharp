using System.Collections.Generic;
using System.Linq;

namespace RandomSharp.UnitTest.Utilities
{
    /// <summary>
    /// Represents a utility class for counting and tracking results of a specified type.
    /// </summary>
    /// <typeparam name="T">The type of the results.</typeparam>
    public struct ResultCounter<T>
    {
        private IList<T> InternalList;

        public int NullCount;

        /// <summary>
        /// Creates a new instance of the <see cref="ResultCounter{T}"/> struct.
        /// </summary>
        /// <returns>A new instance of <see cref="ResultCounter{T}"/>.</returns>
        public static ResultCounter<T> Create()
        {
            return new ResultCounter<T>
            {
                InternalList = new List<T>(),
                NullCount = 0
            };
        }

        /// <summary>
        /// Gets the count of items.
        /// </summary>
        public int ListCount { get { return InternalList.Count; } }

        /// <summary>
        /// Gets an immutable list containing the items.
        /// </summary>
        public IReadOnlyList<T> List { get { return InternalList.ToList().AsReadOnly(); } }

        /// <summary>
        /// Adds an item to the list.
        /// </summary>
        /// <param name="toAdd">The item to add.</param>
        public void AddToList(T toAdd)
        {
            InternalList.Add(toAdd);
        }
    }
}