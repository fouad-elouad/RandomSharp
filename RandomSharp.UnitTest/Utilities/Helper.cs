namespace RandomSharp.UnitTest.Utilities
{
    public class Helper
    {
        /// <summary>
        /// Executes a specified function multiple times and counts the results using <see cref="ResultCounter{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the results.</typeparam>
        /// <param name="func">The function to execute.</param>
        /// <param name="count">The number of times to execute the function.</param>
        /// <returns>A <see cref="ResultCounter{T}"/> object containing the results and counts.</returns>
        public static ResultCounter<T> Run<T>(Func<T> func, int count)
        {
            ResultCounter<T> counter = new ResultCounter<T>();
            for (int i = 0; i < count; i++)
            {
                T result = func.Invoke();
                if (result == null)
                    counter.NullCount++;
                else
                    counter.AddToList(result);
            }
            return counter;
        }
    }
}