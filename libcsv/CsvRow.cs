using System.Collections;
using System.Collections.Generic;

namespace libcsv
{
    internal class CsvRow : IDictionary<string, string>
    {
        SortedDictionary<string, string> dictionary = new SortedDictionary<string, string>();

        public string this[string key]
        {
            get
            {
                string value;
                TryGetValue(key, out value);
                return value;
            }
            set
            {
                dictionary[key] = value;
            }
        }

        public ICollection<string> Keys => dictionary.Keys;

        public ICollection<string> Values => dictionary.Values;

        public int Count => dictionary.Count;

        public bool IsReadOnly => false;

        public void Add(string key, string value)
        {
            dictionary.Add(key, value);
        }

        public void Add(KeyValuePair<string, string> item)
        {
            dictionary.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            dictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            throw new System.NotImplementedException();
        }

        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            dictionary.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }

        public bool Remove(string key)
        {
            return dictionary.Remove(key);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            throw new System.NotImplementedException();
        }

        public bool TryGetValue(string key, out string value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }
    }
}