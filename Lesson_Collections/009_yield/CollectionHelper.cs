using System.Collections;
using System.Collections.Generic;

namespace _009_yield
{
    static class CollectionHelper
    {
        public static IEnumerable<string> CreateEnumerable()
        {
            //yield return "Hello";
            //yield return "Hello";
            //yield return "Hello";
            //yield return "Hello";
            //yield return "Hello";
            return new _CreateEnumerable();
        }

        private sealed class _CreateEnumerable : IEnumerable<string>, IEnumerator<string>
        {
            private int state;
            private string current;

            public string Current
            {
                get { return current; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                Reset();
            }

            public IEnumerator<string> GetEnumerator()
            {
                state = 0;
                return this;
            }

            public bool MoveNext()
            {
                switch (state)
                {
                    case 0:
                        current = "Hello";
                        state = 1;
                        return true;

                    case 1:
                        current = "Hello";
                        state = 2;
                        return true;

                    case 2:
                        current = "Hello";
                        state = 3;
                        return true;

                    case 3:
                        current = "Hello";
                        state = 4;
                        return true;

                    case 4:
                        current = "Hello";
                        state = 5;
                        return true;

                    default:
                        return false;
                }
            }

            public void Reset()
            {
                state = -1;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
