using System;
using System.Collections;
using System.Collections.Generic;

namespace WpfApp
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        public IComparer<T> customComparer;

        private Node<T> root;
       

        public void AddNode(T item)
        {
            if (root == null)
            {
                root = new Node<T>(item);
                return;
            }

            AddNodeRecursively(root, item);
        } 

        private void AddNodeRecursively(Node<T> node, T newItem)
        {
            IComparer<T> comparer = (customComparer == null ? Comparer<T>.Default : customComparer);

            if (comparer.Compare(newItem, node.data) > 0)
            {
                if (node.rNode == null)
                {
                    node.rNode = new Node<T>(newItem);
                    return;
                }
                AddNodeRecursively(node.rNode, newItem);
            }
            else
            {
                if (node.lNode == null)
                {
                    node.lNode = new Node<T>(newItem);
                    return;
                }
                AddNodeRecursively(node.lNode, newItem);
            }
        }



        public IEnumerable<T> Preorder()
        {
            foreach (T data in PreorderCollectionOfNode(root))
            {
                yield return data;
            }
        }

        private IEnumerable<T> PreorderCollectionOfNode(Node<T> node)
        {
            if (node != null)
            {
                yield return node.data;

                foreach (T lData in PreorderCollectionOfNode(node.lNode))
                {
                    yield return lData;
                }

                foreach (T rData in PreorderCollectionOfNode(node.rNode))
                {
                    yield return rData;
                }
            }
        }



        public IEnumerable<T> Inorder()
        {
            foreach (T nodeData in InorderCollectionOfNode(root))
                yield return nodeData;
        }

        private IEnumerable<T> InorderCollectionOfNode(Node<T> node)
        {
            if (node != null)
            {
                foreach (T lData in InorderCollectionOfNode(node.lNode))
                {
                    yield return lData;
                }

                yield return node.data;

                foreach (T rData in InorderCollectionOfNode(node.rNode))
                {
                    yield return rData;
                }
            }
        }



        public IEnumerable<T> Postorder()
        {
            foreach (T nodeData in PostorderCollectionOfNode(root))
                yield return nodeData;
        }

        private IEnumerable<T> PostorderCollectionOfNode(Node<T> node)
        {
            if (node != null)
            {
                foreach (T lData in PostorderCollectionOfNode(node.lNode))
                {
                    yield return lData;
                }

                foreach (T rData in PostorderCollectionOfNode(node.rNode))
                {
                    yield return rData;
                }

                yield return node.data;
            }
        }



        public IEnumerator<T> GetEnumerator()
        {
            return Preorder().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}