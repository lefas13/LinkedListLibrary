using System.Collections;

namespace LinkedListLibrary
{
    public class LinkList<T> : ICollection<T>
    {
        private class Node<D>
        {
            public Node(D data)
            {
                Data = data;
            }
            public D Data { get; set; }
            public Node<D>? Next { get; set; }
        }

        private Node<T>? head; // головной/первый элемент
        private Node<T>? tail; // последний/хвостовой элемент
        private int count;  // количество элементов в списке

        public int Count => count;

        public bool IsReadOnly => false;

        public bool IsEmpty => count == 0;

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item);

            if (IsEmpty)
                head = node;
            else
                tail!.Next = node;
            tail = node;

            count++;
        }

        // добвление в начало
        public void AppendFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            node.Next = head;
            head = node;
            if (IsEmpty)
                tail = head;
            count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T item)
        {
            Node<T>? current = head;
            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(item)) return true;
                current = current.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (!IsEmpty)
            {
                Node<T>? node = head;
                array[arrayIndex++] = node!.Data;
                node = node.Next;
                while (node != null && node.Data != null)
                {
                    array[arrayIndex++] = node.Data;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T>? current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            Node<T>? current = head;
            Node<T>? previous = null;

            while (current != null && current.Data != null)
            {
                if (current.Data.Equals(item))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head?.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}