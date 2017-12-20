namespace WpfApp
{
    public class Node<T>
    {
        public T data;

        public Node<T> rNode;
        public Node<T> lNode;

        public Node(T obj)
        {
            this.data = obj;
        }       
    }
}